#region Copyright © 2015, 2016 MJM [info.ARQODE@gmail.com]
/*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.

* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
* GNU General Public License for more details.

* You should have received a copy of the GNU General Public License
* along with this program.If not, see<http:* www.gnu.org/licenses/>.
*/
using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NJsonSchema;
using NJsonSchema.Validation;


namespace JSonUtil
{
    public class JSonBase
    {
        String AppDataPath;
        
        public JArray jErrors;
        public bool canWrite;
        String str_namespace;
        String file_name;
        bool file_must_exists = false;

        public JSonBase(DirectoryInfo dAppData_path, String NameSpace, bool fileMustExists=false)
        {
            try
            {
                jErrors = new JArray();
                canWrite = false;
                file_must_exists = fileMustExists;

                if (!String.IsNullOrEmpty(NameSpace))
                {
                    // Base app data path
                    AppDataPath = dAppData_path.FullName.Substring(0, dAppData_path.FullName.LastIndexOf("\\"));

                    str_namespace = NameSpace;

                    // Base path
                    DirectoryInfo dJSONPath = dAppData_path;

                    // Get into namespace folder
                    String[] namespaces = str_namespace.Split('.');
                    int i = 0;
                    for (i = 0; i < namespaces.Length - 1; i++)
                    {
                        if (dJSONPath.GetDirectories(namespaces[i].Trim(), SearchOption.TopDirectoryOnly).Count() > 0)
                        {
                            dJSONPath = dJSONPath.GetDirectories(namespaces[i].Trim(), SearchOption.TopDirectoryOnly)[0];
                        }
                        else
                        {
                            dJSONPath = dJSONPath.CreateSubdirectory(namespaces[i].Trim());
                        }
                    }

                    // Get filename
                    file_name = Path.Combine(dJSONPath.FullName, namespaces[i]);

                    canWrite = true;
                }
            }
            catch (Exception exc)
            {
                jErrors.Add(String.Format("Error path not found '{0}\\{1}'. Details: {2}", dAppData_path, NameSpace.Replace(".", "\\"), exc.Message));
            }
        }
        public JSonBase(String file_path, bool fileMustExists = false)
        {
            file_name = file_path;
        }
        
        public String ProgramDir
        {
            get
            {
                FileInfo fi = new FileInfo(file_name);
                return (fi != null)? fi.DirectoryName: "";
            }
        }
        public String file_path
        {
            get { return file_name; }
        }
        public bool file_exists
        {
            get { return File.Exists(file_name); }
        }
        /// <summary>
        /// Read json file and return a JObject
        /// </summary>
        /// <param name="proc_guid"></param>
        /// <returns></returns>
        internal JObject readJsonFile()
        {
            try
            {                
                file_name = (file_name.ToLower().EndsWith(".json")) ? file_name : String.Format("{0}.json", file_name);
                bool file_exist = File.Exists(file_name);
                canWrite = ! ((file_must_exists) && (!file_exist));

                if (file_exist)
                {

                    FileInfo fi = new FileInfo(file_name);

                    StreamReader str = new StreamReader(fi.FullName);
                    JsonTextReader jsr = new JsonTextReader(str);
                    JObject JProc = null;
                    bool errors = false;

                    try
                    {
                        JsonSerializer jser = new JsonSerializer();
                        JProc = jser.Deserialize<JObject>(jsr);
                        if (JProc == null)
                        {
                            errors = true;
                        }
                    }
                    catch (Exception exc)
                    {
                        jErrors.Add(exc.Message);
                        errors = true;
                    }
                    finally
                    {
                        str.Close();
                    }
                    if (errors)
                    {
                        String filecontent = File.ReadAllText(fi.FullName);
                        String schema = "";
                        if (filecontent.Contains("$schema"))
                        {
                            schema = filecontent.Substring(filecontent.ToLower().IndexOf("schemas"));
                            schema = schema.Substring(0, schema.IndexOf("\"")).Replace("\\\\", "\\");
                        }
                        if ((schema != "") && (File.Exists(Path.Combine(AppDataPath, schema))))
                            try
                            {
                                String schema_file = File.ReadAllText(Path.Combine(AppDataPath, schema));
                                JsonSchema4 JSchema = JsonSchema4.FromData(schema_file);
                                foreach (ValidationError ve in JSchema.Validate(filecontent))
                                {
                                    jErrors.Add(String.Format("Error in {0} > {1}: {2}", ve.Path, ve.Property, ve.Kind));
                                }

                                errors = jErrors.Count() > 0;
                            }
                            catch (Exception exc)
                            {
                                jErrors.Add(String.Format("Error in json file '{0}': {1}", file_name, exc.Message));
                                canWrite = false;
                            }
                    }
                    return (!errors) ? JProc : new JObject();
                }      
            }
            catch (Exception exc)
            {
                if (file_must_exists)
                {
                    jErrors.Add(String.Format("Error in '{0}': {1}", file_name, exc.Message));
                    canWrite = false;
                }
            }

            if (canWrite)
            {
                return new JObject();
            }
            else
            {
                jErrors.Add(String.Format("Program file not found: {0}", file_name));
                return null;
            }
            
        }

        /// <summary>
        /// Write json file
        /// </summary>
        /// <param name="jsonObj"></param>
        /// <param name="file_name"></param>
        internal void writeJsonFile(JObject jsonObj)
        {
            if (canWrite)
            {
                bool create_if_not_exists = true;
                file_name = (file_name.ToLower().EndsWith(".json")) ? file_name : String.Format("{0}.json", file_name);

                if ((create_if_not_exists) || (File.Exists(file_name)))
                {
                    File.WriteAllText(file_name, jsonObj.ToString());
                }
            }
        }
    }
}
#endregion
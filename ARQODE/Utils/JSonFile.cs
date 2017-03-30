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
using Newtonsoft.Json.Linq;

namespace JSonUtil
{
    public class JSonFile: JSonBase
    {
        JObject jObj;
        JObject jActiveNode;

        /// <summary>
        /// Create json object from file and manage it
        /// </summary>
        /// <param name="json_dir_path"></param>
        /// <param name="json_file"></param>
        public JSonFile(DirectoryInfo json_dir_path, String NameSpace, bool fileMustExists) :
            base(json_dir_path, NameSpace, fileMustExists)
        {
            // string current location
            jObj = readJsonFile();
            jActiveNode = jObj;
        }
        /// <summary>
        /// Create json object from file and manage it
        /// </summary>
        /// <param name="json_dir_path"></param>
        /// <param name="json_file"></param>
        public JSonFile(DirectoryInfo json_dir_path, String NameSpaces) :
            base(json_dir_path, NameSpaces, false)
        {
            // string current location
            jObj = readJsonFile();
            jActiveNode = jObj;
        }
        /// <summary>
        /// Create json object from file and manage it
        /// </summary>
        /// <param name="json_dir_path"></param>
        /// <param name="json_file"></param>
        public JSonFile(String file_path, bool fileMustExists=false) :
            base(file_path, fileMustExists)
        {
            // string current location
            jObj = readJsonFile();
            jActiveNode = jObj;
        }
        /// <summary>
        /// Constructor for json object from arguments
        /// </summary>
        /// <param name="jobj"></param>
        public JSonFile(JObject jobj):
            base(null, null, false)           
        {            
            jObj = jobj;
            jActiveNode = jObj;
        }
        public bool hasErrors()
        {
            return (jErrors != null)? jErrors.Count() > 0: false;
        }

        /// <summary>
        /// Set active node with a path
        /// </summary>
        /// <param name="path"></param>
        public void setActiveNode(String path)
        {
            if (path != "")
            {
                jActiveNode = getNode(path) as JObject;
            }
        }

        /// <summary>
        /// Get the first node with a path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public JToken getNode(String path)
        {
            return jObj.SelectToken(path);
        }

        /// <summary>
        /// get all nades with a path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public System.Collections.Generic.IEnumerable<JToken> getNodes(String path)
        {
            return jActiveObj.SelectTokens(path);
        }
        public JObject jActiveObj
        {
            get {
                if (jActiveNode != null)
                   return jActiveNode;
                else
                   return jObj;
            }
            set {
                jActiveNode = value;
            }
        }

        /// <summary>
        /// Replace a node with a given Guid
        /// </summary>
        /// <param name="Guid"></param>
        /// <param name="jtoken"></param>
        public void setByGuid(String Guid, JToken jtoken)
        {
            JToken node = getNode(String.Format("$.Notes[?(@.Guid == '{0}')]", Guid));
            if (node != null)
            {
                node.Replace(jtoken);
                Write();
            }
        }
        /// <summary>
        /// set jobject
        /// </summary>
        /// <param name="jobject"></param>
        public void set(JObject jobject)
        {
            jObj = jobject;
        }
        public void set(String property_name, JToken Value)
        {
            jActiveObj[property_name] = Value;
        }
        public void set(String property_name, String Value)
        {
            jActiveObj[property_name] = Value;
        }
        public void set(String property_name, int Value)
        {
            jActiveObj[property_name] = Value;
        }
        public void set(String property_name, double Value)
        {
            jActiveObj[property_name] = Value;
        }
        public void set(String property_name, bool Value)
        {
            jActiveObj[property_name] = Value;
        }
        public void set(String property_name, long Value)
        {
            jActiveObj[property_name] = Value;
        }
        public void set(String property_name, JObject Value)
        {
            jActiveObj[property_name] = Value;
        }
        public void add(String property_name, JToken Value)
        {
            if ((jActiveObj[property_name] == null) || (jActiveObj[property_name].ToString() == ""))
            {
                jActiveObj[property_name] = new JArray();
            }
            (jActiveObj[property_name] as JArray).Add(Value);
        }
        public void add(String property_name, JObject Value)
        {
            if ((jActiveObj[property_name] == null) || (jActiveObj[property_name].ToString() == ""))
            {
                jActiveObj[property_name] = new JArray();
            }
            (jActiveObj[property_name] as JArray).Add(Value);
        }
        public void add(String property_name, object Value)
        {
            if ((jActiveObj[property_name] == null) || (jActiveObj[property_name].ToString() == ""))
            {
                jActiveObj[property_name] = new JArray();
            }
            (jActiveObj[property_name] as JArray).Add(Value);
        }
        public void add(String property_name, String Value)
        {
            if ((jActiveObj[property_name] == null) || (jActiveObj[property_name].ToString() == ""))
            {
                jActiveObj[property_name] = new JArray();
            }
            (jActiveObj[property_name] as JArray).Add(Value);
        }
        public void add(String property_name, int Value)
        {
            if ((jActiveObj[property_name] == null) || (jActiveObj[property_name].ToString() == ""))
            {
                jActiveObj[property_name] = new JArray();
            }
            (jActiveObj[property_name] as JArray).Add(Value);
        }
        public void add(String property_name, bool Value)
        {
            if ((jActiveObj[property_name] == null) || (jActiveObj[property_name].ToString() == ""))
            {
                jActiveObj[property_name] = new JArray();
            }
            (jActiveObj[property_name] as JArray).Add(Value);
        }
        public void add(String property_name, double Value)
        {
            if ((jActiveObj[property_name] == null) || (jActiveObj[property_name].ToString() == ""))
            {
                jActiveObj[property_name] = new JArray();
            }
            (jActiveObj[property_name] as JArray).Add(Value);
        }
        public void add(String property_name, long Value)
        {
            if ((jActiveObj[property_name] == null) || (jActiveObj[property_name].ToString() == ""))
            {
                jActiveObj[property_name] = new JArray();
            }
            (jActiveObj[property_name] as JArray).Add(Value);
        }
        /// <summary>
        /// get jobject
        /// </summary>
        /// <returns></returns>
        public JToken get(String property_name)
        {
            return ((property_name != "") && (jActiveObj[property_name] != null))? jActiveObj[property_name]: null;
        }
        /// <summary>
        /// get jobject
        /// </summary>
        /// <returns></returns>
        public JObject get()
        {
            return jObj;
        }
        /// <summary>
        /// write json object in json file
        /// </summary>
        public void Write()
        {
            writeJsonFile(jObj);
        }

        public override String ToString()
        {
            return jObj.ToString();
        }

    }
}

#endregion
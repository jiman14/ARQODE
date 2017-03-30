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
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using JSonUtil;
using TControls;
using ARQODE_Core;

namespace TLogic
{
    public partial class CLogic
    {
    				/// #NAME#: #DESCRIPTION#
			public void f_17250dd1_6cd2_4b1b_a7cd_58ec52297bb8()
			{
			//INI CODE PRCGUID: 17250dd1-6cd2-4b1b-a7cd-58ec52297bb8

                String fichero_de_salida = Input_str("Fichero de salida");
                if (fichero_de_salida != "")
                {
                    // current program
                    ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                    String ns_programa = CVentanaProgramas.Namespace_programa_activo.ToString();

                    // program stack for recursive exploration
                    Stack<KeyValuePair<int, CProgram>> s_prog = new Stack<KeyValuePair<int, CProgram>>();

                    // Progs and procs dictionarys 
                    Dictionary<String, JToken> exp_programs = new Dictionary<string, JToken>();
                    Dictionary<String, JToken> exp_processes = new Dictionary<String, JToken>();

                    CProgram cprog = new CProgram(sys, App_globals, ns_programa);
                    while ((ns_programa != "") || (s_prog.Count > 0))
                    {
                        int i = 0;

                        // Restore program from stack
                        if (cprog == null)
                        {
                            KeyValuePair<int, CProgram> k_prog = s_prog.Pop();
                            i = k_prog.Key;
                            cprog = k_prog.Value;
                        }
                        int n_prcs = ((JArray)cprog.Logic).Count;
                        bool force_exit = false;

                        // Save program and inner processes
                        while ((!force_exit) && (i < n_prcs))
                        {
                            TProcess proc = new TProcess(sys, App_globals, (JObject)((JArray)cprog.Logic).ElementAt(i));
                            if (!exp_programs.ContainsKey(cprog.Program_namespace))
                            {
                                // add program only once
                                exp_programs.Add(cprog.Program_namespace, cprog.get_json.DeepClone());
                            }

                            i++;
                            if (proc.Guid == "Call")
                            {
                                // Add current program to stack and atach the new one for explore recursively
                                s_prog.Push(new KeyValuePair<int, CProgram>(i, cprog));
                                cprog = new CProgram(sys, App_globals, proc.Configuration["program"].ToString());
                                ns_programa = cprog.Program_namespace;
                                force_exit = true;
                            }
                            else if (!exp_processes.ContainsKey(proc.Guid))
                            {
                                // add process only once
                                exp_processes.Add(proc.Guid, proc.get_json.DeepClone());
                            }
                        }
                        if ((i == n_prcs) && (!force_exit))
                        {
                            // set null program only if previous bucle ends
                            cprog = null;
                            ns_programa = "";
                        }
                    }

                    #region Create zip                 

                    Ionic.Zip.ZipFile exp_file = null;
                    if (File.Exists(fichero_de_salida)) {
                        exp_file = Ionic.Zip.ZipFile.Read(fichero_de_salida);
                    }
                    else
                    {
                        exp_file = new Ionic.Zip.ZipFile(fichero_de_salida);
                    }

                    #region add programs & ns conversions to zip file

                    String entry_path = "";
                    String base_file_path = "";
                    JArray jConversion = new JArray();

                    if (exp_file.ContainsEntry(dEXPORTCODE.STR_IMPORT_CONVS))
                    {
                        Ionic.Zip.ZipEntry ze = exp_file.Entries.Where(entry => entry.FileName == dEXPORTCODE.STR_IMPORT_CONVS).FirstOrDefault();

                        MemoryStream ms = new MemoryStream();
                        ze.Extract(ms);
                        byte[] entry_data = ms.ToArray();
                        String file_content = System.Text.Encoding.Default.GetString(entry_data);
                        ms.Close();
                        jConversion = JArray.Parse(file_content);
                    }
                    foreach (String sprog in exp_programs.Keys)
                    {
                        base_file_path = escape_sc(sprog);

                        // Conversions
                        String new_ns = dPROGRAM.FOLDER + "\\Imports\\" + base_file_path;
                        JObject jconv = new JObject(new JProperty(sprog, new_ns));
                        jConversion.Add(jconv);

                        // Add program
                        entry_path = dPROGRAM.FOLDER + "\\Imports\\" + base_file_path + ".json";
                        if (!exp_file.ContainsEntry(entry_path))
                        {
                            exp_file.AddEntry(entry_path, System.Text.UTF8Encoding.UTF8.GetBytes(exp_programs[sprog].ToString()));
                        }
                    }
                    if (exp_file.ContainsEntry(dEXPORTCODE.STR_IMPORT_CONVS))
                    {
                        exp_file.UpdateEntry(dEXPORTCODE.STR_IMPORT_CONVS, jConversion.ToString());
                    }
                    else
                    {
                        exp_file.AddEntry(dEXPORTCODE.STR_IMPORT_CONVS, jConversion.ToString());
                    }
                    #endregion

                    #region Create processes file

                    JSonFile jfTemplate = new JSonFile(Globals.AppDataSection(dPATH.PROCESSES), dGLOBALS.PROCESS_TEMPLATE.Replace(".json", ""));
                    foreach (JToken jproc in exp_processes.Values)
                    {
                        ((JArray)jfTemplate.get(dPROCESS.PROCESSES)).Add(jproc);
                    }
                    #endregion

                    #region add processes file

                    base_file_path = escape_sc(CVentanaProgramas.Namespace_programa_activo.ToString());
                    entry_path = dPROCESS.FOLDER + "\\Imports\\" + base_file_path + ".json";
                    if (!exp_file.ContainsEntry(entry_path))
                    {
                        exp_file.AddEntry(entry_path, System.Text.UTF8Encoding.UTF8.GetBytes(jfTemplate.jActiveObj.ToString()));
                    }
                    #endregion

                    exp_file.Save();

                    #endregion

                    MessageBox.Show(String.Format("Program exported {0}", CVentanaProgramas.Namespace_programa_activo.ToString()));
                }

                //END CODE PRCGUID: 17250dd1-6cd2-4b1b-a7cd-58ec52297bb8
			}

	
    }
}
#endregion
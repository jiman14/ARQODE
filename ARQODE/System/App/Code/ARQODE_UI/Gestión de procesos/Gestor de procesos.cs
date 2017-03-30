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
			public void f_Cargar_procesos()
			{
			//INI CODE PRCGUID: Cargar procesos

                            ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);

                            DirectoryInfo pprocs = App_globals.AppDataSection(dPATH.PROCESSES);
                            DirectoryInfo processes_path = pprocs;
                            ARQODE_UI.GestorProcesos.CVentanaProcesos CVentanaProcesos = new ARQODE_UI.GestorProcesos.CVentanaProcesos(vm);

                            if (CVentanaProgramas.PProcesses.Controls.Count == 0)
                            {
                                CVentanaProcesos.VentanaProcesos.Dock = DockStyle.Fill;
                                CVentanaProgramas.PProcesses.Controls.Add(CVentanaProcesos.VentanaProcesos);
                            }
                            else if (CVentanaProgramas.PProcesses.Controls[0].Controls.Count == 0)
                            {
                                CVentanaProgramas.PProcesses.Controls.Clear();
                                CVentanaProcesos.VentanaProcesos.Dock = DockStyle.Fill;
                                CVentanaProgramas.PProcesses.Controls.Add(CVentanaProcesos.VentanaProcesos);
                            }

                            String SelectedNodePath = "";
                            if (CVentanaProcesos.TV_Processes.SelectedNode != null)
                            {
                                SelectedNodePath = CVentanaProcesos.TV_Processes.SelectedNode.FullPath;
                            }

                            CVentanaProcesos.TV_Processes.Nodes.Clear();

                            TreeNode tn_processes = (TreeNode)CVentanaProgramas.Cargar_arbol_recursivo.Crear_arbol_desde_carpeta(
                                processes_path.FullName, "base_process.json");

                            CVentanaProcesos.TV_Processes.Nodes.Add(tn_processes);

                            if (SelectedNodePath != "")
                            {
                                TreeNode selNode = CVentanaProcesos.TV_Processes.Nodes[0];
                                foreach (String str in SelectedNodePath.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries))
                                {
                                    if (selNode.Nodes[str] != null)
                                    {
                                        selNode = selNode.Nodes[str];
                                    }
                                }
                                CVentanaProcesos.TV_Processes.SelectedNode = selNode;
                            }
                            //END CODE PRCGUID: Cargar procesos
			}

			/// #NAME#: #DESCRIPTION#
			public void f_Cargar_subprocesos()
			{
			//INI CODE PRCGUID: Cargar subprocesos

                            ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                            ARQODE_UI.GestorProcesos.CVentanaProcesos CVentanaProcesos = new ARQODE_UI.GestorProcesos.CVentanaProcesos(vm);

                            CVentanaProcesos.LProcess.Items.Clear();
                            if (CVentanaProcesos.TV_Processes.SelectedNode != null)
                            {
                                String pathProcesses = CVentanaProcesos.TV_Processes.SelectedNode.FullPath;
                                if (pathProcesses.EndsWith(".json"))
                                {
                                    JSonFile processes_file = new JSonFile(Path.Combine(App_globals.AppDataSection(dPATH.CODE).FullName, pathProcesses), true);

                                    // Guardar fichero activo
                                    ARQODE_UI.GestorProcesos.CFormProceso CFormProceso = new ARQODE_UI.GestorProcesos.CFormProceso(vm);
                                    CFormProceso.FicheroProceso = processes_file.file_path;

                                    if (!processes_file.hasErrors())
                                    {
                                        if (processes_file.jActiveObj["processes"].Count() > 0)
                                        {
                                            foreach (JToken jProc in (JArray)processes_file.jActiveObj["processes"])
                                            {
                                                String Name = (jProc["Name"] != null) ? jProc["Name"].ToString() : jProc["Guid"].ToString();
                                                KeyValuePair<String, JToken> kprocess = new KeyValuePair<string, JToken>(Name, jProc);

                                                CVentanaProcesos.LProcess.Items.Add(kprocess);
                                                CVentanaProcesos.LProcess.ValueMember = "Value";
                                                CVentanaProcesos.LProcess.DisplayMember = "Key";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Errors in json file: " + processes_file.jErrors.ToString());
                                    }
                                }
                                else
                                {
                                    DirectoryInfo processes_path = new DirectoryInfo(Path.Combine(App_globals.AppDataSection(dPATH.CODE).FullName, pathProcesses));

                                    foreach (TreeNode child_node in CVentanaProcesos.TV_Processes.SelectedNode.Nodes)
                                    {
                                        if ((child_node.Nodes.Count == 0) && (!child_node.Text.EndsWith(".json")))
                                        {
                                            foreach (DirectoryInfo subProcesses_folder in processes_path.GetDirectories(child_node.Text)[0].GetDirectories())
                                            {
                                                child_node.Nodes.Add(subProcesses_folder.FullName, subProcesses_folder.Name);
                                                child_node.Nodes[child_node.Nodes.Count - 1].Name = subProcesses_folder.Name;
                                            }

                                            foreach (FileInfo subProcesses_files in processes_path.GetDirectories(child_node.Text)[0].GetFiles())
                                            {
                                                child_node.Nodes.Add(subProcesses_files.FullName, subProcesses_files.Name);
                                                child_node.Nodes[child_node.Nodes.Count - 1].Name = subProcesses_files.Name;
                                            }
                                        }
                                    }
                                }
                            }

                            //END CODE PRCGUID: Cargar subprocesos
			}

			/// #NAME#: #DESCRIPTION#
			public void f_Cargar_formulario_proceso()
			{
			//INI CODE PRCGUID: Cargar formulario proceso

                            ARQODE_UI.GestorProcesos.CVentanaProcesos CVentanaProcesos = new ARQODE_UI.GestorProcesos.CVentanaProcesos(vm);
                            ARQODE_UI.GestorProcesos.CFormProceso CFormProceso = new ARQODE_UI.GestorProcesos.CFormProceso(vm);

                            if (CVentanaProcesos.Pcontent.Controls.Count == 0)
                            {
                                CFormProceso.FormProceso.Dock = DockStyle.Fill;
                                CVentanaProcesos.Pcontent.Controls.Add(CFormProceso.FormProceso);
                                CVentanaProcesos.tabProcesos.SelectedIndex = 0;
                                vm.Cancel_events = true;
                            }
                            //END CODE PRCGUID: Cargar formulario proceso
			}

			/// #NAME#: #DESCRIPTION#
			public void f_Cargar_datos_en_formulario_de_proceso()
			{
			//INI CODE PRCGUID: Cargar datos en formulario de proceso

                            ARQODE_UI.GestorProcesos.CFormProceso CFormProceso = new ARQODE_UI.GestorProcesos.CFormProceso(vm);
                            CFormProceso.FormProceso.ActiveControl = CFormProceso.BGuardar;
                            ARQODE_UI.GestorProcesos.CVentanaProcesos CVentanaProcesos = new ARQODE_UI.GestorProcesos.CVentanaProcesos(vm);

                            if (CVentanaProcesos.LProcess.SelectedItem != null)
                            {
                                JToken JProc = ((KeyValuePair<String, JToken>)CVentanaProcesos.LProcess.SelectedItem).Value;
                                CFormProceso.LGUID.Text = JProc["Guid"].ToString();
                                CFormProceso.TBDescription.Text = JProc["Description"].ToString();
                                CFormProceso.TBName.Text = JProc["Name"].ToString();
                                CFormProceso.TBVersion.Text = JProc["Version"].ToString();
                                CFormProceso.TBInputs.Text = JProc["Inputs"].ToString().Replace("[", "").Replace("]", "").Replace("\"", "").Replace("\r\n", "").Trim();
                                CFormProceso.TBOutputs.Text = JProc["Outputs"].ToString().Replace("[", "").Replace("]", "").Replace("\"", "").Replace("\r\n", "").Trim();
                                if (JProc["Configuration"] != null)
                                {
                                    CFormProceso.TBConfiguration.Text = JProc["Configuration"].ToString().Replace("[", "").Replace("]", "").Replace("\"", "").Replace("\r\n", "").Trim();
                                }
                                if (JProc["Default_Configuration"] != null)
                                {
                                    String str_defaultConfiguration = "";
                                    foreach (String def_confs in JProc["Default_Configuration"].ToString().Replace("[", "").Replace("]", "").Replace("\"", "").Replace("\r\n", "").Replace("{", "").Replace("}", "").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                                    {
                                        str_defaultConfiguration += def_confs.Trim() + ", ";
                                    }
                                    CFormProceso.TBDefault_Configuration.Text = str_defaultConfiguration.TrimEnd(new char[] { ',', ' ' });
                                }

                                // abrir la pestaña de proceso base                    
                                CVentanaProcesos.tabProcesos.SelectedIndex = 0;

                                // Guardar proceso activo
                                CFormProceso.Proceso = JProc;
                            }

                            //END CODE PRCGUID: Cargar datos en formulario de proceso
			}

			/// #NAME#: #DESCRIPTION#
			public void f_Nuevo_proceso()
			{
			//INI CODE PRCGUID: Nuevo proceso

                            ARQODE_UI.ARQODE_UI.CInputDialog CInputDialog = new ARQODE_UI.ARQODE_UI.CInputDialog(vm);
                            CInputDialog.InputDialog.AcceptButton = CInputDialog.BAceptar;
                            CInputDialog.InputDialog.CancelButton = CInputDialog.BCancelar;

                            CInputDialog.InputDialog.Text = "Nuevo proceso";
                            CInputDialog.Label1.Text = "Nombre del proceso";

                            vm.Cancel_events = false;
                            DialogResult dr = CInputDialog.InputDialog.ShowDialog();
                            if (dr == DialogResult.OK)
                            {

                                if (CInputDialog.textBox1.Text.Trim() != "")
                                {
                                    ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);

                                    TreeView TV_Processes = (TreeView)view.getCtrl("TV_Processes");
                                    String Process_path = Path.Combine(App_globals.AppDataSection(dPATH.CODE).FullName, TV_Processes.SelectedNode.FullPath);

                                    // abrir plantilla               
                                    DirectoryInfo pprocs = Globals.AppDataSection(dPATH.PROCESSES);
                                    if (pprocs.GetFiles("base_process.json").Length > 0)
                                    {

                                        // crear proceso usando la plantilla

                                        JSonFile jplantilla_unit_proc = new JSonFile(pprocs.GetFiles("base_unit_process.json")[0].FullName);
                                        jplantilla_unit_proc.jActiveObj[dPROCESS.GUID] = Guid.NewGuid().ToString();
                                        jplantilla_unit_proc.jActiveObj[dPROCESS.NAME] = CInputDialog.textBox1.Text;
                                        jplantilla_unit_proc.jActiveObj[dPROCESS.DESCRIPTION] = "";

                                        // añadir el proceso a la lista de procesos del fichero
                                        JSonFile jProcessFile = new JSonFile(Process_path);
                                        (jProcessFile.get("processes") as JArray).Add(jplantilla_unit_proc.jActiveObj);
                                        jProcessFile.Write();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Plantilla de proceso 'base_process.json' no encontrada en: " + pprocs.FullName);
                                    }
                                }
                            }

                            //END CODE PRCGUID: Nuevo proceso
			}

			/// #NAME#: #DESCRIPTION#
			public void f_Asignar_proceso()
			{
			//INI CODE PRCGUID: Asignar proceso
                            ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);

                            if ((CVentanaProgramas.ArbolProgramas.SelectedNode != null) && (CVentanaProgramas.ArbolProgramas.SelectedNode.Text.EndsWith(".json")))
                            {
                                // obtenemos el proceso a incluir
                                ListBox LProcess = (ListBox)view.getCtrl("LProcess");
                                JToken JProc = ((KeyValuePair<String, JToken>)LProcess.SelectedItem).Value;

                                // obtenemos la ruta del proceso
                                TreeView TV_Processes = (TreeView)view.getCtrl("TV_Processes");
                                if (TV_Processes.SelectedNode != null)
                                {
                                    String prc_namespace = TV_Processes.SelectedNode.FullPath.Replace(dPROCESS.FOLDER + "\\", "").Replace("\\", ".").Replace(".json", "");

                                    // montamos el proceso destino:
                                    JObject JNewProc_2_program = new JObject();
                                    JNewProc_2_program.Add("Namespace", prc_namespace);
                                    JNewProc_2_program.Add("Guid", JProc["Guid"].ToString());
                                    JNewProc_2_program.Add("Name", JProc["Name"].ToString());
                                    JNewProc_2_program.Add("Description", JProc["Description"].ToString());

                                    JObject JConf = new JObject();
                                    if (JProc["Configuration"].Count() > 0)
                                    {
                                        foreach (JToken jitem in (JArray)JProc["Configuration"])
                                        {
                                            JConf.Add(jitem.ToString(), "");
                                        }
                                    }
                                    JNewProc_2_program.Add("Configuration", JConf);
                                    JObject JIn = new JObject();
                                    if (JProc["Inputs"].Count() > 0)
                                    {
                                        foreach (JToken jitem in (JArray)JProc["Inputs"])
                                        {
                                            JIn.Add(jitem.ToString(), "");
                                        }
                                    }
                                    JNewProc_2_program.Add("Inputs", JIn);
                                    JObject JOut = new JObject();
                                    if (JProc["Outputs"].Count() > 0)
                                    {
                                        foreach (JToken jitem in (JArray)JProc["Outputs"])
                                        {
                                            JOut.Add(jitem.ToString(), "");
                                        }
                                    }
                                    JNewProc_2_program.Add("Outputs", JOut);

                                    // obtienes el programa
                                    String rutaPrograma = Path.Combine(
                                        App_globals.AppDataSection(dPATH.CODE).FullName,
                                        CVentanaProgramas.ArbolProgramas.SelectedNode.FullPath);

                                    JSonFile jprograma = new JSonFile(rutaPrograma);
                                    (jprograma.jActiveObj["Logic"] as JArray).Add(JNewProc_2_program);
                                    jprograma.Write();
                                }
                            }


                            //END CODE PRCGUID: Asignar proceso
			}

			/// #NAME#: #DESCRIPTION#
			public void f_df797af7_6e48_40b0_96c3_7278d4d71ab7()
			{
			//INI CODE PRCGUID: df797af7-6e48-40b0-96c3-7278d4d71ab7

                            ARQODE_UI.GestorProcesos.CFormProceso CFormProceso = new ARQODE_UI.GestorProcesos.CFormProceso(vm);
                            JToken JProc = (JToken)CFormProceso.Proceso;

                            JProc["Description"] = CFormProceso.TBDescription.Text;

                            // Load inputs
                            JArray JInputs = new JArray();
                            foreach (String input in CFormProceso.TBInputs.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                            {
                                JInputs.Add(input.Trim());
                            }
                            JProc["Inputs"] = JInputs;

                            // Load outputs
                            JArray JOutputs = new JArray();
                            foreach (String output in CFormProceso.TBOutputs.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                            {
                                JOutputs.Add(output.Trim());
                            }
                            JProc["Outputs"] = JOutputs;

                            // Load configuration
                            JArray JConfiguration = new JArray();
                            foreach (String config in CFormProceso.TBConfiguration.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                            {
                                JConfiguration.Add(config.Trim());
                            }
                            JProc["Configuration"] = JConfiguration;

                            // Load configuration
                            JArray JDefault_Configuration = new JArray();
                            foreach (String def_config in CFormProceso.TBDefault_Configuration.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                            {
                                if (def_config.Contains(":"))
                                {
                                    String[] name_value = def_config.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                                    JDefault_Configuration.Add(new JObject(new JProperty(name_value[0].Trim(), name_value[1].Trim())));
                                }
                                else
                                {
                                    MessageBox.Show("Error in Default config format. Correct samples: default operator: sum, allow null: false, max intents: 4");
                                }

                            }
                            JProc["Default_Configuration"] = JDefault_Configuration;

                            // Process info
                            if ((JProc["Name"].ToString() != CFormProceso.TBName.Text) && (!CFormProceso.TBName.Text.Trim().Equals("")))
                            {
                                JProc["Name"] = CFormProceso.TBName.Text;
                            }

                            ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                            CStructModifications csmod = new CStructModifications(sys, App_globals);
                            csmod.SaveProcess(JProc as JObject);

                            //Replace process
                            JSonFile JProcesses = new JSonFile(CFormProceso.FicheroProceso.ToString());
                            JToken JOld_prce = JProcesses.getNode(String.Format("$.processes[?(@.Guid == '{0}')]", JProc["Guid"].ToString()));
                            JOld_prce.Replace(JProc);
                            JProcesses.Write();


                            //END CODE PRCGUID: df797af7-6e48-40b0-96c3-7278d4d71ab7
			}

			/// #NAME#: #DESCRIPTION#
			public void f_1bcb9da8_47ba_457f_bf60_51e9f3031514()
			{
			//INI CODE PRCGUID: 1bcb9da8-47ba-457f-bf60-51e9f3031514

                            ARQODE_UI.GestorProcesos.CVentanaProcesos CVentanaProcesos = new ARQODE_UI.GestorProcesos.CVentanaProcesos(vm);
                            if (CVentanaProcesos.TV_Processes.SelectedNode != null)
                            {
                                TreeNode NProcActivo = CVentanaProcesos.TV_Processes.SelectedNode;
                                if (NProcActivo.Name.EndsWith(".json")) NProcActivo = NProcActivo.Parent;

                                NProcActivo.Nodes.Add("New process folder (F2)");
                            }




                            //END CODE PRCGUID: 1bcb9da8-47ba-457f-bf60-51e9f3031514
			}

			/// #NAME#: #DESCRIPTION#
			public void f_d7c92550_523c_4cb7_9223_c8da10a35e3d()
			{
			//INI CODE PRCGUID: d7c92550-523c-4cb7-9223-c8da10a35e3d

                            ARQODE_UI.GestorProcesos.CVentanaProcesos CVentanaProcesos = new ARQODE_UI.GestorProcesos.CVentanaProcesos(vm);
                            if (CVentanaProcesos.TV_Processes.SelectedNode != null)
                            {
                                TreeNode NProcActivo = CVentanaProcesos.TV_Processes.SelectedNode;

                                ARQODE_UI.ARQODE_UI.CInputDialog CInputDialog = new ARQODE_UI.ARQODE_UI.CInputDialog(vm);
                                CInputDialog.InputDialog.AcceptButton = CInputDialog.BAceptar;
                                CInputDialog.InputDialog.CancelButton = CInputDialog.BCancelar;

                                CInputDialog.InputDialog.Text = "Renombrar carpeta";
                                CInputDialog.Label1.Text = "Nombre de la carpeta";
                                CInputDialog.textBox1.Text = NProcActivo.Text;

                                vm.Cancel_events = false;
                                DialogResult dr = CInputDialog.InputDialog.ShowDialog();
                                if (dr == DialogResult.OK)
                                {
                                    ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);

                                    String di_antiguo = Path.Combine(App_globals.AppDataSection(dPATH.CODE).FullName, NProcActivo.FullPath);
                                    String di_nuevo = Path.Combine(App_globals.AppDataSection(dPATH.CODE).FullName,
                                            NProcActivo.FullPath.Substring(0, NProcActivo.FullPath.LastIndexOf("\\")));

                                    if (di_antiguo.EndsWith(".json"))
                                    {
                                        String nombre_f = (CInputDialog.textBox1.Text.ToLower().EndsWith(".json")) ? CInputDialog.textBox1.Text : CInputDialog.textBox1.Text + ".json";

                                        String from_path = NProcActivo.FullPath.Replace(dPROCESS.FOLDER + "\\", "").Replace("\\", ".").Replace(".json", "");
                                        String to_path = from_path.Substring(0, from_path.IndexOf(".") + 1) + nombre_f.Replace(".json", "");

                                        CStructModifications csmod = new CStructModifications(sys, App_globals);
                                        csmod.MoveProcess_byNamespace(from_path, to_path);

                                        di_nuevo = Path.Combine(di_nuevo, nombre_f);
                                        File.Move(di_antiguo, di_nuevo);
                                        NProcActivo.Text = nombre_f;
                                    }
                                    else
                                    {
                                        di_nuevo = Path.Combine(di_nuevo, CInputDialog.textBox1.Text);
                                        if (Directory.Exists(di_antiguo))
                                        {
                                            DirectoryInfo di_ant = new DirectoryInfo(di_antiguo);
                                            di_ant.MoveTo(di_nuevo);
                                        }
                                        else
                                        {
                                            Directory.CreateDirectory(di_nuevo);
                                        }
                                        NProcActivo.Text = CInputDialog.textBox1.Text;
                                    }
                                }
                            }

                            //END CODE PRCGUID: d7c92550-523c-4cb7-9223-c8da10a35e3d
			}

			/// #NAME#: #DESCRIPTION#
			public void f_7f1c5983_51c4_4d71_9647_041bf4366321()
			{
			//INI CODE PRCGUID: 7f1c5983-51c4-4d71-9647-041bf4366321

                            ARQODE_UI.ARQODE_UI.CInputDialog CInputDialog = new ARQODE_UI.ARQODE_UI.CInputDialog(vm);
                            CInputDialog.InputDialog.AcceptButton = CInputDialog.BAceptar;
                            CInputDialog.InputDialog.CancelButton = CInputDialog.BCancelar;

                            CInputDialog.InputDialog.Text = "Fichero de procesos";
                            CInputDialog.Label1.Text = "Nombre del fichero";

                            vm.Cancel_events = false;
                            DialogResult dr = CInputDialog.InputDialog.ShowDialog();
                            if (dr == DialogResult.OK)
                            {
                                ARQODE_UI.GestorProcesos.CVentanaProcesos CVentanaProcesos = new ARQODE_UI.GestorProcesos.CVentanaProcesos(vm);
                                if (CVentanaProcesos.TV_Processes.SelectedNode != null)
                                {
                                    String Ruta = CVentanaProcesos.TV_Processes.SelectedNode.FullPath;
                                    ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                                    DirectoryInfo pprocs = Globals.AppDataSection(dPATH.PROCESSES);
                                    FileInfo f_plantilla = pprocs.GetFiles(dGLOBALS.PROCESS_TEMPLATE)[0];
                                    DirectoryInfo di = App_globals.AppDataSection(Path.Combine(dPATH.CODE, Ruta));

                                    JSonFile JPrc_plantilla = new JSonFile(f_plantilla.FullName);
                                    JPrc_plantilla.jActiveObj["description"] = CInputDialog.textBox1.Text;

                                    String n_prc = CInputDialog.textBox1.Text.EndsWith(".json") ? CInputDialog.textBox1.Text : CInputDialog.textBox1.Text + ".json";
                                    JSonFile JNew_process = new JSonFile(Path.Combine(di.FullName, n_prc));
                                    JNew_process.writeJsonFile(JPrc_plantilla.jActiveObj);

                                }
                            }
                            CInputDialog.InputDialog.Close();


                            //END CODE PRCGUID: 7f1c5983-51c4-4d71-9647-041bf4366321
			}

			/// #NAME#: #DESCRIPTION#
			public void f_0a2c9e12_f50d_4299_802c_0de96791a182()
			{
			//INI CODE PRCGUID: 0a2c9e12-f50d-4299-802c-0de96791a182
                            ARQODE_UI.GestorProcesos.CVentanaProcesos CVentanaProcesos = new ARQODE_UI.GestorProcesos.CVentanaProcesos(vm);
                            ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                            if ((CVentanaProcesos.TV_Processes.SelectedNode != null) && (CVentanaProcesos.TV_Processes.SelectedNode.Text.EndsWith(".json")))
                            {
                                if (MessageBox.Show("¿Desea eliminar el proceso: '" + CVentanaProcesos.TV_Processes.SelectedNode.Text + "'?",
                                    "Confirmar acción",
                                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    String prc_namespace = CVentanaProcesos.TV_Processes.SelectedNode.FullPath.Replace(dPROCESS.FOLDER + "\\", "").Replace("\\", ".").Replace(".json", "");
                                    CStructModifications csmod = new CStructModifications(sys, App_globals);
                                    ArrayList prc_references = csmod.FindProcessFileInPrograms(prc_namespace);

                                    if (prc_references.Count <= 0)
                                    {
                                        String proceso = Path.Combine(
                                            App_globals.AppDataSection(dPATH.CODE).FullName,
                                            CVentanaProcesos.TV_Processes.SelectedNode.FullPath);
                                        File.Delete(proceso);
                                        CVentanaProcesos.TV_Processes.SelectedNode.Remove();
                                    }
                                    else
                                    {
                                        String message = "";
                                        DirectoryInfo pprog = App_globals.AppDataSection(dPATH.PROGRAM);
                                        foreach (String reference in prc_references) { message += reference.Replace(pprog.FullName + "\\", "") + "\r\n"; }
                                        MessageBox.Show("Antes de eliminar el fichero de procesos debes eliminar las siguientes referencias en los programas:\r\n" + message);
                                    }
                                }
                            }
                            else
                            {
                                String dir_path = Path.Combine(App_globals.AppDataSection(dPATH.CODE).FullName, CVentanaProcesos.TV_Processes.SelectedNode.FullPath);
                                DirectoryInfo di = new DirectoryInfo(dir_path);
                                if (di.GetFiles().Count() == 0)
                                {
                                    di.Delete();
                                }
                                else
                                {
                                    MessageBox.Show("La carpeta no se puede eliminar mientras no esté vacía");
                                }
                            }

                            //END CODE PRCGUID: 0a2c9e12-f50d-4299-802c-0de96791a182
			}

			/// #NAME#: #DESCRIPTION#
			public void f_11cd42a6_00e1_452a_a4d5_70710a8f083f()
			{
			//INI CODE PRCGUID: 11cd42a6-00e1-452a-a4d5-70710a8f083f

                            ARQODE_UI.GestorProcesos.CVentanaProcesos CVentanaProcesos = new ARQODE_UI.GestorProcesos.CVentanaProcesos(vm);
                            if ((CVentanaProcesos.TV_Processes.SelectedNode != null) &&
                                (CVentanaProcesos.TV_Processes.SelectedNode.FullPath.EndsWith(".json")))
                            {
                                Clipboard.SetText(CVentanaProcesos.TV_Processes.SelectedNode.FullPath.Replace(dPROCESS.FOLDER + "\\", "").Replace(".json", "").Replace("\\", "."));
                                CVentanaProcesos.contextMenu_Procesos.Items[2].Enabled = true;
                                CVentanaProcesos.contextMenu_Procesos.Items[2].Text = "Pegar fichero";
                            }

                            //END CODE PRCGUID: 11cd42a6-00e1-452a-a4d5-70710a8f083f
			}

			/// #NAME#: #DESCRIPTION#
			public void f_e0ac24cc_d14e_4e0c_bb6b_da7a4942a916()
			{
			//INI CODE PRCGUID: e0ac24cc-d14e-4e0c-bb6b-da7a4942a916

                            ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                            ARQODE_UI.GestorProcesos.CVentanaProcesos CVentanaProcesos = new ARQODE_UI.GestorProcesos.CVentanaProcesos(vm);

                            String Origin_path = Clipboard.GetText();

                            if ((!Origin_path.StartsWith("{")) && (CVentanaProcesos.TV_Processes.SelectedNode.FullPath.Contains(dPROCESS.FOLDER + "\\")))
                            {
                                DirectoryInfo pprocs = App_globals.AppDataSection(dPATH.PROCESSES);
                                String Origin_full_path = Path.Combine(pprocs.FullName, Origin_path.Replace(".", "\\") + ".json");

                                if (File.Exists(Origin_full_path))
                                {
                                    FileInfo fi = new FileInfo(Origin_full_path);
                                    String Target_full_path = Path.Combine(Path.Combine(App_globals.AppDataSection(dPATH.CODE).FullName, CVentanaProcesos.TV_Processes.SelectedNode.FullPath), fi.Name);
                                    String Target_path = (CVentanaProcesos.TV_Processes.SelectedNode.FullPath.Replace(dPROCESS.FOLDER + "\\", "") + "." + fi.Name).Replace(".json", "").Replace("\\", ".");

                                    // Replace old program path ocurrencies
                                    CStructModifications csmod = new CStructModifications(sys, App_globals);
                                    csmod.MoveProcess_byNamespace(Origin_path, Target_path);

                                    // File move
                                    File.Move(Origin_full_path, Target_full_path);

                                    CVentanaProcesos.contextMenu_Procesos.Items[2].Enabled = false;
                                }
                                else
                                {
                                    MessageBox.Show("Debe cortar un programa del árbol de programas antes de pegarlo");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Debe pegar el programa dentro del árbol de programas");
                            }

                            //END CODE PRCGUID: e0ac24cc-d14e-4e0c-bb6b-da7a4942a916
			}

			/// #NAME#: #DESCRIPTION#
			public void f_e7508f91_1565_4f0f_b02a_4d2dadabac5f()
			{
			//INI CODE PRCGUID: e7508f91-1565-4f0f-b02a-4d2dadabac5f

                            ARQODE_UI.GestorProcesos.CVentanaProcesos CVentanaProcesos = new ARQODE_UI.GestorProcesos.CVentanaProcesos(vm);
                            if ((CVentanaProcesos.TV_Processes.SelectedNode != null) && (CVentanaProcesos.LProcess.SelectedItem != null))
                            {
                                String Process_path = CVentanaProcesos.TV_Processes.SelectedNode.FullPath;
                                String Process_guid = ((KeyValuePair<String, JToken>)CVentanaProcesos.LProcess.SelectedItem).Value["Guid"].ToString();
                                JObject JProcess_move = new JObject();
                                JProcess_move.Add("Process path", Process_path);
                                JProcess_move.Add("Process guid", Process_guid);

                                Clipboard.SetText(JProcess_move.ToString());

                                CVentanaProcesos.contextMenu_Proceso.Items[2].Enabled = true;
                                CVentanaProcesos.contextMenu_Proceso.Items[2].Text = "Pegar proceso";
                            }


                            //END CODE PRCGUID: e7508f91-1565-4f0f-b02a-4d2dadabac5f
			}

			/// #NAME#: #DESCRIPTION#
			public void f_e0724caf_1ddf_4e3b_82ec_52f91b944f62()
			{
			//INI CODE PRCGUID: e0724caf-1ddf-4e3b-82ec-52f91b944f62

                            ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                            ARQODE_UI.GestorProcesos.CVentanaProcesos CVentanaProcesos = new ARQODE_UI.GestorProcesos.CVentanaProcesos(vm);

                            String Origin_path = Clipboard.GetText();

                            if (Origin_path.StartsWith("{"))
                            {
                                if (CVentanaProcesos.TV_Processes.SelectedNode.FullPath.EndsWith(".json"))
                                {
                                    JObject JPrcMove = JObject.Parse(Origin_path);
                                    String Origin_process_path = Path.Combine(App_globals.AppDataSection(dPATH.CODE).FullName, JPrcMove["Process path"].ToString());
                                    String Origin_process_guid = JPrcMove["Process guid"].ToString();

                                    // open orign file
                                    JSonFile jOriginFile = new JSonFile(Origin_process_path);
                                    JToken JOriginPrc = jOriginFile.getNode(String.Format("$.processes[?(@.Guid == '{0}')]", Origin_process_guid));

                                    // open target file
                                    String Target_process_namespace = CVentanaProcesos.TV_Processes.SelectedNode.FullPath.Replace(dPROCESS.FOLDER + "\\", "").Replace(".json", "").Replace("\\", ".");
                                    String Target_process_path = Path.Combine(App_globals.AppDataSection(dPATH.CODE).FullName, CVentanaProcesos.TV_Processes.SelectedNode.FullPath);
                                    JSonFile JTargetFile = new JSonFile(Target_process_path);
                                    if (JTargetFile.getNode(String.Format("$.processes[?(@.Guid == '{0}')]", Origin_process_guid)) == null)
                                    {
                                        CStructModifications csmod = new CStructModifications(sys, App_globals);
                                        csmod.MoveProcess_byGuid(Origin_process_guid, Target_process_namespace);

                                        (JTargetFile.jActiveObj["processes"] as JArray).Add(JOriginPrc);
                                        JTargetFile.Write();

                                        JOriginPrc.Remove();
                                        jOriginFile.Write();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Ya existe un proceso con el Guid " + Origin_process_guid + " en el fichero de procesos " + CVentanaProcesos.TV_Processes.SelectedNode.FullPath);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Debes seleccionar un fichero del árbol de procesos donde mover el proceso seleccionado.");
                                }
                            }

                            //END CODE PRCGUID: e0724caf-1ddf-4e3b-82ec-52f91b944f62
			}

			/// #NAME#: #DESCRIPTION#
			public void f_246c3776_b78e_4702_b593_78ce31b6fef7()
			{
			//INI CODE PRCGUID: 246c3776-b78e-4702-b593-78ce31b6fef7

                            ARQODE_UI.GestorProcesos.CVentanaProcesos CVentanaProcesos = new ARQODE_UI.GestorProcesos.CVentanaProcesos(vm);

                            JToken JProc = ((KeyValuePair<String, JToken>)CVentanaProcesos.LProcess.SelectedItem).Value;

                            ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                            CStructModifications csmod = new CStructModifications(sys, App_globals);
                            String prc_guid = JProc["Guid"].ToString();
                            ArrayList program_refs = csmod.FindProcessInPrograms(prc_guid);

                            if (program_refs.Count <= 0)
                            {
                                // Remove process
                                String prc_path = Path.Combine(App_globals.AppDataSection(dPATH.CODE).FullName, CVentanaProcesos.TV_Processes.SelectedNode.FullPath);
                                JSonFile jProcess = new JSonFile(prc_path);
                                JToken jPrc = jProcess.getNode(String.Format("$.processes[?(@.Guid == '{0}')]", prc_guid));
                                if (jPrc != null)
                                {
                                    jPrc.Remove();
                                    jProcess.Write();
                                }
                            }
                            else
                            {
                                //String message = "";
                                //DirectoryInfo pprog = App_globals.DataSection(dPATH.PROGRAM);
                                //foreach (String program in program_refs) { message += program.Replace(pprog.FullName + "\\", "") + "\r\n"; }
                                //MessageBox.Show("Antes de eliminar este proceso debe eliminar las siguientes referencias en programas: \r\n" + message);

                                String call_buscar_referencias = Config_str("Call a buscar referencias");
                                vm.CallProgram(event_desc, call_buscar_referencias);
                            }

                            //END CODE PRCGUID: 246c3776-b78e-4702-b593-78ce31b6fef7
			}

			/// #NAME#: #DESCRIPTION#
			public void f_773923b8_4e21_4dc6_afea_6191de56ef68()
			{
			//INI CODE PRCGUID: 773923b8-4e21-4dc6-afea-6191de56ef68
                            ARQODE_UI.GestorProcesos.CVentanaProcesos CVentanaProcesos = new ARQODE_UI.GestorProcesos.CVentanaProcesos(vm);
                            ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                            if ((CVentanaProcesos.LProcess.Items.Count > 0) && (CVentanaProcesos.LProcess.SelectedIndex >= 0))
                            {
                                CStructModifications csmod = new CStructModifications(sys, App_globals);
                                JToken JProc = ((KeyValuePair<String, JToken>)CVentanaProcesos.LProcess.SelectedItem).Value;
                                String prc_active_guid = JProc["Guid"].ToString();

                                ArrayList ar = csmod.FindProcessInPrograms(prc_active_guid);

                                DataTable dt = new DataTable();
                                dt.Columns.Add("Path");
                                dt.Columns.Add("Program name");
                                foreach (string s in ar)
                                {
                                    String cad = s.Replace(App_globals.AppDataSection(dPATH.CODE).FullName + "\\", "").Replace("\\", ".").Replace(".json", "");
                                    dt.Rows.Add(new object[] { cad, cad });
                                }

                                Outputs("Tabla resultados", dt);
                                Outputs("Num columna con path", 0);
                            }

                            //END CODE PRCGUID: 773923b8-4e21-4dc6-afea-6191de56ef68
			}

	
    }
}
#endregion
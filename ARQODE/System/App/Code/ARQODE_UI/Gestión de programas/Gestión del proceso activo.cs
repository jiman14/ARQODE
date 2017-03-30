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
			public void f_b46bc0ee_4897_4dac_9265_3e03514e0eaf()
			{
			//INI CODE PRCGUID: b46bc0ee-4897-4dac-9265-3e03514e0eaf

                            ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                            JToken JProc = (JToken)Input("Proceso activo");
                            if (JProc != null)
                            {
                                String prc_namespace = JProc["Namespace"].ToString();
                                String prc_guid = JProc["Guid"].ToString();
                                String prc_name = (JProc["Name"] != null) ? JProc["Name"].ToString() : prc_guid;
                                ARQODE_UI.GestorProcesos.CVentanaProcesos CVentanaProcesos = new ARQODE_UI.GestorProcesos.CVentanaProcesos(vm);

                                TreeNode tnActivo = CVentanaProcesos.TV_Processes.Nodes[0];
                                CVentanaProcesos.TV_Processes.CollapseAll();
                                vm.Cancel_events = false;
                                // ir al nodo del árbol de procesos
                                foreach (String str_nodo in prc_namespace.ToString().Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries))
                                {
                                    if (tnActivo.Nodes[str_nodo] != null)
                                    {
                                        tnActivo = tnActivo.Nodes[str_nodo];
                                        CVentanaProcesos.TV_Processes.SelectedNode = tnActivo;
                                    }
                                    else if (tnActivo.Nodes[str_nodo + ".json"] != null)
                                    {
                                        tnActivo = tnActivo.Nodes[str_nodo + ".json"];
                                        CVentanaProcesos.TV_Processes.SelectedNode = tnActivo;
                                    }
                                }

                                // Ir al proceso concreto de la lista
                                if (CVentanaProcesos.TV_Processes.Nodes[0] != CVentanaProcesos.TV_Processes.SelectedNode)
                                {
                                    int i = -1;
                                    foreach (KeyValuePair<String, JToken> item in CVentanaProcesos.LProcess.Items)
                                    {
                                        if (item.Key == prc_name) { i++; break; }
                                        else i++;
                                    }
                                    CVentanaProcesos.LProcess.SelectedIndex = i;
                                }

                                // abrir la pestaña de proceso base                    
                                CVentanaProcesos.tabProcesos.SelectedIndex = 0;

                            }
                            //END CODE PRCGUID: b46bc0ee-4897-4dac-9265-3e03514e0eaf
			}

			/// #NAME#: #DESCRIPTION#
			public void f_5814b4ca_7c6d_469e_855f_52d0add56d06()
			{
			//INI CODE PRCGUID: 5814b4ca-7c6d-469e-855f-52d0add56d06

                            ARQODE_UI.GestorProcesos.CFormProcesoActivo CFormProcesoActivo = new ARQODE_UI.GestorProcesos.CFormProcesoActivo(vm);
                            if (CFormProcesoActivo.TV_ViewsVars.SelectedNode != null)
                            {
                                Clipboard.SetText(CFormProcesoActivo.TV_ViewsVars.SelectedNode.FullPath.Replace("\\", ".").Replace(".json", ""));
                            }



                            //END CODE PRCGUID: 5814b4ca-7c6d-469e-855f-52d0add56d06
			}

			/// #NAME#: #DESCRIPTION#
			public void f_e0d3ca8d_66ba_4363_a265_3b9a918e6eeb()
			{
			//INI CODE PRCGUID: e0d3ca8d-66ba-4363-a265-3b9a918e6eeb

                            ARQODE_UI.GestorProcesos.CFormProcesoActivo CFormProcesoActivo = new ARQODE_UI.GestorProcesos.CFormProcesoActivo(vm);
                            if (CFormProcesoActivo.LB_ProgramVars.SelectedItem != null)
                            {
                                Clipboard.SetText(CFormProcesoActivo.LB_ProgramVars.SelectedItem.ToString());
                            }

                            //END CODE PRCGUID: e0d3ca8d-66ba-4363-a265-3b9a918e6eeb
			}

			/// #NAME#: #DESCRIPTION#
			public void f_dc3a6072_eead_4b3b_b9cd_57be3a6cd5b0()
			{
			//INI CODE PRCGUID: dc3a6072-eead-4b3b-b9cd-57be3a6cd5b0

                            ARQODE_UI.GestorProcesos.CFormProcesoActivo CFormProcesoActivo = new ARQODE_UI.GestorProcesos.CFormProcesoActivo(vm);
                            if (CFormProcesoActivo.TV_GlobalsVars.SelectedNode != null)
                            {
                                Clipboard.SetText(CFormProcesoActivo.TV_GlobalsVars.SelectedNode.FullPath.Replace("\\", "."));
                            }


                            //END CODE PRCGUID: dc3a6072-eead-4b3b-b9cd-57be3a6cd5b0
			}

			/// #NAME#: #DESCRIPTION#
			public void f_87c9e177_3406_4660_8e25_a4eccf856dac()
			{
			//INI CODE PRCGUID: 87c9e177-3406-4660-8e25-a4eccf856dac

                            ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                            ARQODE_UI.GestorProcesos.CFormProcesoActivo CFormProcesoActivo = new ARQODE_UI.GestorProcesos.CFormProcesoActivo(vm);
                            if (CFormProcesoActivo.TV_ViewsVars.SelectedNode.Text.EndsWith(".json"))
                            {
                                ARQODE_UI.ARQODE_UI.CInputDialog CInputDialog = new ARQODE_UI.ARQODE_UI.CInputDialog(vm);
                                CInputDialog.InputDialog.AcceptButton = CInputDialog.BAceptar;
                                CInputDialog.InputDialog.CancelButton = CInputDialog.BCancelar;

                                CInputDialog.InputDialog.Text = "Variables";
                                CInputDialog.Label1.Text = "Nueva variable de vista";
                                vm.Cancel_events = false;
                                if (CInputDialog.InputDialog.ShowDialog() == DialogResult.OK)
                                {
                                    if (CInputDialog.textBox1.Text != "")
                                    {
                                        String view_path = Path.Combine(
                                            App_globals.AppDataSection(dPATH.VIEWS).FullName,
                                            CFormProcesoActivo.TV_ViewsVars.SelectedNode.FullPath);
                                        JSonFile JView = new JSonFile(view_path);
                                        (JView.jActiveObj["Variables"] as JArray).Add(CInputDialog.textBox1.Text);
                                        CFormProcesoActivo.TV_ViewsVars.SelectedNode.Nodes.Add(CInputDialog.textBox1.Text);
                                        JView.Write();
                                    }
                                }
                            }

                            //END CODE PRCGUID: 87c9e177-3406-4660-8e25-a4eccf856dac
			}

			/// #NAME#: #DESCRIPTION#
			public void f_c3697a76_651b_43ca_b89e_a035993a9d23()
			{
			//INI CODE PRCGUID: c3697a76-651b-43ca-b89e-a035993a9d23

                            ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                            ARQODE_UI.GestorProcesos.CFormProcesoActivo CFormProcesoActivo = new ARQODE_UI.GestorProcesos.CFormProcesoActivo(vm);
                            if ((CFormProcesoActivo.TV_ViewsVars.SelectedNode != null) &&
                                (CFormProcesoActivo.TV_ViewsVars.SelectedNode.Nodes.Count == 0))
                            {
                                JSonFile jView = new JSonFile(Path.Combine(
                                    App_globals.AppDataSection(dPATH.VIEWS).FullName,
                                    CFormProcesoActivo.TV_ViewsVars.SelectedNode.Parent.FullPath));
                                JToken Jnode = jView.jActiveObj["Variables"].FirstOrDefault(x => x.ToString() == CFormProcesoActivo.TV_ViewsVars.SelectedNode.Text);
                                Jnode.Remove();
                                jView.Write();

                                CFormProcesoActivo.TV_ViewsVars.SelectedNode.Remove();
                            }

                            //END CODE PRCGUID: c3697a76-651b-43ca-b89e-a035993a9d23
			}

			/// #NAME#: #DESCRIPTION#
			public void f_b8c926b9_1f1f_4575_b0d6_abafca3997d9()
			{
			//INI CODE PRCGUID: b8c926b9-1f1f-4575-b0d6-abafca3997d9

                            ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                            ARQODE_UI.ARQODE_UI.CInputDialog CInputDialog = new ARQODE_UI.ARQODE_UI.CInputDialog(vm);
                            CInputDialog.InputDialog.AcceptButton = CInputDialog.BAceptar;
                            CInputDialog.InputDialog.CancelButton = CInputDialog.BCancelar;

                            CInputDialog.InputDialog.Text = "Variables de programa";
                            CInputDialog.Label1.Text = "Nueva variable de programa";
                            vm.Cancel_events = false;
                            if (CInputDialog.InputDialog.ShowDialog() == DialogResult.OK)
                            {
                                String nueva_var = CInputDialog.textBox1.Text.Trim();
                                if (nueva_var != "")
                                {
                                    ARQODE_UI.GestorProcesos.CFormProcesoActivo CFormProcesoActivo = new ARQODE_UI.GestorProcesos.CFormProcesoActivo(vm);
                                    String Programa_activo = CFormProcesoActivo.Namespace_programa_activo.ToString();
                                    CProgram curr_prog = new CProgram(sys, App_globals, Programa_activo);

                                    if (!curr_prog.Variables.Contains(nueva_var))
                                    {
                                        curr_prog.Variables.Add(nueva_var);
                                        curr_prog.Save();
                                        CFormProcesoActivo.LB_ProgramVars.Items.Add(nueva_var);
                                    }
                                    else
                                    {
                                        MessageBox.Show("La variable ya existe en el programa");
                                    }

                                }
                            }



                            //END CODE PRCGUID: b8c926b9-1f1f-4575-b0d6-abafca3997d9
			}

			/// #NAME#: #DESCRIPTION#
			public void f_acbc65a0_6f4f_4d0b_aad9_e7c24e7241a1()
			{
			//INI CODE PRCGUID: acbc65a0-6f4f-4d0b-aad9-e7c24e7241a1
                            ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                            ARQODE_UI.GestorProcesos.CFormProcesoActivo CFormProcesoActivo = new ARQODE_UI.GestorProcesos.CFormProcesoActivo(vm);
                            CProgram curr_prog = new CProgram(sys, App_globals, CFormProcesoActivo.Namespace_programa_activo.ToString());
                            String var = CFormProcesoActivo.LB_ProgramVars.SelectedItem.ToString();
                            curr_prog.vars.Remove(var);
                            curr_prog.Variables.RemoveAt(curr_prog.Variables.ToList().IndexOf(var));
                            curr_prog.Save();
                            CFormProcesoActivo.LB_ProgramVars.Items.Remove(var);


                            //END CODE PRCGUID: acbc65a0-6f4f-4d0b-aad9-e7c24e7241a1
			}

			/// #NAME#: #DESCRIPTION#
			public void f_17ff2b1d_a8cb_4d6f_b0ee_76c3b4eee09b()
			{
			
			}

			/// #NAME#: #DESCRIPTION#
			public void f_72952686_ac22_4565_ada1_2aea139e086f()
			{
			
			}

			/// #NAME#: #DESCRIPTION#
			public void f_9af9d8c3_c621_460b_96a7_fa53cde549dd()
			{
			//INI CODE PRCGUID: 9af9d8c3-c621-460b-96a7-fa53cde549dd


                #region Variables

                ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                TProcess tempprc = new TProcess(sys, App_globals, (JObject)CVentanaProgramas.Proceso_de_programa_activo);


                String codigo_prc = CLogicEditor.get_Code_from_logic(Globals.ARQODE_APP, tempprc.Guid);
                if ((codigo_prc == "") && (tempprc.Code != null) && (tempprc.Code.ToString() != ""))
                {
                    codigo_prc = System.Text.UTF8Encoding.UTF8.GetString(Convert.FromBase64String(tempprc.Code.ToString()));
                }
                // Outputs vars
                Outputs("Código del proceso", codigo_prc);
                #endregion



                //END CODE PRCGUID: 9af9d8c3-c621-460b-96a7-fa53cde549dd
			}

			/// #NAME#: #DESCRIPTION#
			public void f_Cargar_proceso_activo()
			{
			//INI CODE PRCGUID: Cargar proceso activo

                            ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                            ARQODE_UI.GestorProcesos.CFormProcesoActivo CFormProcesoActivo = new ARQODE_UI.GestorProcesos.CFormProcesoActivo(vm);
                            if ((CVentanaProgramas.Namespace_programa_activo != null) && (CVentanaProgramas.ListaProcesos.Rows.Count > 0))
                            {
                                ARQODE_UI.GestorProcesos.CVentanaProcesos CVentanaProcesos = new ARQODE_UI.GestorProcesos.CVentanaProcesos(vm);
                                if (CVentanaProcesos.PProcessPanel.Controls.Count == 0)
                                {
                                    CVentanaProcesos.PProcessPanel.Controls.Add(CFormProcesoActivo.FormProcesoActivo);
                                }
                                CFormProcesoActivo.FormProcesoActivo.Dock = DockStyle.Fill;
                                // Variables de vistas
                                CFormProcesoActivo.TV_ViewsVars.Nodes.Clear();
                                TreeNode tn_views = (TreeNode)CVentanaProgramas.Cargar_arbol_recursivo.Crear_arbol_desde_carpeta(App_globals.AppDataSection(dPATH.VIEWS).FullName, "base_control.json");
                                List<TreeNode> NodosHoja = (List<TreeNode>)CVentanaProgramas.Cargar_arbol_recursivo.Crear_lista_de_nodos_hoja_del_arbol(tn_views);

                                foreach (TreeNode node in tn_views.Nodes)
                                {
                                    CFormProcesoActivo.TV_ViewsVars.Nodes.Add(node);
                                }

                                foreach (TreeNode nodo in NodosHoja)
                                {
                                    JSonFile JView = new JSonFile(Path.Combine(
                                        App_globals.AppDataSection(dPATH.VIEWS).FullName,
                                        nodo.FullPath));
                                    if (JView.jActiveObj["Variables"] != null)
                                    {
                                        foreach (JValue var in JView.jActiveObj["Variables"] as JArray)
                                        {
                                            nodo.Nodes.Add(var.Value.ToString());
                                        }
                                    }
                                }

                                // Variables de programa
                                CFormProcesoActivo.LB_ProgramVars.Items.Clear();

                                CProgram Curr_prog = new CProgram(sys, App_globals, CVentanaProgramas.Namespace_programa_activo.ToString());
                                foreach (String var in Curr_prog.vars.Keys)
                                {
                                    CFormProcesoActivo.LB_ProgramVars.Items.Add(var);
                                }

                                // Variables globals
                                CFormProcesoActivo.TV_GlobalsVars.Nodes.Clear();
                                foreach (JToken JGlob in App_globals.Globals)
                                {
                                    TreeNode tn = new TreeNode(((JProperty)JGlob).Name);

                                    if (((JProperty)JGlob).Value is JObject)
                                    {
                                        JObject JChildGlobs = (JObject)((JProperty)JGlob).Value;

                                        foreach (JProperty JChildGlob in JChildGlobs.Properties())
                                        {
                                            TreeNode tn1 = new TreeNode(JChildGlob.Name);
                                            tn.Nodes.Add(tn1);
                                        }
                                    }

                                    CFormProcesoActivo.TV_GlobalsVars.Nodes.Add(tn);
                                }

                                // Datos del proceso
                                JToken JProgram_logic = (JToken)CVentanaProgramas.Procesos_programa_activo;
                                if (JProgram_logic != null)
                                {
                                    if ((CVentanaProgramas.ListaProcesos.SelectedCells.Count > 0) ||
                                        (CVentanaProgramas.ListaProcesos.Rows.Count > 0))
                                    {
                                        int rowIndex = (CVentanaProgramas.ListaProcesos.SelectedCells.Count > 0) ?
                                            CVentanaProgramas.ListaProcesos.SelectedCells[0].RowIndex :
                                            0;

                                        String PGuid = CVentanaProgramas.ListaProcesos[1, rowIndex].Value.ToString();
                                        JToken JProc = (JProgram_logic as JArray)[rowIndex];
                                        // Eliminar el proceso si está vacío
                                        if (JProc.Count() == 0)
                                        {
                                            JProc.Remove();
                                            JProc = (JProgram_logic as JArray)[rowIndex];
                                        }

                                        // Guardar proceso activo
                                        Outputs("Proceso de programa activo", JProc);

                                        CFormProcesoActivo.Fila_activa = rowIndex;

                                        CFormProcesoActivo.Active_process = JProc;
                                        CFormProcesoActivo.Namespace_programa_activo = CVentanaProgramas.Namespace_programa_activo;

                                        CFormProcesoActivo.LName.Text = (JProc["Name"] != null) ? JProc["Name"].ToString() : JProc["Guid"].ToString();
                                        CFormProcesoActivo.TBDescription.Text = (JProc["Description"] != null) ? JProc["Description"].ToString() : "";

                                        // inputs
                                        System.Data.DataTable dti = new System.Data.DataTable();

                                        dti.Columns.Add("Input");
                                        dti.Columns.Add("Value");
                                        foreach (JProperty JInput in JProc["Inputs"])
                                        {
                                            dti.Rows.Add(new String[] { JInput.Name, JInput.Value.ToString() });
                                        }
                                        CFormProcesoActivo.LInputs.DataSource = dti;

                                        // Outputs
                                        System.Data.DataTable dto = new System.Data.DataTable();

                                        dto.Columns.Add("Output");
                                        dto.Columns.Add("Value");
                                        foreach (JProperty JOutputs in JProc["Outputs"])
                                        {
                                            dto.Rows.Add(new String[] { JOutputs.Name, JOutputs.Value.ToString() });
                                        }
                                        CFormProcesoActivo.LOutputs.DataSource = dto;

                                        // Configuration
                                        if (JProc["Configuration"] != null)
                                        {
                                            System.Data.DataTable dtc = new System.Data.DataTable();

                                            dtc.Columns.Add("Configuration");
                                            dtc.Columns.Add("Value");
                                            foreach (JProperty JConfig in JProc["Configuration"])
                                            {
                                                dtc.Rows.Add(new String[] { JConfig.Name, JConfig.Value.ToString() });
                                            }
                                            CFormProcesoActivo.LConfig.DataSource = dtc;
                                        }

                                    }
                                    else
                                    {
                                        CFormProcesoActivo.Active_process = null;
                                        CFormProcesoActivo.LName.Text = "";
                                        CFormProcesoActivo.TBDescription.Text = "";
                                        CFormProcesoActivo.LInputs.DataSource = null;
                                        CFormProcesoActivo.LOutputs.DataSource = null;
                                        CFormProcesoActivo.LConfig.DataSource = null;
                                        Outputs("Proceso de programa activo", null);
                                    }
                                }

                                CVentanaProcesos.tabProcesos.SelectedIndex = 1;
                            }
                            else
                            {
                                CFormProcesoActivo.Active_process = null;
                                CFormProcesoActivo.LName.Text = "";
                                CFormProcesoActivo.TBDescription.Text = "";
                                CFormProcesoActivo.LInputs.DataSource = null;
                                CFormProcesoActivo.LOutputs.DataSource = null;
                                CFormProcesoActivo.LConfig.DataSource = null;
                                Outputs("Proceso de programa activo", null);
                            }
                            //END CODE PRCGUID: Cargar proceso activo
			}

			/// #NAME#: #DESCRIPTION#
			public void f_Guardar_proceso_activo()
			{
			//INI CODE PRCGUID: Guardar proceso activo

                            ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                            ARQODE_UI.GestorProcesos.CFormProcesoActivo CFormProcesoActivo = new ARQODE_UI.GestorProcesos.CFormProcesoActivo(vm);

                            // cargar fichero de programa
                            CProgram cprog = new CProgram(sys, App_globals, CVentanaProgramas.Namespace_programa_activo.ToString());
                            if ((CVentanaProgramas.ListaProcesos.RowCount > 0) && (CVentanaProgramas.ListaProcesos.SelectedCells.Count > 0))
                            {
                                JToken JProc = (cprog.Logic as JArray)[int.Parse(CFormProcesoActivo.Fila_activa.ToString())];

                                // Guardar descripción
                                JProc["Description"] = CFormProcesoActivo.TBDescription.Text;

                                // Guardar entradas
                                JProc["Inputs"] = new JObject();
                                for (int i = 0; i < CFormProcesoActivo.LInputs.RowCount; i++)
                                {
                                    if ((CFormProcesoActivo.LInputs[0, i].Value != null) && (CFormProcesoActivo.LInputs[1, i].Value != null) && (CFormProcesoActivo.LInputs[0, i].Value.ToString() != ""))
                                    {
                                        JProc["Inputs"][CFormProcesoActivo.LInputs[0, i].Value.ToString()] = CFormProcesoActivo.LInputs[1, i].Value.ToString();
                                    }
                                }

                                // Guardar salidas
                                JProc["Outputs"] = new JObject();
                                for (int i = 0; i < CFormProcesoActivo.LOutputs.RowCount; i++)
                                {
                                    if ((CFormProcesoActivo.LOutputs[0, i].Value != null) && (CFormProcesoActivo.LOutputs[1, i].Value != null) && (CFormProcesoActivo.LOutputs[0, i].Value.ToString() != ""))
                                    {
                                        JProc["Outputs"][CFormProcesoActivo.LOutputs[0, i].Value.ToString()] = CFormProcesoActivo.LOutputs[1, i].Value.ToString();
                                    }
                                }
                                JProc["Configuration"] = new JObject();
                                // Guardar configuration
                                for (int i = 0; i < CFormProcesoActivo.LConfig.RowCount; i++)
                                {
                                    if ((CFormProcesoActivo.LConfig[0, i].Value != null) && (CFormProcesoActivo.LConfig[1, i].Value != null) && (CFormProcesoActivo.LConfig[0, i].Value.ToString() != ""))
                                    {
                                        JProc["Configuration"][CFormProcesoActivo.LConfig[0, i].Value.ToString()] = CFormProcesoActivo.LConfig[1, i].Value.ToString();
                                    }
                                }

                                cprog.Save();
                            }

                            //END CODE PRCGUID: Guardar proceso activo
			}

			/// #NAME#: #DESCRIPTION#
			public void f_Editar_codigo()
			{
			//INI CODE PRCGUID: Editar código

                CProgram CurrentProg = null;
                ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);

                if ((CVentanaProgramas.ListaProcesos.Rows.Count > 0) && (CVentanaProgramas.ListaProcesos.SelectedCells.Count > 0) &&
                    (CVentanaProgramas.ListaProcesos.SelectedCells[0].ColumnIndex == 0))
                {
                    int ri = CVentanaProgramas.ListaProcesos.SelectedCells[0].RowIndex;
                    int ci = CVentanaProgramas.ListaProcesos.SelectedCells[0].ColumnIndex;
                    String edit_code_value = (bool.Parse(CVentanaProgramas.ListaProcesos[ci, ri].Value.ToString())) ? "0" : "1";

                    String p_guid = CVentanaProgramas.ListaProcesos[1, ri].Value.ToString();

                    TreeNode N_ProgramaActivo = CVentanaProgramas.ArbolProgramas.SelectedNode;

                    CurrentProg = new CProgram(sys, App_globals, N_ProgramaActivo.FullPath.Replace(dPROGRAM.FOLDER + "\\", "").Replace(".json", "").Replace("\\", "."));

                    if (p_guid != "Call")
                    {
                        if (!CurrentProg.SetProcess_Edit_Code(p_guid, edit_code_value))
                        {
                            MessageBox.Show("Seleccciona en el arbol de programas el programa correspondiente al proceso: " + p_guid);
                        }
                        else
                        {
                            CVentanaProgramas.ListaProcesos[ci, ri].Selected = false;
                            CVentanaProgramas.ListaProcesos[1, ri].Selected = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se puede editar el código de una función 'Call', sólo procesos.");
                        CVentanaProgramas.ListaProcesos.Rows[ri].Cells[ci].Value = false;
                    }

                    // cambiar la celda activa para que el evento cellcontentchanged no de problemas                    
                    CVentanaProgramas.ListaProcesos[1, CVentanaProgramas.ListaProcesos.SelectedCells[0].RowIndex].Selected = true;
                }
                //END CODE PRCGUID: Editar código
			}

			/// #NAME#: #DESCRIPTION#
			public void f_b2c47523_858c_4555_b656_dc06c3f1690a()
			{
			//INI CODE PRCGUID: b2c47523-858c-4555-b656-dc06c3f1690a

                            ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                            if ((CVentanaProgramas.ListaProcesos.Rows.Count > 0) && (CVentanaProgramas.ListaProcesos.SelectedCells.Count > 0))
                            {
                                CStructModifications csmod = new CStructModifications(sys, App_globals);
                                int filaactiva = CVentanaProgramas.ListaProcesos.SelectedCells[0].RowIndex;
                                String prc_active_guid = CVentanaProgramas.ListaProcesos.Rows[filaactiva].Cells["Guid"].Value.ToString();
                                ArrayList ar = csmod.FindProcessInPrograms(prc_active_guid);
                                DataTable dt = new DataTable();
                                dt.Columns.Add("Path");
                                dt.Columns.Add("Program name");
                                foreach (string s in ar)
                                {
                                    String cad = s.Replace(Globals.AppDataSection(dPATH.CODE).FullName + "\\", "").Replace("\\", ".").Replace(".json", "");
                                    dt.Rows.Add(new object[] { cad, cad });
                                }

                                Outputs("Tabla resultados", dt);
                                Outputs("Num columna con path", 0);
                            }

                            //END CODE PRCGUID: b2c47523-858c-4555-b656-dc06c3f1690a
			}

			/// #NAME#: #DESCRIPTION#
			public void f_f59c1ab8_4979_49af_9503_26fcf239135b()
			{
			//INI CODE PRCGUID: f59c1ab8-4979-49af-9503-26fcf239135b

                ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                
                if (CVentanaProgramas.Proceso_de_programa_activo != null)
                {
                    TProcess tempPrc = prc;
                    prc = new TProcess(sys, App_globals, CVentanaProgramas.Proceso_de_programa_activo as JObject);
                    SendToEditor();
                    //CLogicEditor.SaveCode(Globals.ARQODE_APP);
                    prc = tempPrc;
                }


//END CODE PRCGUID: f59c1ab8-4979-49af-9503-26fcf239135b
			}

	
    }
}
#endregion
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
			public void f_Cargar_programas()
			{
			//INI CODE PRCGUID: Cargar programas

                            ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                            String selNode = "";

                            if (CVentanaProgramas.ArbolProgramas.SelectedNode != null)
                            {
                                selNode = CVentanaProgramas.ArbolProgramas.SelectedNode.FullPath;
                            }
                            CVentanaProgramas.ArbolProgramas.Nodes.Clear();

                            DirectoryInfo program_path = new DirectoryInfo(
                                Path.Combine(App_globals.App_path.FullName, dPATH.PROGRAM.Replace(".", "\\")));



                            TreeNode tn_programas = (TreeNode)CVentanaProgramas.Cargar_arbol_recursivo.Crear_arbol_desde_carpeta(
                                program_path.FullName, "base_program.json");

                            CVentanaProgramas.ArbolProgramas.Nodes.Add(tn_programas);

                            TreeNode snode = CVentanaProgramas.ArbolProgramas.Nodes[0];
                            foreach (String node in selNode.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries))
                            {
                                if (snode.Nodes[node] != null)
                                {
                                    snode = snode.Nodes[node];
                                }
                                else if (snode.Nodes[node + ".json"] != null)
                                {
                                    snode = snode.Nodes[node + ".json"];
                                }
                                CVentanaProgramas.ArbolProgramas.SelectedNode = snode;
                            }
                            CVentanaProgramas.ArbolProgramas.SelectedNode = snode;
                            CVentanaProgramas.ArbolProgramas.SelectedNode.Expand();

                            //END CODE PRCGUID: Cargar programas
			}

			/// #NAME#: #DESCRIPTION#
			public void f_Cargar_subprogramas()
			{
			//INI CODE PRCGUID: Cargar subprogramas

                            ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                            TreeNode ActiveNode = CVentanaProgramas.ArbolProgramas.SelectedNode;
                            int row_index = 0;
                            int col_index = 0;
                            if ((ActiveNode != null) && (ActiveNode.Text.EndsWith(".json")))
                            {
                                CProgram CurrentProg = new CProgram(sys, App_globals, ActiveNode.FullPath.Replace(dPROGRAM.FOLDER + "\\", "").Replace(".json", "").Replace("\\", "."));
                                CVentanaProgramas.Namespace_programa_activo = CurrentProg.Program_namespace;

                                #region Guardar namespace actual en histórico
                                DataTable dt = null;
                                if (CVentanaProgramas.Historico_de_programas == null)
                                {
                                    dt = new DataTable();
                                    dt.Columns.Add("Path");
                                    dt.Columns.Add("Program name");
                                    CVentanaProgramas.Historico_de_programas = dt;
                                }
                                else
                                {
                                    dt = (DataTable)CVentanaProgramas.Historico_de_programas;
                                }
                                if (!((dt.Rows.Count > 0) && (dt.Rows[0][0].ToString() == CurrentProg.Program_namespace)))
                                {
                                    DataRow dr = dt.NewRow();
                                    dr[0] = dPROGRAM.FOLDER + "." + CurrentProg.Program_namespace;
                                    dr[1] = CurrentProg.Program_namespace;
                                    dt.Rows.InsertAt(dr, 0);
                                }

                                Outputs("Histórico de programas", dt);
                                #endregion

                                if (CurrentProg.Logic != null)
                                {
                                    if ((CVentanaProgramas.ListaProcesos.RowCount > 0) && (CVentanaProgramas.ListaProcesos.SelectedCells.Count > 0))
                                    {
                                        row_index = CVentanaProgramas.ListaProcesos.SelectedCells[0].RowIndex;
                                        col_index = CVentanaProgramas.ListaProcesos.SelectedCells[0].ColumnIndex;
                                    }

                                    JArray JProcess_array = new JArray();
                                    foreach (JObject prc_node in CurrentProg.Logic)
                                    {
                                        if (prc_node.Count > 0)
                                        {
                                            TProcess CurrentProc = new TProcess(sys, App_globals, prc_node);

                                            JObject JRow = new JObject();
                                            JRow.Add("Editor", CurrentProc.Edit_code == "1");
                                            JRow.Add("Guid", CurrentProc.Guid.ToString());
                                            String Name = (CurrentProc.Name != null) ? CurrentProc.Name.ToString() : CurrentProc.Guid.ToString();
                                            JRow.Add("Name", Name);

                                            if (Name.EndsWith("Call"))
                                            {
                                                String call_at_end = "";
                                                if (CurrentProc.Configuration["program"].ToString().StartsWith("&"))
                                                {
                                                    call_at_end = "(Execute at end). ";
                                                }
                                        
                                                JRow.Add("Description", call_at_end + CurrentProc.Configuration["program"].ToString());
                                            }
                                            else
                                            {
                                                JRow.Add("Description", (CurrentProc.Description != null) ? CurrentProc.Description.ToString() : "");
                                            }

                                            JProcess_array.Add(JRow);
                                        }
                                    }
                                    CVentanaProgramas.Procesos_programa_activo = CurrentProg.Logic;

                                    DataGridViewCheckBoxColumn c1 = new DataGridViewCheckBoxColumn()
                                    {
                                        ValueType = typeof(bool),
                                        Name = "Editor"
                                    };

                                    DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
                                    c2.ValueType = typeof(string);
                                    c2.Name = "Guid";
                                    DataGridViewTextBoxColumn c3 = new DataGridViewTextBoxColumn();
                                    c3.ValueType = typeof(string);
                                    c3.Name = "Name";
                                    DataGridViewTextBoxColumn c4 = new DataGridViewTextBoxColumn();
                                    c4.ValueType = typeof(string);
                                    c4.Name = "Description";
                                    CVentanaProgramas.ListaProcesos.Columns.Clear();
                                    CVentanaProgramas.ListaProcesos.Columns.Add(c1);
                                    CVentanaProgramas.ListaProcesos.Columns.Add(c2);
                                    CVentanaProgramas.ListaProcesos.Columns.Add(c3);
                                    CVentanaProgramas.ListaProcesos.Columns.Add(c4);
                                    CVentanaProgramas.ListaProcesos.DataSource = null;

                                    CVentanaProgramas.ListaProcesos.Rows.Clear();
                                    foreach (JToken Jpro in JProcess_array)
                                    {
                                        CVentanaProgramas.ListaProcesos.Rows.Add(Jpro["Editor"], Jpro["Guid"], Jpro["Name"], Jpro["Description"]);
                                    }
                                    CVentanaProgramas.ListaProcesos.AllowUserToAddRows = false;
                                    CVentanaProgramas.ListaProcesos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                                    if (CVentanaProgramas.ListaProcesos.RowCount > 0)
                                    {
                                        if ((CVentanaProgramas.ListaProcesos.Rows.Count > row_index) && (CVentanaProgramas.ListaProcesos.Columns.Count > col_index))
                                        {
                                            CVentanaProgramas.ListaProcesos[col_index, row_index].Selected = true;
                                            CVentanaProgramas.ListaProcesos[0, 0].Selected = false;
                                        }
                                    }
                                    CVentanaProgramas.ListaProcesos.Columns[0].Width = 40;
                                    CVentanaProgramas.ListaProcesos.Columns[1].Width = 200;
                                }
                                else
                                {
                                    MessageBox.Show("El programa seleccionado contiene errores, revisar formato del json.");
                                }
                            }
                            else
                            {
                                CVentanaProgramas.ListaProcesos.Rows.Clear();
                            }
                            //END CODE PRCGUID: Cargar subprogramas
			}

			/// #NAME#: #DESCRIPTION#
			public void f_Cerrar_ventana_de_programa()
			{
			//INI CODE PRCGUID: Cerrar ventana de programa
                            //vm.Cancel_next_event = true;
                            //vm.removeViews(view.Name);
                            //vm.Cancel_next_event = false;
                            //END CODE PRCGUID: Cerrar ventana de programa
			}

			/// #NAME#: #DESCRIPTION#
			public void f_Abrir_ficha_de_programa()
			{
			//INI CODE PRCGUID: Abrir ficha de programa
                            ARQODE_UI.GestorProgramas.VentanasAyuda.CFichaPrograma CFichaPrograma = new ARQODE_UI.GestorProgramas.VentanasAyuda.CFichaPrograma(vm);
                            CFichaPrograma.FichaPrograma.AcceptButton = CFichaPrograma.button_save;
                            CFichaPrograma.FichaPrograma.CancelButton = CFichaPrograma.button_cancel;
                            CFichaPrograma.button_cancel.DialogResult = DialogResult.Cancel;
                            CFichaPrograma.button_save.DialogResult = DialogResult.OK;
                            CFichaPrograma.FichaPrograma.ActiveControl = CFichaPrograma.tb_nombre_programa;
                            ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);

                            if (CVentanaProgramas.ArbolProgramas.SelectedNode != null)
                            {
                                CFichaPrograma.Ruta = CVentanaProgramas.ArbolProgramas.SelectedNode.FullPath;
                                vm.Cancel_events = false;
                                CFichaPrograma.FichaPrograma.ShowDialog();
                            }
                            //END CODE PRCGUID: Abrir ficha de programa
			}

			/// #NAME#: #DESCRIPTION#
			public void f_edb60e5a_8595_4c01_b62a_28420d6d0d18()
			{
			//INI CODE PRCGUID: edb60e5a-8595-4c01-b62a-28420d6d0d18

                            ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                            if (CVentanaProgramas.ArbolProgramas.SelectedNode != null)
                            {
                                Clipboard.SetText(CVentanaProgramas.ArbolProgramas.SelectedNode.FullPath.Replace(dPROGRAM.FOLDER + "\\", "").Replace(".json", "").Replace("\\", "."));
                            }


                            //END CODE PRCGUID: edb60e5a-8595-4c01-b62a-28420d6d0d18
			}

			/// #NAME#: #DESCRIPTION#
			public void f_4e18d420_853d_4652_9f0f_dd41587094d4()
			{
			//INI CODE PRCGUID: 4e18d420-853d-4652-9f0f-dd41587094d4

                            ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                            String active_app = (CVentanaProgramas.MenuTop.Items[5].Text != "") ?
                                CVentanaProgramas.MenuTop.Items[5].Text :
                                dGLOBALS.SYSTEM_APP;
                            CStructModifications csmod = new CStructModifications(sys, App_globals);
                            ArrayList ar = csmod.CheckProcessIntegrityInPrograms();

                            CVentanaProgramas.MenuTop.Items[12].BackColor = (ar.Count > 0) ?
                                    System.Drawing.Color.Red :
                                    System.Drawing.Color.FromName("Control");

                            Outputs("Errores reportados", ar);

                            //END CODE PRCGUID: 4e18d420-853d-4652-9f0f-dd41587094d4
			}

			/// #NAME#: #DESCRIPTION#
			public void f_54b8eead_551e_428b_98e6_7d3e831d475d()
			{
			//INI CODE PRCGUID: 54b8eead-551e-428b-98e6-7d3e831d475d


                            #region Variables

                            // Inputs vars
                            object I_Namespace_programa_activo = Input("Namespace programa activo", false);
                            #endregion

                            if (I_Namespace_programa_activo != null)
                            {
                                ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                                CStructModifications csmod = new CStructModifications(sys, App_globals);
                                ArrayList ar = csmod.FindProgramReferences(I_Namespace_programa_activo.ToString());
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

                            //END CODE PRCGUID: 54b8eead-551e-428b-98e6-7d3e831d475d
			}

			/// #NAME#: #DESCRIPTION#
			public void f_99692b49_db30_4c26_a250_48f88bbff43c()
			{
			//INI CODE PRCGUID: 99692b49-db30-4c26-a250-48f88bbff43c


                            #region Variables

                            // Inputs vars
                            object I_Namespace_del_programa = Input("Namespace del programa", false);
                            #endregion
                            if (I_Namespace_del_programa != null)
                            {
                                ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                                TreeNode snode = CVentanaProgramas.ArbolProgramas.Nodes[0];
                                foreach (String node in I_Namespace_del_programa.ToString().Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries))
                                {
                                    if (snode.Nodes[node] != null)
                                    {
                                        snode = snode.Nodes[node];
                                    }
                                    else if (snode.Nodes[node + ".json"] != null)
                                    {
                                        snode = snode.Nodes[node + ".json"];
                                    }
                                    CVentanaProgramas.ArbolProgramas.SelectedNode = snode;
                                }
                                CVentanaProgramas.ArbolProgramas.SelectedNode = snode;
                                CVentanaProgramas.ArbolProgramas.SelectedNode.Expand();

                            }


                            //END CODE PRCGUID: 99692b49-db30-4c26-a250-48f88bbff43c
			}

	
    }
}
#endregion
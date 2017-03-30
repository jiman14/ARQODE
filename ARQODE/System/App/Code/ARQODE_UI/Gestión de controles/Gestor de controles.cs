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
			public void f_fd7bbb95_2c3f_4e41_869f_5dca33016355()
			{
			//INI CODE PRCGUID: fd7bbb95-2c3f-4e41-869f-5dca33016355

                            ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                            if (CVentanaProgramas.ArbolProgramas.SelectedNode != null)
                            {
                                Clipboard.SetText(CVentanaProgramas.ArbolProgramas.SelectedNode.FullPath.Replace(dPROGRAM.FOLDER + "\\", "").Replace("\\", ".").Replace(".json", ""));
                            }

                            ARQODE_UI.GestorControles.CFormControlesEventos CFormControlesEventos = new ARQODE_UI.GestorControles.CFormControlesEventos(vm);

                            // Cargar árbol de controles
                            DirectoryInfo program_path = App_globals.AppDataSection(dPATH.VIEWS);

                            if (CFormControlesEventos.TV_Controles.Nodes.Count == 0)
                            {
                                CFormControlesEventos.TV_Controles.Nodes.Clear();
                                TreeNode tn_vistas = (TreeNode)CVentanaProgramas.Cargar_arbol_recursivo.Crear_arbol_desde_carpeta(
                                    program_path.FullName, "base_control.json");

                                foreach (TreeNode tnchild in tn_vistas.Nodes)
                                {
                                    CFormControlesEventos.TV_Controles.Nodes.Add(tnchild);
                                }
                                // Añadir controles al árbol de vistas
                                List<TreeNode> Nodos_vista = (List<TreeNode>)CVentanaProgramas.Cargar_arbol_recursivo.Crear_lista_de_nodos_hoja_del_arbol(tn_vistas);
                                foreach (TreeNode nodo_vista in Nodos_vista)
                                {
                                    String nombre_vista = nodo_vista.FullPath.Replace("\\", ".").Replace(".json", "");

                                    try
                                    {
                                        CView VTemp = new CView(App_globals, nombre_vista);
                                        if (VTemp != null)
                                        {
                                            foreach (CView.CtrlStruct cstr in VTemp.getAllControls())
                                            {
                                                TreeNode tn = null;
                                                if (nombre_vista == cstr.control_name)
                                                    tn = new TreeNode(cstr.control_name.Substring(cstr.control_name.IndexOf(".") + 1));
                                                else
                                                    tn = new TreeNode(cstr.control_name);
                                                nodo_vista.Nodes.Add(tn);
                                            }
                                        }
                                    }
                                    catch (Exception exc)
                                    {
                                        errors.warning = exc.Message;
                                    }
                                }
                            }

                            // Enlazar opciones de menú con programas
                            String C_Programa_filtrar_busqueda = Config_str("Programa filtrar busqueda");
                            CFormControlesEventos.view.Set_event_handler(
                              CFormControlesEventos.toolStrip1.Items[1],
                              CFormControlesEventos.toolStrip1.Items[1].Name,
                              "Click",
                              C_Programa_filtrar_busqueda);

                            CFormControlesEventos.view.Set_event_handler(
                              CFormControlesEventos.toolStrip1.Items[0],
                              CFormControlesEventos.toolStrip1.Items[0].Name,
                              "TextChanged",
                              C_Programa_filtrar_busqueda);


                            CFormControlesEventos.FormControlesEventos.Show();


                            //END CODE PRCGUID: fd7bbb95-2c3f-4e41-869f-5dca33016355
			}

			/// #NAME#: #DESCRIPTION#
			public void f_b13e1604_2b91_425d_9af7_336d95429aeb()
			{
			//INI CODE PRCGUID: b13e1604-2b91-425d-9af7-336d95429aeb

                ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                ARQODE_UI.GestorControles.CFormControlesEventos CFormControlesEventos = new ARQODE_UI.GestorControles.CFormControlesEventos(vm);
                if ((CFormControlesEventos.TV_Controles.SelectedNode != null) && (CFormControlesEventos.TV_Controles.SelectedNode.Nodes.Count == 0))
                {
                    // Cargar ventana 
                    String str_parent_view = CFormControlesEventos.TV_Controles.SelectedNode.Parent.FullPath.Replace("\\", ".").Replace(".json", "");
                    CView CParentView = new CView(App_globals, str_parent_view);

                    // Cargar control struct del control seleccionado en el árbol
                    CView.CtrlStruct ctrl_str =
                        (str_parent_view.EndsWith("." + CFormControlesEventos.TV_Controles.SelectedNode.Text)) ?
                        CParentView.getCtrlStruct(str_parent_view) :
                        CParentView.getCtrlStruct(CFormControlesEventos.TV_Controles.SelectedNode.Text);

                    #region Add setted events
                    CFormControlesEventos.DG_EventosControl.Rows.Clear();
                    if (CFormControlesEventos.DG_EventosControl.Columns.Count == 0)
                    {
                        CFormControlesEventos.DG_EventosControl.Columns.Add("Event_name", "Evento");
                        CFormControlesEventos.DG_EventosControl.Columns.Add("Value", "Valor");
                    }
                    if (ctrl_str.events != null)
                    {
                        foreach (JProperty jp in ctrl_str.events)
                        {
                            CFormControlesEventos.DG_EventosControl.Rows.Add(new object[] { jp.Name, jp.Value.ToString() });
                        }
                    }
                    #endregion

                    #region Add controls events

                    if ((ctrl_str.ctrl is ContextMenuStrip) || (ctrl_str.ctrl is MenuStrip))
                    {
                        CFormControlesEventos.ListaEventos.Clear();
                        CFormControlesEventos.ListaEventos.View = View.List;

                        ToolStripItemCollection menu_items = (ctrl_str.ctrl is MenuStrip) ?
                            ((MenuStrip)ctrl_str.ctrl).Items :
                            ((ContextMenuStrip)ctrl_str.ctrl).Items;

                        Stack<KeyValuePair<int, ToolStripItemCollection>> menu_stack = new Stack<KeyValuePair<int, ToolStripItemCollection>>();
                        menu_stack.Push(new KeyValuePair<int, ToolStripItemCollection>(0, menu_items));
                        while (menu_stack.Count > 0)
                        {
                            KeyValuePair<int, ToolStripItemCollection> kp_item = (KeyValuePair<int, ToolStripItemCollection>)menu_stack.Pop();
                            int pos = kp_item.Key;
                            menu_items = kp_item.Value;

                            for (int i = pos; i < menu_items.Count; i++)
                            {
                                if ((menu_items[i] is ToolStripMenuItem) && (((ToolStripMenuItem)menu_items[i]).DropDownItems.Count > 0))
                                {
                                    ToolStripItemCollection menu_depp_level = ((ToolStripMenuItem)menu_items[i]).DropDownItems;
                                    menu_stack.Push(new KeyValuePair<int, ToolStripItemCollection>(i + 1, menu_items));
                                    menu_stack.Push(new KeyValuePair<int, ToolStripItemCollection>(0, menu_depp_level));
                                    break;
                                }
                                else if (menu_items[i] is ToolStripItem)
                                {
                                    ListViewItem lvi = new ListViewItem();
                                    lvi.Text = menu_items[i].Text;
                                    lvi.Tag = menu_items[i].Name;
                                    CFormControlesEventos.ListaEventos.Items.Add(lvi);
                                }
                            }
                        }

                        Outputs("Lista de eventos", null);
                    }
                    else
                    {
                        Type tc = ctrl_str.ctrl.GetType();
                        CFormControlesEventos.ListaEventos.Clear();
                        CFormControlesEventos.ListaEventos.View = View.List;
                        foreach (EventInfo ei in tc.GetEvents())
                        {
                            ListViewItem lvi = new ListViewItem();
                            lvi.Text = ei.Name;
                            lvi.Tag = ei.Name;
                            CFormControlesEventos.ListaEventos.Items.Add(lvi);
                        }

                        Outputs("Lista de eventos", tc.GetEvents());
                    }
                    #endregion
                }

                //END CODE PRCGUID: b13e1604-2b91-425d-9af7-336d95429aeb
			}

			/// #NAME#: #DESCRIPTION#
			public void f_a6099e20_957f_477e_9ff5_92c4fc54e87c()
			{
			//INI CODE PRCGUID: a6099e20-957f-477e-9ff5-92c4fc54e87c

                            ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                            ARQODE_UI.GestorControles.CFormControlesEventos CFormControlesEventos = new ARQODE_UI.GestorControles.CFormControlesEventos(vm);
                            if ((CFormControlesEventos.TV_Controles.SelectedNode != null) && (CFormControlesEventos.TV_Controles.SelectedNode.Nodes.Count == 0))
                            {
                                String view_name = CFormControlesEventos.TV_Controles.SelectedNode.Parent.FullPath.Replace("\\", ".").Replace(".json", "");
                                String view_file = Path.Combine(
                                    App_globals.AppDataSection(dPATH.VIEWS).FullName,
                                    CFormControlesEventos.TV_Controles.SelectedNode.Parent.FullPath);
                                if (File.Exists(view_file))
                                {
                                    JSonFile jView = new JSonFile(view_file);
                                    JToken JControl = jView.jActiveObj.SelectToken(String.Format("$.Controls[?(@.Guid == '{0}')]", CFormControlesEventos.TV_Controles.SelectedNode.Text));

                                    if (JControl != null)
                                    {
                                        JObject JEvents = new JObject();
                                        for (int i = 0; i < CFormControlesEventos.DG_EventosControl.RowCount; i++)
                                        {
                                            if ((CFormControlesEventos.DG_EventosControl[0, i].Value != null) && (CFormControlesEventos.DG_EventosControl[1, i].Value != null))
                                            {
                                                JProperty JEvent = new JProperty(CFormControlesEventos.DG_EventosControl[0, i].Value.ToString(),
                                                                          CFormControlesEventos.DG_EventosControl[1, i].Value.ToString());
                                                JEvents.Add(JEvent);
                                            }
                                        }

                                        if (JControl["Events"] != null)
                                        {
                                            JControl["Events"].Replace(JEvents);
                                        }
                                        else
                                        {
                                            JControl["Events"] = JEvents;
                                        }

                                        jView.Write();
                                    }
                                }


                            }


                            //END CODE PRCGUID: a6099e20-957f-477e-9ff5-92c4fc54e87c
			}

			/// #NAME#: #DESCRIPTION#
			public void f_e41d4e06_7f4e_4b3a_93b0_ba10de11f366()
			{
			//INI CODE PRCGUID: e41d4e06-7f4e-4b3a-93b0-ba10de11f366

                            ARQODE_UI.GestorControles.CFormControlesEventos CFormControlesEventos = new ARQODE_UI.GestorControles.CFormControlesEventos(vm);
                            CFormControlesEventos.FormControlesEventos.Text = "";


                            //END CODE PRCGUID: e41d4e06-7f4e-4b3a-93b0-ba10de11f366
			}

			/// #NAME#: #DESCRIPTION#
			public void f_035a40d6_72be_48aa_9aef_5305b5dc7976()
			{
			//INI CODE PRCGUID: 035a40d6-72be-48aa-9aef-5305b5dc7976

                            ARQODE_UI.GestorControles.CFormControlesEventos CFormControlesEventos = new ARQODE_UI.GestorControles.CFormControlesEventos(vm);
                            if (CFormControlesEventos.ListaEventos.SelectedItems.Count > 0)
                            {
                                String nombre_evento = CFormControlesEventos.ListaEventos.SelectedItems[0].Tag.ToString();
                                String nombre_programa = Clipboard.GetText();
                                if (nombre_programa != "")
                                {
                                    bool founded = false;
                                    foreach (DataGridViewRow drow in CFormControlesEventos.DG_EventosControl.Rows)
                                    {
                                        if ((drow.Cells[0].Value != null) && (drow.Cells[0].Value.ToString() == nombre_evento))
                                        {
                                            drow.Cells[1].Value = nombre_programa;
                                            founded = true;
                                        }
                                    }
                                    if (!founded)
                                    {
                                        CFormControlesEventos.DG_EventosControl.Rows.Add(new object[] { nombre_evento, nombre_programa });
                                    }
                                }
                            }



                            //END CODE PRCGUID: 035a40d6-72be-48aa-9aef-5305b5dc7976
			}

			/// #NAME#: #DESCRIPTION#
			public void f_3ef11a02_d7fa_400c_bb81_4339207679ae()
			{
			//INI CODE PRCGUID: 3ef11a02-d7fa-400c-bb81-4339207679ae


                #region Variables

                // Inputs vars
                object I_Lista_de_eventos = Input("Lista de eventos", false);
                #endregion
                if (I_Lista_de_eventos != null)
                {
                    ARQODE_UI.GestorControles.CFormControlesEventos CFormControlesEventos = new ARQODE_UI.GestorControles.CFormControlesEventos(vm);
                    CFormControlesEventos.ListaEventos.Clear();
                    foreach (EventInfo ei in (EventInfo[])I_Lista_de_eventos)
                    {
                        if (ei.Name.ToLower().Contains(CFormControlesEventos.toolStrip1.Items[0].Text))
                        {
                            ListViewItem lvi = new ListViewItem();
                            lvi.Text = ei.Name;
                            lvi.Tag = ei.Name;
                            CFormControlesEventos.ListaEventos.Items.Add(lvi);
                        }
                    }
                }


                //END CODE PRCGUID: 3ef11a02-d7fa-400c-bb81-4339207679ae
			}

	
    }
}
#endregion
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
			public void f_2200a384_ef11_461c_9c81_b62170f98566()
			{
			//INI CODE PRCGUID: 2200a384-ef11-461c-9c81-b62170f98566


                            #region Variables

                            // Inputs vars
                            object I_Datasource = Input("Datasource", false);
                            object I_Num_columna_con_path = Input("Num columna con path", false);

                            #endregion

                            if ((I_Datasource != null) && (I_Num_columna_con_path != null))
                            {
                                DataTable dt = (DataTable)I_Datasource;
                                int num_col_con_path = int.Parse(I_Num_columna_con_path.ToString());

                                ARQODE_UI.ARQODE_UI.CTablaB CTablaB = new ARQODE_UI.ARQODE_UI.CTablaB(vm);
                                if ((CTablaB.Tabla.DataSource == null) || (CTablaB.Tabla.DataSource is DataView) || (((DataTable)CTablaB.Tabla.DataSource).Columns.Count == 0))
                                {
                                    CTablaB.TablaB.Text = "Referencias encontradas";
                                    CTablaB.Tabla.Columns.Clear();
                                    int i = 0;
                                    foreach (DataColumn dc in dt.Columns)
                                    {
                                        if (i == num_col_con_path)
                                        {
                                            DataGridViewButtonColumn dgb = new DataGridViewButtonColumn();
                                            DataGridViewButtonCell dgb_cell = new DataGridViewButtonCell();
                                            dgb_cell.UseColumnTextForButtonValue = true;
                                            dgb.CellTemplate = dgb_cell;
                                            dgb.DataPropertyName = dc.ColumnName;
                                            dgb.HeaderText = "Ir";
                                            CTablaB.Tabla.Columns.Add(dgb);
                                        }
                                        else if (dc.ColumnName != "Guid")
                                        {
                                            DataGridViewTextBoxColumn dgt = new DataGridViewTextBoxColumn();
                                            dgt.HeaderText = dc.ColumnName;
                                            dgt.DataPropertyName = dc.ColumnName;
                                            dgt.ReadOnly = true;
                                            CTablaB.Tabla.Columns.Add(dgt);
                                        }
                                        i++;
                                    }

                                    CTablaB.Tabla.AutoGenerateColumns = false;
                                    CTablaB.Tabla.DataSource = dt;
                                    CTablaB.Tabla.Columns[num_col_con_path].Width = 30;
                                }
                                else if (((DataTable)CTablaB.Tabla.DataSource).Rows.Count == 0)
                    {
                                    foreach (DataRow dr in dt.Rows)
                                    {                            
                                        ((DataTable)CTablaB.Tabla.DataSource).Rows.Add(dr);
                                    }
                                }
                                CTablaB.TablaB.Show();
                            }

                            //END CODE PRCGUID: 2200a384-ef11-461c-9c81-b62170f98566
			}

			/// #NAME#: #DESCRIPTION#
			public void f_14c779c9_2388_4c4d_a894_c013247a69c1()
			{
			//INI CODE PRCGUID: 14c779c9-2388-4c4d-a894-c013247a69c1


                String goto_program_path = Config_str("Call ir a programa");
                String goto_process_path = Config_str("Call ir a proceso");

                ARQODE_UI.ARQODE_UI.CTablaB CTablaB = new ARQODE_UI.ARQODE_UI.CTablaB(vm);
                if ((args != null) && (args[0] is DataGridViewCellEventArgs))
                {
                    DataGridViewCellEventArgs cell_ev = (DataGridViewCellEventArgs)args[0];
                    DataView dv = (CTablaB.Tabla.DataSource is DataView) ? (DataView)CTablaB.Tabla.DataSource : new DataView((DataTable)CTablaB.Tabla.DataSource);
                    if (cell_ev.RowIndex >= 0)
                    {
                        String path = dv[cell_ev.RowIndex][cell_ev.ColumnIndex].ToString();
                        if (path.StartsWith(dPROGRAM.FOLDER))
                        {
                            Outputs("Namespace programa destino", path.Replace(dPROGRAM.FOLDER + ".", ""));
                            vm.CallProgram(event_desc, goto_program_path);

                        }
                        else
                        {
                            JObject JProc = new JObject();
                            JProc["Namespace"] = dv[cell_ev.RowIndex]["Ruta"].ToString().Replace(dPROCESS.FOLDER + ".", "");
                            JProc["Name"] = dv[cell_ev.RowIndex]["Proceso"].ToString();
                            JProc["Guid"] = dv[cell_ev.RowIndex]["Guid"].ToString();

                            Outputs("Proceso destino", JProc);
                            vm.CallProgram(event_desc, goto_process_path);
                        }
                    }
                }

                //END CODE PRCGUID: 14c779c9-2388-4c4d-a894-c013247a69c1
			}

			/// #NAME#: #DESCRIPTION#
			public void f_c98e6736_4ba4_4187_a79e_ae5ed0c6f64d()
			{
			//INI CODE PRCGUID: c98e6736-4ba4-4187-a79e-ae5ed0c6f64d

                            ARQODE_UI.ARQODE_UI.CTablaB CTablaB = new ARQODE_UI.ARQODE_UI.CTablaB(vm);


                            //END CODE PRCGUID: c98e6736-4ba4-4187-a79e-ae5ed0c6f64d
			}

			/// #NAME#: #DESCRIPTION#
			public void f_e00d514e_4d94_400d_829b_8b1ff531daa1()
			{
			//INI CODE PRCGUID: e00d514e-4d94-400d-829b-8b1ff531daa1


                            #region Variables

                            // Inputs vars
                            object I_Datasource = Input("Datasource", false);
                            object I_Num_columna_con_path = Input("Num columna con path", false);
                            #endregion
                            ARQODE_UI.ARQODE_UI.CTablaB CTablaB = new ARQODE_UI.ARQODE_UI.CTablaB(vm);
                            if ((I_Datasource != null) && (I_Num_columna_con_path != null) && (CTablaB.TextBox1.Text.Trim().Length > 0))
                            {
                                DataTable dt = (DataTable)I_Datasource;
                                int n_col = (int)I_Num_columna_con_path;
                                String texto = CTablaB.TextBox1.Text.Trim();
                                DataView dv = new DataView(dt);
                                String filtro = "";
                                String sep = "";
                                int i = 0;
                                foreach (DataColumn dc in dt.Columns)
                                {
                                    if (i != n_col)
                                    {
                                        if (dc.DataType == typeof(string))
                                        {
                                            filtro += sep + String.Format("{0} like '%{1}%'", dc.ColumnName, texto);
                                        }
                                        else
                                        {
                                            filtro += sep + String.Format("{0} = '{1}'", dc.ColumnName, texto);
                                        }
                                        sep = " or ";
                                    }
                                    i++;
                                }
                                dv.RowFilter = filtro;
                                CTablaB.Tabla.DataSource = dv;
                            }

                            //END CODE PRCGUID: e00d514e-4d94-400d-829b-8b1ff531daa1
			}

	
    }
}
#endregion
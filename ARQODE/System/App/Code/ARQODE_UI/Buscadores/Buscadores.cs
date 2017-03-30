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
			public void f_b6e71095_5f94_49c4_a330_9950b390d963()
			{
			//INI CODE PRCGUID: b6e71095-5f94-49c4-a330-9950b390d963

                            ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                            String cadBusqueda = CVentanaProgramas.MenuTop.Items[7].Text;

                            CStructModifications csmod = new CStructModifications(sys, App_globals);
                            List<KeyValuePair<JToken, int>> res = csmod.Find_all_in_programs(cadBusqueda);

                            DataTable dt = new DataTable();
                            dt.Columns.Add("Path");
                            dt.Columns.Add("Ruta");
                            dt.Columns.Add("Proceso");
                            dt.Columns.Add("Guid");
                            int max = 0;
                            foreach (KeyValuePair<JToken, int> s in res)
                            {
                                if (max == 0) max = s.Value;
                                if (s.Value > max - 2)
                                {
                                    String programa = s.Key["Program"].ToString();
                                    String proceso = s.Key["Process name"].ToString();
                                    String proc_guid = s.Key["Process guid"].ToString();

                                    String cad = programa.Replace(App_globals.AppDataSection(dPATH.CODE).FullName + "\\", "").Replace("\\", ".").Replace(".json", "");
                                    dt.Rows.Add(new object[] { cad, cad, proceso, proc_guid });
                                }
                                else
                                {
                                    break;
                                }
                            }

                            Outputs("Tabla resultados", dt);
                            Outputs("Num columna con path", 0);

                            //END CODE PRCGUID: b6e71095-5f94-49c4-a330-9950b390d963
			}

			/// #NAME#: #DESCRIPTION#
			public void f_61bb9810_2b5a_49d2_9a05_3705c8785181()
			{
			//INI CODE PRCGUID: 61bb9810-2b5a-49d2-9a05-3705c8785181

                            ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                            String cadBusqueda = CVentanaProgramas.MenuTop.Items[7].Text;

                            CStructModifications csmod = new CStructModifications(sys, App_globals);
                            List<KeyValuePair<JToken, int>> res = csmod.Find_all_in_processes(cadBusqueda);

                            DataTable dt = null;

                            object I_Datasource = Input("Tabla resultados anterior", false);
                            if (I_Datasource != null)
                            {
                                dt = (DataTable)I_Datasource;
                            }
                            else
                            {
                                dt = new DataTable();
                                dt.Columns.Add("Path");
                                dt.Columns.Add("Ruta");
                                dt.Columns.Add("Proceso");
                                dt.Columns.Add("Guid");
                            }

                            int max = 0;
                            foreach (KeyValuePair<JToken, int> s in res)
                            {
                                if (max == 0) max = s.Value;
                                if (s.Value > max - 2)
                                {
                                    String programa = s.Key["Process"].ToString();
                                    String proceso = s.Key["Process name"].ToString();
                                    String proc_guid = s.Key["Process guid"].ToString();
                                    String cad = programa.Replace(App_globals.AppDataSection(dPATH.CODE).FullName + "\\", "").Replace("\\", ".").Replace(".json", "");
                                    dt.Rows.Add(new object[] { cad, cad, proceso, proc_guid });
                                }
                                else
                                {
                                    break;
                                }
                            }

                            Outputs("Tabla resultados", dt);
                            Outputs("Num columna con path", 0);

                            //END CODE PRCGUID: 61bb9810-2b5a-49d2-9a05-3705c8785181
			}

	
    }
}
#endregion
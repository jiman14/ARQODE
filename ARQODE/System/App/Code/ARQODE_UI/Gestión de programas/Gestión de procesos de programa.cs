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
			public void f_781150d3_d1ed_4245_8fe9_9fe26a594e2f()
			{
			//INI CODE PRCGUID: 781150d3-d1ed-4245-8fe9-9fe26a594e2f

                            ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);

                            String nombre_programa = Clipboard.GetText();

                            if (nombre_programa != "")
                            {
                                // montamos el proceso destino:
                                JObject JNewProc_2_program = new JObject();
                                JNewProc_2_program.Add("Namespace", "System.Call");
                                JNewProc_2_program.Add("Guid", "Call");
                                JNewProc_2_program.Add("Name", "Call " + nombre_programa);
                                JNewProc_2_program.Add("Description", "");

                                JObject JConf = new JObject();
                                JConf.Add("program", nombre_programa);
                                JNewProc_2_program.Add("Configuration", JConf);


                                JObject JIn = new JObject();
                                JNewProc_2_program.Add("Inputs", JIn);

                                JObject JOut = new JObject();
                                JNewProc_2_program.Add("Outputs", JOut);

                                // obtienes el programa
                                String rutaPrograma = Path.Combine(
                                    App_globals.AppDataSection(dPATH.CODE).FullName,
                                    CVentanaProgramas.ArbolProgramas.SelectedNode.FullPath);

                                JSonFile jprograma = new JSonFile(rutaPrograma);
                                (jprograma.jActiveObj["Logic"] as JArray).Add(JNewProc_2_program);
                                jprograma.Write();

                            }


                            //END CODE PRCGUID: 781150d3-d1ed-4245-8fe9-9fe26a594e2f
			}

			/// #NAME#: #DESCRIPTION#
			public void f_ce9567d0_f165_45e0_844a_a2881290bfeb()
			{
			//INI CODE PRCGUID: ce9567d0-f165-45e0-844a-a2881290bfeb

                            ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                            CProgram currProg = new CProgram(sys, App_globals, CVentanaProgramas.Namespace_programa_activo.ToString());
                            ((JArray)currProg.Logic)[CVentanaProgramas.ListaProcesos.SelectedCells[0].RowIndex].Remove();
                            currProg.Save();


                            //END CODE PRCGUID: ce9567d0-f165-45e0-844a-a2881290bfeb
			}

			/// #NAME#: #DESCRIPTION#
			public void f_57c58cbe_c7d5_4437_b06c_85232bda9804()
			{
			//INI CODE PRCGUID: 57c58cbe-c7d5-4437-b06c-85232bda9804


                            ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                            if (CVentanaProgramas.ListaProcesos.SelectedCells[0].RowIndex > 0)
                            {
                                CProgram currProg = new CProgram(sys, App_globals, CVentanaProgramas.Namespace_programa_activo.ToString());
                                JToken proc_active = ((JArray)currProg.Logic)[CVentanaProgramas.ListaProcesos.SelectedCells[0].RowIndex];
                                ((JArray)currProg.Logic).Insert(CVentanaProgramas.ListaProcesos.SelectedCells[0].RowIndex - 1, proc_active);
                                proc_active.Remove();
                                currProg.Save();
                            }


                            //END CODE PRCGUID: 57c58cbe-c7d5-4437-b06c-85232bda9804
			}

			/// #NAME#: #DESCRIPTION#
			public void f_3343e203_c0a9_4a7c_9792_f3cb5411ff44()
			{
			//INI CODE PRCGUID: 3343e203-c0a9-4a7c-9792-f3cb5411ff44

                            ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                            if (CVentanaProgramas.ListaProcesos.SelectedCells[0].RowIndex < CVentanaProgramas.ListaProcesos.RowCount - 1)
                            {
                                int ri = CVentanaProgramas.ListaProcesos.SelectedCells[0].RowIndex;
                                CProgram currProg = new CProgram(sys, App_globals, CVentanaProgramas.Namespace_programa_activo.ToString());
                                JToken proc_active = ((JArray)currProg.Logic)[ri];
                                ((JArray)currProg.Logic).Insert(ri + 2, proc_active);
                                ((JArray)currProg.Logic)[ri].Remove();
                                currProg.Save();
                            }


                            //END CODE PRCGUID: 3343e203-c0a9-4a7c-9792-f3cb5411ff44
			}

	
    }
}
#endregion
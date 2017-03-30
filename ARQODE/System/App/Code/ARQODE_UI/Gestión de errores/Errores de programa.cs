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
			public void f_0fc207e4_213a_4321_a167_214072c7de6e()
			{
			//INI CODE PRCGUID: 0fc207e4-213a-4321-a167-214072c7de6e

                CSystem _system = null; 
                if (App_globals.ActiveAppName == dGLOBALS.SYSTEM_APP)
                {
                    _system = sys;
                }
                else if (Input("Aplicación activa") != null)
                {
                    _system = ((ACORE)Input("Aplicación activa"))._system;
                }
                if (_system != null)
                {

                    ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                    ARQODE_UI.ARQODE_UI.CVisorTexto CVisorTexto = new ARQODE_UI.ARQODE_UI.CVisorTexto(vm);
                    String trace_info =
                        String.Format("Estado global: " + _system.ProgramTracer.GlobalStatus.ToString()) + "\r\n" +
                        _system.ProgramTracer.Program_traces.ToString();
                    trace_info += (_system.ProgramErrors.hasErrors()) ? "\r\n\r\nErrores:\r\n\r\n" +
                        _system.ProgramErrors.getErrors().ToString() : "";
                    CVisorTexto.RB_Texto.Text = trace_info;
                    CVisorTexto.VisorTexto.Show();
                }
                            //END CODE PRCGUID: 0fc207e4-213a-4321-a167-214072c7de6e
			}

			/// #NAME#: #DESCRIPTION#
			public void f_20363399_d305_4e90_a478_dc16fb83fff6()
			{
			//INI CODE PRCGUID: 20363399-d305-4e90-a478-dc16fb83fff6

                            object Errores = Input("Errores reportados");
                            if (Errores != null)
                            {
                                ArrayList ar = (ArrayList)Errores;
                                ARQODE_UI.ARQODE_UI.CVisorTexto CVisorTexto = new ARQODE_UI.ARQODE_UI.CVisorTexto(vm);
                                CVisorTexto.VisorTexto.Text = "Chequeo de integridad de los procesos de programas";

                                if (ar.Count > 0)
                                {
                                    String s = "";
                                    foreach (String cad in ar)
                                    {
                                        s += cad + "\r\n";
                                    }
                                    CVisorTexto.RB_Texto.Text = s;
                                }
                                else
                                {
                                    CVisorTexto.RB_Texto.Text = "No se ha encontrado ningún error de integridad.";
                                }
                                CVisorTexto.VisorTexto.Show();
                            }


                            //END CODE PRCGUID: 20363399-d305-4e90-a478-dc16fb83fff6
			}

			/// #NAME#: #DESCRIPTION#
			public void f_8a4259e0_60da_4908_9394_0655c5bf876e()
			{
			//INI CODE PRCGUID: 8a4259e0-60da-4908-9394-0655c5bf876e
                CSystem _system = null;
                if (App_globals.ActiveAppName == dGLOBALS.SYSTEM_APP)
                {
                    _system = sys;
                }
                else if (Input("Aplicación activa") != null)
                {
                    _system = ((ACORE)Input("Aplicación activa"))._system;
                }
                if (_system != null)
                {
                    ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                    CVentanaProgramas.MenuTop.Items[2].BackColor = (sys.ProgramErrors.hasErrors()) ? System.Drawing.Color.Red :
                                                                                            System.Drawing.Color.FromName("Control");
                    CVentanaProgramas.MenuTop.Items[0].BackColor = (sys.errors.hasErrors()) ? System.Drawing.Color.Red :
                    System.Drawing.Color.FromName("Control");
                }
                            //END CODE PRCGUID: 8a4259e0-60da-4908-9394-0655c5bf876e
			}

			/// #NAME#: #DESCRIPTION#
			public void f_bd10b0ce_47e5_4466_8ab3_c842eec83295()
			{
			//INI CODE PRCGUID: bd10b0ce-47e5-4466-8ab3-c842eec83295

                            String program_path = Config_str("Cron program path");
                            String interval = Config_str("Cron interval");

                            ARQODE_UI.GestorProgramas.CVentanaProgramas VP = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                            if (VP.MenuTop.Items[14].BackColor == System.Drawing.Color.FromName("InactiveCaption"))
                            {
                                sys.Cron.addProgram(program_path, int.Parse(interval));
                                VP.MenuTop.Items[14].BackColor = System.Drawing.Color.FromName("Control");
                                VP.MenuTop.Items[14].Text = "No chequear errores";
                            }
                            else
                            {
                                sys.Cron.removeProgram(program_path);
                                VP.MenuTop.Items[14].BackColor = System.Drawing.Color.FromName("InactiveCaption");
                                VP.MenuTop.Items[14].Text = "Chequear errores";
                            }

                            //END CODE PRCGUID: bd10b0ce-47e5-4466-8ab3-c842eec83295
			}

	
    }
}
#endregion
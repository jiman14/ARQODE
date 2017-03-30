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
			public void f_caf36585_f6eb_4f3f_b0ec_fac689ce4eac()
			{
			//INI CODE PRCGUID: caf36585-f6eb-4f3f-b0ec-fac689ce4eac

                            #region Variables

                            // Configuration vars
                            String C_Buscar_en_todo = Config_str("Buscar en todo");
                            String C_Buscar_en_programas = Config_str("Buscar en programas");
                            String C_Buscar_en_procesos = Config_str("Buscar en procesos");
                            String C_Abrir_debug = Config_str("Abrir debug");
                            String C_Abrir_errores_de_programa = Config_str("Abrir errores de programa");
                            String C_Abrir_errores_UI = Config_str("Abrir errores UI");
                            String C_Activar_app = Config_str("Activar App");
                            String C_Chequear_IOC = Config_str("Chequear IOC");
                            String C_Chequear_Errores_Auto = Config_str("Auto chequear errores");
                            String C_Historico_Programas = Config_str("Histórico de programas");
                            String C_RunApp = Config_str("Run app");
                String C_Map_UI = Config_str("Map UI");
                #endregion
                ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);

                            // Buscar_en_todo
                            CVentanaProgramas.view.Set_event_handler(
                                CVentanaProgramas.MenuTop.Items[8],
                                CVentanaProgramas.MenuTop.Items[8].Name,
                                "Click",
                                C_Buscar_en_todo);
                            // Buscar_en_programas
                            CVentanaProgramas.view.Set_event_handler(
                                CVentanaProgramas.MenuTop.Items[9],
                                CVentanaProgramas.MenuTop.Items[9].Name,
                                "Click",
                                C_Buscar_en_programas);
                            // Buscar_en_procesos
                            CVentanaProgramas.view.Set_event_handler(
                                CVentanaProgramas.MenuTop.Items[10],
                                CVentanaProgramas.MenuTop.Items[10].Name,
                                "Click",
                                C_Buscar_en_procesos);
                            // Debug
                            CVentanaProgramas.view.Set_event_handler(
                                CVentanaProgramas.MenuTop.Items[4],
                                CVentanaProgramas.MenuTop.Items[4].Name,
                                "Click",
                                C_Abrir_debug);
                            // Abrir_errores_de_program
                            CVentanaProgramas.view.Set_event_handler(
                                CVentanaProgramas.MenuTop.Items[2],
                                CVentanaProgramas.MenuTop.Items[2].Name,
                                "Click",
                                C_Abrir_errores_de_programa);

                            // Abrir_errores_UI
                            CVentanaProgramas.view.Set_event_handler(
                                CVentanaProgramas.MenuTop.Items[0],
                                CVentanaProgramas.MenuTop.Items[0].Name,
                                "Click",
                                C_Abrir_errores_UI);

                            // Chequear_IOC
                            CVentanaProgramas.view.Set_event_handler(
                                CVentanaProgramas.MenuTop.Items[12],
                                CVentanaProgramas.MenuTop.Items[12].Name,
                                "Click",
                                C_Chequear_IOC);

                            // Chequear_Errores_Auto
                            CVentanaProgramas.view.Set_event_handler(
                                CVentanaProgramas.MenuTop.Items[14],
                                CVentanaProgramas.MenuTop.Items[14].Name,
                                "Click",
                                C_Chequear_Errores_Auto);

                            // Histórico de programas
                            CVentanaProgramas.view.Set_event_handler(
                                CVentanaProgramas.MenuTop.Items[16],
                                CVentanaProgramas.MenuTop.Items[16].Name,
                                "Click",
                                C_Historico_Programas);

                            // Run app
                            CVentanaProgramas.view.Set_event_handler(
                                CVentanaProgramas.MenuTop.Items[18],
                                CVentanaProgramas.MenuTop.Items[18].Name,
                                "Click",
                                C_RunApp);

                // Map UI
                CVentanaProgramas.view.Set_event_handler(
                    CVentanaProgramas.MenuTop.Items[20],
                    CVentanaProgramas.MenuTop.Items[20].Name,
                    "Click",
                    C_Map_UI);

                // App text box
                CVentanaProgramas.MenuTop.Items[5].Visible = false;
                            CVentanaProgramas.VentanaProgramas.Text += ": " + App_globals.ActiveAppName;

                            //END CODE PRCGUID: caf36585-f6eb-4f3f-b0ec-fac689ce4eac
			}

	
    }
}
#endregion
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
			public void f_7536ce3d_08b4_4489_84ea_5a48752c7a83()
			{
			//INI CODE PRCGUID: 7536ce3d-08b4-4489-84ea-5a48752c7a83

                            ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);

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
                    if (_system.errors.hasErrors())
                    {
                        ARQODE_UI.ARQODE_UI.CVisorTexto CVisorTexto = new ARQODE_UI.ARQODE_UI.CVisorTexto(vm);
                        CVisorTexto.RB_Texto.Text =
                            _system.errors.getErrors().ToString();
                        CVisorTexto.VisorTexto.Show();
                    }
                    else
                    {
                        MessageBox.Show("No hay errores en la UI");
                    }
                }
                            //END CODE PRCGUID: 7536ce3d-08b4-4489-84ea-5a48752c7a83
			}

	
    }
}
#endregion
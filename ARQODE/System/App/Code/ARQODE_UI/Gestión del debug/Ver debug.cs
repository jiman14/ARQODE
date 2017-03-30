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
			public void f_6c018c5b_070d_41ec_ade6_a3a0100b02c1()
			{
			//INI CODE PRCGUID: 6c018c5b-070d-41ec-ade6-a3a0100b02c1

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
                    CVisorTexto.RB_Texto.Text = _system.debug.getDebug().ToString();
                    CVisorTexto.VisorTexto.Show();
                }
                            //END CODE PRCGUID: 6c018c5b-070d-41ec-ade6-a3a0100b02c1
			}

	
    }
}
#endregion
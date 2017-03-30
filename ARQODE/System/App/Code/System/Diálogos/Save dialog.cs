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
			public void f_13308de3_1318_435b_80bc_b614d76cad4b()
			{
			//INI CODE PRCGUID: 13308de3-1318-435b-80bc-b614d76cad4b
				
				String C_Filtros = Config_str("Filtros");
                ARQODE_UI.GestorProgramas.CVentanaProgramas CVentanaProgramas = new ARQODE_UI.GestorProgramas.CVentanaProgramas(vm);
                String ns_programa = CVentanaProgramas.Namespace_programa_activo.ToString();

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = C_Filtros;
                sfd.FileName = ns_programa;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Outputs("Fichero seleccionado", sfd.FileName);
                }
                else { Outputs("Fichero seleccionado", ""); }


                //END CODE PRCGUID: 13308de3-1318-435b-80bc-b614d76cad4b
			}

	
    }
}
#endregion
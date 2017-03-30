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
			public void f_c07b0b72_8ada_4945_91c4_0c49a542736f()
			{
			//INI CODE PRCGUID: c07b0b72-8ada-4945-91c4-0c49a542736f

                ACORE NewApp = new ACORE(App_globals.App_path.FullName);
                if (NewApp.MainForm != null)
                            {
                                NewApp.MainForm.Show();
                                Outputs("Aplicación activa", NewApp);
                            }
                            else
                            {
                                Outputs("Aplicación activa", null);
                                MessageBox.Show("Error al cargar la aplicación chequea los programas que se ejecuten al cargar el formulario principal.");
                            }
                            // Outputs vars




                            //END CODE PRCGUID: c07b0b72-8ada-4945-91c4-0c49a542736f
			}

	
    }
}
#endregion
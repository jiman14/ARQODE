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
			public void f_Abrir_ventana_principal()
			{
			//INI CODE PRCGUID: Abrir ventana principal

                            String ventana = (Config_str_nullable("-ventana") != "") ? Config_str("-ventana") : Input_str("-ventana");

                            CView cventana = vm.getFirstView(ventana);

                            if (cventana != null)
                            {
                                try
                                {
                                    cventana.mainControl().Show();
                                }
                                catch (Exception exc)
                                {
                                    errors.warning = exc.Message;
                                    vm.freeView(cventana.Name);

                                    cventana = vm.AddView(ventana);
                                    cventana.mainControl().Show();
                                }
                            }
                            else
                            {
                                cventana = vm.AddView(ventana);
                                cventana.mainControl().Show();
                            }
                            //END CODE PRCGUID: Abrir ventana principal
			}

			/// #NAME#: #DESCRIPTION#
			public void f_722de0b2_e5e6_4f0e_b3b8_96b29a923049()
			{
			//INI CODE PRCGUID: 722de0b2-e5e6-4f0e-b3b8-96b29a923049


                            #region Variables

                            // Inputs vars
                            object I_Texto = Input("Texto", false);
                            #endregion


                            ARQODE_UI.ARQODE_UI.CVisorTexto CVisorTexto = new ARQODE_UI.ARQODE_UI.CVisorTexto(vm);
                            CVisorTexto.RB_Texto.Text = (I_Texto != null) ? I_Texto.ToString() : "";
                            //(CVisorTexto.Texto != null) ? CVentanaTexto.Texto.ToString() : "";



                            //END CODE PRCGUID: 722de0b2-e5e6-4f0e-b3b8-96b29a923049
			}

			/// #NAME#: #DESCRIPTION#
			public void f_c1cefd6f_b8ee_4ad4_8f85_a108120db648()
			{
			//INI CODE PRCGUID: c1cefd6f-b8ee-4ad4-8f85-a108120db648

                ARQODE_VISUAL_EDITOR.MapUI Mapui = new ARQODE_VISUAL_EDITOR.MapUI(App_globals.AppDataSection(dPATH.VIEWS).FullName);
                Mapui.Show();

                //END CODE PRCGUID: c1cefd6f-b8ee-4ad4-8f85-a108120db648
			}

	
    }
}
#endregion
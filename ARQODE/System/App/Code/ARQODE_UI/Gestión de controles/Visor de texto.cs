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
			public void f_4e818c04_a133_4820_805b_bf8c4ef66764()
			{
			//INI CODE PRCGUID: 4e818c04-a133-4820-805b-bf8c4ef66764

                            ARQODE_UI.ARQODE_UI.CVisorTexto CVisorTexto = new ARQODE_UI.ARQODE_UI.CVisorTexto(vm);
                            String FindText = CVisorTexto.TB_Busqueda.Text;
                            bool MatchCase = CVisorTexto.CH_CaseSensitive.Checked;
                            bool WholeWord = CVisorTexto.CH_Palabra.Checked;

                            CVisorTexto.RB_Texto.HideSelection = false;
                            CVisorTexto.RB_Texto.AutoWordSelection = false;
                            CVisorTexto.RB_Texto.SelectionProtected = true;
                            int start_index = 0;
                            int finded_pos = -1;

                            do
                            {
                                if (MatchCase == true)
                                {
                                    if (WholeWord == true)
                                    {
                                        finded_pos = CVisorTexto.RB_Texto.Find(FindText, start_index, RichTextBoxFinds.MatchCase | RichTextBoxFinds.WholeWord);
                                    }
                                    else
                                    {
                                        finded_pos = CVisorTexto.RB_Texto.Find(FindText, start_index, RichTextBoxFinds.MatchCase);
                                    }
                                }
                                else
                                {
                                    if (WholeWord == true)
                                    {
                                        finded_pos = CVisorTexto.RB_Texto.Find(FindText, start_index, RichTextBoxFinds.WholeWord);
                                    }
                                    else
                                    {
                                        finded_pos = CVisorTexto.RB_Texto.Find(FindText, start_index, RichTextBoxFinds.None);
                                    }
                                }
                                CVisorTexto.RB_Texto.SelectionBackColor = System.Drawing.Color.Orange;

                                start_index = finded_pos + CVisorTexto.RB_Texto.SelectionLength;
                            } while (finded_pos > 0);

                            // Aquí es donde esta condición no se cumple  y me manda el mensaje                    
                            if (CVisorTexto.RB_Texto.SelectionLength == 0)
                            {
                                MessageBox.Show("No se encuentra el texto: " + FindText);

                            }

                            //END CODE PRCGUID: 4e818c04-a133-4820-805b-bf8c4ef66764
			}

	
    }
}
#endregion
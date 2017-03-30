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
			public void f_439a02f9_bfb8_467a_8443_6607ca19b912()
			{
			//INI CODE PRCGUID: 439a02f9-bfb8-467a-8443-6607ca19b912
								
				String I_Fichero_importaciones = Input_str("Fichero importaciones");

                            Ionic.Zip.ZipFile zf = new Ionic.Zip.ZipFile(I_Fichero_importaciones);
                JToken ImportConvs = null;
                foreach (Ionic.Zip.ZipEntry ze in zf.Entries)
                {
                    #region get import convs data
                    if (ze.FileName.Contains("ImportConvs.json"))
                    {
                        MemoryStream ms = new MemoryStream();
                        ze.Extract(ms);
                        byte[] entry_data = ms.ToArray();                        
                        String file_content = System.Text.Encoding.Default.GetString(entry_data);
                        ms.Close();
                        ImportConvs = JArray.Parse(file_content);
                    }
                    #endregion
                    #region Extract progrmas & processes
                    else
                    {
                        ze.Extract(App_globals.AppDataSection(dPATH.CODE).FullName);
                    }
                    #endregion
                }

                #region Update imported programs namespaces

                if (ImportConvs != null)
                {
                    CStructModifications csmod = new CStructModifications(sys, App_globals);
                    foreach (JObject jImp in ImportConvs as JArray)
                    {
                        JProperty jprop = (JProperty) jImp.First;
                        csmod.MoveProgram(jprop.Name, 
                            jprop.Value.ToString()
                                .Replace("\\", ".")
                                .Replace(dPROGRAM.FOLDER + ".", ""));
                    }
                }
                MessageBox.Show("Program imported successfully");

                #endregion                

                //END CODE PRCGUID: 439a02f9-bfb8-467a-8443-6607ca19b912
			}

	
    }
}
#endregion
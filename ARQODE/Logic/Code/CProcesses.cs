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
    partial class CLogic
    {

        /// <summary>
        /// Run single process
        /// </summary>
        /// <param name="process_guid"></param>
        private bool execute_process(String process_guid)
        {
            bool process_not_found = false;
            try
            {
                switch (process_guid)
                {
                    					case "Call":
{
//INI CODE PRCGUID: Call

                            // Get program from config (first) or input
                            String Program = (Config_str("program") == "") ? Input_str("program") : Config_str("program");
                            if (Program != "") vm.CallProgram(event_desc, Program);

                            //END CODE PRCGUID: Call
					}
break;
					case "Cron add program":
{
//INI CODE PRCGUID: Cron add program

String Program = Config_str("program");
int Interval = Config_int("interval");
sys.Cron.addProgram(Program, Interval);

//END CODE PRCGUID: Cron add program       
					}
break;
					case "Cron remove program":
{
//INI CODE PRCGUID: Cron remove program

String Program = Config_str("program");
sys.Cron.removeProgram(Program);

//END CODE PRCGUID: Cron remove program
					}
break;
					case "SetVar":
{
//INI CODE PRCGUID: SetVar

                            if (Config_nullable("-value").ToString() != "") Outputs("variable", Config("-value"));
                            else Outputs("variable", Input("-value"));

                            //END CODE PRCGUID: SetVar
					}
break;
					case "d7c66f82-4473-4e8c-b556-0f6c6509782e":
{
//INI CODE PRCGUID: d7c66f82-4473-4e8c-b556-0f6c6509782e

                            // Configuration vars
                            String C_Filtros = Config_str("Filtros");

                            OpenFileDialog fd = new OpenFileDialog();
                            fd.Filter = C_Filtros;

                            if (fd.ShowDialog() == DialogResult.OK)
                            {
                                Outputs("Fichero seleccionado", fd.FileName);
                            }
                            else
                            {
                                Outputs("Fichero seleccionado", "");
                            }

                            //END CODE PRCGUID: d7c66f82-4473-4e8c-b556-0f6c6509782e
					}
break;
					case "13308de3-1318-435b-80bc-b614d76cad4b":
{
//INI CODE PRCGUID: 13308de3-1318-435b-80bc-b614d76cad4b


                            #region Variables

                            SaveFileDialog sfd = new SaveFileDialog();
                            sfd.FileName = Config_str("Nombre predeterminado");
                            sfd.Filter = Config_str("Filtros");
                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                Outputs("Fichero seleccionado", sfd.FileName);
                            }
                            else
                            {
                                Outputs("Fichero seleccionado", "");
                            }
                            #endregion

                            //END CODE PRCGUID: 13308de3-1318-435b-80bc-b614d76cad4b
					}
break;
 //END LOGIC

                    default:

                        process_not_found = true;
                        break;
                }
            }
            catch (Exception exc)
            {
                prc_error = true;
                sys.ProgramTracer.AddError(exc.Message);

                errors.unhandledError = String.Format("Error in '{0}->{1}': {2}", event_desc.Program, (prc.Name != null) ? prc.Name.ToString() : prc.Guid, exc.Message);
            }
            return process_not_found;
        }
    }
}
#endregion
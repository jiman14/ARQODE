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
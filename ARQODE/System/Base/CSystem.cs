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
using TLogic;

namespace ARQODE_Core
{
    public class CSystem
    {
        public CGlobals App_globals;
        public CGlobals Globals;
        public CErrors errors;
        public CDebug debug;
        public TTracer ProgramTracer;
        public TErrors ProgramErrors;
        public TDebug ProgramDebug;
        public CCron Cron;
        private bool system_errors;

        /// <summary>
        /// Get global vars. And initialize basic error and debug objects
        /// </summary>
        public CSystem(String app_path)
        {
            // Load system globals vars            
            if (app_path == "")
            {
                Globals = new CGlobals();
                // Load app globals vars
                App_globals = new CGlobals(Globals.get_str(dGLOBALS.ACTIVE_APP));
            }
            else
            {
                Globals = new CGlobals(app_path);
            }

            system_errors = false;
            if (Globals.Errors != "")
            {
                Console.WriteLine("Error in Globals file: " + Globals.Errors);
                system_errors = true;
            }
            else
            {
                // Program tracer
                ProgramTracer = new TTracer(Globals);

                // views errors & debug
                errors = new CErrors(Globals);
                debug = new CDebug(Globals);

                // Init Cron
                Cron = new CCron(Globals, errors, debug);
            }
        }

        /// <summary>
        ///  Close all
        /// </summary>
        internal void CloseAll()
        {
            Cron.StopAll();
            ProgramTracer.Write();
        }

        /// <summary>
        /// Get if system errors;
        /// </summary>
        /// <returns></returns>
        public bool hasErrors()
        {
            return system_errors;
        }

        /// <summary>
        /// Reset UI Errors
        /// </summary>
        public void reset_UI_errors()
        {
            errors.reset_UI_errors();
        }

        /// <summary>
        /// Force active program break
        /// </summary>
        public void ForceExit()
        {
            ProgramErrors.forceExitProgram = true;
        }

    }
}
#endregion
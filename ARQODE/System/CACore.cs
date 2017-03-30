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
using System.Windows.Forms;
using TControls;
using TLogic;


namespace ARQODE_Core
{
    public class ACORE
    {
        #region constructor

        public CSystem _system;
        CViewsManager ViewsManager;
        CRunner Runner;
        
        /// <summary>
        /// ARQODE_Core Load application (System app by default)
        /// </summary>
        public ACORE(string app_path= "")
        {
            Initialize_ARQODE_Core(app_path);

            if ((!_system.hasErrors()) && (!ErrorsLoadingViews))
            {
                // Update views if changes
                if (_system.Globals.ActiveAppName == dGLOBALS.SYSTEM_APP)
                {
                    string Arqode_app_path = _system.Globals.ARQODE_APP;
                    string Sys_app_path = _system.Globals.App_path.FullName;
                    string ActiveApp = _system.Globals.ActiveAppName;
                    string App_path = _system.Globals.App_path.FullName;

                    // get map vars code
                    CMap cmap = new CMap(Sys_app_path, App_path, Arqode_app_path, ActiveApp);

                    // Map changes in views 
                    cmap.MapViews();
                }
                MainForm.FormClosed += MainForm_FormClosed;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _system.CloseAll();
        }

        #endregion

        #region public ARQODE_Core properties

        /// <summary>
        /// Return Main form for Run
        /// </summary>
        public Form MainForm
        {
            get { return ViewsManager.getMainForm(); }
        }
               
        #endregion

        #region Manage ARQODE_Core

        /// <summary>
        /// Initialize core system
        /// </summary>
        /// <param name="App_path"></param>
        private void Initialize_ARQODE_Core(string app_path)
        {
            // Init UI
            _system = new CSystem(app_path);
            if (!_system.hasErrors())
            {
                _system.Cron.runProgram += Vm_runProgram;

                // Init views manager & load UI
                ViewsManager = new CViewsManager(_system);

                ViewsManager.runProgram += Vm_runProgram;

                // Init program runner
                Runner = new CRunner(_system, ViewsManager);
            }
        }

        /// <summary>
        /// Return errors
        /// </summary>
        private bool ErrorsLoadingViews
        {
            get { return ViewsManager.hasErrors(); }
        }

        #endregion

        #region Run programas from events

        /// <summary>
        /// Launch program from event
        /// </summary>
        /// <param name="event_desc"></param>
        private void Vm_runProgram(CEventDesc event_desc, object program_vars)
        {
            if (event_desc.Program != "")
            {
                program_vars = Runner.LaunchProgram(event_desc, program_vars);
            }
            // Run programs in queue
            while (Runner.Programs_in_queue)
            {
                program_vars = Runner.LaunchProgramInQueue(program_vars);
            }

            _system.reset_UI_errors();
        }
        #endregion
    }
}
#endregion
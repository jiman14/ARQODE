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
        #region Variables

        CSystem sys;                    // System class mainly contains errors & debugs behind objects
        TErrors errors;                 // Program error object
        TDebug debug;                   // Debug object
        CViewsManager vm;               // View manager for access all views and controls
        CView MainView;                 // Main view       
        CGlobals Globals;               // Global vars from Main form view
        TProcess prc;                   // Running process info
        CView view;                     // View from where launched the event
        CEventDesc event_desc;          // Event description struct
        Control mainCtrl;               // Main Form or User control in the view that launch the event
        Control fireCtrl;               // Control who fire the event
        object[] args;                  // Control event args 

        CView.CtrlStruct fireCtrl_str; // Controls struct who fire the event    
        #endregion

        #region initialize

        /// <summary>
        /// Load all information from UI to work with
        /// </summary>
        /// <param name="viewManager"></param>
        /// <param name="eventDesc"></param>
        public CLogic(CSystem csystem, CViewsManager views_manager, CEventDesc eventDesc)
        {
            sys = csystem;
            vm = views_manager;
            Globals = sys.Globals;
            errors = sys.ProgramErrors;
            debug = sys.ProgramDebug;
            event_desc = eventDesc;
            if (event_desc != null)
            {
                view = (event_desc.View_Guid != "") ? vm.getFirstView_byGuid(event_desc.View_Guid) : null;
                if (view != null)
                {
                    mainCtrl = view.mainControl();
                    fireCtrl_str = view.getCtrlStruct(eventDesc.Control_Name);
                }
                fireCtrl = (Control)event_desc.fireCtrl;
                args = event_desc.args;
            }
            MainView = ((view != null) && (Globals.get_str(dGLOBALS.MAIN_VIEW) == view.Name)) ? view : vm.getFirstView(Globals.get_str(dGLOBALS.MAIN_VIEW));
        }
        #endregion

        #region Run process

        /// <summary>
        /// Prepare for execute process
        /// </summary>
        /// <param name="prc"></param>
        /// <returns></returns>
        public void Run(TProcess proc)
        {
            prc = proc;

            // Check inputs first
            if (CDataIntegrity.CheckAllVariables(prc, ref errors))
            {
                // init timer
                DateTime prcInitTime = DateTime.Now;

                // Execute process
                debug.cprint(String.Format("Running process: '{0}', from program {1} and view {2}",
                    (prc.Name != null) ? prc.Name.ToString() : prc.Guid, event_desc.Program, event_desc.View_Name));

                try
                {
                    Type t = this.GetType();
                    MethodInfo mi = t.GetMethod("f_" + TLogic.Utils.escape_sc(prc.Guid));
                    mi.Invoke(this, null);
                }
                catch (Exception exc)
                {
                    errors.unhandledError = exc.Message;
                }

                // set process time
                prc.Total_time = Math.Round((DateTime.Now - prcInitTime).TotalSeconds, 2);

            }
        }

        #endregion

    }
}
#endregion
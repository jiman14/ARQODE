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

* You should have received a copy of the GNU General Public Licens3e
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
using Ionic.Zip;
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
        bool prc_error;                 // Process error flag

        CView.CtrlStruct fireCtrl_str; // Controls struct who fire the event

        #endregion

        /// <summary>
        /// Edit yor process code here
        /// </summary>
        public void Edit_code()
        {
            debug.Status = "Editing process " + prc.Name + " (" + prc.Guid + ")";

            try
            {
                #region BEGIN_CODE
                #endregion END_CODE 

                prc_error = false;
            }
            catch (Exception exc)
            {
                prc_error = true;
                debug.processError = exc.Message;
            }
        }
    }
}
#endregion
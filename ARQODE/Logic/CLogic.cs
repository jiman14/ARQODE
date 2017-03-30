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
        #region initialize

        CGlobals App_globals;

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
            App_globals = sys.App_globals;
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
            prc_error = false;
            prc = proc;

            // Check inputs first
            if (CDataIntegrity.CheckAllVariables(prc, ref errors))
            {
                if ((Globals.is_system) && (!App_globals.is_system)) 
                {
                    try
                    {   
                        Type t = this.GetType();
                        MethodInfo mi = t.GetMethod("f_" + escape_sc(prc.Guid));
                        mi.Invoke(this, null);
                    }
                    catch (Exception exc)
                    {
                        errors.unhandledError = exc.Message;
                    }
                }
                else
                {
                    // init timer
                    DateTime prcInitTime = DateTime.Now;

                    // Execute process
                    debug.cprint(String.Format("Running process: '{0}', from program {1} and view {2}",
                        (prc.Name != null) ? prc.Name.ToString() : prc.Guid, event_desc.Program, event_desc.View_Name));

                    if (prc.Edit_code == "1")
                    {
                        SendToEditor();
                    }
                    else
                    {
                        if (execute_process(prc.Guid))
                        {
                            //si no se encuentra el proceso enviar a código la ejecución
                            SendToEditor();
                        }
                    }

                    // set process time
                    prc.Total_time = Math.Round((DateTime.Now - prcInitTime).TotalSeconds, 2);

                    if (prc_error)
                    {
                        // if error send process to editor
                        SendToEditor();                        
                    }
                }
            }
        }

        /// <summary>
        /// Send to editor
        /// </summary>
        private void SendToEditor()
        {
            CLogicEditor.SendCodeToEditor(Globals.App_path.FullName, Globals.ActiveAppName, prc.Guid, prc);
            bool there_was_error = prc_error;
            Edit_code();
            
            if (!prc_error)
            {
                if ((there_was_error) && (!prc_error))
                    errors.fixErrors();
                String prc_guid = "";
                String prc_code = CLogicEditor.get_Code_from_editor(Globals.ARQODE_APP, ref prc_guid);
                prc.Code = Convert.ToBase64String(System.Text.UTF8Encoding.UTF8.GetBytes(prc_code));

                //CLogicEditor.SaveCode(Globals.ARQODE_APP);
            }           
        }

        #endregion

        #region Util      

        /// <summary>
        /// Escapar carácteres especiales
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        private String escape_sc(String cadena)
        {

            String escape_chars = "á,é,í,ó,ú,Á,É,Í,Ó,Ú, ,ñ,Ñ,ü,Ü,-,(,),-,.";
            String replace_escape_chars = "a,e,i,o,u,A,E,I,O,U,_,n,N,u,U,_,_,_,_,_";
            String[] rec_array = replace_escape_chars.Split(',');
            int i = 0;
            foreach (String spc in escape_chars.Split(','))
            {
                cadena = cadena.Replace(spc, rec_array[i]);
                i++;
            }
            return cadena;
        }
        #endregion
    }
}
#endregion
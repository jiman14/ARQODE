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
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

using ARQODE_Core;

namespace TControls
{
    public class CViewsManager
    {
        #region Variables and events

        CSystem cs;
        CGlobals globals;
        List<CView> listViews;
        Lookup<String, CView> views_byName;
        Lookup<String, CView> views_byGuid;
        CErrors errors;
        CDebug debug;

        bool cancel_event_propagation = false;

        public delegate void program_controller(CEventDesc event_desc, object program_vars);
        public event program_controller runProgram;
        #endregion

        #region Views manager

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="base_errors"></param>
        /// <param name="base_debug"></param>
        /// <param name="MainView"></param>
        public CViewsManager(CSystem csystem)
        {            
            cs = csystem;
            globals = csystem.Globals;
            errors = csystem.errors;
            debug = csystem.debug;

            listViews = new List<CView>();

            String MainView_name = Globals.get(dGLOBALS.MAIN_VIEW).ToString();
            if (MainView_name != "") AddView(MainView_name);
        }

        /// <summary>
        /// Add view
        /// </summary>
        /// <param name="main_control"></param>
        /// <returns></returns>
        public CView AddView(String main_control)
        {
            debug.add("Add view: " + main_control);

            // Init view
            CView view = new CView(cs, main_control);
            if (!errors.hasErrors())
            {
                view.on_any_event += Ctrl_on_any_event;
                listViews.Add(view);
                views_byName = (Lookup<String, CView>)listViews.ToLookup(p => p.Name, p => p);
                views_byGuid = (Lookup<String, CView>)listViews.ToLookup(p => p.guid, p => p);
                return view;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Remove view by name
        /// </summary>
        /// <param name="view_name"></param>
        public void removeViews(String view_name)
        {
            debug.add("Remove view: " + view_name);
            IEnumerable<CView> views = views_byName[view_name];            
            while (views.Count() > 0)
            {
                CView view = views.First();
                view.Free();
                listViews.Remove(view);
                views_byName = (Lookup<String, CView>)listViews.ToLookup(p => p.Name, p => p);
                views_byGuid = (Lookup<String, CView>)listViews.ToLookup(p => p.guid, p => p);
                views = views_byName[view_name];
            }
            
        }
        /// <summary>
        /// Remove view by name
        /// </summary>
        /// <param name="view_name"></param>
        public void removeViews_byGuid(String view_guid)
        {
            debug.add("Remove view: " + view_guid);
            IEnumerable<CView> views = views_byGuid[view_guid];
            if (views.Count() > 0)
            {
                CView view = views.First();
                view.Free();
                listViews.Remove(view);
                views_byName = (Lookup<String, CView>)listViews.ToLookup(p => p.Name, p => p);
                views_byGuid = (Lookup<String, CView>)listViews.ToLookup(p => p.guid, p => p);
            }
        }
        /// <summary>
        /// Free all views
        /// </summary>
        public void freeViews()
        {
            while (views_byGuid.Count > 0)
            {
                removeViews_byGuid(views_byGuid.Last().Key);
            }
        }

        /// <summary>
        /// Free all views
        /// </summary>
        public void freeView(String view_name)
        {
            removeViews(view_name);            
        }
        /// <summary>
        /// Free all views
        /// </summary>
        public void freeView(CView view)
        {
            removeViews_byGuid(view.guid);
        }
        #endregion

        #region public properties

        /// <summary>
        /// Globals vars object
        /// </summary>
        public CGlobals Globals
        {
            get { return globals; }
        }

        /// <summary>
        /// get single view by name
        /// </summary>
        /// <param name="view_name"></param>
        /// <returns></returns>
        public CView getFirstView(String view_name)
        {
            if ((views_byName != null) && (views_byName.Contains(view_name)))
            {
                CView vtemp = views_byName[view_name].First();
                if (vtemp.Activa) {
                    return vtemp;
                }
                else
                {
                    removeViews(view_name);
                    return null;
                }

            }
            else return null;
        }

        /// <summary>
        /// Get all views by name
        /// </summary>
        /// <param name="view_name"></param>
        /// <returns></returns>
        public List<CView> getViews(String view_name)
        {
            if (view_name == "") return listViews;
            if (views_byName.Contains(view_name))
                return views_byName[view_name].ToList();
            else return new List<CView>();
        }

        /// <summary>
        /// get single view by name
        /// </summary>
        /// <param name="view_name"></param>
        /// <returns></returns>
        public CView getFirstView_byGuid(String view_guid)
        {
            if (views_byGuid.Contains(view_guid))
            {
                CView vtemp = views_byGuid[view_guid].First();
                return (vtemp.Activa) ? vtemp : null;
            }                
            else return null;
        }
        /// <summary>
        /// Return main view Form
        /// </summary>
        /// <param name="view_name"></param>
        /// <returns></returns>
        public Control mainViewControl(String view_name)
        {
            CView vtemp = getFirstView(view_name);
            return (vtemp != null)? vtemp.mainControl(): null; 
        }
        /// <summary>
        /// Return main form view
        /// </summary>
        /// <returns></returns>
        public CView getMainView()
        {
            return getFirstView(Globals.get(dGLOBALS.MAIN_VIEW).ToString());
        }        

        /// <summary>
        /// Get main form
        /// </summary>
        /// <returns></returns>
        public Form getMainForm()
        {
            return (getMainView() != null) ? (Form)getMainView().mainControl(): null;
        }

        public bool hasErrors()
        {
            return errors.hasErrors();
        }

        public bool Cancel_events
        {
            get { return cancel_event_propagation; }
            set { cancel_event_propagation = value; }
        }
        #endregion

        #region Event handling

        /// <summary>
        /// Direct program call
        /// </summary>
        /// <param name="eDesc"></param>
        /// <param name="Program"></param>
        public void CallProgram(CEventDesc eDesc, String Program, object program_vars = null)
        {
            CEventDesc desc = null;
            if (getFirstView_byGuid(eDesc.View_Guid) != null)
            {
                desc = new CEventDesc(eDesc.View_Guid, eDesc.View_Name, eDesc.Control_Name, "PROGRAM_CALL", Program);
            }
            else
            {                
                desc = new CEventDesc(getMainView().guid, getMainView().Name, "", "PROGRAM_CALL", Program);
            }

            if (runProgram != null) 
            {
                debug.add(string.Format("Call program event fired '{0}', program launched '{1}'. From view '{2}' => control '{3}'",
                    desc.Event_Name, desc.Program, desc.View_Name, desc.Control_Name));

                runProgram(desc, program_vars);                
            }           
        }
        /// <summary>
        /// Generic event handler 
        /// </summary>
        /// <param name="desc"></param>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void Ctrl_on_any_event(CView.CctrlEventDesc desc, object sender, object [] args)
        {
            if ((runProgram != null) && (!cancel_event_propagation))
            {
                debug.add(string.Format("Event fired '{0}', program launched '{1}'. From view '{2}' => control '{3}'",
                   desc.Event_Name, desc.Program, desc.View_Name, desc.Control_Name));
                desc.setEventArgs(sender as Control, args);

                runProgram(desc, null);
            }
            else
            {
                debug.add(string.Format("Inside program event fired '{0}', but not executed. From view '{1}' => control '{2}'",
                   desc.Event_Name, desc.View_Name, desc.Control_Name));
            }
        }
        #endregion
    }
}
#endregion
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
using System.IO;
using Newtonsoft.Json.Linq;
using JSonUtil;
using System.Reflection;
using System.Xml;

namespace ARQODE_Core
{
    public class CGlobals
    {
        #region constructor

        public String ARQODE_APP;

        private JSonFile pInfo;
        private JToken globals;
        private String active_app_name;
        DirectoryInfo dArqode_app;              // Arqode path
        DirectoryInfo dApp_path;                // Active app folder
        DirectoryInfo dData_path;                // Active app data folder
        DirectoryInfo dAppData_path;            // Active app appdata folder
        DirectoryInfo dResources_path;          // Active app resources folder
        DirectoryInfo dAssemblies_path;         // Active app data assemblies       
        
        String errors = "";
        private bool _debug = false;
        public bool debug
        {
            get { return _debug; }
        }
        public bool is_system
        {
            get { return active_app_name == dGLOBALS.SYSTEM_APP; }
        }


        /// <summary>
        /// Load Globals vars
        /// </summary>
        /// <param name="GLOBALS"></param>
        public CGlobals(String app_path = "")
        {
            ARQODE_APP = Assembly.GetExecutingAssembly().Location;

            DirectoryInfo dArqode_Manager = new DirectoryInfo(ARQODE_APP).Parent;
            while ((dArqode_Manager != null) && (dArqode_Manager.GetDirectories(dGLOBALS.ARQODE).Length == 0))
            {
                dArqode_Manager = dArqode_Manager.Parent;
            }
            ARQODE_APP = dArqode_Manager.GetDirectories(dGLOBALS.ARQODE)[0].FullName;

            dArqode_app = dArqode_Manager.GetDirectories(dGLOBALS.ARQODE)[0];

            if (app_path != "")
            {
                if (Directory.Exists(app_path))
                {
                    dApp_path = new DirectoryInfo(app_path);
                }
                else
                {
                    dApp_path = new DirectoryInfo(Path.Combine(dArqode_Manager.FullName, Path.Combine(dGLOBALS.APPS, app_path)));
                }
            }
            else
            {
                dApp_path = dArqode_Manager.GetDirectories(dGLOBALS.APPS)[0].GetDirectories(dGLOBALS.SYSTEM_APP)[0];
            }            

            dData_path = dApp_path.GetDirectories(dGLOBALS.DATA_PATH)[0];
            pInfo = new JSonFile(dData_path, dGLOBALS.GLOBALS);
            if (!pInfo.hasErrors())
            {
                globals = pInfo.get(dGLOBALS.GLOBALS);

                // Active application
                active_app_name = (app_path !="")? app_path.Substring(app_path.LastIndexOf("\\") + 1): dGLOBALS.SYSTEM_APP;

                // appdata path
                dAppData_path = dApp_path.GetDirectories(dGLOBALS.APPDATA_PATH)[0];

                // data path
                dData_path = dApp_path.GetDirectories(dGLOBALS.DATA_PATH)[0];
                // resources path
                dResources_path = (dApp_path.GetDirectories(dGLOBALS.RESOURCES_PATH).Length > 0) ?
                                    dApp_path.GetDirectories(dGLOBALS.RESOURCES_PATH)[0] :
                                    null;
                // assembly path
                dAssemblies_path = (dAppData_path.GetDirectories(dGLOBALS.ASSEMBLIES_PATH).Length > 0) ?
                                    dAppData_path.GetDirectories(dGLOBALS.ASSEMBLIES_PATH)[0] :
                                    null;
            }
            else
            {
                errors = pInfo.jErrors.ToString();
            }
        }

        /// <summary>
        /// Get active app
        /// </summary>
        public String ActiveAppName
        {
            get { return active_app_name;  }
        }
        
        /// <summary>
        /// Return errors
        /// </summary>
        public String Errors
        {
            get { return errors; }
        }      

        /// <summary>
        /// Get single var in Globals
        /// </summary>true
        /// <param name="variable"></param>
        /// <returns></returns>
        public JToken get(String variable)
        {
            return globals[variable];
        }
        /// <summary>
        /// Get single var in Globals
        /// </summary>true
        /// <param name="variable"></param>
        /// <returns></returns>
        public JToken get(String path, String variable)
        {
            JToken jnode = null;
            foreach (string node in path.Split('.'))
            {
                if (node != dGLOBALS.GLOBALS)
                {
                    if (jnode == null) jnode = globals[node];
                    else jnode = jnode[node];
                }                        
            }
            return (jnode != null)? jnode[variable]: globals[variable];
        }
        public String get_str(String Variable)
        {
            return (get(Variable) != null)?
                get(Variable).ToString(): "";
        }
        public String get_str(String path, String variable)
        {
            return get(path, variable).ToString();
        }        
        /// <summary>
        /// Get all globals vars
        /// </summary>
        public JToken Globals
        {
            get { return globals; }
        }
        public DirectoryInfo App_path
        {
            get { return dApp_path; }
        }      
        
        /// <summary>
        /// Return AppData_path or a section of it
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public DirectoryInfo AppDataSection(String section)
        {
            DirectoryInfo dtemp = new DirectoryInfo(dApp_path.FullName);
            String[] sections = section.Split('.');
            foreach (String sec in sections)
            {
                if ((sec != "") && (dtemp != null))
                {
                    dtemp = (dtemp.GetDirectories(sec).Length > 0) ? dtemp.GetDirectories(sec)[0] : null;
                }
            }
            return dtemp;
        }

        /// <summary>
        /// Resources string path
        /// </summary>
        public String Resources_path
        {
            get { return dResources_path.FullName; }
        }

        /// <summary>
        /// Data path
        /// </summary>
        public String DataPath
        {
            get { return dData_path.FullName; }
        }

        /// <summary>
        /// Get assembly full path
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public string getAssembly(string assembly)
        {
            DirectoryInfo dtemp = new DirectoryInfo(dAssemblies_path.FullName);
            String[] sections = assembly.Split('.');
            int nSec = sections.Length;
            if (sections.Length > 1)
            {
                for (int i = 0; i < nSec - 2; i++)
                {
                    if ((sections[i] != "") && (dtemp != null))
                    {
                        dtemp = (dtemp.GetDirectories(sections[i]).Length > 0) ? dtemp.GetDirectories(sections[i])[0] : null;
                    }
                }
            }
            return ((dtemp != null) && (sections.Length > 1))?
                Path.Combine(dtemp.FullName, sections[nSec-2] + "." + sections[nSec-1]): "";
        }
        #endregion
    }
}
#endregion
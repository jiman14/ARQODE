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

namespace ARQODE_Core
{
    public class CGlobals
    {
        #region constructor

        private JSonFile pInfo;
        private JToken globals;
        private String active_app;
        DirectoryInfo dApps;                    // Root apps folder
        DirectoryInfo dApp_path;                // Active app folder
        DirectoryInfo dData_path;                // Active app data folder
        DirectoryInfo dAppData_path;            // Active app appdata folder
        DirectoryInfo dResources_path;          // Active app resources folder
        DirectoryInfo dAssemblies_path;         // Active app data assemblies

        String errors = "";

        /// <summary>
        /// Load Globals vars
        /// </summary>
        /// <param name="GLOBALS"></param>
        public CGlobals(String App_name)
        {
            active_app = App_name;
            // Get AppData location
            dApp_path = new DirectoryInfo(Assembly.GetExecutingAssembly().Location);
            String sApps_path = dGLOBALS.APPDATA_PATH;
            while ((dApp_path != null) && (!Directory.Exists(Path.Combine(dApp_path.FullName, sApps_path))))
            {
                dApp_path = dApp_path.Parent;
            }
            if (dApp_path != null)
            {
                // Apps path
                dApps = dApp_path.Parent;

                if (dApp_path != null)
                {
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
                else errors = "Error loading AppData path";

                if (errors == "")
                {
                    #region Get globals from settings

                    //String sglobals = VS_PROJECT.Properties.Settings.Default.Globals;
                    //JObject jGlobals = JObject.Parse(System.Text.UTF8Encoding.UTF8.GetString(Convert.FromBase64String(sglobals)));

                    //pInfo = new JSonFile(jGlobals);
                    //globals = pInfo.jActiveObj;
                    #endregion

                    #region Get globals from globals.json

                    pInfo = new JSonFile(dData_path, dGLOBALS.GLOBALS);
                    if (!pInfo.hasErrors())
                    {
                        globals = pInfo.get(dGLOBALS.GLOBALS);
                    }
                    else
                    {
                        errors = pInfo.jErrors.ToString();
                    }
                    #endregion
                }
            }
            else errors = "AppData path not found";
        }

        /// <summary>
        /// Get active app
        /// </summary>
        public String ActiveApp
        {
            get { return active_app;  }
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
            return get(Variable).ToString();
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
        public DirectoryInfo Apps_path
        {
            get { return dApps; }
        }

        
        /// <summary>
        /// Return AppData_path or a section of it
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public DirectoryInfo AppPath(String section)
        {            
            DirectoryInfo dtemp = new DirectoryInfo(dApp_path.FullName);
            String[] sections = section.Split('.');
            foreach (String sec in sections) {
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
        /// Get assembly full path
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public string getAssembly(string assembly)
        {
            DirectoryInfo dtemp = new DirectoryInfo(dAssemblies_path.FullName);
            String[] sections = assembly.Split('.');
            int nSec = sections.Length;
            for (int i=0; i<nSec-2; i++)
            {
                if ((sections[i] != "") && (dtemp != null))
                {
                    dtemp = (dtemp.GetDirectories(sections[i]).Length > 0) ? dtemp.GetDirectories(sections[i])[0] : null;
                }
            }
            return Path.Combine(dtemp.FullName, sections[nSec-2] + "." + sections[nSec-1]);
        }
        #endregion
    }
}
#endregion
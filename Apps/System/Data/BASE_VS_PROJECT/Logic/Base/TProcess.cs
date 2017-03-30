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
using Newtonsoft.Json.Linq;
using JSonUtil;
using ARQODE_Core;

namespace TLogic
{
    public class TProcess 
    {
        #region constructor

        private JSonFile pActivePrc;
        private JSonFile pBasePrc;
        public Dictionary<String, object> vars;

        public TProcess(CSystem csystem, ref Dictionary<String, Object> program_vars, JObject prc)
        {
            vars = program_vars;
            pActivePrc = new JSonFile(prc);

            #region get base process from string
            Type tobj = typeof(CLogic);

            String var_base_process = "BP_" + TLogic.Utils.escape_sc(prc[dPROCESS.GUID].ToString());
            System.Reflection.PropertyInfo JSON = tobj.GetProperty(var_base_process);
            String json_value = JSON.GetValue(null).ToString();
            pBasePrc = new JSonFile(JObject.Parse(System.Text.UTF8Encoding.UTF8.GetString(Convert.FromBase64String(json_value))));
            #endregion

        }
        public TProcess(CSystem csystem, CSystem csystem_app, JObject prc)
        {
            pActivePrc = new JSonFile(prc);
            if (!loadBaseProcess(csystem))
            {
                if (!loadBaseProcess(csystem_app))
                {
                    csystem.ProgramErrors.invalidJSON =
                        String.Format("Error loading json: file not found {0}.{1}. ",
                            dPATH.PROCESSES,
                            Namespace);
                }
            }
        }
        private bool loadBaseProcess(CSystem sys)
        {            
            pBasePrc = new JSonFile(sys.Globals.AppPath(dPATH.PROCESSES), Namespace, false);
            if (pBasePrc.file_exists)
            {
                if (!pBasePrc.hasErrors())
                {
                    pBasePrc.setActiveNode(String.Format("$.{0}[?(@.{1} == '{2}')]", dPROCESS.PROCESSES, dPROCESS.GUID.ToString(), Guid));
                }
                else
                {
                    sys.ProgramErrors.invalidJSON =
                        String.Format("Error loading json file {0}.{1}. Details: {2}",
                            dPATH.PROCESSES,
                            Namespace,
                            pBasePrc.jErrors.ToString());
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region public properties

        public JToken Data
        {
            get { return pActivePrc.jActiveObj; }
        }

        public String Namespace
        {
            get { return pActivePrc.get(dPROCESS.NAMESPACE).ToObject<String>(); }
        }
        public String Guid
        {
            get { return pActivePrc.get(dPROCESS.GUID).ToObject<String>(); }
        }
        public String Edit_code
        {
            get { return (pActivePrc.get(dPROCESS.EDIT_CODE) != null) ? pActivePrc.get(dPROCESS.EDIT_CODE).ToObject<String>() : ""; }
            set
            {
                pActivePrc.set(dPROCESS.EDIT_CODE, value);
            }
        }
        public JToken Name
        {
            get { return pActivePrc.get(dPROCESS.NAME); }
            set { pActivePrc.set(dPROCESS.NAME, value); }
        }
        public JToken Description
        {
            get { return pActivePrc.get(dPROCESS.DESCRIPTION); }
            set { pActivePrc.set(dPROCESS.DESCRIPTION, value); }
        }
        public JToken Version
        {
            get { return pBasePrc.get(dPROCESS.VERSION); }
            set { pBasePrc.set(dPROCESS.VERSION, value); }
        }
        public JToken Default_Configuration
        {
            get { return pActivePrc.get(dPROCESS.DEFAULT_CONFIGURATION); }
            set { pActivePrc.set(dPROCESS.DEFAULT_CONFIGURATION, value); }
        }
        public JToken BaseConfiguration
        {
            get { return pBasePrc.get(dPROCESS.CONFIGURATION); }
            set { pBasePrc.set(dPROCESS.CONFIGURATION, value); }
        }
        public JToken Configuration
        {
            get { return pActivePrc.get(dPROCESS.CONFIGURATION); }
            set { pActivePrc.set(dPROCESS.CONFIGURATION, value); }
        }
        public JToken Inputs
        {
            get { return pActivePrc.get(dPROCESS.INPUTS); }
            set { pActivePrc.set(dPROCESS.INPUTS, value); }
        }
        public JToken BaseInputs
        {
            get { return pBasePrc.get(dPROCESS.INPUTS); }
            set { pBasePrc.set(dPROCESS.INPUTS, value); }
        }
        public JToken Outputs
        {
            get { return pActivePrc.get(dPROCESS.OUTPUTS); }
            set { pActivePrc.set(dPROCESS.OUTPUTS, value); }
        }
        public JToken BaseOutputs
        {
            get { return pBasePrc.get(dPROCESS.OUTPUTS); }
            set { pBasePrc.set(dPROCESS.OUTPUTS, value); }
        }
        public JToken Total_time
        {
            get { return pActivePrc.get(dPROCESS.TOTAL_TIME); }
            set { pActivePrc.set(dPROCESS.TOTAL_TIME, value); }
        }
        public JToken Debug_info
        {
            get { return pActivePrc.get(dPROCESS.DEBUG_INFO); }
            set { pActivePrc.set(dPROCESS.DEBUG_INFO, value); }
        }

        #endregion

    }
}
#endregion
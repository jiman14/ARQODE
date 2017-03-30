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
using JSonUtil;
using Newtonsoft.Json.Linq;
using ARQODE_Core;

namespace TLogic
{
    public class TErrors
    {
        #region Vars

        bool Console_output = true;

        private enum generalStatus
        {
            ERROR_FIXED,
            READY,
            WARNINGS,
            ERRORS_DETECTED
        }                   // General status enum
        public enum errorTypes
        {
            DB_CONNECTION,
            WARNING,
            INPUTS,
            OUTPUTS,
            CONFIGURATION,
            NON_CLASSIFIED,
            UNHANDLED,
            INVALID_JSON
        }                      // Error types enum
        private JSonFile errorInfo;                     // Error info json file
        private JToken active_prc;                      // Active program's process
        public bool forceExitProgram = false;           // Force program exit

        #endregion

        #region Constructor

        public TErrors(CGlobals Globals, String Program)
        {
            errorInfo = new JSonFile(Globals.AppPath(dPATH.ERRORS), Program);

            errorInfo.set(dERROR.STATUS, generalStatus.READY.ToString());
        }
        

        #endregion

        #region Destructor

        public void Close()
        {
            errorInfo.Write();
        }

        #endregion

        #region Public methods

        public JObject get()
        {
            return errorInfo.jActiveObj;
        }
        /// <summary>
        /// Return true only if was errors or critical errors
        /// </summary>
        /// <returns></returns>
        public bool hasErrors()
        {
            return errorInfo.get(dERROR.STATUS).ToString() == generalStatus.ERRORS_DETECTED.ToString();
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Set active process
        /// </summary>
        public TProcess Active_Process
        {
            set
            {
                active_prc = value.Data;
            }
        }
        public JToken Name
        {
            get { return errorInfo.get(dERROR.NAME); }
            set { errorInfo.set(dERROR.NAME, value); }
        }
        public JToken Description
        {
            get { return errorInfo.get(dERROR.DESCRIPTION); }
            set { errorInfo.set(dERROR.DESCRIPTION, value); }
        }
        public String GeneralStatus
        {
            get { return errorInfo.get(dERROR.STATUS).ToString(); }
        }
        public JArray getErrors()
        {
            return errorInfo.get(dERROR.ERRORS) as JArray;
        }

        /// <summary>
        /// Add error
        /// </summary>
        /// <param name="errorType"></param>
        /// <param name="error"></param>
        /// <param name="prc_info"></param>
        public void addError(errorTypes errorType, JToken error)
        {
            if ((error.ToString() != "") && (error.ToString() != "[]"))
            {
                // create error object
                JObject jError = new JObject();
                jError.Add(dERROR.ERROR_TIME, DateTime.Now.ToString());
                jError.Add(dERROR.PROCESS_INFO, active_prc);
                jError.Add(dERROR.ERROR, error);

                // Add error data to erros array
                errorInfo.add(dERROR.ERRORS, jError);

                // set general status
                if (errorType == errorTypes.WARNING)
                {
                    errorInfo.set(dERROR.STATUS, generalStatus.WARNINGS.ToString());
                }
                else
                {
                    errorInfo.set(dERROR.STATUS, generalStatus.ERRORS_DETECTED.ToString());
                }

                // output in console
                if (Console_output) Console.WriteLine(error.ToString());
            }
        }
        public void fixErrors()
        {
            errorInfo.set(dERROR.STATUS, generalStatus.ERROR_FIXED.ToString());
        }
        #region Add error by status

        internal JToken dbConnection
        {
            set
            {
                addError(errorTypes.DB_CONNECTION, value);
            }
        }
        internal JToken non_classified
        {
            set
            {
                addError(errorTypes.NON_CLASSIFIED, value);
            }
        }
        internal JToken warning
        {
            set
            {
                addError(errorTypes.WARNING, value);
            }
        }
        internal JToken noInputs
        {
            set
            {
                addError(errorTypes.INPUTS, value);
            }
        }
        internal JToken noOutputs
        {
            set
            {
                addError(errorTypes.OUTPUTS, value);
            }
        }
        internal JToken noConfiguration
        {
            set
            {
                addError(errorTypes.CONFIGURATION, value);
            }
        }
        internal JToken unhandledError
        {
            set
            {
                addError(errorTypes.UNHANDLED, value);
            }
        }
        internal JToken invalidJSON
        {
            set
            {
                addError(errorTypes.INVALID_JSON, value);
            }
        }
        #endregion

        #endregion

    }
}
#endregion
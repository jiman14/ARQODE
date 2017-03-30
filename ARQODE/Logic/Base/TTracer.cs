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
using Newtonsoft.Json.Linq;
using JSonUtil;
using ARQODE_Core;

namespace TLogic
{
    public class TTracer
    {
        #region Vars and enumerations

        CGlobals Globals;
        
        public enum tracerStatus
        {
            READY,
            ERRORS_DETECTED
        }
        #endregion

        #region constructor

        private tracerStatus global_status;
        private JArray Traces;
        private JSonFile tracerInfo;

        public TTracer(CGlobals globals)
        {
            Globals = globals;
            tracerInfo = new JSonFile(Globals.AppDataSection(dPATH.TRACER), Globals.ActiveAppName, false);
            initializar_tracer();
        }
        private void initializar_tracer()
        {
            if (tracerInfo.jActiveObj[dTRACER.TRACES] == null)
            {
                global_status = tracerStatus.READY;
                ((JObject)tracerInfo.jActiveObj).Add(dTRACER.GLOBAL_STATUS, tracerStatus.READY.ToString());
                ((JObject)tracerInfo.jActiveObj).Add(dTRACER.GLOBAL_DATE, DateTime.Now);
                ((JObject)tracerInfo.jActiveObj).Add(dTRACER.TRACES, new JArray());
            }
            Traces = tracerInfo.jActiveObj[dTRACER.TRACES] as JArray;
        }
        #endregion

        #region Destructor

        public void Write()
        {
            tracerInfo.Write();
        }

        #endregion

        #region Public funtions & properties

        /// <summary>
        /// Add trace
        /// </summary>
        /// <param name="trace"></param>
        public void AddTrace(JToken trace)
        {
            JObject jItem = new JObject();
            jItem.Add(dTRACER.DATE, DateTime.Now.ToString());
            jItem.Add(dTRACER.INFO, trace);
            Traces.Add(jItem);
        }

        /// <summary>
        /// Add error trace
        /// </summary>
        /// <param name="trace"></param>
        public void AddError(JToken trace)
        {
            global_status = tracerStatus.ERRORS_DETECTED;

            JObject jItem = new JObject();
            jItem.Add(dTRACER.DATE, DateTime.Now.ToString());
            jItem.Add(dTRACER.INFO, trace);
            Traces.Add(jItem);
        }

        /// <summary>
        /// Clean all traces
        /// </summary>
        public void CleanTraces()
        {
            tracerInfo.jActiveObj.RemoveAll();
            initializar_tracer();
        }

        /// <summary>
        /// Get program traces
        /// </summary>
        public JToken Program_traces
        {
            get { return Traces; }
        }

        /// <summary>
        /// Determine if there is errors
        /// </summary>
        /// <returns></returns>
        public bool has_errors()
        {
            return global_status == tracerStatus.ERRORS_DETECTED;
        }
        
        /// <summary>
        /// global status
        /// </summary>
        public tracerStatus GlobalStatus
        {
            get {
                return (tracerInfo.jActiveObj[dTRACER.GLOBAL_STATUS].ToString() == tracerStatus.ERRORS_DETECTED.ToString())? 
                    tracerStatus.ERRORS_DETECTED:
                    tracerStatus.READY;
            }
            set { tracerInfo.jActiveObj[dTRACER.GLOBAL_STATUS] = value.ToString(); }
        }
        #endregion

        #region Utils
        public void cprint(JToken message)
        {
            Console.WriteLine(message.ToString());
        }
        
        #endregion
       
    }
}
#endregion
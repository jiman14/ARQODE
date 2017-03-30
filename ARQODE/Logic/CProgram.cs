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
using System.Linq;
using Newtonsoft.Json.Linq;
using JSonUtil;
using ARQODE_Core;

namespace TLogic
{
    public class CProgram
    {
        #region constructor

        private CSystem sys;
        private JSonFile progInfo;                          // Program object descriptor
        public Dictionary<String, object> vars;             // Program vars
        public TDebug debug;                                // Debug object
        public delegate void RunProcess(TProcess prc);      // Run process delegate
        public event RunProcess ExecuteProcess;             // Execute process event
        private String program_name;

        public CProgram(CSystem csystem, CGlobals Globals, String program, object program_vars = null)
        {
            sys = csystem;
            // Remove program queued flag
            program_name = (program.StartsWith("&")) ? program.Substring(1) : program;
            // Read program
            progInfo = new JSonFile(Globals.AppDataSection(dPATH.PROGRAM), program_name, true);

            if (!progInfo.hasErrors())
            {
                // Init csystem.ProgramErrors and debug for program execution
                csystem.ProgramErrors = new TErrors(Globals, program);
                csystem.ProgramDebug = new TDebug(Globals, program);               
                debug = csystem.ProgramDebug;

                csystem.ProgramErrors.Name = Name;
                csystem.ProgramErrors.Description = Description;
                debug.Name = Name;
                debug.Description = Description;

                // Init vars
                if (program_vars == null)
                {
                    vars = new Dictionary<string, object>();
                }
                else
                {
                    vars = (Dictionary<string, object>)program_vars;
                }
                foreach (JValue var in Variables)
                {
                    if (!vars.ContainsKey(var.Value.ToString()))
                    {
                        vars.Add(var.Value.ToString(), null);
                    }
                }                
            }
            else
            {
                csystem.ProgramErrors = new TErrors(Globals, program);
                csystem.ProgramErrors.invalidJSON = progInfo.jErrors;
            }
        }
        /// <summary>
        /// Check queued program's flag
        /// </summary>
        /// <param name="program"></param>
        /// <returns></returns>
        static public bool CheckQueuedFlag(String program)
        {
            return program.StartsWith("&");
        }

        /// <summary>
        /// Save debug and csystem.ProgramErrors
        /// </summary>
        public void ProgramClose()
        {
            if (debug != null) debug.Close();
            sys.ProgramErrors.Close();
        }       

        /// <summary>
        /// Has errors
        /// </summary>
        /// <returns></returns>
        public bool hasErrors()
        {
            return sys.ProgramErrors.hasErrors() || progInfo.hasErrors();
        }
        
        #endregion

        #region Public properties

        /// <summary>
        /// Program name
        /// </summary>
        public JToken Name { get { return progInfo.get(dPROGRAM.NAME); } }

        /// <summary>
        /// Parallel execution
        /// </summary>
        public bool Parallel_execution {
            get
            {
                JToken pe = progInfo.get(dPROGRAM.PARALLEL_EXECUTION);
                return (pe != null)? pe.ToObject<bool>(): false;
            }
        }
        public JToken get_json { get { return progInfo.jActiveObj; } }
        /// <summary>
        /// Program description
        /// </summary>
        public JToken Description { get { return progInfo.get(dPROGRAM.DESCRIPTION); } }

        /// <summary>
        /// Program configuration
        /// </summary>
        public JToken Configuration { get { return progInfo.get(dPROGRAM.CONFIGURATION); } }

        /// <summary>
        /// Get logic
        /// </summary>
        public JToken Logic
        {
            get { return (JArray)progInfo.get(dPROGRAM.LOGIC); }
            set { progInfo.set(dPROGRAM.LOGIC, value); }
        }
        /// <summary>
        /// Get logic
        /// </summary>
        public JArray Variables
        {
            get { return (JArray)progInfo.get(dPROGRAM.VARIABLES); }
            set { progInfo.set(dPROGRAM.VARIABLES, value); }
        }
        /// <summary>
        /// Get program name with path
        /// </summary>
        public String Program_namespace { get { return program_name; }  }

        /// <summary>
        /// Save program json
        /// </summary>
        public void Save()
        {
            progInfo.Write();
        }

        /// <summary>
        /// Get process by guid
        /// </summary>
        /// <param name="process_guid"></param>
        /// <returns></returns>
        public JToken get_Process(String process_guid)
        {
            foreach (JObject prc_node in Logic)
            {
                if ((prc_node.Count > 0) && (prc_node[dPROCESS.GUID].ToString() == process_guid))
                {
                    return prc_node;
                }
            }
            return null;
        }
        /// <summary>
        /// Set process edit code var
        /// </summary>
        /// <param name="process_guid"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public bool SetProcess_Edit_Code(string process_guid, string value)
        {
            JToken jprocess = null;
            if ((jprocess = get_Process(process_guid)) != null)
            {
                jprocess[dPROCESS.EDIT_CODE] = value;
                Save();
                return true;
            }
            return false;
        }
        #endregion

        #region Program logic

        public void Run()
        {
            #region Initalize program

            if ((String.IsNullOrEmpty(debug.Status)) || (debug.Status == TDebug.debugStatus.FINISHED.ToString()))
            {   
                debug.Status = TDebug.debugStatus.PROCESSING.ToString();
            }
            sys.ProgramTracer.AddTrace(String.Format("{0} Program executing...", program_name));

            DateTime initTime = DateTime.Now;

            #endregion

            #region main bucle
            bool exists_process = false;
            foreach (JObject prc_node in Logic)
            {
                if (prc_node.Count > 0)
                {
                    exists_process = true;
                    execute_process(prc_node);
                    if (sys.ProgramErrors.hasErrors())
                    {
                        sys.ProgramTracer.AddError(String.Format("Aborting program execution '{0}' due errors in: {1}", Name.ToString(), prc_node["Guid"].ToString()));
                        break;
                    }
                    if (sys.ProgramErrors.forceExitProgram)
                    {
                        sys.debug.add("Force program exit flag actived by process");
                        break;
                    }
                }
            }
            if (!exists_process)
            {
                sys.debug.add("There is no process in current program: " + Name.ToString());
            }
            #endregion

            #region end runing

            debug.Status = sys.ProgramErrors.GeneralStatus;
            debug.Total_time = Math.Round((DateTime.Now - initTime).TotalSeconds, 2);
            debug.Last_Execution_Time = DateTime.Now.ToString();

            #endregion
        }

        /// <summary>
        /// Execute process by program process object
        /// </summary>
        /// <param name="prc_node"></param>
        /// <returns></returns>
        private TProcess execute_process(JObject prc_node)
        {
            // Get process base
            TProcess proc = new TProcess(sys, ref vars, prc_node);
            
            // set active process to errors
            sys.ProgramErrors.Active_Process = proc;
            
            // run recursive processes in inputs
            //for (int i = 0; i < proc.Inputs.Count(); i++)
            //{
            //    JToken jActiveInput = proc.Inputs.ElementAt(i);
            //    if ((jActiveInput != null) && (jActiveInput is JObject) && (jActiveInput[dPROCESS.GUID.ToString()] != null))
            //    {
            //        TProcess act_prc = execute_process(jActiveInput as JObject);
            //    }
            //}

            if (!sys.ProgramErrors.hasErrors())
            {
                // run current proccess
                if (ExecuteProcess != null)
                {
                    ExecuteProcess(proc);
                }

                debug.Processes.Add(proc.Data);
                return proc;
            }
            else return null;            
        }
        #endregion

    }
}
#endregion
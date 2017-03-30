using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using TControls;
using ARQODE_Core;
using JSonUtil;

namespace TLogic
{
    public class CStructModifications
    {
        #region Init class

        CSystem sys;
        CGlobals Globals;
        DirectoryInfo cProgramas;
        DirectoryInfo cProcesos;
        DirectoryInfo cVistas;

        bool replace_in_programs = true;
        enum replace_process_options
        {
            replace_by_namespace,
            replace_by_guid,
            replace_process,
            check_integrity
        }
        replace_process_options replace_prc_options;

        public CStructModifications(CSystem system, CGlobals app_globals)
        {
            sys = system;
            Globals = app_globals;
            cVistas = Globals.AppDataSection(dPATH.VIEWS);
            cProgramas = Globals.AppDataSection(dPATH.PROGRAM);
            cProcesos = Globals.AppDataSection(dPATH.PROCESSES);
        }
        #endregion

        #region Move program

        /// <summary>
        /// Move a program to a diferent location
        /// </summary>
        /// <param name="from_path"></param>
        /// <param name="to_path"></param>
        public ArrayList MoveProgram(String from_path, String to_path)
        {
            ArrayList FindedPrograms = new ArrayList();
            replace_in_programs = true;
            search_in_calls_IOC(cProgramas, from_path, to_path, ref FindedPrograms);

            search_in_events(cVistas, from_path, to_path);

            return FindedPrograms;
        }
        /// <summary>
        /// Find program references (calls)
        /// </summary>
        /// <param name="program_path"></param>
        /// <returns></returns>
        public ArrayList FindProgramReferences(String program_path)
        {
            ArrayList FindedPrograms = new ArrayList();
            replace_in_programs = false;
            search_in_calls_IOC(cProgramas, program_path, "", ref FindedPrograms);

            return FindedPrograms;
        }
        /// <summary>
        /// Find in programs process all words in find_str
        /// </summary>
        /// <param name="find_string"></param>
        /// <returns></returns>
        public List<KeyValuePair<JToken, int>> Find_all_in_programs(String find_string)
        {
            List<KeyValuePair<JToken, int>> FindedPrograms = new List<KeyValuePair<JToken, int>>();
            ArrayList find_str = new ArrayList();
            foreach (String s in find_string.Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries))
            {
                find_str.Add(s);
            }
            search_in_all(cProgramas, find_str, ref FindedPrograms);

            FindedPrograms.Sort(Compare2);

            return FindedPrograms;
        }
        /// <summary>
        /// Find in processes all words in find_str
        /// </summary>
        /// <param name="find_string"></param>
        /// <returns></returns>
        public List<KeyValuePair<JToken, int>> Find_all_in_processes(String find_string)
        {
            List<KeyValuePair<JToken, int>> FindedProcesses = new List<KeyValuePair<JToken, int>>();
            ArrayList find_str = new ArrayList();
            foreach (String s in find_string.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
            {
                find_str.Add(s);
            }
            search_in_all(cProcesos, find_str, ref FindedProcesses);

            FindedProcesses.Sort(Compare2);

            return FindedProcesses;
        }
        static int Compare2(KeyValuePair<JToken, int> a, KeyValuePair<JToken, int> b)
        {
            return b.Value.CompareTo(a.Value);
        }

        /// <summary>
        /// Search a program path in all program calls
        /// </summary>
        /// <param name="program_path"></param>
        /// <returns></returns>
        public ArrayList SearchProgramCalls_IOC(String program_path)
        {
            ArrayList FindedPrograms = new ArrayList();
            replace_in_programs = false;
            search_in_calls_IOC(cProgramas, program_path, "", ref FindedPrograms);

            return FindedPrograms;
        }

        #region Search in calls

        /// <summary>
        /// Recursive load files
        /// </summary>
        /// <param name="di"></param>
        /// <param name="from_path"></param>
        /// <param name="to_path"></param>
        private void search_in_calls_IOC(DirectoryInfo di, String from_path, String to_path, ref ArrayList FindedPrograms)
        {
            foreach (FileInfo fi in di.GetFiles())
            {
                if (replace_in_programs_calls_IOC(fi, from_path, to_path))
                {
                    FindedPrograms.Add(fi.FullName);
                }

            }
            foreach (DirectoryInfo di_child in di.GetDirectories())
            {
                search_in_calls_IOC(di_child, from_path, to_path, ref FindedPrograms);
            }
        }
        /// <summary>
        /// Recursive load files
        /// </summary>
        /// <param name="di"></param>
        /// <param name="from_path"></param>
        /// <param name="to_path"></param>       
        private void search_in_all(DirectoryInfo di, ArrayList find_str, ref List<KeyValuePair<JToken, int>> Finded)
        {
            foreach (FileInfo fi in di.GetFiles())
            {
                if (di.FullName.Contains(dPATH.PROGRAM.Replace(".", "\\")))  
                    find_in_programs(fi, find_str, ref Finded);
                else
                    find_in_processes(fi, find_str, ref Finded);
            }
            foreach (DirectoryInfo di_child in di.GetDirectories())
            {
                search_in_all(di_child, find_str, ref Finded);
            }
        }

        /// <summary>
        /// Find in programs process all words in find_str
        /// </summary>
        /// <param name="fi"></param>
        /// <param name="find_str"></param>
        /// <param name="findedPrograms"></param>
        private void find_in_programs(FileInfo fi, ArrayList find_str, ref List<KeyValuePair<JToken, int>> findedPrograms)
        {
            JSonFile jProgram = new JSonFile(fi.FullName);
            int founded = 0;
            int max_founded = 0;
            // Search in calls
            foreach (JToken Jnode in jProgram.jActiveObj["Logic"] as JArray)
            {
                String Guid = Jnode["Guid"].ToString();
                Jnode["Guid"] = "";
                founded = 0;
                String cad_bus = "";
                if (find_str.Count > 2)
                {
                    foreach (string find in find_str)
                    {
                        cad_bus += find + " ";
                    }
                    if (Jnode.ToString().ToLower().Contains(cad_bus))
                    {
                        founded += 2;
                    }
                    cad_bus = "";
                }
                for (int i=1; i< find_str.Count && find_str.Count > 1; i++)
                {
                    cad_bus = find_str[i-1] + " " + find_str[i];
                    if (Jnode.ToString().ToLower().Contains(cad_bus))
                    {
                        founded += 1;
                    }
                }

                foreach (string find in find_str)
                {
                    if (Jnode.ToString().ToLower().Contains(find.ToLower()))
                    {
                        founded++;
                    }
                }
                if (founded >= find_str.Count)
                {
                    if (max_founded < founded) { max_founded = founded; }
                    JObject jfind = new JObject();
                    jfind["Program"] = fi.FullName;
                    jfind["Process guid"] = Guid;
                    jfind["Process name"] = (Jnode["Name"] != null) ? Jnode["Name"] : Guid;
                    findedPrograms.Add(new KeyValuePair<JToken, int>(jfind, founded));
                }
            }
            #region find in path
            founded = 0;
            foreach (string find in find_str)
            {
                if (fi.FullName.ToLower().Contains(find.ToLower()))
                {
                    founded++;
                }
            }
            if (founded >= find_str.Count - 1)
            {
                JObject jfind = new JObject();
                jfind["Program"] = fi.FullName;
                jfind["Process guid"] = "";
                jfind["Process name"] = "";
                if (max_founded < founded) { max_founded = founded; }
                findedPrograms.Add(new KeyValuePair<JToken, int>(jfind, max_founded + (founded - find_str.Count)));
            }
            #endregion
        }

        /// <summary>
        /// Find in processes process all words in find_str
        /// </summary>
        /// <param name="fi"></param>
        /// <param name="find_str"></param>
        /// <param name="findedProcesses"></param>
        private void find_in_processes(FileInfo fi, ArrayList find_str, ref List<KeyValuePair<JToken, int>> findedProcesses)
        {
            JSonFile jProcess = new JSonFile(fi.FullName);
            int max_founded = 0;
            int founded = 0;
            // Search in calls
            if (jProcess.jActiveObj["processes"] != null) {
                foreach (JToken Jnode in jProcess.jActiveObj["processes"] as JArray)
                {
                    String Guid = Jnode["Guid"].ToString();
                    Jnode["Guid"] = "";
                    founded = 0;
                    String cad_bus = "";
                    if (find_str.Count > 2)
                    {
                        foreach (string find in find_str)
                        {
                            cad_bus += find + " ";
                        }
                        if (Jnode.ToString().ToLower().Contains(cad_bus))
                        {
                            founded += 2;
                        }
                        cad_bus = "";
                    }
                    for (int i = 1; i < find_str.Count && find_str.Count > 1; i++)
                    {
                        cad_bus = find_str[i - 1] + " " + find_str[i];
                        if (Jnode.ToString().ToLower().Contains(cad_bus))
                        {
                            founded += 1;
                        }
                    }

                    foreach (string find in find_str)
                    {
                        if (Jnode.ToString().ToLower().Contains(find.ToLower()))
                        {
                            founded++;
                        }
                    }
                    if (founded >= find_str.Count)
                    {
                        if (max_founded < founded) { max_founded = founded; }
                        JObject jfind = new JObject();
                        jfind["Process"] = fi.FullName;
                        jfind["Process guid"] = Guid;
                        jfind["Process name"] = (Jnode["Name"] != null) ? Jnode["Name"] : Guid;
                        findedProcesses.Add(new KeyValuePair<JToken, int>(jfind, founded));
                    }
                }
            }
            #region find in path
            founded = 0;
            foreach (string find in find_str)
            {
                if (fi.FullName.ToLower().Contains(find.ToLower()))
                {
                    founded++;
                }
            }
            if (founded >= find_str.Count-1)
            {
                JObject jfind = new JObject();
                jfind["Process"] = fi.FullName;
                jfind["Process guid"] = "";
                jfind["Process name"] = "";
                if (max_founded < founded) { max_founded = founded; }
                findedProcesses.Add(new KeyValuePair<JToken, int>(jfind, max_founded + (founded-find_str.Count) ));
            }
            #endregion
        }

        /// <summary>
        /// Replace in files
        /// </summary>
        /// <param name="fi"></param>
        /// <param name="from_path"></param>
        /// <param name="to_path"></param>
        private bool replace_in_programs_calls_IOC(FileInfo fi, string from_path, string to_path)
        {
            JSonFile jProgram = new JSonFile(fi.FullName);
            bool changed = false;

            // Search in calls
            foreach (JToken Jnode in jProgram.getNodes("$.Logic[?(@.Guid == 'Call')]"))
            {
                if (Jnode["Configuration"]["program"].ToString().Equals(from_path))
                {
                    if (replace_in_programs)
                    {
                        Jnode["Name"] = "Call " + to_path;
                        Jnode["Configuration"]["program"] = to_path;
                    }
                    changed = true;
                }
            }

            // Search in IOC only if to_path is filled
            if ((to_path != "") && (jProgram.jActiveObj["Logic"].ToString().Contains(from_path)))
            {
                // entrarpor las configuraciones 
                foreach (JToken Jnode in jProgram.getNode("$.Logic") as JArray)
                {
                    // Replace Inputs, Outputs & Configuration
                    change_prop_in_array(Jnode["Inputs"] as JObject, to_path, from_path, ref changed);
                    change_prop_in_array(Jnode["Outputs"] as JObject, to_path, from_path, ref changed);
                    change_prop_in_array(Jnode["Configuration"] as JObject, to_path, from_path, ref changed);
                }
            }
            if ((changed) && (replace_in_programs)) jProgram.Write();

            return changed;
        }
        #endregion

        #region Search in events
        /// <summary>
        /// Recusive load files
        /// </summary>
        /// <param name="di"></param>
        /// <param name="from_path"></param>
        /// <param name="to_path"></param>
        private void search_in_events(DirectoryInfo di, String from_path, String to_path)
        {
            foreach (FileInfo fi in di.GetFiles())
            {
                replace_in_events(fi, from_path, to_path);
            }
            foreach (DirectoryInfo di_child in di.GetDirectories())
            {
                search_in_events(di_child, from_path, to_path);
            }
        }

        /// <summary>
        /// Replace program events
        /// </summary>
        /// <param name="fi"></param>
        /// <param name="from_path"></param>
        /// <param name="to_path"></param>
        private void replace_in_events(FileInfo fi, string from_path, string to_path)
        {
            JSonFile jView = new JSonFile(fi.FullName);
            bool changed = false;
            foreach (JToken Jnode in jView.getNodes("$.Controls[?(@.Events)]"))
            {
                foreach (JProperty jp in ((JObject)Jnode["Events"]).Properties())
                {
                    if (jp.Value.ToString().Equals(from_path))
                    {
                        jp.Value = to_path;
                        changed = true;
                    }
                }                
            }
            if (changed) jView.Write();
        }
        #endregion

        #endregion

        #region Move view

        /// <summary>
        /// Move view references, and his var's list
        /// </summary>
        /// <param name="from_path"></param>
        /// <param name="to_path"></param>
        public void MoveView(String from_path, String to_path)
        {
            Dictionary<String, String> ReplacementVarList = new Dictionary<String, String>();

            // Fill replacement var with view's vars
            search_in_views(cVistas, from_path, to_path, ref ReplacementVarList);

            // Add view replacement
            ReplacementVarList.Add(from_path, to_path);

            // Search and replace vars
            Search_in_program_files(cProgramas, ReplacementVarList);
        }

        #region Find views vars

        /// <summary>
        /// Find view files
        /// </summary>
        /// <param name="di"></param>
        /// <param name="from_path"></param>
        /// <param name="to_path"></param>
        private void search_in_views(DirectoryInfo di, String from_path, String to_path, ref Dictionary<String, String> ReplacementVarList)
        {
            foreach (FileInfo fi in di.GetFiles())
            {
                add_views_vars_to_list(fi, from_path, to_path, ref ReplacementVarList);
            }
            foreach (DirectoryInfo di_child in di.GetDirectories())
            {
                search_in_views(di_child, from_path, to_path, ref ReplacementVarList);
            }
        }

        /// <summary>
        /// Add view vars
        /// </summary>
        /// <param name="fi"></param>
        /// <param name="from_path"></param>
        /// <param name="to_path"></param>
        private void add_views_vars_to_list(FileInfo fi, string from_path, string to_path, ref Dictionary<String, String> ReplacementVarList)
        {
            JSonFile jView = new JSonFile(fi.FullName);
            foreach (JToken jVar in jView.jActiveObj["Variables"] as JArray)
            {
                ReplacementVarList.Add(from_path + "." + jVar.ToString(), to_path + "." + jVar.ToString());
            }                       
        }
        #endregion

        /// <summary>
        /// get program files
        /// </summary>
        /// <param name="di"></param>
        /// <param name="ReplacementVarList"></param>
        private void Search_in_program_files(DirectoryInfo di, Dictionary<String, String> ReplacementVarList)
        {
            foreach (FileInfo fi in di.GetFiles())
            {
                replace_in_programs_IOC(fi, ReplacementVarList);
            }
            foreach (DirectoryInfo di_child in di.GetDirectories())
            {
                Search_in_program_files(di_child, ReplacementVarList);
            }
        }
        /// <summary>
        /// Replace var list in program IOC
        /// </summary>
        /// <param name="fi"></param>
        /// <param name="ReplacementVarList"></param>
        private void replace_in_programs_IOC(FileInfo fi, Dictionary<String, String> ReplacementVarList)
        {
            JSonFile jProgram = new JSonFile(fi.FullName);
            bool changed = false;

            // Loop into processes
            foreach (JToken Jnode in jProgram.getNode("$.Logic") as JArray)
            {
                // Loop into replacements
                foreach (String key in ReplacementVarList.Keys) {
                    // Replace Inputs, Outputs & Configuration
                    change_prop_in_array(Jnode["Inputs"] as JObject, ReplacementVarList[key], key, ref changed);
                    change_prop_in_array(Jnode["Outputs"] as JObject, ReplacementVarList[key], key, ref changed);
                    change_prop_in_array(Jnode["Configuration"] as JObject, ReplacementVarList[key], key, ref changed);
                }                
            }
            if (changed) jProgram.Write();
        }
        
        #endregion

        #region Move process

        /// <summary>
        /// Rename process
        /// </summary>
        /// <param name="prc_guid"></param>
        /// <param name="to_path"></param>
        public ArrayList SaveProcess(JObject prc_base)
        {
            replace_in_programs = true;
            replace_prc_options = replace_process_options.replace_process;
            ArrayList FindedPrograms = new ArrayList();
            search_in_programs(cProgramas, prc_base["Guid"].ToString(), "", ref FindedPrograms, prc_base);

            return FindedPrograms;
        }

        /// <summary>
        /// Move process namespace by old namespace
        /// </summary>
        /// <param name="prc_namespace"></param>
        /// <param name="to_path"></param>
        /// <returns></returns>
        public ArrayList MoveProcess_byNamespace(String prc_namespace, String to_path)
        {
            replace_in_programs = true;
            replace_prc_options = replace_process_options.replace_by_namespace;
            ArrayList FindedPrograms = new ArrayList();
            search_in_programs(cProgramas, prc_namespace, to_path, ref FindedPrograms);

            return FindedPrograms;
        }

        /// <summary>
        /// Move process namespace by buid
        /// </summary>
        /// <param name="prc_guid"></param>
        /// <param name="to_path"></param>
        /// <returns></returns>
        public ArrayList MoveProcess_byGuid(String prc_guid, String to_path)
        {            
            replace_in_programs = true;
            replace_prc_options = replace_process_options.replace_by_guid;
            ArrayList FindedPrograms = new ArrayList();
            search_in_programs(cProgramas, prc_guid, to_path, ref FindedPrograms);

            return FindedPrograms;
        }
        /// <summary>
        /// Find process in programs by guid
        /// </summary>
        /// <param name="prc_guid"></param>
        /// <returns></returns>
        public ArrayList FindProcessInPrograms(String prc_guid)
        {
            replace_in_programs = false;
            replace_prc_options = replace_process_options.replace_by_guid;
            ArrayList FindedPrograms = new ArrayList();
            search_in_programs(cProgramas, prc_guid, "", ref FindedPrograms);

            return FindedPrograms;
        }
        /// <summary>
        /// Find process in programs by namespace
        /// </summary>
        /// <param name="prc_namespace"></param>
        /// <returns></returns>
        public ArrayList FindProcessFileInPrograms(String prc_namespace)
        {
            replace_in_programs = false;
            replace_prc_options = replace_process_options.replace_by_namespace;
            ArrayList FindedPrograms = new ArrayList();
            search_in_programs(cProgramas, prc_namespace, "", ref FindedPrograms);

            return FindedPrograms;
        }

        /// <summary>
        /// Check integrity in programs processes
        /// </summary>
        /// <returns></returns>
        public ArrayList CheckProcessIntegrityInPrograms()
        {
            replace_in_programs = false;
            replace_prc_options = replace_process_options.check_integrity;
            ArrayList FindedPrograms = new ArrayList();
            search_in_programs(cProgramas, "", "", ref FindedPrograms);

            return FindedPrograms;
        }

        /// <summary>
        /// Recursive load files
        /// </summary>
        /// <param name="di"></param>
        /// <param name="new_value"></param>
        private void search_in_programs(DirectoryInfo di, String prc_key, String new_value, ref ArrayList FindedPrograms, JObject prc_base=null)
        {
            foreach (FileInfo fi in di.GetFiles())
            {
                bool founded = false;
                if (replace_prc_options == replace_process_options.replace_by_guid)
                {
                    founded = replace_prc_namespace_in_programs_by_guid(fi, prc_key, new_value);
                }
                else if (replace_prc_options == replace_process_options.replace_by_namespace)
                {
                    founded = replace_prc_namespace_in_programs_by_namespace(fi, prc_key, new_value);
                }
                else if (replace_prc_options == replace_process_options.replace_process)
                {
                    founded = replace_prc_in_programs(fi, prc_key, prc_base);
                }
                else if (replace_prc_options == replace_process_options.check_integrity)
                {
                    founded = check_integrity_in_process(fi, ref FindedPrograms);
                }

                if (founded)
                {
                    FindedPrograms.Add(fi.FullName);
                }
            }
            foreach (DirectoryInfo di_child in di.GetDirectories())
            {
                search_in_programs(di_child, prc_key, new_value, ref FindedPrograms, prc_base);
            }
        }

        /// <summary>
        /// Replace prc namespace in program files by guid
        /// </summary>
        /// <param name="fi"></param>
        /// <param name="to_path"></param>
        private bool replace_prc_namespace_in_programs_by_guid(FileInfo fi, String prc_guid, String to_path)
        {
            JSonFile jProgram = new JSonFile(fi.FullName);
            bool changed = false;
            foreach (JToken Jnode in jProgram.getNodes(String.Format("$.Logic[?(@.Guid == '{0}')]", prc_guid)))
            {
                if (replace_in_programs)
                {
                    Jnode["Namespace"] = to_path;
                }
                changed = true;
            }
            if ((changed) && (replace_in_programs)) jProgram.Write();
            return changed;
        }
        /// <summary>
        /// Replace prc namespace in program files by namespace
        /// </summary>
        /// <param name="fi"></param>
        /// <param name="to_path"></param>
        private bool replace_prc_namespace_in_programs_by_namespace(FileInfo fi, String prc_namespace, String to_path)
        {
            JSonFile jProgram = new JSonFile(fi.FullName);
            bool changed = false;
            foreach (JToken Jnode in jProgram.getNodes(String.Format("$.Logic[?(@.Namespace == '{0}')]", prc_namespace)))
            {
                if (replace_in_programs)
                {
                    Jnode["Namespace"] = to_path;
                }
                changed = true;
            }
            if ((changed) && (replace_in_programs)) jProgram.Write();
            return changed;
        }        

        /// <summary>
        /// Replace prc name in program files
        /// </summary>
        /// <param name="fi"></param>
        /// <param name="to_path"></param>
        private bool replace_prc_in_programs(FileInfo fi, String prc_guid, JObject prc_base)
        {
            JSonFile jProgram = new JSonFile(fi.FullName);
            bool changed = false;
            foreach (JToken Jnode in jProgram.getNodes(String.Format("$.Logic[?(@.Guid == '{0}')]", prc_guid)))
            {
                if (replace_in_programs)
                {
                    Jnode["Name"] = prc_base["Name"];
                }
                changed = true;

                // update program IOC changes from prc base
                Update_program_process_IOC(prc_base, Jnode as JObject);
            }
            if ((changed) && (replace_in_programs)) jProgram.Write();
            return changed;
        }

        /// <summary>
        /// Check integrity in program processes
        /// </summary>
        /// <param name="fi"></param>
        /// <param name="FindedPrograms"></param>
        /// <returns></returns>
        private bool check_integrity_in_process(FileInfo fi, ref ArrayList FindedPrograms)
        {
            try
            {
                JSonFile jProgram = new JSonFile(fi.FullName);
                String program_path = fi.FullName.Replace(Globals.AppDataSection(dPATH.PROGRAM).FullName + "\\", "").Replace("\\", ".").Replace(".json", "");
                TErrors er = new TErrors(Globals, program_path);
                foreach (JObject prc_node in jProgram.jActiveObj["Logic"] as JArray)
                {
                    if (prc_node.Properties().Count() > 0)
                    {
                        TProcess prc = new TProcess(sys, Globals, prc_node);
                        if (!CDataIntegrity.CheckAllVariables(prc, ref er))
                        {
                            FindedPrograms.Add(String.Format("Program: {0}: \r\n   -> Process: {1} \r\n   -> {2}",
                                program_path, prc.Name, er.getErrors().ToString()));
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                FindedPrograms.Add(exc.Message);
            }
            return false; 
        }

        /// <summary>
        /// Update program process IOC from base process 
        /// </summary>
        /// <param name="jPrcBase"></param>
        /// <param name="JProgPrc"></param>
        private void Update_program_process_IOC(JObject jPrcBase, JObject JProgPrc)
        {

            // delete keys that not exists in base anymore            
            Remove_var_in_program_process(jPrcBase, JProgPrc, "Inputs");
            Remove_var_in_program_process(jPrcBase, JProgPrc, "Outputs");
            Remove_var_in_program_process(jPrcBase, JProgPrc, "Configuration");

            // change keys optinal prefix "-"
            Update_optional_vars_in_program_process(jPrcBase, JProgPrc, "Inputs");
            Update_optional_vars_in_program_process(jPrcBase, JProgPrc, "Outputs");
            Update_optional_vars_in_program_process(jPrcBase, JProgPrc, "Configuration");

            // insert new keys in 
            Insert_new_vars_in_program_process(jPrcBase, JProgPrc, "Inputs");
            Insert_new_vars_in_program_process(jPrcBase, JProgPrc, "Outputs");
            Insert_new_vars_in_program_process(jPrcBase, JProgPrc, "Configuration");
        }

        /// <summary>
        /// Remove from program process IOC not used var by key name
        /// </summary>
        /// <param name="jPrcBase"></param>
        /// <param name="JProgPrc"></param>
        /// <param name="IOC"></param>
        private void Remove_var_in_program_process(JObject jPrcBase, JObject JProgPrc, String IOC)
        {
            if (((JProgPrc[IOC] != null) && ((JObject)JProgPrc[IOC]).Properties().Count() > 0))
            {
                int i = 0;
                JProperty jp;
                while (i < ((JObject)JProgPrc[IOC]).Properties().Count())
                {
                    jp = ((JObject)JProgPrc[IOC]).Properties().ElementAt(i);
                    if ((!jp.Name.StartsWith("-")) &&
                        (!jPrcBase[IOC].Select(x => x.ToString() == jp.Name).Contains(true)) &&
                        (!jPrcBase[IOC].Select(x => x.ToString() == "-" + jp.Name).Contains(true)))
                    {
                        jp.Remove();
                    }
                    else if ((jp.Name.StartsWith("-")) &&
                        (!jPrcBase[IOC].Select(x => x.ToString() == jp.Name).Contains(true)) &&
                        (!jPrcBase[IOC].Select(x => x.ToString() == jp.Name.Substring(1)).Contains(true)))
                    {
                        jp.Remove();
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }
        /// <summary>
        /// update program process IOC's optional vars by key name
        /// </summary>
        /// <param name="jPrcBase"></param>
        /// <param name="JProgPrc"></param>
        /// <param name="IOC"></param>
        private void Update_optional_vars_in_program_process(JObject jPrcBase, JObject JProgPrc, String IOC)
        {
            if (((JProgPrc[IOC] != null) && ((JObject)JProgPrc[IOC]).Properties().Count() > 0))
            {
                for (int i=0;i< ((JObject)JProgPrc[IOC]).Properties().Count();i++)                
                {
                    JProperty jp = ((JObject)JProgPrc[IOC]).Properties().ElementAt(i);
                    if ((jp.Name.StartsWith("-")) &&
                        (jPrcBase[IOC].Select(x => x.ToString() == jp.Name.Substring(1)).Contains(true)))                        
                    {
                        JProperty jp_new = new JProperty(jp.Name.Substring(1), jp.Value);
                        jp.Replace(jp_new);
                    }
                    else if ((!jp.Name.StartsWith("-")) && 
                        (jPrcBase[IOC].Select(x => x.ToString() == "-" + jp.Name).Contains(true)))
                    {
                        JProperty jp_new = new JProperty("-" + jp.Name, jp.Value);
                        jp.Replace(jp_new);
                    }
                }
            }
        }

        /// <summary>
        /// Insert new vars in program process 
        /// </summary>
        /// <param name="jPrcBase"></param>
        /// <param name="JProgPrc"></param>
        /// <param name="IOC"></param>
        private void Insert_new_vars_in_program_process(JObject jPrcBase, JObject JProgPrc, String IOC)
        {
            if ((jPrcBase[IOC] != null) && ((jPrcBase[IOC] as JArray).Count() > 0))
            {
                foreach (JValue jval in (jPrcBase[IOC] as JArray))
                {
                    if (JProgPrc[IOC][jval.ToString()] == null)
                    {
                        (JProgPrc[IOC] as JObject).Add(jval.ToString(), "");
                    }
                }
            }
        }
        #endregion

        #region Common functions

        /// <summary>
        /// Change value of any jobject property
        /// </summary>
        /// <param name="jNodes"></param>
        /// <param name="ReplacementVarList"></param>
        /// <param name="key"></param>
        /// <param name="changed"></param>
        private void change_prop_in_array(JObject jNodes, String ReplacementVar, String key, ref bool changed)
        {
            if (jNodes != null)
            {
                foreach (JToken jnode in jNodes.Properties())
                {
                    if (((JProperty)jnode).Value.ToString().Equals(key))
                    {
                        ((JProperty)jnode).Value = ReplacementVar;
                        changed = true;
                    }
                }
            }
        }

        #endregion
    }
}

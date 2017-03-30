using System;
using System.Xml;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ARQODE_Core;
using TLogic;
using TControls;
using JSonUtil;
using Newtonsoft.Json.Linq;

namespace ARQODE_APPManager
{
    public class CExportApp
    {
        bool system_app = false;
        String System_code_path = @"System\App\Code";
        String ARQODE_PATH;
        String ARQODE_UI_PATH;
        String SYS_BASE_PROJECT_PATH;
        String SYS_MAPS_PATH;
        String SYS_PATH;

        String APP_VSPROJECT_PATH;
        String APP_PATH;
        String APP_NAME;

        DirectoryInfo DAPP_VIEWS;
        DirectoryInfo DAPP_PRC;
        DirectoryInfo DAPP_PROG;

        #region VS Project vars
        bool changes_in_pj = false;
        XmlDocument x_pj = null;
        XmlNode x_item_group = null;
        Dictionary<String, XmlNode> pj_compile_items = null;
        Dictionary<String, XmlNode> pj_views_compile_items = null;
        #endregion

        public enum enfunctions
        {
            EXPORT_PROCESSES,
            EXPORT_PROGRAMS
        }


        public CExportApp(
            DirectoryInfo _DAPP_VIEWS, DirectoryInfo _DAPP_PRC, DirectoryInfo _DAPP_PROG,
            String _ARQODE_path, String _ARQODE_UI_path, String _SYS_BASE_PROJECT, String _SYS_MAPS_PATH,
            String _APP_VSPROJECT, String _APP_NAME)
        {
            DAPP_VIEWS = _DAPP_VIEWS;
            DAPP_PRC = _DAPP_PRC;
            DAPP_PROG = _DAPP_PROG;

            // System paths
            ARQODE_UI_PATH = _ARQODE_UI_path;
            ARQODE_PATH = _ARQODE_path;
            SYS_BASE_PROJECT_PATH = _SYS_BASE_PROJECT;
            SYS_MAPS_PATH = _SYS_MAPS_PATH;
            SYS_PATH = new DirectoryInfo(SYS_MAPS_PATH).Parent.Parent.FullName;

            // App paths
            APP_VSPROJECT_PATH = _APP_VSPROJECT;
            APP_NAME = _APP_NAME;
            APP_PATH = DAPP_VIEWS.Parent.Parent.FullName;
        }

        public void Export_all(bool _system_app)
        {
            system_app = _system_app;

            // Open VS Project
            Open_VS_Project();

            // Export processes
            ExportProcesses();

            if (!system_app)
            {
                // Export programs
                ExportPrograms();

                // Export views and maps
                CopyViews();
            }
            // save project file
            Save_VS_Project();
        }
        /// <summary>
        /// Call recursive export for processes
        /// </summary>
        private void ExportProcesses()
        {
            // Get code if exists in editor            
            String prc_guid = CLogicEditor.SaveCode(ARQODE_PATH);
            recursive_get_file(DAPP_PRC, enfunctions.EXPORT_PROCESSES, ref prc_guid);

        }
        /// <summary>
        /// Map programs in programs cs file
        /// </summary>
        private void ExportPrograms()
        {
            String prog_cs_base_path = Path.Combine(Path.Combine(SYS_BASE_PROJECT_PATH, dEXPORTCODE.VS_PROGRAMS_PATH), dEXPORTCODE.VS_PROGRAMS_CS);
            String prog_cs_path = Path.Combine(Path.Combine(APP_VSPROJECT_PATH, dEXPORTCODE.VS_PROGRAMS_PATH), dEXPORTCODE.VS_PROGRAMS_CS);
            if (File.Exists(prog_cs_base_path))
            {
                String prog_cs_content = File.ReadAllText(prog_cs_base_path);
                String MapedFile = "";
                recursive_get_file(DAPP_PROG, enfunctions.EXPORT_PROGRAMS, ref MapedFile);

                prog_cs_content = prog_cs_content.Replace(dEXPORTCODE.VS_PROGRAMS_CS_REP, MapedFile);
                File.WriteAllText(prog_cs_path, prog_cs_content);
            }
        }

        /// <summary>
        /// Open project file and get Compile items node from project file
        /// </summary>
        private void Open_VS_Project()
        {

            #region Open project file, create if not exists

            changes_in_pj = false;

            System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
            String project_file = (system_app) ? ARQODE_Core.dGLOBALS.ARQODE + ".csproj" : ARQODE_Core.dGLOBALS.VS_PROJECT_FILE;
            if ((Directory.Exists(APP_VSPROJECT_PATH)) && (new DirectoryInfo(APP_VSPROJECT_PATH).GetFiles(project_file).Length > 0))
            {
                x_pj = new XmlDocument();
                x_pj.Load(new DirectoryInfo(APP_VSPROJECT_PATH).GetFiles(project_file)[0].FullName);
            }

            if (x_pj == null)
            {
                Create_VS_Project();
                x_pj = new XmlDocument();
                x_pj.Load(new DirectoryInfo(APP_VSPROJECT_PATH).GetFiles(dGLOBALS.VS_PROJECT_FILE)[0].FullName);
            }
            #endregion

            #region  Group item for compile, and compile items list

            // Get item group Compile
            x_item_group = null;
            foreach (XmlNode xnode in x_pj[dEXPORTCODE.VS_PJ_PROYECT_NODE].ChildNodes)
            {
                if ((xnode.Name == dEXPORTCODE.VS_PJ_ITEM_GROUP) && (xnode.FirstChild.Name == dEXPORTCODE.VS_PJ_ITEM_COMPILE))
                {
                    x_item_group = xnode;
                    break;
                }
            }

            // fill compile items in Logic\Code
            pj_compile_items = new Dictionary<String, XmlNode>();
            foreach (XmlNode xnode in x_item_group.ChildNodes)
            {
                String code_path = (system_app) ? System_code_path : dEXPORTCODE.VS_CODE_PATH;
                if (xnode.Attributes[dEXPORTCODE.VS_PJ_ATT_INCLUDE].Value.StartsWith(code_path))
                {
                    pj_compile_items.Add(xnode.Attributes[dEXPORTCODE.VS_PJ_ATT_INCLUDE].Value, xnode);
                }
            }

            pj_views_compile_items = new Dictionary<String, XmlNode>();
            foreach (XmlNode xnode in x_item_group.ChildNodes)
            {
                if (xnode.Attributes[dEXPORTCODE.VS_PJ_ATT_INCLUDE].Value.StartsWith(dEXPORTCODE.VS_PJ_UI_PATH))
                {
                    pj_views_compile_items.Add(xnode.Attributes[dEXPORTCODE.VS_PJ_ATT_INCLUDE].Value, xnode);
                }
            }

            #endregion
        }

        private void CopyViews()
        {
            #region ReMap Views

            TLogic.CMap CMap = new CMap(SYS_PATH, APP_PATH, ARQODE_PATH, APP_NAME);
            CMap.MapViews(true);
            #endregion

            String map_views_path = Path.Combine(APP_VSPROJECT_PATH, dEXPORTCODE.VS_PJ_UI_PATH);

            DirectoryInfo source_pj_ui_path = new DirectoryInfo(ARQODE_UI_PATH);

            FileInfo[] views = DAPP_VIEWS.GetFiles("*.json", SearchOption.AllDirectories);
            foreach (FileInfo fview in views)
            {
                if (!fview.Name.Equals(dCONTROLS.BASE_CONTROL)) {
                    try
                    {
                        #region Get SSource file
                        String file_name = fview.Name.Replace(".json", dEXPORTCODE.VIEW_MAP_CS_SUFIX);
                        String relative_path = fview.FullName.Replace(DAPP_VIEWS.FullName, "")
                                                             .Replace(".json", dEXPORTCODE.VIEW_MAP_CS_SUFIX);
                        FileInfo[] sourcefiles = source_pj_ui_path.GetFiles(file_name, SearchOption.AllDirectories);
                        if (sourcefiles.Count() > 0)
                        {
                            DateTime modTime = DateTime.Parse("1/1/200");
                            int i = 0;
                            int lastMod_index = -1;
                            foreach (FileInfo sourcef in sourcefiles)
                            {
                                if (modTime < sourcef.LastWriteTime)
                                {
                                    modTime = sourcef.LastWriteTime;
                                    lastMod_index = i;
                                }
                                i++;
                            }
                            copy_from_relative_path(map_views_path, sourcefiles[lastMod_index],
                                relative_path);
                            #endregion

                            #region get view file

                            file_name = fview.Name.Replace(".json", ".*");
                            FileInfo[] viewsfiles = source_pj_ui_path.GetFiles(file_name, SearchOption.AllDirectories);
                            foreach (FileInfo viewfile in viewsfiles)
                            {
                                if (viewfile.Name.EndsWith(dEXPORTCODE.VS_PJ_DESIGNER_SUF))
                                {
                                    copy_from_relative_path(map_views_path, viewfile,
                                        relative_path.Substring(0, relative_path.LastIndexOf("\\") + 1) + viewfile.Name);
                                }
                                else if ((viewfile.Name.EndsWith(".cs")) && (!viewfile.Name.EndsWith(dEXPORTCODE.VIEW_MAP_CS_SUFIX)))
                                {
                                    copy_from_relative_path(map_views_path, viewfile,
                                        relative_path.Substring(0, relative_path.LastIndexOf("\\") + 1) + viewfile.Name);
                                }
                                else
                                {
                                    copy_from_relative_path(map_views_path, viewfile,
                                        relative_path.Substring(0, relative_path.LastIndexOf("\\") + 1) + viewfile.Name);
                                }
                            }
                            #endregion
                        }
                    }
                    catch (Exception exc)
                    {
                        System.Windows.Forms.MessageBox.Show("Error: " + exc.Message);
                    }
                }
            }

        }
        /// <summary>
        /// Copy from relative path, create folders in destinity if not exists
        /// </summary>
        /// <param name="target_path"></param>
        /// <param name="source_full_path"></param>
        /// <param name="source_relative_path"></param>
        private void copy_from_relative_path(String target_path, FileInfo source_full_path, String source_relative_path)
        {
            String target_full_path = target_path;
            
            foreach (String folder in source_relative_path.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries))
            {
                if ((!folder.EndsWith(".cs")) && (!folder.EndsWith(".resx")))
                {
                    target_full_path = Path.Combine(target_full_path, folder);
                    if (!Directory.Exists(target_full_path)) Directory.CreateDirectory(target_full_path);
                }
            }
            target_full_path = Path.Combine(target_full_path, source_full_path.Name);

            #region Insert into VS project file

            String view_name = source_relative_path.Replace(".cs", "").Replace("\\", ".").Substring(1);
            source_relative_path = dEXPORTCODE.VS_PJ_UI_PATH + source_relative_path;
            // Add node if not founded else remove from pj_compile list
            if (!pj_views_compile_items.ContainsKey(source_relative_path))
            {
                #region Add View map file
                if (source_relative_path.EndsWith(dEXPORTCODE.VIEW_MAP_CS_SUFIX))
                {
                    XmlNode xnode = x_pj.CreateNode(XmlNodeType.Element, dEXPORTCODE.VS_PJ_ITEM_COMPILE, null);
                    XmlAttribute xatt = x_pj.CreateAttribute(dEXPORTCODE.VS_PJ_ATT_INCLUDE);
                    xatt.Value = source_relative_path;
                    xnode.Attributes.Append(xatt);
                    x_item_group.AppendChild(xnode);
                    changes_in_pj = true;
                }
                #endregion
                #region Add Designer file
                else if (source_relative_path.EndsWith(dEXPORTCODE.VS_PJ_DESIGNER_SUF))
                {
                    XmlNode xsubnode = x_pj.CreateNode(XmlNodeType.Element, dEXPORTCODE.VS_PJ_ITEM_COMPILE_DEP, null);
                    XmlNode xsubnode_value = x_pj.CreateNode(XmlNodeType.Text, dEXPORTCODE.VS_PJ_ITEM_COMPILE_DEP, null);
                    xsubnode_value.Value = source_full_path.Name.Replace(dEXPORTCODE.VS_PJ_DESIGNER_SUF, ".cs");
                    xsubnode.AppendChild(xsubnode_value);
                    XmlNode xnode = x_pj.CreateNode(XmlNodeType.Element, dEXPORTCODE.VS_PJ_ITEM_COMPILE, null);
                    XmlAttribute xatt = x_pj.CreateAttribute(dEXPORTCODE.VS_PJ_ATT_INCLUDE);
                    xatt.Value = source_relative_path;
                    xnode.Attributes.Append(xatt);
                    xnode.AppendChild(xsubnode);
                    x_item_group.AppendChild(xnode);
                    changes_in_pj = true;
                }
                #endregion
                #region Add View code file
                else if (source_relative_path.EndsWith(".cs"))
                {
                    CView tview = new CView(new CGlobals(APP_PATH), view_name);
                    XmlNode xsubnode = x_pj.CreateNode(XmlNodeType.Element, dEXPORTCODE.VS_PJ_ITEM_COMPILE_SUBTYPE, null);
                    XmlNode xsubnode_value = x_pj.CreateNode(XmlNodeType.Text, dEXPORTCODE.VS_PJ_ITEM_COMPILE_SUBTYPE, null);
                    xsubnode_value.Value = (tview.mainControl() is System.Windows.Forms.Form) ? "Form" : "UserControl";
                    xsubnode.AppendChild(xsubnode_value);
                    XmlNode xnode = x_pj.CreateNode(XmlNodeType.Element, dEXPORTCODE.VS_PJ_ITEM_COMPILE, null);
                    XmlAttribute xatt = x_pj.CreateAttribute(dEXPORTCODE.VS_PJ_ATT_INCLUDE);
                    xatt.Value = source_relative_path;
                    xnode.Attributes.Append(xatt);
                    xnode.AppendChild(xsubnode);
                    x_item_group.AppendChild(xnode);
                    changes_in_pj = true;
                }
                #endregion
            }
            else
            {
                pj_views_compile_items.Remove(source_relative_path);
            }
            #endregion

            File.Copy(source_full_path.FullName, target_full_path, true);
        }

        /// <summary>
        /// Crear proyecto VS a partir de la copia local en system
        /// </summary>
        private void Create_VS_Project()
        {
            DirectoryInfo origin_path = new DirectoryInfo(SYS_BASE_PROJECT_PATH);
            DirectoryInfo target_path = new DirectoryInfo(APP_VSPROJECT_PATH);

            CopyAll(origin_path, target_path);

            #region Set app name in pj settings

            String pj_main_path = Path.Combine(target_path.FullName, dGLOBALS.BASE_VS_PROJECT_MAIN);
            String pj_main = File.ReadAllText(pj_main_path);
            pj_main = pj_main.Replace(dGLOBALS.VS_PROJECT_NAME, APP_NAME);
            File.WriteAllText(pj_main_path, pj_main);
            #endregion
        }
        /// <summary>
        /// Copia recursiva de ficheros
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }
        /// <summary>
        /// Save VS Project file
        /// </summary>
        private void Save_VS_Project()
        {
            // Remove unused files from VS Project
            int i = 0;
            foreach (XmlNode xnode in pj_compile_items.Values)
            {
                x_item_group.RemoveChild(xnode);
                File.Delete(Path.Combine(APP_VSPROJECT_PATH, pj_compile_items.Keys.ElementAt(i)));
                i++;
                changes_in_pj = true;
            }
            if (!system_app)
            {
                i = 0;
                foreach (XmlNode xnode in pj_views_compile_items.Values)
                {
                    x_item_group.RemoveChild(xnode);
                    File.Delete(Path.Combine(APP_VSPROJECT_PATH, pj_views_compile_items.Keys.ElementAt(i)));
                    i++;
                    changes_in_pj = true;
                }
            }
            if (changes_in_pj)
            {
                String project_file = (system_app) ? ARQODE_Core.dGLOBALS.ARQODE + ".csproj" : dGLOBALS.VS_PROJECT_FILE;
                x_pj.Save(new DirectoryInfo(APP_VSPROJECT_PATH).GetFiles(project_file)[0].FullName);
            }

        }

        /// <summary>
        /// Recursively get .json process files
        /// </summary>
        /// <param name="di"></param>
        /// <param name="enFunction"></param>
        /// <param name="str_temp"></param>
        private void recursive_get_file(DirectoryInfo di, enfunctions enFunction, ref String str_temp)
        {
            foreach (FileInfo fi in di.GetFiles())
            {
                if (enFunction == enfunctions.EXPORT_PROCESSES)
                {
                    Export_Process(fi);
                }
                else if (enFunction == enfunctions.EXPORT_PROGRAMS)
                {
                    Export_Program(fi, ref str_temp);
                }
            }
            foreach (DirectoryInfo di_child in di.GetDirectories())
            {
                recursive_get_file(di_child, enFunction, ref str_temp);
            }
        }

        private void Export_Program(FileInfo fi, ref String programs_list)
        {
            if (fi.Name != "base_program.json")
            {
                String ns = fi.FullName.Replace(DAPP_PROG.FullName + "\\", "").Replace("\\", ".").Replace(".json", "");
                JSonFile jProcess = new JSonFile(fi.FullName);
                programs_list += String.Format("\t\t\tLPrograms.Add(\"{0}\", \"{1}\"); \n",
                ns,
                Convert.ToBase64String(System.Text.UTF8Encoding.UTF8.GetBytes(jProcess.jActiveObj.ToString())));
            }          
        }

        /// <summary>
        /// Export process to code folder in vs project
        /// </summary>
        /// <param name="fi"></param>
        /// <param name="mapedFile"></param>
        private void Export_Process(FileInfo fi)
        {
            #region Mapped process template file

            FileInfo f_prc_template = new DirectoryInfo(SYS_MAPS_PATH).GetFiles(dGLOBALS.MAPS_PROCESS)[0];
            String prc_template = File.ReadAllText(f_prc_template.FullName);
            #endregion

            #region Loop into processes

            JSonFile jProcess = new JSonFile(fi.FullName);
            if ((jProcess.jActiveObj[dPROCESS.PROCESSES] != null) && (fi.Name != "base_process.json"))
            {
                String functions = "";
                String base_processes = "";

                #region create path to code

                // export code to 
                String code_path = (system_app) ? System_code_path : dEXPORTCODE.VS_CODE_PATH;
                String codeMapPath = Path.Combine(APP_VSPROJECT_PATH, code_path);                    

                String processes_path = DAPP_PRC.FullName;
                String file_path = fi.FullName.Replace(processes_path, "");
                String relative_path = "";
                String filename = "";
                foreach (String dir in file_path.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (!dir.Contains(".json"))
                    {
                        relative_path = Path.Combine(relative_path, dir);
                        if (!Directory.Exists(Path.Combine(codeMapPath, relative_path)))
                        {
                            Directory.CreateDirectory(Path.Combine(codeMapPath, relative_path));
                        }
                    }
                    else
                    {
                        filename = dir.Replace(".json", ".cs");
                    }
                }
                #endregion

                #region Get code from logic and insert into process file

                foreach (JToken Jnode in jProcess.jActiveObj[dPROCESS.PROCESSES] as JArray)
                {
                    // Get code from logic
                    String Guid = Jnode[dPROCESS.GUID].ToString();
                    String Name = (Jnode[dPROCESS.NAME] != null) ? Jnode[dPROCESS.NAME].ToString() : "";
                    String Desciption = (Jnode[dPROCESS.DESCRIPTION] != null) ? Jnode[dPROCESS.DESCRIPTION].ToString() : "";
                    String prc_code = CLogicEditor.get_Code_from_logic(ARQODE_PATH, Guid);

                    if ((prc_code == "") && (Jnode[dPROCESS.CODE] != null) && (Jnode[dPROCESS.CODE].ToString() != ""))
                    {
                        prc_code = System.Text.UTF8Encoding.UTF8.GetString(Convert.FromBase64String(Jnode[dPROCESS.CODE].ToString()));
                    }                    
                    if (prc_code != "")
                    {
                        // Save into current process
                        Jnode[dPROCESS.CODE] = Convert.ToBase64String(System.Text.UTF8Encoding.UTF8.GetBytes(prc_code));

                        // write replaced template file to mapped folder. Renaming guid to valid function name
                        functions += dEXPORTCODE.F_TEMPLATE.
                            Replace(dEXPORTCODE.F_NAME, Name).
                            Replace(dEXPORTCODE.F_DESCRIPTION, Desciption).
                            Replace(dEXPORTCODE.F_FUNCTION_NAME, Utils.escape_sc(Guid)).
                            Replace(dEXPORTCODE.F_CODE, prc_code);
                    }

                    #region Save base process string

                    JToken base_prc = Jnode.DeepClone();
                    if (Jnode[dPROCESS.CODE] != null)
                    {
                        ((JObject)base_prc).Property(dPROCESS.CODE).Remove();
                    }
                    base_processes += "public static string BP_"+ Utils.escape_sc(Guid) + 
                        " { get { return \""+
                        Convert.ToBase64String(System.Text.UTF8Encoding.UTF8.GetBytes(base_prc.ToString()))
                        + "\"; } } \r\n";
                    #endregion
                }
                jProcess.Write();
                #endregion

                if (functions != "")
                {
                    #region Save process file 

                    prc_template = prc_template
                        .Replace(dEXPORTCODE.F_FUNCTIONS, functions)            // Replace functions
                        .Replace(dEXPORTCODE.F_BASE_PROCESSES, base_processes); // Replace base processs strings

                    File.WriteAllText(Path.Combine(codeMapPath, Path.Combine(relative_path, filename)), prc_template);
                    #endregion

                    #region Insert into VS project file

                    // Add node if not founded else remove from pj_compile list
                    if (!pj_compile_items.ContainsKey(Path.Combine(code_path, Path.Combine(relative_path, filename))))
                    {
                        XmlNode xnode = x_pj.CreateNode(XmlNodeType.Element, dEXPORTCODE.VS_PJ_ITEM_COMPILE, null);
                        XmlAttribute xatt = x_pj.CreateAttribute(dEXPORTCODE.VS_PJ_ATT_INCLUDE);
                        xatt.Value = Path.Combine(code_path, Path.Combine(relative_path, filename));
                        xnode.Attributes.Append(xatt);
                        x_item_group.AppendChild(xnode);
                        changes_in_pj = true;
                    }
                    else
                    {
                        pj_compile_items.Remove(Path.Combine(code_path, Path.Combine(relative_path, filename)));
                    }
                    #endregion
                }
            }
            #endregion

        }

    }
}

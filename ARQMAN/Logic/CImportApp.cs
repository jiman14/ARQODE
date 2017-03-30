using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ARQODE_Core;
using TLogic;
using TControls;
using JSonUtil;
using Newtonsoft.Json.Linq;

namespace ARQODE_APPManager
{
    public class CImportApp
    {
        String ARQODE_PATH;
        String ARQODE_UI_PATH;

        String SYS_MAPS_PATH;

        String APP_VSPROJECT_PATH;
        String APP_NAME;

        DirectoryInfo DAPP_PRC;

        public CImportApp(
            DirectoryInfo _DAPP_PRC, 
            String _ARQODE_path, String _ARQODE_UI_path, String _SYS_MAPS_PATH,
            String _APP_VSPROJECT, String _APP_NAME)
        {
            DAPP_PRC = _DAPP_PRC;

            // System paths
            ARQODE_UI_PATH = _ARQODE_UI_path;
            ARQODE_PATH = _ARQODE_path;
            SYS_MAPS_PATH = _SYS_MAPS_PATH;
            // App paths
            APP_VSPROJECT_PATH = _APP_VSPROJECT;
            APP_NAME = _APP_NAME;
        }

        /// <summary>
        /// Import code and views
        /// </summary>
        public void ImportAll(bool debug_system = false)
        {
            ImportUI(debug_system, APP_VSPROJECT_PATH, ARQODE_PATH);

            ImportCode();            
        }

        /// <summary>
        /// Import code from json processes
        /// </summary>
        /// <param name="SOURCE_PATH"></param>
        /// <param name="TARGET_PATH"></param>
        private void ImportCode()
        {
            // Replace processes with clean map file

            String map_processes_path = Path.Combine(SYS_MAPS_PATH, dGLOBALS.MAPS_PROCESSES);
            String processes_path = Path.Combine(ARQODE_PATH, dEXPORTCODE.P_LOGIC_CS);

            File.Copy(map_processes_path, processes_path, true);
            
            // Load logic file, fill with processes and save

            String logicfile_path = Path.Combine(ARQODE_PATH, dEXPORTCODE.P_LOGIC_CS);
            String logicfile = File.ReadAllText(logicfile_path);

            recursive_get_file(DAPP_PRC, ref logicfile);

            File.WriteAllText(logicfile_path, logicfile);            
        }

        /// <summary>
        /// Recursively get .json process files
        /// </summary>
        /// <param name="di"></param>
        /// <param name="enFunction"></param>
        /// <param name="MapedFile"></param>
        private void recursive_get_file(DirectoryInfo di, ref String logicfile)
        {
            foreach (FileInfo fi in di.GetFiles())
            {
                Import_Process(fi, ref logicfile);
            }
            foreach (DirectoryInfo di_child in di.GetDirectories())
            {
                recursive_get_file(di_child, ref logicfile);
            }
        }
        /// <summary>
        /// Insert code process in logic
        /// </summary>
        /// <param name="fi"></param>
        private void Import_Process(FileInfo fi, ref String logicfile)
        {
            JSonFile jProcess = new JSonFile(fi.FullName);

            // Iterate in nodes
            if (jProcess.jActiveObj[dPROCESS.PROCESSES] != null)
            {                
                foreach (JToken Jnode in jProcess.jActiveObj[dPROCESS.PROCESSES] as JArray)
                {
                    String prc_guid = Jnode[dPROCESS.GUID].ToString();
                    String codigo_prc_editor = (Jnode[dPROCESS.CODE] != null)?
                        System.Text.UTF8Encoding.UTF8.GetString(Convert.FromBase64String(Jnode[dPROCESS.CODE].ToString())): "";

                    // buscar marca de fin en el fichero de lógica e insertar ahí el código del editor

                    int ini_code = logicfile.IndexOf(dEXPORTCODE.P_End_logic_code);
                    if (ini_code > 0)
                    {
                        // poner case
                        String Init_case = String.Format("\t\t\t\t\tcase \"{0}\":\n", prc_guid) + "{\n";
                        String End_case = "\n\t\t\t\t\t}\nbreak;\n";

                        logicfile = logicfile.Insert(ini_code - 1, Init_case + codigo_prc_editor + End_case);
                    }
                }
            }
        }
        /// <summary>
        /// Import UI files
        /// </summary>
        /// <param name="SOURCE_PATH"></param>
        /// <param name="TARGET_ARQODE_PATH"></param>
        private void ImportUI(bool debug_system, String SOURCE_PATH, String TARGET_ARQODE_PATH)
        {
            #region Open Target project file

            String ARQODE_VSPROJECT_PATH = Path.Combine(TARGET_ARQODE_PATH, dGLOBALS.ARQODE + ".csproj");

            XmlDocument xArqode_pj = new XmlDocument();
            XmlNode xArqode_item_group = null;
            if (File.Exists(ARQODE_VSPROJECT_PATH))
            {
                xArqode_pj.Load(ARQODE_VSPROJECT_PATH);

                // Get item group Compile
                foreach (XmlNode xnode in xArqode_pj[dEXPORTCODE.VS_PJ_PROYECT_NODE].ChildNodes)
                {
                    if ((xnode.Name == dEXPORTCODE.VS_PJ_ITEM_GROUP) && (xnode.FirstChild.Name == dEXPORTCODE.VS_PJ_ITEM_COMPILE))
                    {
                        xArqode_item_group = xnode;
                        break;
                    }
                }
            }
            #endregion

            #region Open VS Source project file

            XmlNode xApp_item_group = null;
            if (!debug_system)
            {
                String VSPROJECT_PATH = Path.Combine(SOURCE_PATH, dGLOBALS.VS_PROJECT_FILE);

                XmlDocument xApp_pj = new XmlDocument();
                if (File.Exists(VSPROJECT_PATH))
                {
                    xApp_pj.Load(VSPROJECT_PATH);

                    // Get item group Compile
                    foreach (XmlNode xnode in xApp_pj[dEXPORTCODE.VS_PJ_PROYECT_NODE].ChildNodes)
                    {
                        if ((xnode.Name == dEXPORTCODE.VS_PJ_ITEM_GROUP) && (xnode.FirstChild.Name == dEXPORTCODE.VS_PJ_ITEM_COMPILE))
                        {
                            xApp_item_group = xnode;
                            break;
                        }
                    }
                }
            }
            #endregion

            #region  Remove UI files and nodes in vs project file
            
            int i = 0;
            while (i < xArqode_item_group.ChildNodes.Count)
            {
                XmlNode xnode = xArqode_item_group.ChildNodes[i];
                if (xnode.Attributes[dEXPORTCODE.VS_PJ_ATT_INCLUDE].Value.StartsWith(dEXPORTCODE.VS_PJ_UI_PATH))
                {
                    try
                    {
                        File.Delete(Path.Combine(TARGET_ARQODE_PATH, xnode.Attributes[dEXPORTCODE.VS_PJ_ATT_INCLUDE].Value));
                    }
                    catch { }
                    xArqode_item_group.RemoveChild(xnode);
                }
                else
                {
                    i++;
                }
            }
            try
            {
                Directory.Delete(Path.Combine(TARGET_ARQODE_PATH, ARQODE_Core.dEXPORTCODE.VS_PJ_UI_PATH), true);
            }
            catch { System.Windows.Forms.MessageBox.Show("Error eliminando carpeta UI en ARQODE Manager"); }
            try
            {
                Directory.CreateDirectory(Path.Combine(TARGET_ARQODE_PATH, ARQODE_Core.dEXPORTCODE.VS_PJ_UI_PATH));
            }
            catch { }
            #endregion

            #region Copy UI files and insert nodes in vs project file
            if (xApp_item_group != null)
            {
                foreach (XmlNode xnode in xApp_item_group.ChildNodes)
                {
                    if (xnode.Attributes[dEXPORTCODE.VS_PJ_ATT_INCLUDE].Value.StartsWith(dEXPORTCODE.VS_PJ_UI_PATH))
                    {
                        String dir = xnode.Attributes[dEXPORTCODE.VS_PJ_ATT_INCLUDE].Value;
                        dir = dir.Substring(0, dir.LastIndexOf("\\") + 1);
                        if (!Directory.Exists(Path.Combine(TARGET_ARQODE_PATH, dir)))
                        {
                            Directory.CreateDirectory(Path.Combine(TARGET_ARQODE_PATH, dir));
                        }
                        File.Copy(
                            Path.Combine(SOURCE_PATH, xnode.Attributes[dEXPORTCODE.VS_PJ_ATT_INCLUDE].Value),
                            Path.Combine(TARGET_ARQODE_PATH, xnode.Attributes[dEXPORTCODE.VS_PJ_ATT_INCLUDE].Value), true);

                        XmlNode importNode = xArqode_pj.ImportNode(xnode, true);
                        xArqode_item_group.AppendChild(importNode);
                    }
                }
            }
            #endregion

            #region Save project file

            xArqode_pj.Save(ARQODE_VSPROJECT_PATH);
            #endregion
        }
    }
}

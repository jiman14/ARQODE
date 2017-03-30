using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ARQODE_APPManager
{
    public partial class MainView : Form
    {
        #region Initialize

        string userProfile;
        DirectoryInfo dApps;
        static String aARQODE_SLN_path;
        static String rTargetProject_path;
        static String aVS2017_path = @"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\devenv.exe";

        // Export system base paths
        static String aARQODE_path;
        String rARQODE_UI = "UI";

        String aSYS_DATA_GLOBALS;
        String aSYS_BASE_PROJECT;
        String aSYS_BASE_APP;
        String aSYS_MAPS_PATH;

        // Export app base paths
        String rAPP_VSPROJECT;
        String rAPP_VIEWS_PATH;
        String rAPP_PRC_PATH;
        String rAPP_PROG_PATH;

        /// <summary>
        /// Initialize all paths to system an apps
        /// </summary>
        public MainView()
        {
            InitializeComponent();

            String ARQMAN_Path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            DirectoryInfo dARQMAN = new DirectoryInfo(ARQMAN_Path);
            DirectoryInfo dARQODE = new DirectoryInfo(dARQMAN.FullName).Parent;
            while ((dARQODE != null) && (dARQODE.GetDirectories(ARQODE_Core.dGLOBALS.ARQODE).Length == 0))
            {
                dARQODE = dARQODE.Parent;
            }
            aARQODE_path = dARQODE.GetDirectories(ARQODE_Core.dGLOBALS.ARQODE)[0].FullName;
            dApps = dARQODE.GetDirectories(ARQODE_Core.dGLOBALS.APPS)[0];
            aSYS_BASE_PROJECT = Path.Combine(dApps.FullName,
                                    Path.Combine(ARQODE_Core.dGLOBALS.SYSTEM_APP,
                                        Path.Combine(ARQODE_Core.dGLOBALS.DATA_PATH, ARQODE_Core.dGLOBALS.BASE_VS_PROJECT_PATH)));

            aSYS_BASE_APP = Path.Combine(dApps.FullName,
                                    Path.Combine(ARQODE_Core.dGLOBALS.SYSTEM_APP,
                                        Path.Combine(ARQODE_Core.dGLOBALS.DATA_PATH, ARQODE_Core.dGLOBALS.BASE_APP)));

            aSYS_MAPS_PATH = Path.Combine(dApps.FullName,
                                    Path.Combine(ARQODE_Core.dGLOBALS.SYSTEM_APP, TLogic.dPATH.MAPS.Replace(".", "\\")));

            aSYS_DATA_GLOBALS = Path.Combine(dApps.FullName,
                                    Path.Combine(ARQODE_Core.dGLOBALS.SYSTEM_APP,
                                        Path.Combine(ARQODE_Core.dGLOBALS.DATA_PATH, ARQODE_Core.dGLOBALS.GLOBALS + ".json")));

            aARQODE_SLN_path = Path.Combine(aARQODE_path, ARQODE_Core.dGLOBALS.ARQODE + ".sln");

            rTargetProject_path = Path.Combine(ARQODE_Core.dGLOBALS.APPDATA_PATH, ARQODE_Core.dGLOBALS.VS_PROJECT_PATH);

            userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            TBApps_path.Text = Path.Combine(dARQODE.FullName, ARQODE_Core.dGLOBALS.APPS);

            // Relative app paths
            rAPP_VIEWS_PATH = TControls.dCONTROLS.PATH.Replace(".", "\\");
            rAPP_PRC_PATH = TLogic.dPATH.PROCESSES.Replace(".", "\\");
            rAPP_PROG_PATH = TLogic.dPATH.PROGRAM.Replace(".", "\\");
            rAPP_VSPROJECT = Path.Combine(ARQODE_Core.dGLOBALS.APPDATA_PATH, ARQODE_Core.dGLOBALS.VS_PROJECT_PATH);

            InitializeRegistry();
        }

        /// <summary>
        /// Update apps path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BUpdate_AppPaths_Click(object sender, EventArgs e)
        {
            InitializeRegistry();
        }

        /// <summary>
        ///  Initialize registry apps
        /// </summary>
        private void InitializeRegistry()
        {
            lactiveapp.Text = ActiveAPP;

            if (Directory.Exists(TBApps_path.Text))
            {
                DirectoryInfo di = new DirectoryInfo(TBApps_path.Text);
                LApps.Items.Clear();
                LApps.DisplayMember = "Key";
                LApps.ValueMember = "Value";
                foreach (DirectoryInfo dapp in di.GetDirectories())
                {
                    LApps.Items.Add(new KeyValuePair<String, String>(dapp.Name, dapp.FullName));
                    if ((LApps.Text != "") && (LApps.Text == dapp.FullName))
                        LApps.SelectedIndex = LApps.Items.Count - 1;
                }
            }
        }

        /// <summary>
        /// Get active app name
        /// </summary>
        private String ActiveAPP
        {
            get
            {
                JSonUtil.JSonFile jGlobals = new JSonUtil.JSonFile(aSYS_DATA_GLOBALS);
                return jGlobals.jActiveObj[ARQODE_Core.dGLOBALS.GLOBALS]["Active app"].ToString();
            }
            set
            {
                JSonUtil.JSonFile jGlobals = new JSonUtil.JSonFile(aSYS_DATA_GLOBALS);
                jGlobals.jActiveObj[ARQODE_Core.dGLOBALS.GLOBALS]["Active app"] = value;
                jGlobals.Write();
            }
        }

        #endregion

        #region Load app
        private void LoadApp()
        {
            if (LApps.SelectedIndex >= 0)
            {
                if (!((KeyValuePair<String, String>)LApps.SelectedItem).Value.EndsWith("\\" + ActiveAPP))
                {
                    ImportActiveApp();
                }

                System.Diagnostics.Process.Start(aVS2017_path,
                    String.Format("\"{0}\" /Run Debug /log", aARQODE_SLN_path));
            }

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadApp();
        }
        private void LApps_DoubleClick(object sender, EventArgs e)
        {
            LoadApp();
        }
        #endregion

        #region Import & Export

        private void ImportActiveApp()
        {
            if (!((KeyValuePair<String, String>)LApps.SelectedItem).Value.EndsWith("\\" + ActiveAPP))
            {
                ExportActiveApp();
            }
            if (LApps.SelectedIndex >= 0)
            {
                String app = ((KeyValuePair<String, String>)LApps.SelectedItem).Value;
                String app_name = ((KeyValuePair<String, String>)LApps.SelectedItem).Key;

                // system paths
                String aARQODE_UI_path = Path.Combine(aARQODE_path, rARQODE_UI);

                // app paths                
                String aAPP_VSPROJECT = Path.Combine(app, rAPP_VSPROJECT);
                
                String codefile_path = Path.Combine(aARQODE_path, ARQODE_Core.dEXPORTCODE.P_CODER_CS);
                if (!IsFileLocked(codefile_path))
                {
                    CImportApp cexp = new CImportApp(
                        new DirectoryInfo(Path.Combine(app, rAPP_PRC_PATH)),
                        aARQODE_path, aARQODE_UI_path, aSYS_MAPS_PATH,
                        aAPP_VSPROJECT, app_name);

                    cexp.ImportAll(app_name == ARQODE_Core.dGLOBALS.SYSTEM_APP);

                    ActiveAPP = app_name;
                    lactiveapp.Text = app_name;

                    MessageBox.Show("App importada: " + app_name);
                }
                else
                {
                    MessageBox.Show(String.Format("El proyecto '{0}' está bloqueado. Cierra Visual Studio primero.", app_name));
                }
            }
        }
        private void BImportarApp_Click(object sender, EventArgs e)
        {
            ImportActiveApp();
        }

        private void ExportActiveApp()
        {
            String app_name = ActiveAPP;
            String app = Path.Combine(dApps.FullName, ActiveAPP);
            bool system_app = app_name == ARQODE_Core.dGLOBALS.SYSTEM_APP;

            // system paths
            String aARQODE_UI_path = Path.Combine(aARQODE_path, rARQODE_UI);

            // app paths                            
            String app_VSPROJECT = (!system_app)? Path.Combine(app, rAPP_VSPROJECT):
                aARQODE_path;
            String project_file = (system_app) ? ARQODE_Core.dGLOBALS.ARQODE + ".csproj" : ARQODE_Core.dGLOBALS.VS_PROJECT_FILE;

            if (!IsFileLocked(Path.Combine(app_VSPROJECT, project_file)))
            {
                CExportApp cexp = new CExportApp(
                    new DirectoryInfo(Path.Combine(app, rAPP_VIEWS_PATH)),
                    new DirectoryInfo(Path.Combine(app, rAPP_PRC_PATH)),
                    new DirectoryInfo(Path.Combine(app, rAPP_PROG_PATH)),
                    aARQODE_path, aARQODE_UI_path, aSYS_BASE_PROJECT, aSYS_MAPS_PATH,
                    app_VSPROJECT, app_name);

                cexp.Export_all(system_app);

                MessageBox.Show("App exportada: " + app_name);
            }
            else
            {
                MessageBox.Show(String.Format("El proyecto '{0}' está bloqueado. Cierra Visual Studio primero.", app_name));
            }
        }
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportActiveApp();
        }
        #endregion

        #region Utils: check file locked

        protected bool IsFileLocked(String file)
        {
            return IsFileLocked(new FileInfo(file));
        }
        protected bool IsFileLocked(FileInfo file)
        {
            if ((file != null) && (File.Exists(file.FullName)))
            {
                FileStream stream = null;

                try
                {
                    stream = file.Open(FileMode.Open, FileAccess.Write, FileShare.None);
                }
                catch (IOException)
                {
                    //the file is unavailable because it is:
                    //still being written to
                    //or being processed by another thread
                    //or does not exist (has already been processed)
                    return true;
                }
                finally
                {
                    if (stream != null)
                        stream.Close();
                }
            }

            //file is not locked
            return false;
        }
        #endregion

        #region New application

        private void newApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ARQODE_VISUAL_EDITOR.ARQODE_UI.InputDialog ib = new ARQODE_VISUAL_EDITOR.ARQODE_UI.InputDialog();
            ib.Text = "Crear aplicación";
            Label lin = (Label)ib.Controls.Find("Label1", true)[0];
            lin.Text = "Nombre aplicación";
            if (ib.ShowDialog() == DialogResult.OK)
            {
                TextBox tbin = (TextBox)ib.Controls.Find("textBox1", true)[0];
                if (tbin.Text.Trim() != "")
                {
                    CExportApp.CopyAll(new DirectoryInfo(aSYS_BASE_APP), new DirectoryInfo(Path.Combine(TBApps_path.Text, tbin.Text)));
                    BUpdate_AppPaths_Click(null, null);
                    MessageBox.Show(String.Format("Aplicación '{0}' creada correctamente.", tbin.Text));
                }
            }
        }
        #endregion

    }
}


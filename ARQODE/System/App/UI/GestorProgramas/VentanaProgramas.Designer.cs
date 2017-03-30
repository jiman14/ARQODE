namespace ARQODE_VISUAL_EDITOR.ARQODE_UI
{
    partial class VentanaProgramas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaProgramas));
            this.PTop = new System.Windows.Forms.Panel();
            this.PListaProcesos = new System.Windows.Forms.Panel();
            this.ListaProcesos = new System.Windows.Forms.DataGridView();
            this.contextMenu_LProcesos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.irAlProcesoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.subirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bajarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarReferenciasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.callprogramaPreviamenteCortadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verCódigoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarCódigoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelArbolProgramas = new System.Windows.Forms.Panel();
            this.ArbolProgramas = new System.Windows.Forms.TreeView();
            this.contextMenu_Programas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cortarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pegarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaCarpetaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renombrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignarAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarReferenciasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.importarProgramaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarProgramaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PProcesses = new System.Windows.Forms.Panel();
            this.MenuTop = new System.Windows.Forms.ToolStrip();
            this.Menu_Errores_UI = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Menu_Errores_programa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Menu_Debug = new System.Windows.Forms.ToolStripButton();
            this.Apps_tsb = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.TB_Buscador = new System.Windows.Forms.ToolStripTextBox();
            this.B_BuscarEnTodo = new System.Windows.Forms.ToolStripButton();
            this.B_BuscarPROG = new System.Windows.Forms.ToolStripButton();
            this.B_BuscarPRC = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.Menu_CheckIOC = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_AutoCheckErrors = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_Historico = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_RunApp = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_MapUI = new System.Windows.Forms.ToolStripButton();
            this.PTop.SuspendLayout();
            this.PListaProcesos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListaProcesos)).BeginInit();
            this.contextMenu_LProcesos.SuspendLayout();
            this.PanelArbolProgramas.SuspendLayout();
            this.contextMenu_Programas.SuspendLayout();
            this.MenuTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // PTop
            // 
            this.PTop.Controls.Add(this.PListaProcesos);
            this.PTop.Controls.Add(this.PanelArbolProgramas);
            this.PTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PTop.Location = new System.Drawing.Point(0, 25);
            this.PTop.Name = "PTop";
            this.PTop.Size = new System.Drawing.Size(1212, 222);
            this.PTop.TabIndex = 3;
            // 
            // PListaProcesos
            // 
            this.PListaProcesos.Controls.Add(this.ListaProcesos);
            this.PListaProcesos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PListaProcesos.Location = new System.Drawing.Point(400, 0);
            this.PListaProcesos.Name = "PListaProcesos";
            this.PListaProcesos.Size = new System.Drawing.Size(812, 222);
            this.PListaProcesos.TabIndex = 3;
            // 
            // ListaProcesos
            // 
            this.ListaProcesos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListaProcesos.ContextMenuStrip = this.contextMenu_LProcesos;
            this.ListaProcesos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaProcesos.Location = new System.Drawing.Point(0, 0);
            this.ListaProcesos.Name = "ListaProcesos";
            this.ListaProcesos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.ListaProcesos.Size = new System.Drawing.Size(812, 222);
            this.ListaProcesos.TabIndex = 0;
            // 
            // contextMenu_LProcesos
            // 
            this.contextMenu_LProcesos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.irAlProcesoToolStripMenuItem,
            this.eliminarToolStripMenuItem1,
            this.subirToolStripMenuItem,
            this.bajarToolStripMenuItem,
            this.buscarReferenciasToolStripMenuItem,
            this.callprogramaPreviamenteCortadoToolStripMenuItem,
            this.verCódigoToolStripMenuItem,
            this.editarCódigoToolStripMenuItem});
            this.contextMenu_LProcesos.Name = "contextMenu_LProcesos";
            this.contextMenu_LProcesos.Size = new System.Drawing.Size(236, 180);
            // 
            // irAlProcesoToolStripMenuItem
            // 
            this.irAlProcesoToolStripMenuItem.Name = "irAlProcesoToolStripMenuItem";
            this.irAlProcesoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.irAlProcesoToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.irAlProcesoToolStripMenuItem.Tag = "Gestión de Programas.Procesos del programa.Ir al proceso activo";
            this.irAlProcesoToolStripMenuItem.Text = "Go to process";
            // 
            // eliminarToolStripMenuItem1
            // 
            this.eliminarToolStripMenuItem1.Name = "eliminarToolStripMenuItem1";
            this.eliminarToolStripMenuItem1.Size = new System.Drawing.Size(235, 22);
            this.eliminarToolStripMenuItem1.Tag = "Gestión de Programas.Procesos del programa.Eliminar proceso";
            this.eliminarToolStripMenuItem1.Text = "Delete";
            // 
            // subirToolStripMenuItem
            // 
            this.subirToolStripMenuItem.Name = "subirToolStripMenuItem";
            this.subirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.subirToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.subirToolStripMenuItem.Tag = "Gestión de Programas.Procesos del programa.Subir proceso";
            this.subirToolStripMenuItem.Text = "Up position";
            // 
            // bajarToolStripMenuItem
            // 
            this.bajarToolStripMenuItem.Name = "bajarToolStripMenuItem";
            this.bajarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.bajarToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.bajarToolStripMenuItem.Tag = "Gestión de Programas.Procesos del programa.Bajar proceso";
            this.bajarToolStripMenuItem.Text = "Down position";
            // 
            // buscarReferenciasToolStripMenuItem
            // 
            this.buscarReferenciasToolStripMenuItem.Name = "buscarReferenciasToolStripMenuItem";
            this.buscarReferenciasToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.buscarReferenciasToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.buscarReferenciasToolStripMenuItem.Tag = "Gestión de Programas.Información.Buscar referencias a un proceso";
            this.buscarReferenciasToolStripMenuItem.Text = "Search refs";
            // 
            // callprogramaPreviamenteCortadoToolStripMenuItem
            // 
            this.callprogramaPreviamenteCortadoToolStripMenuItem.Name = "callprogramaPreviamenteCortadoToolStripMenuItem";
            this.callprogramaPreviamenteCortadoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.callprogramaPreviamenteCortadoToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.callprogramaPreviamenteCortadoToolStripMenuItem.Tag = "Gestión de Programas.Gestión del call.Asignar call al programa activo";
            this.callprogramaPreviamenteCortadoToolStripMenuItem.Text = "Call (cut one PRG first)";
            // 
            // verCódigoToolStripMenuItem
            // 
            this.verCódigoToolStripMenuItem.Name = "verCódigoToolStripMenuItem";
            this.verCódigoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.verCódigoToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.verCódigoToolStripMenuItem.Tag = "Gestión de Programas.Información.Ver código del proceso";
            this.verCódigoToolStripMenuItem.Text = "View code";
            // 
            // editarCódigoToolStripMenuItem
            // 
            this.editarCódigoToolStripMenuItem.Name = "editarCódigoToolStripMenuItem";
            this.editarCódigoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.editarCódigoToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.editarCódigoToolStripMenuItem.Text = "Edit code";
            // 
            // PanelArbolProgramas
            // 
            this.PanelArbolProgramas.Controls.Add(this.ArbolProgramas);
            this.PanelArbolProgramas.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelArbolProgramas.Location = new System.Drawing.Point(0, 0);
            this.PanelArbolProgramas.Name = "PanelArbolProgramas";
            this.PanelArbolProgramas.Size = new System.Drawing.Size(400, 222);
            this.PanelArbolProgramas.TabIndex = 1;
            // 
            // ArbolProgramas
            // 
            this.ArbolProgramas.ContextMenuStrip = this.contextMenu_Programas;
            this.ArbolProgramas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArbolProgramas.HideSelection = false;
            this.ArbolProgramas.Location = new System.Drawing.Point(0, 0);
            this.ArbolProgramas.Name = "ArbolProgramas";
            this.ArbolProgramas.Size = new System.Drawing.Size(400, 222);
            this.ArbolProgramas.TabIndex = 0;
            // 
            // contextMenu_Programas
            // 
            this.contextMenu_Programas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.cortarToolStripMenuItem,
            this.pegarToolStripMenuItem,
            this.eliminarToolStripMenuItem,
            this.nuevaCarpetaToolStripMenuItem,
            this.renombrarToolStripMenuItem,
            this.asignarAToolStripMenuItem,
            this.buscarReferenciasToolStripMenuItem1,
            this.importarProgramaToolStripMenuItem,
            this.exportarProgramaToolStripMenuItem});
            this.contextMenu_Programas.Name = "contextMenu_Programas";
            this.contextMenu_Programas.Size = new System.Drawing.Size(210, 224);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.nuevoToolStripMenuItem.Tag = "Gestión de Programas.Estructuración.Abrir ficha de programa";
            this.nuevoToolStripMenuItem.Text = "New";
            // 
            // cortarToolStripMenuItem
            // 
            this.cortarToolStripMenuItem.Name = "cortarToolStripMenuItem";
            this.cortarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cortarToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.cortarToolStripMenuItem.Tag = "Gestión de Programas.Estructuración.Cortar";
            this.cortarToolStripMenuItem.Text = "Cut";
            // 
            // pegarToolStripMenuItem
            // 
            this.pegarToolStripMenuItem.Enabled = false;
            this.pegarToolStripMenuItem.Name = "pegarToolStripMenuItem";
            this.pegarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pegarToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.pegarToolStripMenuItem.Tag = "Gestión de Programas.Estructuración.Pegar";
            this.pegarToolStripMenuItem.Text = "Paste";
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.eliminarToolStripMenuItem.Tag = "Gestión de Programas.Estructuración.Eliminar programa";
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            // 
            // nuevaCarpetaToolStripMenuItem
            // 
            this.nuevaCarpetaToolStripMenuItem.Name = "nuevaCarpetaToolStripMenuItem";
            this.nuevaCarpetaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.nuevaCarpetaToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.nuevaCarpetaToolStripMenuItem.Tag = "Gestión de Programas.Estructuración.Nueva carpeta";
            this.nuevaCarpetaToolStripMenuItem.Text = "New folder";
            // 
            // renombrarToolStripMenuItem
            // 
            this.renombrarToolStripMenuItem.Name = "renombrarToolStripMenuItem";
            this.renombrarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.renombrarToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.renombrarToolStripMenuItem.Tag = "Gestión de Programas.Estructuración.Renombrar";
            this.renombrarToolStripMenuItem.Text = "Rename";
            // 
            // asignarAToolStripMenuItem
            // 
            this.asignarAToolStripMenuItem.Name = "asignarAToolStripMenuItem";
            this.asignarAToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.asignarAToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.asignarAToolStripMenuItem.Tag = "Gestión de controles.Cargar ventana";
            this.asignarAToolStripMenuItem.Text = "Set control events";
            // 
            // buscarReferenciasToolStripMenuItem1
            // 
            this.buscarReferenciasToolStripMenuItem1.Name = "buscarReferenciasToolStripMenuItem1";
            this.buscarReferenciasToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.buscarReferenciasToolStripMenuItem1.Size = new System.Drawing.Size(209, 22);
            this.buscarReferenciasToolStripMenuItem1.Tag = "Gestión de Programas.Información.Buscar referencias a un programa";
            this.buscarReferenciasToolStripMenuItem1.Text = "Search refs";
            // 
            // importarProgramaToolStripMenuItem
            // 
            this.importarProgramaToolStripMenuItem.Name = "importarProgramaToolStripMenuItem";
            this.importarProgramaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.importarProgramaToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.importarProgramaToolStripMenuItem.Text = "Import PRG";
            // 
            // exportarProgramaToolStripMenuItem
            // 
            this.exportarProgramaToolStripMenuItem.Name = "exportarProgramaToolStripMenuItem";
            this.exportarProgramaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exportarProgramaToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.exportarProgramaToolStripMenuItem.Text = "Export PRG";
            // 
            // PProcesses
            // 
            this.PProcesses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PProcesses.Location = new System.Drawing.Point(0, 247);
            this.PProcesses.Name = "PProcesses";
            this.PProcesses.Size = new System.Drawing.Size(1212, 401);
            this.PProcesses.TabIndex = 4;
            // 
            // MenuTop
            // 
            this.MenuTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Errores_UI,
            this.toolStripSeparator1,
            this.Menu_Errores_programa,
            this.toolStripSeparator2,
            this.Menu_Debug,
            this.Apps_tsb,
            this.toolStripSeparator4,
            this.TB_Buscador,
            this.B_BuscarEnTodo,
            this.B_BuscarPROG,
            this.B_BuscarPRC,
            this.toolStripSeparator3,
            this.Menu_CheckIOC,
            this.toolStripSeparator5,
            this.tsb_AutoCheckErrors,
            this.toolStripSeparator6,
            this.tsb_Historico,
            this.toolStripSeparator7,
            this.tsb_RunApp,
            this.toolStripSeparator8,
            this.tsb_MapUI});
            this.MenuTop.Location = new System.Drawing.Point(0, 0);
            this.MenuTop.Name = "MenuTop";
            this.MenuTop.Size = new System.Drawing.Size(1212, 25);
            this.MenuTop.TabIndex = 0;
            this.MenuTop.Text = "toolStrip1";
            // 
            // Menu_Errores_UI
            // 
            this.Menu_Errores_UI.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Menu_Errores_UI.BackColor = System.Drawing.SystemColors.Control;
            this.Menu_Errores_UI.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Menu_Errores_UI.Name = "Menu_Errores_UI";
            this.Menu_Errores_UI.Size = new System.Drawing.Size(55, 22);
            this.Menu_Errores_UI.Text = "UI Errors";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // Menu_Errores_programa
            // 
            this.Menu_Errores_programa.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Menu_Errores_programa.BackColor = System.Drawing.SystemColors.Control;
            this.Menu_Errores_programa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Menu_Errores_programa.Name = "Menu_Errores_programa";
            this.Menu_Errores_programa.Size = new System.Drawing.Size(66, 22);
            this.Menu_Errores_programa.Text = "PRG Errors";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // Menu_Debug
            // 
            this.Menu_Debug.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Menu_Debug.Name = "Menu_Debug";
            this.Menu_Debug.Size = new System.Drawing.Size(46, 22);
            this.Menu_Debug.Text = "Debug";
            // 
            // Apps_tsb
            // 
            this.Apps_tsb.BackColor = System.Drawing.SystemColors.Control;
            this.Apps_tsb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Apps_tsb.Enabled = false;
            this.Apps_tsb.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Apps_tsb.Name = "Apps_tsb";
            this.Apps_tsb.Size = new System.Drawing.Size(150, 25);
            this.Apps_tsb.Text = "Active App";
            this.Apps_tsb.ToolTipText = "Active App";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // TB_Buscador
            // 
            this.TB_Buscador.Name = "TB_Buscador";
            this.TB_Buscador.Size = new System.Drawing.Size(200, 25);
            // 
            // B_BuscarEnTodo
            // 
            this.B_BuscarEnTodo.BackColor = System.Drawing.SystemColors.Control;
            this.B_BuscarEnTodo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.B_BuscarEnTodo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.B_BuscarEnTodo.Name = "B_BuscarEnTodo";
            this.B_BuscarEnTodo.Size = new System.Drawing.Size(23, 22);
            this.B_BuscarEnTodo.Text = "B";
            // 
            // B_BuscarPROG
            // 
            this.B_BuscarPROG.BackColor = System.Drawing.SystemColors.Control;
            this.B_BuscarPROG.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.B_BuscarPROG.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.B_BuscarPROG.Name = "B_BuscarPROG";
            this.B_BuscarPROG.Size = new System.Drawing.Size(33, 22);
            this.B_BuscarPROG.Text = "PRG";
            // 
            // B_BuscarPRC
            // 
            this.B_BuscarPRC.BackColor = System.Drawing.SystemColors.Control;
            this.B_BuscarPRC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.B_BuscarPRC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.B_BuscarPRC.Name = "B_BuscarPRC";
            this.B_BuscarPRC.Size = new System.Drawing.Size(33, 22);
            this.B_BuscarPRC.Text = "PRC";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // Menu_CheckIOC
            // 
            this.Menu_CheckIOC.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Menu_CheckIOC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Menu_CheckIOC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Menu_CheckIOC.Name = "Menu_CheckIOC";
            this.Menu_CheckIOC.Size = new System.Drawing.Size(67, 22);
            this.Menu_CheckIOC.Text = "Check IOC";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tsb_AutoCheckErrors
            // 
            this.tsb_AutoCheckErrors.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsb_AutoCheckErrors.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tsb_AutoCheckErrors.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsb_AutoCheckErrors.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_AutoCheckErrors.Name = "tsb_AutoCheckErrors";
            this.tsb_AutoCheckErrors.Size = new System.Drawing.Size(77, 22);
            this.tsb_AutoCheckErrors.Text = "Check errors";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // tsb_Historico
            // 
            this.tsb_Historico.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsb_Historico.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Historico.Name = "tsb_Historico";
            this.tsb_Historico.Size = new System.Drawing.Size(49, 22);
            this.tsb_Historico.Text = "History";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // tsb_RunApp
            // 
            this.tsb_RunApp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsb_RunApp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_RunApp.Name = "tsb_RunApp";
            this.tsb_RunApp.Size = new System.Drawing.Size(55, 22);
            this.tsb_RunApp.Text = "Run app";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // tsb_MapUI
            // 
            this.tsb_MapUI.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsb_MapUI.Image = ((System.Drawing.Image)(resources.GetObject("tsb_MapUI.Image")));
            this.tsb_MapUI.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_MapUI.Name = "tsb_MapUI";
            this.tsb_MapUI.Size = new System.Drawing.Size(49, 22);
            this.tsb_MapUI.Text = "Map UI";
            // 
            // VentanaProgramas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 648);
            this.Controls.Add(this.PProcesses);
            this.Controls.Add(this.PTop);
            this.Controls.Add(this.MenuTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VentanaProgramas";
            this.Text = "ARQODE program editor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.PTop.ResumeLayout(false);
            this.PListaProcesos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ListaProcesos)).EndInit();
            this.contextMenu_LProcesos.ResumeLayout(false);
            this.PanelArbolProgramas.ResumeLayout(false);
            this.contextMenu_Programas.ResumeLayout(false);
            this.MenuTop.ResumeLayout(false);
            this.MenuTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PTop;
        private System.Windows.Forms.Panel PListaProcesos;
        private System.Windows.Forms.Panel PanelArbolProgramas;
        private System.Windows.Forms.TreeView ArbolProgramas;
        private System.Windows.Forms.Panel PProcesses;
        private System.Windows.Forms.ContextMenuStrip contextMenu_Programas;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaCarpetaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renombrarToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenu_LProcesos;
        private System.Windows.Forms.ToolStripMenuItem irAlProcesoToolStripMenuItem;
        private System.Windows.Forms.DataGridView ListaProcesos;
        private System.Windows.Forms.ToolStripMenuItem subirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bajarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem asignarAToolStripMenuItem;
        private System.Windows.Forms.ToolStrip MenuTop;
        private System.Windows.Forms.ToolStripButton Menu_Errores_UI;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton Menu_Errores_programa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton Menu_Debug;
        private System.Windows.Forms.ToolStripTextBox TB_Buscador;
        private System.Windows.Forms.ToolStripButton B_BuscarEnTodo;
        private System.Windows.Forms.ToolStripButton B_BuscarPROG;
        private System.Windows.Forms.ToolStripButton B_BuscarPRC;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton Menu_CheckIOC;
        private System.Windows.Forms.ToolStripMenuItem cortarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pegarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem callprogramaPreviamenteCortadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verCódigoToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox Apps_tsb;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsb_AutoCheckErrors;
        private System.Windows.Forms.ToolStripMenuItem buscarReferenciasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarReferenciasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tsb_Historico;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton tsb_RunApp;
        private System.Windows.Forms.ToolStripMenuItem importarProgramaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarProgramaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarCódigoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton tsb_MapUI;
    }
}
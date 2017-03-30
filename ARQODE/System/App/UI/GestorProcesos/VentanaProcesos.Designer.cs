namespace ARQODE_VISUAL_EDITOR.ARQODE_UI
{
    partial class VentanaProcesos
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
            this.PLeft = new System.Windows.Forms.Panel();
            this.PProcessList = new System.Windows.Forms.Panel();
            this.LProcess = new System.Windows.Forms.ListBox();
            this.contextMenu_Proceso = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cortarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pegarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.asignarAlProgramaActivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PProcessDir = new System.Windows.Forms.Panel();
            this.TV_Processes = new System.Windows.Forms.TreeView();
            this.contextMenu_Procesos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NuevoFichero_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cortarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pegarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaCarpetaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renombrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabProcesos = new System.Windows.Forms.TabControl();
            this.Pcontent = new System.Windows.Forms.TabPage();
            this.PProcessPanel = new System.Windows.Forms.TabPage();
            this.buscarReferenciasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PLeft.SuspendLayout();
            this.PProcessList.SuspendLayout();
            this.contextMenu_Proceso.SuspendLayout();
            this.PProcessDir.SuspendLayout();
            this.contextMenu_Procesos.SuspendLayout();
            this.tabProcesos.SuspendLayout();
            this.SuspendLayout();
            // 
            // PLeft
            // 
            this.PLeft.Controls.Add(this.PProcessList);
            this.PLeft.Controls.Add(this.PProcessDir);
            this.PLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.PLeft.Location = new System.Drawing.Point(0, 0);
            this.PLeft.Name = "PLeft";
            this.PLeft.Size = new System.Drawing.Size(400, 554);
            this.PLeft.TabIndex = 0;
            // 
            // PProcessList
            // 
            this.PProcessList.Controls.Add(this.LProcess);
            this.PProcessList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PProcessList.Location = new System.Drawing.Point(0, 300);
            this.PProcessList.Name = "PProcessList";
            this.PProcessList.Size = new System.Drawing.Size(400, 254);
            this.PProcessList.TabIndex = 1;
            // 
            // LProcess
            // 
            this.LProcess.ContextMenuStrip = this.contextMenu_Proceso;
            this.LProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LProcess.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LProcess.FormattingEnabled = true;
            this.LProcess.ItemHeight = 16;
            this.LProcess.Location = new System.Drawing.Point(0, 0);
            this.LProcess.Name = "LProcess";
            this.LProcess.Size = new System.Drawing.Size(400, 254);
            this.LProcess.TabIndex = 0;
            this.LProcess.SelectedIndexChanged += new System.EventHandler(this.LProcess_SelectedIndexChanged);
            // 
            // contextMenu_Proceso
            // 
            this.contextMenu_Proceso.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.cortarToolStripMenuItem1,
            this.pegarToolStripMenuItem1,
            this.eliminarToolStripMenuItem1,
            this.asignarAlProgramaActivoToolStripMenuItem,
            this.buscarReferenciasToolStripMenuItem});
            this.contextMenu_Proceso.Name = "contextMenu_Proceso";
            this.contextMenu_Proceso.Size = new System.Drawing.Size(259, 158);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.toolStripMenuItem1.Size = new System.Drawing.Size(258, 22);
            this.toolStripMenuItem1.Tag = "Gestión de Procesos.Proceso.Nuevo proceso";
            this.toolStripMenuItem1.Text = "New";
            // 
            // cortarToolStripMenuItem1
            // 
            this.cortarToolStripMenuItem1.Name = "cortarToolStripMenuItem1";
            this.cortarToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cortarToolStripMenuItem1.Size = new System.Drawing.Size(258, 22);
            this.cortarToolStripMenuItem1.Tag = "Gestión de Procesos.Proceso.Cortar";
            this.cortarToolStripMenuItem1.Text = "Cut";
            // 
            // pegarToolStripMenuItem1
            // 
            this.pegarToolStripMenuItem1.Enabled = false;
            this.pegarToolStripMenuItem1.Name = "pegarToolStripMenuItem1";
            this.pegarToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pegarToolStripMenuItem1.Size = new System.Drawing.Size(258, 22);
            this.pegarToolStripMenuItem1.Tag = "Gestión de Procesos.Proceso.Pegar";
            this.pegarToolStripMenuItem1.Text = "Paste";
            // 
            // eliminarToolStripMenuItem1
            // 
            this.eliminarToolStripMenuItem1.Name = "eliminarToolStripMenuItem1";
            this.eliminarToolStripMenuItem1.Size = new System.Drawing.Size(258, 22);
            this.eliminarToolStripMenuItem1.Tag = "Gestión de Procesos.Proceso.Eliminar proceso";
            this.eliminarToolStripMenuItem1.Text = "Delete";
            // 
            // asignarAlProgramaActivoToolStripMenuItem
            // 
            this.asignarAlProgramaActivoToolStripMenuItem.Name = "asignarAlProgramaActivoToolStripMenuItem";
            this.asignarAlProgramaActivoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.asignarAlProgramaActivoToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.asignarAlProgramaActivoToolStripMenuItem.Tag = "Gestión de Procesos.Proceso.Asignar proceso";
            this.asignarAlProgramaActivoToolStripMenuItem.Text = "Asign to active program";
            // 
            // PProcessDir
            // 
            this.PProcessDir.Controls.Add(this.TV_Processes);
            this.PProcessDir.Dock = System.Windows.Forms.DockStyle.Top;
            this.PProcessDir.Location = new System.Drawing.Point(0, 0);
            this.PProcessDir.Name = "PProcessDir";
            this.PProcessDir.Size = new System.Drawing.Size(400, 300);
            this.PProcessDir.TabIndex = 0;
            // 
            // TV_Processes
            // 
            this.TV_Processes.ContextMenuStrip = this.contextMenu_Procesos;
            this.TV_Processes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TV_Processes.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TV_Processes.HideSelection = false;
            this.TV_Processes.Location = new System.Drawing.Point(0, 0);
            this.TV_Processes.Name = "TV_Processes";
            this.TV_Processes.Size = new System.Drawing.Size(400, 300);
            this.TV_Processes.TabIndex = 0;
            // 
            // contextMenu_Procesos
            // 
            this.contextMenu_Procesos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NuevoFichero_ToolStripMenuItem,
            this.cortarToolStripMenuItem,
            this.pegarToolStripMenuItem,
            this.eliminarToolStripMenuItem,
            this.nuevaCarpetaToolStripMenuItem,
            this.renombrarToolStripMenuItem});
            this.contextMenu_Procesos.Name = "contextMenu_Procesos";
            this.contextMenu_Procesos.Size = new System.Drawing.Size(192, 136);
            // 
            // NuevoFichero_ToolStripMenuItem
            // 
            this.NuevoFichero_ToolStripMenuItem.Name = "NuevoFichero_ToolStripMenuItem";
            this.NuevoFichero_ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.NuevoFichero_ToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.NuevoFichero_ToolStripMenuItem.Tag = "Gestión de Procesos.Gestión.Abrir ficha de proceso";
            this.NuevoFichero_ToolStripMenuItem.Text = "New";
            // 
            // cortarToolStripMenuItem
            // 
            this.cortarToolStripMenuItem.Name = "cortarToolStripMenuItem";
            this.cortarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cortarToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.cortarToolStripMenuItem.Tag = "Gestión de Procesos.Gestión.Cortar";
            this.cortarToolStripMenuItem.Text = "Cut";
            // 
            // pegarToolStripMenuItem
            // 
            this.pegarToolStripMenuItem.Enabled = false;
            this.pegarToolStripMenuItem.Name = "pegarToolStripMenuItem";
            this.pegarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pegarToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.pegarToolStripMenuItem.Tag = "Gestión de Procesos.Gestión.Pegar";
            this.pegarToolStripMenuItem.Text = "Paste";
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.eliminarToolStripMenuItem.Tag = "Gestión de Procesos.Gestión.Eliminar fichero procesos";
            this.eliminarToolStripMenuItem.Text = "Delete";
            // 
            // nuevaCarpetaToolStripMenuItem
            // 
            this.nuevaCarpetaToolStripMenuItem.Name = "nuevaCarpetaToolStripMenuItem";
            this.nuevaCarpetaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.nuevaCarpetaToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.nuevaCarpetaToolStripMenuItem.Tag = "Gestión de Procesos.Gestión.Nueva carpeta";
            this.nuevaCarpetaToolStripMenuItem.Text = "New folder";
            // 
            // renombrarToolStripMenuItem
            // 
            this.renombrarToolStripMenuItem.Name = "renombrarToolStripMenuItem";
            this.renombrarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.renombrarToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.renombrarToolStripMenuItem.Tag = "Gestión de Procesos.Gestión.Renombrar fichero de proceso";
            this.renombrarToolStripMenuItem.Text = "Rename";
            // 
            // tabProcesos
            // 
            this.tabProcesos.Controls.Add(this.Pcontent);
            this.tabProcesos.Controls.Add(this.PProcessPanel);
            this.tabProcesos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabProcesos.Location = new System.Drawing.Point(400, 0);
            this.tabProcesos.Name = "tabProcesos";
            this.tabProcesos.SelectedIndex = 0;
            this.tabProcesos.Size = new System.Drawing.Size(392, 554);
            this.tabProcesos.TabIndex = 2;
            // 
            // Pcontent
            // 
            this.Pcontent.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pcontent.Location = new System.Drawing.Point(4, 22);
            this.Pcontent.Name = "Pcontent";
            this.Pcontent.Padding = new System.Windows.Forms.Padding(3);
            this.Pcontent.Size = new System.Drawing.Size(384, 528);
            this.Pcontent.TabIndex = 0;
            this.Pcontent.Text = "Base process";
            this.Pcontent.UseVisualStyleBackColor = true;
            // 
            // PProcessPanel
            // 
            this.PProcessPanel.Location = new System.Drawing.Point(4, 22);
            this.PProcessPanel.Name = "PProcessPanel";
            this.PProcessPanel.Padding = new System.Windows.Forms.Padding(3);
            this.PProcessPanel.Size = new System.Drawing.Size(384, 528);
            this.PProcessPanel.TabIndex = 1;
            this.PProcessPanel.Text = "Process";
            this.PProcessPanel.UseVisualStyleBackColor = true;
            // 
            // buscarReferenciasToolStripMenuItem
            // 
            this.buscarReferenciasToolStripMenuItem.Name = "buscarReferenciasToolStripMenuItem";
            this.buscarReferenciasToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.buscarReferenciasToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.buscarReferenciasToolStripMenuItem.Tag = "Gestión de procesos.Buscar referencias a proceso en programas";
            this.buscarReferenciasToolStripMenuItem.Text = "Search refs";
            // 
            // VentanaProcesos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabProcesos);
            this.Controls.Add(this.PLeft);
            this.Name = "VentanaProcesos";
            this.Size = new System.Drawing.Size(792, 554);
            this.Load += new System.EventHandler(this.VentanaProcesos_Load);
            this.PLeft.ResumeLayout(false);
            this.PProcessList.ResumeLayout(false);
            this.contextMenu_Proceso.ResumeLayout(false);
            this.PProcessDir.ResumeLayout(false);
            this.contextMenu_Procesos.ResumeLayout(false);
            this.tabProcesos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PLeft;
        private System.Windows.Forms.Panel PProcessList;
        private System.Windows.Forms.ListBox LProcess;
        private System.Windows.Forms.Panel PProcessDir;
        private System.Windows.Forms.TreeView TV_Processes;
        private System.Windows.Forms.ContextMenuStrip contextMenu_Procesos;
        private System.Windows.Forms.ToolStripMenuItem NuevoFichero_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaCarpetaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renombrarToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenu_Proceso;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem asignarAlProgramaActivoToolStripMenuItem;
        private System.Windows.Forms.TabControl tabProcesos;
        private System.Windows.Forms.TabPage Pcontent;
        private System.Windows.Forms.TabPage PProcessPanel;
        private System.Windows.Forms.ToolStripMenuItem cortarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pegarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cortarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pegarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem buscarReferenciasToolStripMenuItem;
    }
}
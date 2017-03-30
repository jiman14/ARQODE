namespace ARQODE_VISUAL_EDITOR.ARQODE_UI
{
    partial class FormProcesoActivo
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
            this.PTop = new System.Windows.Forms.Panel();
            this.PViews = new System.Windows.Forms.Panel();
            this.PContentViewsVars = new System.Windows.Forms.Panel();
            this.TV_ViewsVars = new System.Windows.Forms.TreeView();
            this.contextMenu_ViewVars = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaVariableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarVariableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PTopViews = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.PGlobals = new System.Windows.Forms.Panel();
            this.PContentGlobalVars = new System.Windows.Forms.Panel();
            this.LB_ProgramVars = new System.Windows.Forms.ListBox();
            this.contextMenu_ProgramVars = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaVariableToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarVariableToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.PTopGlobals = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.PPrograms = new System.Windows.Forms.Panel();
            this.PContentProgVars = new System.Windows.Forms.Panel();
            this.TV_GlobalsVars = new System.Windows.Forms.TreeView();
            this.contextMenu_GlobalVars = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaVariableToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarVariableToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.PTopProgVars = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.PFormProcesoActivo = new System.Windows.Forms.Panel();
            this.TBDescription = new System.Windows.Forms.TextBox();
            this.LConfig = new System.Windows.Forms.DataGridView();
            this.LOutputs = new System.Windows.Forms.DataGridView();
            this.LInputs = new System.Windows.Forms.DataGridView();
            this.BSave = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PTop.SuspendLayout();
            this.PViews.SuspendLayout();
            this.PContentViewsVars.SuspendLayout();
            this.contextMenu_ViewVars.SuspendLayout();
            this.PTopViews.SuspendLayout();
            this.PGlobals.SuspendLayout();
            this.PContentGlobalVars.SuspendLayout();
            this.contextMenu_ProgramVars.SuspendLayout();
            this.PTopGlobals.SuspendLayout();
            this.PPrograms.SuspendLayout();
            this.PContentProgVars.SuspendLayout();
            this.contextMenu_GlobalVars.SuspendLayout();
            this.PTopProgVars.SuspendLayout();
            this.PFormProcesoActivo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LConfig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LOutputs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LInputs)).BeginInit();
            this.SuspendLayout();
            // 
            // PTop
            // 
            this.PTop.Controls.Add(this.PViews);
            this.PTop.Controls.Add(this.PGlobals);
            this.PTop.Controls.Add(this.PPrograms);
            this.PTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PTop.Location = new System.Drawing.Point(0, 0);
            this.PTop.Name = "PTop";
            this.PTop.Size = new System.Drawing.Size(646, 212);
            this.PTop.TabIndex = 0;
            // 
            // PViews
            // 
            this.PViews.Controls.Add(this.PContentViewsVars);
            this.PViews.Controls.Add(this.PTopViews);
            this.PViews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PViews.Location = new System.Drawing.Point(0, 0);
            this.PViews.Name = "PViews";
            this.PViews.Size = new System.Drawing.Size(263, 212);
            this.PViews.TabIndex = 2;
            // 
            // PContentViewsVars
            // 
            this.PContentViewsVars.Controls.Add(this.TV_ViewsVars);
            this.PContentViewsVars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PContentViewsVars.Location = new System.Drawing.Point(0, 32);
            this.PContentViewsVars.Name = "PContentViewsVars";
            this.PContentViewsVars.Size = new System.Drawing.Size(263, 180);
            this.PContentViewsVars.TabIndex = 1;
            // 
            // TV_ViewsVars
            // 
            this.TV_ViewsVars.ContextMenuStrip = this.contextMenu_ViewVars;
            this.TV_ViewsVars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TV_ViewsVars.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TV_ViewsVars.HideSelection = false;
            this.TV_ViewsVars.Location = new System.Drawing.Point(0, 0);
            this.TV_ViewsVars.Name = "TV_ViewsVars";
            this.TV_ViewsVars.Size = new System.Drawing.Size(263, 180);
            this.TV_ViewsVars.TabIndex = 5;
            // 
            // contextMenu_ViewVars
            // 
            this.contextMenu_ViewVars.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.nuevaVariableToolStripMenuItem,
            this.eliminarVariableToolStripMenuItem});
            this.contextMenu_ViewVars.Name = "contextMenu_ViewVars";
            this.contextMenu_ViewVars.Size = new System.Drawing.Size(196, 70);
            this.contextMenu_ViewVars.Tag = "";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.copyToolStripMenuItem.Tag = "Gestión de Programas.Variables.Copiar variable vista";
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // nuevaVariableToolStripMenuItem
            // 
            this.nuevaVariableToolStripMenuItem.Name = "nuevaVariableToolStripMenuItem";
            this.nuevaVariableToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.nuevaVariableToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.nuevaVariableToolStripMenuItem.Tag = "Gestión de Programas.Variables.Nueva variable vista";
            this.nuevaVariableToolStripMenuItem.Text = "New var";
            // 
            // eliminarVariableToolStripMenuItem
            // 
            this.eliminarVariableToolStripMenuItem.Name = "eliminarVariableToolStripMenuItem";
            this.eliminarVariableToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.eliminarVariableToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.eliminarVariableToolStripMenuItem.Tag = "Gestión de Programas.Variables.Eliminar variable vista";
            this.eliminarVariableToolStripMenuItem.Text = "Delete var";
            // 
            // PTopViews
            // 
            this.PTopViews.Controls.Add(this.label1);
            this.PTopViews.Dock = System.Windows.Forms.DockStyle.Top;
            this.PTopViews.Location = new System.Drawing.Point(0, 0);
            this.PTopViews.Name = "PTopViews";
            this.PTopViews.Size = new System.Drawing.Size(263, 32);
            this.PTopViews.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Views vars";
            // 
            // PGlobals
            // 
            this.PGlobals.Controls.Add(this.PContentGlobalVars);
            this.PGlobals.Controls.Add(this.PTopGlobals);
            this.PGlobals.Dock = System.Windows.Forms.DockStyle.Right;
            this.PGlobals.Location = new System.Drawing.Point(263, 0);
            this.PGlobals.Name = "PGlobals";
            this.PGlobals.Size = new System.Drawing.Size(200, 212);
            this.PGlobals.TabIndex = 1;
            // 
            // PContentGlobalVars
            // 
            this.PContentGlobalVars.Controls.Add(this.LB_ProgramVars);
            this.PContentGlobalVars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PContentGlobalVars.Location = new System.Drawing.Point(0, 32);
            this.PContentGlobalVars.Name = "PContentGlobalVars";
            this.PContentGlobalVars.Size = new System.Drawing.Size(200, 180);
            this.PContentGlobalVars.TabIndex = 1;
            // 
            // LB_ProgramVars
            // 
            this.LB_ProgramVars.ContextMenuStrip = this.contextMenu_ProgramVars;
            this.LB_ProgramVars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LB_ProgramVars.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_ProgramVars.FormattingEnabled = true;
            this.LB_ProgramVars.ItemHeight = 16;
            this.LB_ProgramVars.Location = new System.Drawing.Point(0, 0);
            this.LB_ProgramVars.Name = "LB_ProgramVars";
            this.LB_ProgramVars.Size = new System.Drawing.Size(200, 180);
            this.LB_ProgramVars.TabIndex = 6;
            this.LB_ProgramVars.Tag = "Gestión de Programas.Copiar variable de programa";
            // 
            // contextMenu_ProgramVars
            // 
            this.contextMenu_ProgramVars.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem1,
            this.nuevaVariableToolStripMenuItem1,
            this.eliminarVariableToolStripMenuItem1});
            this.contextMenu_ProgramVars.Name = "contextMenu_ProgramVars";
            this.contextMenu_ProgramVars.Size = new System.Drawing.Size(196, 70);
            // 
            // copyToolStripMenuItem1
            // 
            this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            this.copyToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem1.Size = new System.Drawing.Size(195, 22);
            this.copyToolStripMenuItem1.Tag = "Gestión de Programas.Variables.Copiar variable de programa";
            this.copyToolStripMenuItem1.Text = "Copy";
            // 
            // nuevaVariableToolStripMenuItem1
            // 
            this.nuevaVariableToolStripMenuItem1.Name = "nuevaVariableToolStripMenuItem1";
            this.nuevaVariableToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.nuevaVariableToolStripMenuItem1.Size = new System.Drawing.Size(195, 22);
            this.nuevaVariableToolStripMenuItem1.Tag = "Gestión de Programas.Variables.Nueva variable de programa";
            this.nuevaVariableToolStripMenuItem1.Text = "New var";
            // 
            // eliminarVariableToolStripMenuItem1
            // 
            this.eliminarVariableToolStripMenuItem1.Name = "eliminarVariableToolStripMenuItem1";
            this.eliminarVariableToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.eliminarVariableToolStripMenuItem1.Size = new System.Drawing.Size(195, 22);
            this.eliminarVariableToolStripMenuItem1.Tag = "Gestión de Programas.Variables.Eliminar variable de programa";
            this.eliminarVariableToolStripMenuItem1.Text = "Delete var";
            // 
            // PTopGlobals
            // 
            this.PTopGlobals.Controls.Add(this.label2);
            this.PTopGlobals.Dock = System.Windows.Forms.DockStyle.Top;
            this.PTopGlobals.Location = new System.Drawing.Point(0, 0);
            this.PTopGlobals.Name = "PTopGlobals";
            this.PTopGlobals.Size = new System.Drawing.Size(200, 32);
            this.PTopGlobals.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Program vars";
            // 
            // PPrograms
            // 
            this.PPrograms.Controls.Add(this.PContentProgVars);
            this.PPrograms.Controls.Add(this.PTopProgVars);
            this.PPrograms.Dock = System.Windows.Forms.DockStyle.Right;
            this.PPrograms.Location = new System.Drawing.Point(463, 0);
            this.PPrograms.Name = "PPrograms";
            this.PPrograms.Size = new System.Drawing.Size(183, 212);
            this.PPrograms.TabIndex = 0;
            // 
            // PContentProgVars
            // 
            this.PContentProgVars.Controls.Add(this.TV_GlobalsVars);
            this.PContentProgVars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PContentProgVars.Location = new System.Drawing.Point(0, 32);
            this.PContentProgVars.Name = "PContentProgVars";
            this.PContentProgVars.Size = new System.Drawing.Size(183, 180);
            this.PContentProgVars.TabIndex = 1;
            // 
            // TV_GlobalsVars
            // 
            this.TV_GlobalsVars.ContextMenuStrip = this.contextMenu_GlobalVars;
            this.TV_GlobalsVars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TV_GlobalsVars.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TV_GlobalsVars.HideSelection = false;
            this.TV_GlobalsVars.Location = new System.Drawing.Point(0, 0);
            this.TV_GlobalsVars.Name = "TV_GlobalsVars";
            this.TV_GlobalsVars.Size = new System.Drawing.Size(183, 180);
            this.TV_GlobalsVars.TabIndex = 7;
            // 
            // contextMenu_GlobalVars
            // 
            this.contextMenu_GlobalVars.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem2,
            this.nuevaVariableToolStripMenuItem2,
            this.eliminarVariableToolStripMenuItem2});
            this.contextMenu_GlobalVars.Name = "contextMenu_GlobalVars";
            this.contextMenu_GlobalVars.Size = new System.Drawing.Size(196, 70);
            this.contextMenu_GlobalVars.Tag = "Global var copy";
            // 
            // copyToolStripMenuItem2
            // 
            this.copyToolStripMenuItem2.Name = "copyToolStripMenuItem2";
            this.copyToolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem2.Size = new System.Drawing.Size(195, 22);
            this.copyToolStripMenuItem2.Tag = "Gestión de Programas.Variables.Copiar variable global";
            this.copyToolStripMenuItem2.Text = "Copy";
            // 
            // nuevaVariableToolStripMenuItem2
            // 
            this.nuevaVariableToolStripMenuItem2.Name = "nuevaVariableToolStripMenuItem2";
            this.nuevaVariableToolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.nuevaVariableToolStripMenuItem2.Size = new System.Drawing.Size(195, 22);
            this.nuevaVariableToolStripMenuItem2.Tag = "Gestión de Programas.Variables.Nueva variable global";
            this.nuevaVariableToolStripMenuItem2.Text = "New var";
            // 
            // eliminarVariableToolStripMenuItem2
            // 
            this.eliminarVariableToolStripMenuItem2.Name = "eliminarVariableToolStripMenuItem2";
            this.eliminarVariableToolStripMenuItem2.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.eliminarVariableToolStripMenuItem2.Size = new System.Drawing.Size(195, 22);
            this.eliminarVariableToolStripMenuItem2.Tag = "Gestión de Programas.Variables.Eliminar variable global";
            this.eliminarVariableToolStripMenuItem2.Text = "Delete var";
            // 
            // PTopProgVars
            // 
            this.PTopProgVars.Controls.Add(this.label3);
            this.PTopProgVars.Dock = System.Windows.Forms.DockStyle.Top;
            this.PTopProgVars.Location = new System.Drawing.Point(0, 0);
            this.PTopProgVars.Name = "PTopProgVars";
            this.PTopProgVars.Size = new System.Drawing.Size(183, 32);
            this.PTopProgVars.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Globals vars";
            // 
            // PFormProcesoActivo
            // 
            this.PFormProcesoActivo.AutoScroll = true;
            this.PFormProcesoActivo.AutoScrollMinSize = new System.Drawing.Size(1, 1);
            this.PFormProcesoActivo.Controls.Add(this.TBDescription);
            this.PFormProcesoActivo.Controls.Add(this.LConfig);
            this.PFormProcesoActivo.Controls.Add(this.LOutputs);
            this.PFormProcesoActivo.Controls.Add(this.LInputs);
            this.PFormProcesoActivo.Controls.Add(this.BSave);
            this.PFormProcesoActivo.Controls.Add(this.label10);
            this.PFormProcesoActivo.Controls.Add(this.label9);
            this.PFormProcesoActivo.Controls.Add(this.label8);
            this.PFormProcesoActivo.Controls.Add(this.LName);
            this.PFormProcesoActivo.Controls.Add(this.label7);
            this.PFormProcesoActivo.Controls.Add(this.label4);
            this.PFormProcesoActivo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PFormProcesoActivo.Location = new System.Drawing.Point(0, 212);
            this.PFormProcesoActivo.Name = "PFormProcesoActivo";
            this.PFormProcesoActivo.Size = new System.Drawing.Size(646, 424);
            this.PFormProcesoActivo.TabIndex = 1;
            // 
            // TBDescription
            // 
            this.TBDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBDescription.Location = new System.Drawing.Point(282, 38);
            this.TBDescription.Multiline = true;
            this.TBDescription.Name = "TBDescription";
            this.TBDescription.Size = new System.Drawing.Size(352, 35);
            this.TBDescription.TabIndex = 4;
            // 
            // LConfig
            // 
            this.LConfig.AllowUserToAddRows = false;
            this.LConfig.AllowUserToDeleteRows = false;
            this.LConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LConfig.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.LConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LConfig.Location = new System.Drawing.Point(12, 324);
            this.LConfig.MultiSelect = false;
            this.LConfig.Name = "LConfig";
            this.LConfig.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.LConfig.Size = new System.Drawing.Size(622, 98);
            this.LConfig.TabIndex = 2;
            // 
            // LOutputs
            // 
            this.LOutputs.AllowUserToAddRows = false;
            this.LOutputs.AllowUserToDeleteRows = false;
            this.LOutputs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LOutputs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.LOutputs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LOutputs.Location = new System.Drawing.Point(12, 206);
            this.LOutputs.MultiSelect = false;
            this.LOutputs.Name = "LOutputs";
            this.LOutputs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.LOutputs.Size = new System.Drawing.Size(622, 96);
            this.LOutputs.TabIndex = 1;
            // 
            // LInputs
            // 
            this.LInputs.AllowUserToAddRows = false;
            this.LInputs.AllowUserToDeleteRows = false;
            this.LInputs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LInputs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.LInputs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LInputs.Location = new System.Drawing.Point(12, 79);
            this.LInputs.MultiSelect = false;
            this.LInputs.Name = "LInputs";
            this.LInputs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.LInputs.Size = new System.Drawing.Size(622, 105);
            this.LInputs.TabIndex = 0;
            // 
            // BSave
            // 
            this.BSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BSave.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BSave.Location = new System.Drawing.Point(545, 5);
            this.BSave.Name = "BSave";
            this.BSave.Size = new System.Drawing.Size(89, 30);
            this.BSave.TabIndex = 3;
            this.BSave.Text = "Save";
            this.BSave.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(13, 187);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 16);
            this.label10.TabIndex = 8;
            this.label10.Text = "Outputs:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 305);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 16);
            this.label9.TabIndex = 8;
            this.label9.Text = "Configuration:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "Inputs:";
            // 
            // LName
            // 
            this.LName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LName.Location = new System.Drawing.Point(13, 21);
            this.LName.Name = "LName";
            this.LName.Size = new System.Drawing.Size(250, 37);
            this.LName.TabIndex = 4;
            this.LName.Text = "Process name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(279, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "Description:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Name:";
            // 
            // FormProcesoActivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PFormProcesoActivo);
            this.Controls.Add(this.PTop);
            this.Name = "FormProcesoActivo";
            this.Size = new System.Drawing.Size(646, 636);
            this.PTop.ResumeLayout(false);
            this.PViews.ResumeLayout(false);
            this.PContentViewsVars.ResumeLayout(false);
            this.contextMenu_ViewVars.ResumeLayout(false);
            this.PTopViews.ResumeLayout(false);
            this.PTopViews.PerformLayout();
            this.PGlobals.ResumeLayout(false);
            this.PContentGlobalVars.ResumeLayout(false);
            this.contextMenu_ProgramVars.ResumeLayout(false);
            this.PTopGlobals.ResumeLayout(false);
            this.PTopGlobals.PerformLayout();
            this.PPrograms.ResumeLayout(false);
            this.PContentProgVars.ResumeLayout(false);
            this.contextMenu_GlobalVars.ResumeLayout(false);
            this.PTopProgVars.ResumeLayout(false);
            this.PTopProgVars.PerformLayout();
            this.PFormProcesoActivo.ResumeLayout(false);
            this.PFormProcesoActivo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LConfig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LOutputs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LInputs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PTop;
        private System.Windows.Forms.Panel PViews;
        private System.Windows.Forms.Panel PContentViewsVars;
        private System.Windows.Forms.TreeView TV_ViewsVars;
        private System.Windows.Forms.Panel PTopViews;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PGlobals;
        private System.Windows.Forms.Panel PContentGlobalVars;
        private System.Windows.Forms.ListBox LB_ProgramVars;
        private System.Windows.Forms.Panel PTopGlobals;
        private System.Windows.Forms.Panel PPrograms;
        private System.Windows.Forms.Panel PContentProgVars;
        private System.Windows.Forms.TreeView TV_GlobalsVars;
        private System.Windows.Forms.Panel PTopProgVars;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel PFormProcesoActivo;
        private System.Windows.Forms.Button BSave;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip contextMenu_ViewVars;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenu_ProgramVars;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenu_GlobalVars;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem2;
        private System.Windows.Forms.DataGridView LConfig;
        private System.Windows.Forms.DataGridView LOutputs;
        private System.Windows.Forms.DataGridView LInputs;
        private System.Windows.Forms.TextBox TBDescription;
        private System.Windows.Forms.ToolStripMenuItem nuevaVariableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarVariableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaVariableToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem eliminarVariableToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nuevaVariableToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem eliminarVariableToolStripMenuItem2;
    }
}
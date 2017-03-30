namespace ARQODE_VISUAL_EDITOR.ARQODE_UI
{
    partial class FormControlesEventos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormControlesEventos));
            this.PLeft = new System.Windows.Forms.Panel();
            this.TV_Controles = new System.Windows.Forms.TreeView();
            this.PRight = new System.Windows.Forms.Panel();
            this.PEventBottom = new System.Windows.Forms.Panel();
            this.PEventsGrid = new System.Windows.Forms.Panel();
            this.DG_EventosControl = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BGuardar = new System.Windows.Forms.Button();
            this.PTopEvent_Consult = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TSFiltroEventos = new System.Windows.Forms.ToolStripTextBox();
            this.TSBFiltrar = new System.Windows.Forms.ToolStripButton();
            this.ListaEventos = new System.Windows.Forms.ListView();
            this.PLeft.SuspendLayout();
            this.PRight.SuspendLayout();
            this.PEventBottom.SuspendLayout();
            this.PEventsGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG_EventosControl)).BeginInit();
            this.panel1.SuspendLayout();
            this.PTopEvent_Consult.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PLeft
            // 
            this.PLeft.Controls.Add(this.TV_Controles);
            this.PLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PLeft.Location = new System.Drawing.Point(0, 0);
            this.PLeft.MaximumSize = new System.Drawing.Size(300, 0);
            this.PLeft.Name = "PLeft";
            this.PLeft.Size = new System.Drawing.Size(300, 757);
            this.PLeft.TabIndex = 0;
            // 
            // TV_Controles
            // 
            this.TV_Controles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TV_Controles.Font = new System.Drawing.Font("Arial", 9.75F);
            this.TV_Controles.HideSelection = false;
            this.TV_Controles.Location = new System.Drawing.Point(0, 0);
            this.TV_Controles.Name = "TV_Controles";
            this.TV_Controles.Size = new System.Drawing.Size(300, 757);
            this.TV_Controles.TabIndex = 0;
            // 
            // PRight
            // 
            this.PRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PRight.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PRight.Controls.Add(this.PEventBottom);
            this.PRight.Controls.Add(this.PTopEvent_Consult);
            this.PRight.Location = new System.Drawing.Point(302, 0);
            this.PRight.Name = "PRight";
            this.PRight.Size = new System.Drawing.Size(655, 757);
            this.PRight.TabIndex = 0;
            // 
            // PEventBottom
            // 
            this.PEventBottom.Controls.Add(this.PEventsGrid);
            this.PEventBottom.Controls.Add(this.panel1);
            this.PEventBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PEventBottom.Location = new System.Drawing.Point(0, 405);
            this.PEventBottom.Name = "PEventBottom";
            this.PEventBottom.Size = new System.Drawing.Size(655, 352);
            this.PEventBottom.TabIndex = 3;
            // 
            // PEventsGrid
            // 
            this.PEventsGrid.Controls.Add(this.DG_EventosControl);
            this.PEventsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PEventsGrid.Location = new System.Drawing.Point(0, 0);
            this.PEventsGrid.Name = "PEventsGrid";
            this.PEventsGrid.Size = new System.Drawing.Size(655, 294);
            this.PEventsGrid.TabIndex = 2;
            // 
            // DG_EventosControl
            // 
            this.DG_EventosControl.AllowUserToResizeRows = false;
            this.DG_EventosControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DG_EventosControl.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DG_EventosControl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_EventosControl.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DG_EventosControl.DefaultCellStyle = dataGridViewCellStyle1;
            this.DG_EventosControl.Location = new System.Drawing.Point(3, 3);
            this.DG_EventosControl.MultiSelect = false;
            this.DG_EventosControl.Name = "DG_EventosControl";
            this.DG_EventosControl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DG_EventosControl.Size = new System.Drawing.Size(649, 291);
            this.DG_EventosControl.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BGuardar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 294);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(655, 58);
            this.panel1.TabIndex = 1;
            // 
            // BGuardar
            // 
            this.BGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BGuardar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BGuardar.Location = new System.Drawing.Point(552, 14);
            this.BGuardar.Name = "BGuardar";
            this.BGuardar.Size = new System.Drawing.Size(91, 30);
            this.BGuardar.TabIndex = 0;
            this.BGuardar.Text = "Save";
            this.BGuardar.UseVisualStyleBackColor = true;
            // 
            // PTopEvent_Consult
            // 
            this.PTopEvent_Consult.Controls.Add(this.toolStrip1);
            this.PTopEvent_Consult.Controls.Add(this.ListaEventos);
            this.PTopEvent_Consult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PTopEvent_Consult.Location = new System.Drawing.Point(0, 0);
            this.PTopEvent_Consult.Name = "PTopEvent_Consult";
            this.PTopEvent_Consult.Size = new System.Drawing.Size(655, 757);
            this.PTopEvent_Consult.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSFiltroEventos,
            this.TSBFiltrar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(655, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TSFiltroEventos
            // 
            this.TSFiltroEventos.Name = "TSFiltroEventos";
            this.TSFiltroEventos.Size = new System.Drawing.Size(200, 25);
            // 
            // TSBFiltrar
            // 
            this.TSBFiltrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TSBFiltrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSBFiltrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBFiltrar.Name = "TSBFiltrar";
            this.TSBFiltrar.Size = new System.Drawing.Size(92, 22);
            this.TSBFiltrar.Text = "Event filter";
            // 
            // ListaEventos
            // 
            this.ListaEventos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListaEventos.Font = new System.Drawing.Font("Arial", 9.75F);
            this.ListaEventos.HideSelection = false;
            this.ListaEventos.LabelEdit = true;
            this.ListaEventos.Location = new System.Drawing.Point(0, 51);
            this.ListaEventos.MultiSelect = false;
            this.ListaEventos.Name = "ListaEventos";
            this.ListaEventos.Size = new System.Drawing.Size(652, 348);
            this.ListaEventos.TabIndex = 0;
            this.ListaEventos.UseCompatibleStateImageBehavior = false;
            // 
            // FormControlesEventos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 757);
            this.Controls.Add(this.PRight);
            this.Controls.Add(this.PLeft);
            this.Name = "FormControlesEventos";
            this.Text = "Controls events";
            this.PLeft.ResumeLayout(false);
            this.PRight.ResumeLayout(false);
            this.PEventBottom.ResumeLayout(false);
            this.PEventsGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DG_EventosControl)).EndInit();
            this.panel1.ResumeLayout(false);
            this.PTopEvent_Consult.ResumeLayout(false);
            this.PTopEvent_Consult.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PLeft;
        private System.Windows.Forms.TreeView TV_Controles;
        private System.Windows.Forms.Panel PRight;
        private System.Windows.Forms.Panel PTopEvent_Consult;
        private System.Windows.Forms.ListView ListaEventos;
        private System.Windows.Forms.Panel PEventBottom;
        private System.Windows.Forms.Panel PEventsGrid;
        private System.Windows.Forms.DataGridView DG_EventosControl;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BGuardar;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox TSFiltroEventos;
        private System.Windows.Forms.ToolStripButton TSBFiltrar;
    }
}
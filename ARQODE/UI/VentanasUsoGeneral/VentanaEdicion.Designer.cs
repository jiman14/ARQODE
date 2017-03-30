namespace ARQODE_VISUAL_EDITOR.REGISTRO_ACCESOS
{
    partial class VentanaEdicion
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
            this.PContent = new System.Windows.Forms.Panel();
            this.PTop = new System.Windows.Forms.Panel();
            this.BNuevaFila = new System.Windows.Forms.Button();
            this.BGuardar = new System.Windows.Forms.Button();
            this.PContenido = new System.Windows.Forms.Panel();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.PContent.SuspendLayout();
            this.PTop.SuspendLayout();
            this.PContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.SuspendLayout();
            // 
            // PContent
            // 
            this.PContent.Controls.Add(this.PTop);
            this.PContent.Controls.Add(this.PContenido);
            this.PContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PContent.Location = new System.Drawing.Point(0, 0);
            this.PContent.Name = "PContent";
            this.PContent.Size = new System.Drawing.Size(786, 479);
            this.PContent.TabIndex = 0;
            // 
            // PTop
            // 
            this.PTop.Controls.Add(this.BNuevaFila);
            this.PTop.Controls.Add(this.BGuardar);
            this.PTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PTop.Location = new System.Drawing.Point(0, 0);
            this.PTop.Name = "PTop";
            this.PTop.Size = new System.Drawing.Size(786, 46);
            this.PTop.TabIndex = 2;
            // 
            // BNuevaFila
            // 
            this.BNuevaFila.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BNuevaFila.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BNuevaFila.Location = new System.Drawing.Point(643, 7);
            this.BNuevaFila.Name = "BNuevaFila";
            this.BNuevaFila.Size = new System.Drawing.Size(131, 33);
            this.BNuevaFila.TabIndex = 0;
            this.BNuevaFila.Text = "Añadir fila";
            this.BNuevaFila.UseVisualStyleBackColor = true;
            // 
            // BGuardar
            // 
            this.BGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BGuardar.Location = new System.Drawing.Point(506, 7);
            this.BGuardar.Name = "BGuardar";
            this.BGuardar.Size = new System.Drawing.Size(131, 33);
            this.BGuardar.TabIndex = 0;
            this.BGuardar.Text = "Guardar";
            this.BGuardar.UseVisualStyleBackColor = true;
            // 
            // PContenido
            // 
            this.PContenido.Controls.Add(this.Grid1);
            this.PContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PContenido.Location = new System.Drawing.Point(0, 0);
            this.PContenido.Name = "PContenido";
            this.PContenido.Size = new System.Drawing.Size(786, 479);
            this.PContenido.TabIndex = 1;
            // 
            // Grid1
            // 
            this.Grid1.AllowUserToAddRows = false;
            this.Grid1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Aqua;
            this.Grid1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Grid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid1.GridColor = System.Drawing.Color.Silver;
            this.Grid1.Location = new System.Drawing.Point(3, 52);
            this.Grid1.MultiSelect = false;
            this.Grid1.Name = "Grid1";
            this.Grid1.Size = new System.Drawing.Size(755, 403);
            this.Grid1.TabIndex = 1;
            this.Grid1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.Grid1_DataError);
            // 
            // VentanaEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 479);
            this.Controls.Add(this.PContent);
            this.Name = "VentanaEdicion";
            this.Text = "Edición de datos";
            this.PContent.ResumeLayout(false);
            this.PTop.ResumeLayout(false);
            this.PContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PContent;
        private System.Windows.Forms.Panel PTop;
        private System.Windows.Forms.Button BGuardar;
        private System.Windows.Forms.Panel PContenido;
        private System.Windows.Forms.DataGridView Grid1;
        private System.Windows.Forms.Button BNuevaFila;
    }
}
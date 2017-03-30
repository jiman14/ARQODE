namespace ARQODE_VISUAL_EDITOR
{
    partial class MapUI
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
            this.PContenido = new System.Windows.Forms.FlowLayoutPanel();
            this.CBProyectos = new System.Windows.Forms.ComboBox();
            this.CBForms = new System.Windows.Forms.ComboBox();
            this.CBDialogo = new System.Windows.Forms.CheckBox();
            this.BVerForm = new System.Windows.Forms.Button();
            this.BGenerar = new System.Windows.Forms.Button();
            this.BGuardar = new System.Windows.Forms.Button();
            this.PPreview = new System.Windows.Forms.Panel();
            this.TB_Preview = new System.Windows.Forms.TextBox();
            this.SaveDiag = new System.Windows.Forms.SaveFileDialog();
            this.PContenido.SuspendLayout();
            this.PPreview.SuspendLayout();
            this.SuspendLayout();
            // 
            // PContenido
            // 
            this.PContenido.Controls.Add(this.CBProyectos);
            this.PContenido.Controls.Add(this.CBForms);
            this.PContenido.Controls.Add(this.CBDialogo);
            this.PContenido.Controls.Add(this.BVerForm);
            this.PContenido.Controls.Add(this.BGenerar);
            this.PContenido.Controls.Add(this.BGuardar);
            this.PContenido.Dock = System.Windows.Forms.DockStyle.Top;
            this.PContenido.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PContenido.Location = new System.Drawing.Point(0, 0);
            this.PContenido.Name = "PContenido";
            this.PContenido.Size = new System.Drawing.Size(1076, 76);
            this.PContenido.TabIndex = 3;
            // 
            // CBProyectos
            // 
            this.CBProyectos.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBProyectos.FormattingEnabled = true;
            this.CBProyectos.Location = new System.Drawing.Point(10, 10);
            this.CBProyectos.Margin = new System.Windows.Forms.Padding(10);
            this.CBProyectos.Name = "CBProyectos";
            this.CBProyectos.Size = new System.Drawing.Size(167, 24);
            this.CBProyectos.TabIndex = 8;
            this.CBProyectos.SelectedIndexChanged += new System.EventHandler(this.TBProyectos_SelectedIndexChanged);
            // 
            // CBForms
            // 
            this.CBForms.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBForms.FormattingEnabled = true;
            this.CBForms.Location = new System.Drawing.Point(197, 10);
            this.CBForms.Margin = new System.Windows.Forms.Padding(10);
            this.CBForms.Name = "CBForms";
            this.CBForms.Size = new System.Drawing.Size(239, 24);
            this.CBForms.TabIndex = 4;
            // 
            // CBDialogo
            // 
            this.CBDialogo.AutoSize = true;
            this.CBDialogo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.CBDialogo.Location = new System.Drawing.Point(449, 3);
            this.CBDialogo.Name = "CBDialogo";
            this.CBDialogo.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.CBDialogo.Size = new System.Drawing.Size(76, 40);
            this.CBDialogo.TabIndex = 7;
            this.CBDialogo.Text = "Dialogo";
            this.CBDialogo.UseVisualStyleBackColor = true;
            // 
            // BVerForm
            // 
            this.BVerForm.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BVerForm.Location = new System.Drawing.Point(528, 10);
            this.BVerForm.Margin = new System.Windows.Forms.Padding(0, 10, 10, 10);
            this.BVerForm.Name = "BVerForm";
            this.BVerForm.Size = new System.Drawing.Size(75, 23);
            this.BVerForm.TabIndex = 3;
            this.BVerForm.Text = "Ver form";
            this.BVerForm.UseVisualStyleBackColor = true;
            this.BVerForm.Click += new System.EventHandler(this.BVerForm_Click);
            // 
            // BGenerar
            // 
            this.BGenerar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BGenerar.Location = new System.Drawing.Point(613, 10);
            this.BGenerar.Margin = new System.Windows.Forms.Padding(0, 10, 10, 10);
            this.BGenerar.Name = "BGenerar";
            this.BGenerar.Size = new System.Drawing.Size(151, 23);
            this.BGenerar.TabIndex = 5;
            this.BGenerar.Text = "Generar ARQODE UI CODE";
            this.BGenerar.UseVisualStyleBackColor = true;
            this.BGenerar.Click += new System.EventHandler(this.BGenerar_Click);
            // 
            // BGuardar
            // 
            this.BGuardar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BGuardar.Location = new System.Drawing.Point(774, 10);
            this.BGuardar.Margin = new System.Windows.Forms.Padding(0, 10, 10, 10);
            this.BGuardar.Name = "BGuardar";
            this.BGuardar.Size = new System.Drawing.Size(80, 23);
            this.BGuardar.TabIndex = 6;
            this.BGuardar.Text = "Guardar";
            this.BGuardar.UseVisualStyleBackColor = true;
            this.BGuardar.Click += new System.EventHandler(this.BGuardar_Click);
            // 
            // PPreview
            // 
            this.PPreview.Controls.Add(this.TB_Preview);
            this.PPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PPreview.Location = new System.Drawing.Point(0, 76);
            this.PPreview.Name = "PPreview";
            this.PPreview.Size = new System.Drawing.Size(1076, 360);
            this.PPreview.TabIndex = 5;
            // 
            // TB_Preview
            // 
            this.TB_Preview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TB_Preview.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_Preview.Location = new System.Drawing.Point(0, 0);
            this.TB_Preview.Multiline = true;
            this.TB_Preview.Name = "TB_Preview";
            this.TB_Preview.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TB_Preview.Size = new System.Drawing.Size(1076, 360);
            this.TB_Preview.TabIndex = 2;
            // 
            // SaveDiag
            // 
            this.SaveDiag.FileName = "Nombre ventanta.json";
            // 
            // MapUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 436);
            this.Controls.Add(this.PPreview);
            this.Controls.Add(this.PContenido);
            this.Name = "MapUI";
            this.Text = "ARQODE UI DESIGNER";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.PContenido.ResumeLayout(false);
            this.PContenido.PerformLayout();
            this.PPreview.ResumeLayout(false);
            this.PPreview.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel PContenido;
        private System.Windows.Forms.ComboBox CBForms;
        private System.Windows.Forms.Button BVerForm;
        private System.Windows.Forms.Button BGenerar;
        private System.Windows.Forms.Panel PPreview;
        private System.Windows.Forms.TextBox TB_Preview;
        private System.Windows.Forms.Button BGuardar;
        private System.Windows.Forms.SaveFileDialog SaveDiag;
        private System.Windows.Forms.CheckBox CBDialogo;
        private System.Windows.Forms.ComboBox CBProyectos;
    }
}


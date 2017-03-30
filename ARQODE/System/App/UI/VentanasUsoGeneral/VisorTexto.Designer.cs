namespace ARQODE_VISUAL_EDITOR.ARQODE_UI
{
    partial class VisorTexto
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
            this.PTop = new System.Windows.Forms.Panel();
            this.PContent = new System.Windows.Forms.Panel();
            this.RB_Texto = new System.Windows.Forms.RichTextBox();
            this.TB_Busqueda = new System.Windows.Forms.TextBox();
            this.CH_CaseSensitive = new System.Windows.Forms.CheckBox();
            this.CH_Palabra = new System.Windows.Forms.CheckBox();
            this.BBuscar = new System.Windows.Forms.Button();
            this.LRes = new System.Windows.Forms.Label();
            this.PTop.SuspendLayout();
            this.PContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // PTop
            // 
            this.PTop.Controls.Add(this.LRes);
            this.PTop.Controls.Add(this.BBuscar);
            this.PTop.Controls.Add(this.CH_Palabra);
            this.PTop.Controls.Add(this.CH_CaseSensitive);
            this.PTop.Controls.Add(this.TB_Busqueda);
            this.PTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PTop.Location = new System.Drawing.Point(0, 0);
            this.PTop.Name = "PTop";
            this.PTop.Size = new System.Drawing.Size(923, 49);
            this.PTop.TabIndex = 1;
            // 
            // PContent
            // 
            this.PContent.Controls.Add(this.RB_Texto);
            this.PContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PContent.Location = new System.Drawing.Point(0, 49);
            this.PContent.Name = "PContent";
            this.PContent.Size = new System.Drawing.Size(923, 481);
            this.PContent.TabIndex = 2;
            // 
            // RB_Texto
            // 
            this.RB_Texto.AcceptsTab = true;
            this.RB_Texto.AutoWordSelection = true;
            this.RB_Texto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RB_Texto.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RB_Texto.Location = new System.Drawing.Point(0, 0);
            this.RB_Texto.Name = "RB_Texto";
            this.RB_Texto.Size = new System.Drawing.Size(923, 481);
            this.RB_Texto.TabIndex = 1;
            this.RB_Texto.Text = "";
            this.RB_Texto.WordWrap = false;
            // 
            // TB_Busqueda
            // 
            this.TB_Busqueda.Font = new System.Drawing.Font("Arial", 9.75F);
            this.TB_Busqueda.Location = new System.Drawing.Point(13, 13);
            this.TB_Busqueda.Name = "TB_Busqueda";
            this.TB_Busqueda.Size = new System.Drawing.Size(316, 22);
            this.TB_Busqueda.TabIndex = 0;
            // 
            // CH_CaseSensitive
            // 
            this.CH_CaseSensitive.AutoSize = true;
            this.CH_CaseSensitive.Font = new System.Drawing.Font("Arial", 9.75F);
            this.CH_CaseSensitive.Location = new System.Drawing.Point(335, 15);
            this.CH_CaseSensitive.Name = "CH_CaseSensitive";
            this.CH_CaseSensitive.Size = new System.Drawing.Size(43, 20);
            this.CH_CaseSensitive.TabIndex = 1;
            this.CH_CaseSensitive.Text = "Aa";
            this.CH_CaseSensitive.UseVisualStyleBackColor = true;
            // 
            // CH_Palabra
            // 
            this.CH_Palabra.AutoSize = true;
            this.CH_Palabra.Font = new System.Drawing.Font("Arial", 9.75F);
            this.CH_Palabra.Location = new System.Drawing.Point(384, 16);
            this.CH_Palabra.Name = "CH_Palabra";
            this.CH_Palabra.Size = new System.Drawing.Size(142, 20);
            this.CH_Palabra.TabIndex = 1;
            this.CH_Palabra.Text = "Palabras completas";
            this.CH_Palabra.UseVisualStyleBackColor = true;
            // 
            // BBuscar
            // 
            this.BBuscar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBuscar.Location = new System.Drawing.Point(540, 12);
            this.BBuscar.Name = "BBuscar";
            this.BBuscar.Size = new System.Drawing.Size(105, 30);
            this.BBuscar.TabIndex = 2;
            this.BBuscar.Text = "Buscar";
            this.BBuscar.UseVisualStyleBackColor = true;
            // 
            // LRes
            // 
            this.LRes.AutoSize = true;
            this.LRes.Font = new System.Drawing.Font("Arial", 9.75F);
            this.LRes.Location = new System.Drawing.Point(661, 19);
            this.LRes.Name = "LRes";
            this.LRes.Size = new System.Drawing.Size(0, 16);
            this.LRes.TabIndex = 3;
            // 
            // VisorTexto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 530);
            this.Controls.Add(this.PContent);
            this.Controls.Add(this.PTop);
            this.AcceptButton = this.BBuscar;
            this.Name = "VisorTexto";
            this.Text = "Visor";
            this.PTop.ResumeLayout(false);
            this.PTop.PerformLayout();
            this.PContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PTop;
        private System.Windows.Forms.Button BBuscar;
        private System.Windows.Forms.CheckBox CH_Palabra;
        private System.Windows.Forms.CheckBox CH_CaseSensitive;
        private System.Windows.Forms.TextBox TB_Busqueda;
        private System.Windows.Forms.Panel PContent;
        private System.Windows.Forms.RichTextBox RB_Texto;
        private System.Windows.Forms.Label LRes;
    }
}
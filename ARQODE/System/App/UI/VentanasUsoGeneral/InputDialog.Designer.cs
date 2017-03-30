namespace ARQODE_VISUAL_EDITOR.ARQODE_UI
{
    partial class InputDialog
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BCancelar = new System.Windows.Forms.Button();
            this.BAceptar = new System.Windows.Forms.Button();
            this.PContenido = new System.Windows.Forms.Panel();
            this.PTextBox = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.PLabel = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.PContenido.SuspendLayout();
            this.PTextBox.SuspendLayout();
            this.PLabel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BCancelar);
            this.panel1.Controls.Add(this.BAceptar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(633, 56);
            this.panel1.TabIndex = 0;
            // 
            // BCancelar
            // 
            this.BCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCancelar.Location = new System.Drawing.Point(413, 14);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(101, 30);
            this.BCancelar.TabIndex = 2;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.UseVisualStyleBackColor = true;
            this.BCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // BAceptar
            // 
            this.BAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BAceptar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAceptar.Location = new System.Drawing.Point(520, 14);
            this.BAceptar.Name = "BAceptar";
            this.BAceptar.Size = new System.Drawing.Size(101, 30);
            this.BAceptar.TabIndex = 1;
            this.BAceptar.Text = "Aceptar";
            this.BAceptar.UseVisualStyleBackColor = true;
            this.BAceptar.Click += new System.EventHandler(this.BAceptar_Click);
            // 
            // PContenido
            // 
            this.PContenido.Controls.Add(this.PTextBox);
            this.PContenido.Controls.Add(this.PLabel);
            this.PContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PContenido.Location = new System.Drawing.Point(0, 0);
            this.PContenido.Name = "PContenido";
            this.PContenido.Size = new System.Drawing.Size(633, 85);
            this.PContenido.TabIndex = 1;
            // 
            // PTextBox
            // 
            this.PTextBox.Controls.Add(this.textBox1);
            this.PTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PTextBox.Location = new System.Drawing.Point(0, 38);
            this.PTextBox.Name = "PTextBox";
            this.PTextBox.Size = new System.Drawing.Size(633, 47);
            this.PTextBox.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(16, 3);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(605, 32);
            this.textBox1.TabIndex = 0;
            // 
            // PLabel
            // 
            this.PLabel.Controls.Add(this.Label1);
            this.PLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PLabel.Location = new System.Drawing.Point(0, 0);
            this.PLabel.Name = "PLabel";
            this.PLabel.Size = new System.Drawing.Size(633, 38);
            this.PLabel.TabIndex = 0;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(13, 13);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(42, 16);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "label1";
            // 
            // InputDialog
            // 
            this.AcceptButton = this.BAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BCancelar;
            this.ClientSize = new System.Drawing.Size(633, 141);
            this.Controls.Add(this.PContenido);
            this.Controls.Add(this.panel1);
            this.Name = "InputDialog";
            this.Text = "Entrada de datos";
            this.Shown += new System.EventHandler(this.InputDialog_Shown);
            this.panel1.ResumeLayout(false);
            this.PContenido.ResumeLayout(false);
            this.PTextBox.ResumeLayout(false);
            this.PTextBox.PerformLayout();
            this.PLabel.ResumeLayout(false);
            this.PLabel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Button BAceptar;
        private System.Windows.Forms.Panel PContenido;
        private System.Windows.Forms.Panel PTextBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel PLabel;
        private System.Windows.Forms.Label Label1;
    }
}
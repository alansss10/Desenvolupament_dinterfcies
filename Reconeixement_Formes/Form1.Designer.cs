namespace Reconeixement_Formes
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnAturar = new System.Windows.Forms.Button();
            this.lblForma = new System.Windows.Forms.Label();
            this.chkContorns = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(776, 202);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(24, 284);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(109, 23);
            this.btnIniciar.TabIndex = 1;
            this.btnIniciar.Text = "Iniciar Càmera";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnAturar
            // 
            this.btnAturar.Location = new System.Drawing.Point(139, 284);
            this.btnAturar.Name = "btnAturar";
            this.btnAturar.Size = new System.Drawing.Size(75, 23);
            this.btnAturar.TabIndex = 2;
            this.btnAturar.Text = "Aturar";
            this.btnAturar.UseVisualStyleBackColor = true;
            // 
            // lblForma
            // 
            this.lblForma.AutoSize = true;
            this.lblForma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblForma.Location = new System.Drawing.Point(29, 321);
            this.lblForma.Name = "lblForma";
            this.lblForma.Size = new System.Drawing.Size(185, 20);
            this.lblForma.TabIndex = 3;
            this.lblForma.Text = "Forma detectada: [Cap]";
            // 
            // chkContorns
            // 
            this.chkContorns.AutoSize = true;
            this.chkContorns.Location = new System.Drawing.Point(257, 288);
            this.chkContorns.Name = "chkContorns";
            this.chkContorns.Size = new System.Drawing.Size(105, 17);
            this.chkContorns.TabIndex = 4;
            this.chkContorns.Text = "Mostrar contorns";
            this.chkContorns.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chkContorns);
            this.Controls.Add(this.lblForma);
            this.Controls.Add(this.btnAturar);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnAturar;
        private System.Windows.Forms.Label lblForma;
        private System.Windows.Forms.CheckBox chkContorns;
    }
}


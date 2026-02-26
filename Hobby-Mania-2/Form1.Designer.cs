namespace Hobby_Mania_2
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
            this.btnCarregar1 = new System.Windows.Forms.Button();
            this.btnGris1 = new System.Windows.Forms.Button();
            this.btnSuavitzat1 = new System.Windows.Forms.Button();
            this.btnSegmentacio1 = new System.Windows.Forms.Button();
            this.btnContorn1 = new System.Windows.Forms.Button();
            this.btnAfegir1 = new System.Windows.Forms.Button();
            this.btnInforme1 = new System.Windows.Forms.Button();
            this.tbCerca1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(41, 122);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(411, 268);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnCarregar1
            // 
            this.btnCarregar1.Location = new System.Drawing.Point(39, 415);
            this.btnCarregar1.Name = "btnCarregar1";
            this.btnCarregar1.Size = new System.Drawing.Size(134, 73);
            this.btnCarregar1.TabIndex = 2;
            this.btnCarregar1.Text = "Carregar Imatge";
            this.btnCarregar1.UseVisualStyleBackColor = true;
            this.btnCarregar1.Click += new System.EventHandler(this.btnCarregar1_Click);
            // 
            // btnGris1
            // 
            this.btnGris1.Location = new System.Drawing.Point(179, 418);
            this.btnGris1.Name = "btnGris1";
            this.btnGris1.Size = new System.Drawing.Size(134, 70);
            this.btnGris1.TabIndex = 3;
            this.btnGris1.Text = "Convertir a Gris";
            this.btnGris1.UseVisualStyleBackColor = true;
            this.btnGris1.Click += new System.EventHandler(this.btnGris1_Click);
            // 
            // btnSuavitzat1
            // 
            this.btnSuavitzat1.Location = new System.Drawing.Point(179, 570);
            this.btnSuavitzat1.Name = "btnSuavitzat1";
            this.btnSuavitzat1.Size = new System.Drawing.Size(134, 70);
            this.btnSuavitzat1.TabIndex = 4;
            this.btnSuavitzat1.Text = "Suavitzat";
            this.btnSuavitzat1.UseVisualStyleBackColor = true;
            this.btnSuavitzat1.Click += new System.EventHandler(this.btnSuavitzat1_Click);
            // 
            // btnSegmentacio1
            // 
            this.btnSegmentacio1.Location = new System.Drawing.Point(179, 494);
            this.btnSegmentacio1.Name = "btnSegmentacio1";
            this.btnSegmentacio1.Size = new System.Drawing.Size(134, 70);
            this.btnSegmentacio1.TabIndex = 5;
            this.btnSegmentacio1.Text = "Segmentació";
            this.btnSegmentacio1.UseVisualStyleBackColor = true;
            this.btnSegmentacio1.Click += new System.EventHandler(this.btnSegmentacio1_Click);
            // 
            // btnContorn1
            // 
            this.btnContorn1.Location = new System.Drawing.Point(319, 418);
            this.btnContorn1.Name = "btnContorn1";
            this.btnContorn1.Size = new System.Drawing.Size(133, 70);
            this.btnContorn1.TabIndex = 6;
            this.btnContorn1.Text = "Contorn";
            this.btnContorn1.UseVisualStyleBackColor = true;
            this.btnContorn1.Click += new System.EventHandler(this.btnContorn1_Click);
            // 
            // btnAfegir1
            // 
            this.btnAfegir1.Location = new System.Drawing.Point(717, 419);
            this.btnAfegir1.Name = "btnAfegir1";
            this.btnAfegir1.Size = new System.Drawing.Size(133, 69);
            this.btnAfegir1.TabIndex = 7;
            this.btnAfegir1.Text = "Afegir Polígon";
            this.btnAfegir1.UseVisualStyleBackColor = true;
            this.btnAfegir1.Click += new System.EventHandler(this.btnAfegir1_Click);
            // 
            // btnInforme1
            // 
            this.btnInforme1.Location = new System.Drawing.Point(995, 417);
            this.btnInforme1.Name = "btnInforme1";
            this.btnInforme1.Size = new System.Drawing.Size(133, 70);
            this.btnInforme1.TabIndex = 8;
            this.btnInforme1.Text = "Informe PDF";
            this.btnInforme1.UseVisualStyleBackColor = true;
            this.btnInforme1.Click += new System.EventHandler(this.btnInforme1_Click);
            // 
            // tbCerca1
            // 
            this.tbCerca1.Location = new System.Drawing.Point(871, 442);
            this.tbCerca1.Name = "tbCerca1";
            this.tbCerca1.Size = new System.Drawing.Size(118, 20);
            this.tbCerca1.TabIndex = 9;
            this.tbCerca1.TextChanged += new System.EventHandler(this.tbCerca1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(376, 495);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Cerca:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(717, 122);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(411, 268);
            this.dataGridView1.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbCerca1);
            this.Controls.Add(this.btnInforme1);
            this.Controls.Add(this.btnAfegir1);
            this.Controls.Add(this.btnContorn1);
            this.Controls.Add(this.btnSegmentacio1);
            this.Controls.Add(this.btnSuavitzat1);
            this.Controls.Add(this.btnGris1);
            this.Controls.Add(this.btnCarregar1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Sistema de Triatge de Peces - Hobby Mania";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCarregar1;
        private System.Windows.Forms.Button btnGris1;
        private System.Windows.Forms.Button btnSuavitzat1;
        private System.Windows.Forms.Button btnSegmentacio1;
        private System.Windows.Forms.Button btnContorn1;
        private System.Windows.Forms.Button btnAfegir1;
        private System.Windows.Forms.Button btnInforme1;
        private System.Windows.Forms.TextBox tbCerca1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}


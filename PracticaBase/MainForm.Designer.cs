namespace PracticaEvaluable2
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBoxStudents = new ListBox();
            label1 = new Label();
            label2 = new Label();
            listBoxAdmins = new ListBox();
            buttonExit = new Button();
            SuspendLayout();
            // 
            // listBoxStudents
            // 
            listBoxStudents.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBoxStudents.FormattingEnabled = true;
            listBoxStudents.ItemHeight = 15;
            listBoxStudents.Location = new Point(12, 44);
            listBoxStudents.Name = "listBoxStudents";
            listBoxStudents.SelectionMode = SelectionMode.None;
            listBoxStudents.Size = new Size(635, 139);
            listBoxStudents.TabIndex = 0;
            listBoxStudents.SelectedIndexChanged += listBoxStudents_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 26);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 1;
            label1.Text = "Students";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 186);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 2;
            label2.Text = "Admins";
            // 
            // listBoxAdmins
            // 
            listBoxAdmins.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBoxAdmins.FormattingEnabled = true;
            listBoxAdmins.ItemHeight = 15;
            listBoxAdmins.Location = new Point(12, 204);
            listBoxAdmins.Name = "listBoxAdmins";
            listBoxAdmins.SelectionMode = SelectionMode.None;
            listBoxAdmins.Size = new Size(635, 94);
            listBoxAdmins.TabIndex = 3;
            // 
            // buttonExit
            // 
            buttonExit.Location = new Point(572, 304);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(75, 23);
            buttonExit.TabIndex = 4;
            buttonExit.Text = "Exit";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += buttonExit_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(659, 336);
            Controls.Add(buttonExit);
            Controls.Add(listBoxAdmins);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listBoxStudents);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Application with Usability, Accessibility, Polymorphism, and Inheritance";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxStudents;
        private Label label1;
        private Label label2;
        private ListBox listBoxAdmins;
        private Button buttonExit;
    }
}

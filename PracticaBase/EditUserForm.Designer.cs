namespace PracticaEvaluable2
{
    partial class EditUserForm
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
            groupBox1 = new GroupBox();
            comboBoxUserType = new ComboBox();
            label4 = new Label();
            textBoxMail = new TextBox();
            textBoxName = new TextBox();
            textBoxId = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            buttonSave = new Button();
            buttonCancel = new Button();
            groupBoxCustomData = new GroupBox();
            textBoxCustomData = new TextBox();
            labelCustomData = new Label();
            buttonDelete = new Button();
            groupBox1.SuspendLayout();
            groupBoxCustomData.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboBoxUserType);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(textBoxMail);
            groupBox1.Controls.Add(textBoxName);
            groupBox1.Controls.Add(textBoxId);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(13, 13);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(330, 128);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "User Data";
            // 
            // comboBoxUserType
            // 
            comboBoxUserType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxUserType.FormattingEnabled = true;
            comboBoxUserType.Location = new Point(194, 29);
            comboBoxUserType.Name = "comboBoxUserType";
            comboBoxUserType.Size = new Size(121, 23);
            comboBoxUserType.TabIndex = 7;
            comboBoxUserType.SelectedIndexChanged += comboBoxUserType_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(157, 31);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 6;
            label4.Text = "Type";
            // 
            // textBoxMail
            // 
            textBoxMail.Location = new Point(51, 87);
            textBoxMail.Name = "textBoxMail";
            textBoxMail.Size = new Size(264, 23);
            textBoxMail.TabIndex = 5;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(51, 58);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(264, 23);
            textBoxName.TabIndex = 4;
            // 
            // textBoxId
            // 
            textBoxId.Enabled = false;
            textBoxId.Location = new Point(51, 28);
            textBoxId.Name = "textBoxId";
            textBoxId.Size = new Size(100, 23);
            textBoxId.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 31);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.No;
            label3.Size = new Size(17, 15);
            label3.TabIndex = 2;
            label3.Text = "Id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 87);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 1;
            label2.Text = "Mail";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 58);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(187, 210);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 1;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(268, 210);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 2;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // groupBoxCustomData
            // 
            groupBoxCustomData.Controls.Add(textBoxCustomData);
            groupBoxCustomData.Controls.Add(labelCustomData);
            groupBoxCustomData.Location = new Point(13, 147);
            groupBoxCustomData.Name = "groupBoxCustomData";
            groupBoxCustomData.Size = new Size(331, 57);
            groupBoxCustomData.TabIndex = 3;
            groupBoxCustomData.TabStop = false;
            groupBoxCustomData.Text = "Student Data";
            // 
            // textBoxCustomData
            // 
            textBoxCustomData.Location = new Point(52, 23);
            textBoxCustomData.Name = "textBoxCustomData";
            textBoxCustomData.Size = new Size(264, 23);
            textBoxCustomData.TabIndex = 1;
            // 
            // labelCustomData
            // 
            labelCustomData.AutoSize = true;
            labelCustomData.Location = new Point(7, 26);
            labelCustomData.Name = "labelCustomData";
            labelCustomData.Size = new Size(44, 15);
            labelCustomData.TabIndex = 0;
            labelCustomData.Text = "Course";
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(12, 210);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 23);
            buttonDelete.TabIndex = 4;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // EditUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(358, 242);
            Controls.Add(buttonDelete);
            Controls.Add(groupBoxCustomData);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(groupBox1);
            Name = "EditUserForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EditUserForm";
            Load += EditUserForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBoxCustomData.ResumeLayout(false);
            groupBoxCustomData.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private TextBox textBoxMail;
        private TextBox textBoxName;
        private TextBox textBoxId;
        private Label label3;
        private Button buttonSave;
        private Button buttonCancel;
        private GroupBox groupBoxCustomData;
        private TextBox textBoxCustomData;
        private Label labelCustomData;
        private Label label4;
        private ComboBox comboBoxUserType;
        private Button buttonDelete;
    }
}
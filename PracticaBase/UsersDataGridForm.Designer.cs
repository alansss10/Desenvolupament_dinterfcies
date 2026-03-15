namespace PracticaEvaluable2
{
    partial class UsersDataGridForm
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
            usersDataGridView = new DataGridView();
            closeButton = new Button();
            buttonAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)usersDataGridView).BeginInit();
            SuspendLayout();
            // 
            // usersDataGridView
            // 
            usersDataGridView.AllowUserToAddRows = false;
            usersDataGridView.AllowUserToDeleteRows = false;
            usersDataGridView.AllowUserToOrderColumns = true;
            usersDataGridView.AllowUserToResizeRows = false;
            usersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            usersDataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            usersDataGridView.Location = new Point(12, 12);
            usersDataGridView.MultiSelect = false;
            usersDataGridView.Name = "usersDataGridView";
            usersDataGridView.Size = new Size(604, 386);
            usersDataGridView.TabIndex = 0;
            usersDataGridView.CellContentClick += usersDataGridView_CellContentClick;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(541, 404);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(75, 23);
            closeButton.TabIndex = 1;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // button1
            // 
            buttonAdd.Location = new Point(12, 404);
            buttonAdd.Name = "button1";
            buttonAdd.Size = new Size(75, 23);
            buttonAdd.TabIndex = 2;
            buttonAdd.Text = "buttonAdd";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += addButton_Click;
            // 
            // UsersDataGridForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(629, 437);
            Controls.Add(buttonAdd);
            Controls.Add(closeButton);
            Controls.Add(usersDataGridView);
            Name = "UsersDataGridForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Users Repository";
            Load += UsersDataGrid_Load;
            ((System.ComponentModel.ISupportInitialize)usersDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView usersDataGridView;
        private Button closeButton;
        private Button buttonAdd;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace PracticaEvaluable2
{
    public partial class UsersDataGridForm : Form
    {
        private UsersRepository Repository;
        private MainForm MainForm;

        public UsersDataGridForm(MainForm main)
        {
            InitializeComponent();
            Repository = UsersRepository.GetInstance();
            MainForm = main;
        }

        private void UsersDataGrid_Load(object sender, EventArgs e)
        {
            usersDataGridView.ColumnCount = 4;
            usersDataGridView.Columns[0].Name = "ID";
            usersDataGridView.Columns[1].Name = "First Name";
            usersDataGridView.Columns[2].Name = "Last Name";
            usersDataGridView.Columns[3].Name = "Type";
            usersDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            buttonAdd.Text = "Add";

            InitDataGridRows();
        }

        private void InitDataGridRows()
        {
            usersDataGridView.Rows.Clear();
            Repository.GetAll()
                .ForEach(u =>
                {
                    var row = new string[] { u.Id.ToString(), u.Name, u.Mail, u.GetUserType().ToString() };
                    usersDataGridView.Rows.Add(row);
                });
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void usersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = usersDataGridView.Rows[e.RowIndex];
            var id = row.Cells[0].Value;

            UserBase? user = Repository.GetById(int.Parse(id.ToString()));
            var editForm = new EditUserForm(this, user);
            editForm.ShowDialog();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var editForm = new EditUserForm(this);
            editForm.ShowDialog();
        }

        public void RefreshFormData()
        {
            InitDataGridRows();
            MainForm.RefreshFormData();
        }
    }
}

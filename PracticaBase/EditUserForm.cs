using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaEvaluable2
{
    public partial class EditUserForm : Form
    {
        private UserBase? User;
        private UsersRepository Repository;
        private UsersDataGridForm DataGridForm;

        public EditUserForm(UsersDataGridForm dataGridForm, UserBase? user = null)
        {
            InitializeComponent();
            User = user;
            Repository = UsersRepository.GetInstance();
            DataGridForm = dataGridForm;
        }

        private void EditUserForm_Load(object sender, EventArgs e)
        {
            comboBoxUserType.DataSource = Enum.GetValues(typeof(UserType));

            if (User == null)
            {
                this.Text = "Create New User";
                textBoxId.Text = Repository.GetNextUserId().ToString();
                buttonSave.Text = "Create";
                buttonDelete.Enabled = false;
            }
            else
            {
                this.Text = $"Update User - {User.Name} (id: {User.Id})";
                textBoxId.Text = User.Id.ToString();
                textBoxName.Text = User.Name; 
                textBoxMail.Text = User.Mail;
                comboBoxUserType.SelectedItem = User.GetUserType();
                comboBoxUserType.Enabled = false;
                buttonSave.Text = "Update";


                SetCustomDataLabels(User.GetUserType());

                if (User.GetUserType() == UserType.Student)
                {
                    Student s = (Student)User;
                    textBoxCustomData.Text = s.Course;
                }
                else
                {
                    textBoxCustomData.Text = ((Admin)User).Department;
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!IsValidForm())
            {
                return;
            }

            if (User == null)
            {
                User = (UserType)comboBoxUserType.SelectedValue == UserType.Admin ?
                    new Admin(int.Parse(textBoxId.Text), textBoxName.Text, textBoxMail.Text, textBoxCustomData.Text) :
                new Student(int.Parse(textBoxId.Text), textBoxName.Text, textBoxMail.Text, textBoxCustomData.Text);
                
                Repository.Add(User);

                MessageBox.Show($"User {User.Name} ({User.Id}) successfully created", "User created", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                User.Name = textBoxName.Text;
                User.Mail = textBoxMail.Text;
                if (User.GetUserType() == UserType.Admin)
                {
                    var a = (Admin)User;
                    a.Department = textBoxCustomData.Text;
                }
                else
                {
                    var s = (Student)User;
                   s.Course = textBoxCustomData.Text;
                }
                
                Repository.Update(User);
               
                MessageBox.Show($"User {User.Name} ({User.Id}) successfully updated", "User updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            DataGridForm.RefreshFormData();
            this.Dispose();
        }

        private bool IsValidForm()
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Name can not be null or empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(textBoxMail.Text))
            {
                MessageBox.Show("Mail can not be null or empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void comboBoxUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCustomDataLabels((UserType)comboBoxUserType.SelectedValue);
        }

        private void SetCustomDataLabels(UserType type)
        {
            labelCustomData.Text = type == UserType.Student ? "Course" : "Dept.";
            groupBoxCustomData.Text = (type == UserType.Student ? "Student" : "Admin") + " Data";
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"User {User.Name} ({User.Id}) will be removed. Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes) {
                Repository.Delete(User.Id);
                MessageBox.Show($"User {User.Name} ({User.Id}) have been removed", "User removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataGridForm.RefreshFormData();
                this.Dispose();
            }
        }
    }
}

using System;
using System.Windows.Forms;

namespace PracticaEvaluable2
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
        }

        private void HelpForm_Load(object sender, EventArgs e)
        {
            this.Text = "Manual de Ayuda";
        }
    }
}
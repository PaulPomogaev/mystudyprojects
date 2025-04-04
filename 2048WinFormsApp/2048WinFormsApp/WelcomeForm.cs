using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048WinFormsApp
{
    public partial class WelcomeForm : Form
    {
        public string PlayerName { get; private set; }

        public WelcomeForm()
        {
            InitializeComponent();

        }

        private void btnStart_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите имя!");
                return;
            }
            PlayerName = txtName.Text.Trim();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

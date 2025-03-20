using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeniyIdiotWinFormsApp
{
    public partial class WellcomeForm : Form
    {
        public string UserName => userNameTextBox.Text.Trim();
        public WellcomeForm()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(userNameTextBox.Text))
            {
                MessageBox.Show("Введите ваше имя");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}

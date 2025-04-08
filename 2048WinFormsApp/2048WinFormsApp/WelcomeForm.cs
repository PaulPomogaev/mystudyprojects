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
        public int MapSize { get; private set; } = 4;

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

            if (radio5x5.Checked)
            {
                MapSize = 5;
            }
            else if (radio6x6.Checked)
            {
                MapSize = 6;
            }
            else if (radio7x7.Checked)
            {
                MapSize = 7;
            }


            PlayerName = txtName.Text.Trim();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

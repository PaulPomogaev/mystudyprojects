using System;
using System.Windows.Forms;

namespace FrogWinFormsApp
{
    public partial class WinForm : Form
    {
        public WinForm()
        {
            InitializeComponent();
        }

        public void SetMessage(int moves, int target)
        {
            string message;

            if (moves == target)
            {
                message = $"Поздравляем! Вы решили головоломку за {moves} ходов!";
            }
            else
            {
                message = $"Поздравляем! Лучший результат: {target} ходов. Ваш результат: {moves}";
            }

            messageLabel.Text = message + "\nХотите сыграть ещё раз?";
        }

        private void yesButton_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void noButton_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }
    }
}

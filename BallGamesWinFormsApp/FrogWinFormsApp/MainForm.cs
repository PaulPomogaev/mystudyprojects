using System;
using System.Windows.Forms;

namespace FrogWinFormsApp
{
    public partial class Frog : Form
    {
        private int moveCount = 0;
        private const int targetMoves = 24;

        public Frog()
        {
            InitializeComponent();
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            Swap((PictureBox)sender);
        }

        private void Swap(PictureBox clickedPicture)
        {
            var distance = Math.Abs(clickedPicture.Location.X - emptyPictureBox.Location.X) / emptyPictureBox.Size.Width;
            if (distance > 2)
            {
                MessageBox.Show("“ак ходить нельз€!");
            }
            else
            {
                var location = clickedPicture.Location;
                clickedPicture.Location = emptyPictureBox.Location;
                emptyPictureBox.Location = location;
                moveCount++;
                moveCountLabel.Text = moveCount.ToString();

                if (GameIsEnded())
                {
                    EndGame();
                }
            }
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void ruleButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            "÷ель игры - переставить л€гушек так, чтобы все левые л€гушки (смотр€щие вправо) оказались справа,\n" +
            "а правые (смотр€щие влево) Ч слева.\n\n" +
            "’одить можно только на пустую кувшинку или через одну л€гушку.\n" +
            "ћинимальное число ходов Ч 24.",
            "ѕравила игры");
        }

        private bool GameIsEnded()
        {
            int emptyX = emptyPictureBox.Location.X;

            if (rightPictureBox1.Location.X >= emptyX)
            {
                return false;
            }
            if (rightPictureBox2.Location.X >= emptyX)
            {
                return false;
            }
            if (rightPictureBox3.Location.X >= emptyX)
            {
                return false;
            }
            if (rightPictureBox4.Location.X >= emptyX)
            {
                return false;
            }

            if (leftPictureBox1.Location.X <= emptyX)
            {
                return false;
            }

            if (leftPictureBox2.Location.X <= emptyX)
            {
                return false;
            }
            if (leftPictureBox3.Location.X <= emptyX)
            {
                return false;
            }
            if (leftPictureBox4.Location.X <= emptyX)
            {
                return false;
            }
            return true;
        }

        private void EndGame()
        {
            var winForm = new WinForm();
            winForm.SetMessage(moveCount, targetMoves);

            if (winForm.ShowDialog() == DialogResult.Yes)
            {
                Application.Restart();
            }
            Close();
            
        }

    }
}

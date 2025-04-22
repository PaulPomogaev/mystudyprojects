using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace SalutWinFormsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            GenerateBalls(e.X, e.Y);
        }

        private void generateSaluteButton_Click(object sender, EventArgs e)
        {
            var salut = new RocketBall(this, new SolidBrush(Color.Red));

            salut.Exploded += Rocket_Exploded;
            salut.Start();
        }

        private void Rocket_Exploded(object sender, ExplosionEventArgs e)
        {
            CreateSaluteBalls(e.X, e.Y);
        }

        private void CreateSaluteBalls(float x, float y)
        {
            GenerateBalls(x, y);
        }

        private void GenerateBalls(float x, float y)
        {
            var random = new Random();
            var count = random.Next(22, 35);

            int r = random.Next(256);
            int g = random.Next(256);
            int b = random.Next(256);

            Brush brush = new SolidBrush(Color.FromArgb(r, g, b));

            for (int i = 0; i < count; i++)
            {
                var salut = new SaluteBall(this, new SolidBrush(Color.FromArgb(random.Next(256), random.Next(256), random.Next(256))), (int)x, (int)y);
                salut.Start();
            }
        }
    }
}

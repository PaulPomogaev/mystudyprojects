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
            var random = new Random();
            var count = random.Next(8, 19);

            int r = random.Next(256);
            int g = random.Next(256);
            int b = random.Next(256);

            Brush brush = new SolidBrush(Color.FromArgb(r, g, b));

            for (int i = 0; i < count; i++)
            {
                var salut = new SaluteBall(this, new SolidBrush(Color.FromArgb(random.Next(256), random.Next(256), random.Next(256))), e.X, e.Y);
                salut.Start();
            }
        }


    }
}

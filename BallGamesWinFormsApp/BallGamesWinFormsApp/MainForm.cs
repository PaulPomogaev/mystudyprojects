namespace BallGamesWinFormsApp
{
    public partial class MainForm : Form
    {
        RandomSizeAndPointBall randomSizeAndPointBall;

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            randomSizeAndPointBall.Clear();
            randomSizeAndPointBall.Go();
            randomSizeAndPointBall.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            randomSizeAndPointBall = new RandomSizeAndPointBall(this);
            randomSizeAndPointBall.Show();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            var pointBall = new PointBall(this, e.X, e.Y);
            pointBall.Show();
        }
    }
}

namespace BallGamesWinFormsApp
{
    public partial class MainForm : Form
    {
        List <MoveBall> moveBalls = new List<MoveBall>();
        PointBall pointBall;

        public MainForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //timer.Enabled = !timer.Enabled;

        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            pointBall = new PointBall(this, e.X, e.Y);
            pointBall.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                moveBalls[i].Stop();
            }

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            
            for (int i = 0; i < 10; i++)
            {
                moveBalls[i].Move();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
               var moveBall = new MoveBall(this);
                moveBalls.Add(moveBall);
                moveBall.Start();
            }

            
        }
    }
}

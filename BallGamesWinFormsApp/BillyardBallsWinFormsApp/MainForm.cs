using BallGamesWinFormsLibrary;

namespace BillyardBallsWinFormsApp
{
    public partial class MainForm : Form
    {
        private List<BillyardBall> balls = new List<BillyardBall>();

        public MainForm()
        {
            InitializeComponent();
        }


        private void Ball_OnHited(object? sender, HitEventArgs e)
        {
            switch (e.Side)
            {
                case Side.Left:
                    leftLabel.Text = (Convert.ToInt32(leftLabel.Text) + 1).ToString();
                    break;
                case Side.Right:
                    rightLabel.Text = (Convert.ToInt32(rightLabel.Text) + 1).ToString();
                    break;
                case Side.Top:
                    topLabel.Text = (Convert.ToInt32(topLabel.Text) + 1).ToString();
                    break;
                case Side.Down:
                    downLabel.Text = (Convert.ToInt32(downLabel.Text) + 1).ToString();
                    break;
            }
        }

        private void createBallButton_Click(object sender, EventArgs e)
        {
            balls.Clear();

            for (int i = 0; i < 10; i++)
            {
                var ball = new BillyardBall(this);
                ball.OnHited += Ball_OnHited;
                ball.Start();
                balls.Add(ball);
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            foreach(var ball in balls)
            {
                ball.Stop();
            }
        }
    }
}

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

        private void Ball_OnHited2(object? sender, HitEventArgs e)
        {
            switch (e.Side)
            {
                case Side.Left:
                    leftLabel2.Text = (Convert.ToInt32(leftLabel2.Text) + 1).ToString();
                    break;
                case Side.Right:
                    rightLabel2.Text = (Convert.ToInt32(rightLabel2.Text) + 1).ToString();
                    break;
                case Side.Top:
                    topLabel2.Text = (Convert.ToInt32(topLabel2.Text) + 1).ToString();
                    break;
                case Side.Down:
                    downLabel2.Text = (Convert.ToInt32(downLabel2.Text) + 1).ToString();
                    break;
            }
        }

        private void createBallButton_Click(object sender, EventArgs e)
        {
            balls.Clear();

            for (int i = 0; i < 10; i++)
            {
                var ball = new BillyardBall(this, Brushes.Aqua);
                ball.OnHited += Ball_OnHited;
                ball.Start();
                balls.Add(ball);

                ball = new BillyardBall(this, Brushes.Red);
                ball.OnHited += Ball_OnHited2;
                ball.Start();
                balls.Add(ball);
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            foreach (var ball in balls)
            {
                ball.Stop();
            }
        }

    }
}

using BallGamesWinFormsLibrary;

namespace BallGamesWinFormsApp2
{
    public partial class ManForm : Form
    {
        List<MoveBall> moveBalls = new List<MoveBall>();
        private int caughtCount = 0;


        public ManForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            clearButton.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            clearButton.Enabled = true;
            moveBalls = new List<MoveBall>();
            for (int i = 0; i < 10; i++)
            {
                var moveBall = new MoveBall(this);
                moveBalls.Add(moveBall);
                moveBall.Start();
            }
        }

        private void ManForm_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (var ball in moveBalls)
            {
                if (!ball.IsStoped && ball.Contains(e.X, e.Y))
                {
                    ball.Stop();
                    caughtCount++;
                }
            }
            UpdateCaughtBallsInfo();
            
        }

        private void UpdateCaughtBallsInfo()
        {
            labelScore.Text = caughtCount.ToString();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            foreach (var ball in moveBalls)
            {
                ball.Clear(); 

            }

            caughtCount = 0;
            UpdateCaughtBallsInfo();
            clearButton.Enabled = false;
            startButton.Enabled = true;
        }
    }
}

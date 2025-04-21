using BallGamesWinFormsLibrary;

namespace BillyardBallsWinFormsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Ball ball = new BillyardBall(this);
            ball.Start();

            Ball ball2 = new MoveBall(this);
            ball2.Start();
        }
    }
}

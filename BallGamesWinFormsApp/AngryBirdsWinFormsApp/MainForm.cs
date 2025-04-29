using Timer = System.Windows.Forms.Timer;

namespace AngryBirdsWinFormsApp
{
    public partial class MainForm : Form
    {
        private BirdBall bird;
        private PigBall pig;
        private Timer timer = new Timer();
        private int score = 0;
        private bool isBirdActive = false;

        public MainForm()
        {
            InitializeComponent();
            InitializeGame();
        }

        public void InitializeGame()
        {
            bird = new BirdBall(this);
            pig = new PigBall(this);
            timer.Interval = 30;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (isBirdActive)
            {
                if (bird.Contains((int)pig.GetCenterX(), (int)pig.GetCenterY()))
                {
                    score++;
                    scoreLabel.Text = $"{score}";
                    pig.RandomPosition();
                    ResetBird();
                }
                if (Math.Abs(bird.GetVx()) < 0.1f && Math.Abs(bird.GetVy()) < 0.1f)
                {
                    ResetBird();
                }
            }
        }

        public void ResetBird()
        {
            bird.ResetPosition();
            isBirdActive = false;
            bird.Stop();
        }


    }
}

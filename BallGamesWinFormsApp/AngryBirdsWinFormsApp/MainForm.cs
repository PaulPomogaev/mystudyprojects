using BallGamesWinFormsLibrary;
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
        float maxSpeed = 27f;

        public MainForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.Paint += MainForm_Paint;
            this.MouseDown += MainForm_MouseDown;
            InitializeGame();
        }

        public void InitializeGame()
        {

            bird = new BirdBall(this);
            pig = new PigBall(this);
            timer.Interval = 30;
            timer.Tick += Timer_Tick;
            timer.Start();
            Invalidate();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            bird.Draw(e.Graphics);
            pig.Draw(e.Graphics);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (isBirdActive)
            {
                bird.Move();
                Invalidate();

                if (IsCollision(bird, pig))
                {
                    score++;
                    scoreLabel.Text = $"{score}";
                    scoreLabel.Refresh();

                    pig.RandomPosition();
                    ResetBird();
                    return;
                }
                if (Math.Abs(bird.GetVx) < 0.1f && Math.Abs(bird.GetVy) < 0.1f)
                {
                    ResetBird();
                }
            }
        }

        private bool IsCollision(BirdBall birdBall, PigBall pigBall)
        {
            float dx = birdBall.GetCenterX() - pigBall.GetCenterX();
            float dy = birdBall.GetCenterY() - pigBall.GetCenterY();
            float distance = (float)Math.Sqrt(dx * dx + dy * dy);
            return distance < (birdBall.GetRadius() + pigBall.GetRadius());
        }


        public void ResetBird()
        {
            bird.ResetPosition();
            isBirdActive = false;
            bird.Stop();
            Invalidate();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (!isBirdActive)
            {
                float dx = e.X - bird.GetCenterX();
                float dy = e.Y - bird.GetCenterY();
                float distance = (float)Math.Sqrt(dx * dx + dy * dy);
                float speed = distance * 0.05f;
                if (speed > maxSpeed)
                {
                    speed = maxSpeed;
                }

                if (distance > 0)
                {
                    bird.GetVx = (dx / distance) * speed;
                    bird.GetVy = (dy / distance) * speed;
                }

                isBirdActive = true;
                bird.Start();
            }
        }

        
    }
}

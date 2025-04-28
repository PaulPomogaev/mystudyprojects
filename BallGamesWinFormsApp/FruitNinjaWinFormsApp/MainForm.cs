using BallGamesWinFormsLibrary;
using Timer = System.Windows.Forms.Timer;

namespace FruitNinjaWinFormsApp
{
    public partial class Form1 : Form
    {
        private static Random random = new Random();
        private Timer timer = new Timer();
        private Timer slowdownTimer = new Timer();
        private List<FruitBall> fruits = new List<FruitBall>();

        public Form1()
        {
            InitializeComponent();
            slowdownTimer.Interval = 5000;
            slowdownTimer.Tick += SlowdownTimer_Tick;
        }

        private void SlowdownTimer_Tick(object? sender, EventArgs e)
        {
            foreach (var ball in fruits)
            {
                ball.ResetSpeed(); 
            }
            slowdownTimer.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            for (int i = 0; i < random.Next(4, 10); i++)
            {
                var bombNumber = random.Next(6);
                FruitBall ball;

                if (bombNumber == 4)
                {
                    ball = new BombBall(this);
                }
                else if (bombNumber == 5)
                {
                    ball = new BananaBall(this);
                }
                else
                {
                    ball = new FruitBall(this);
                }
                    

                fruits.Add(ball);
                ball.Start();
            }

            timer.Interval = random.Next(2000, 5000);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            List<FruitBall> fruitsToRemove = new List<FruitBall>();

            foreach (var fruit in fruits)
            {
                if (fruit.IsMovable() && fruit.Contains(e.X, e.Y))
                {
                    fruit.Stop();
                    if (fruit is BombBall)
                    {
                        EndGame();
                        return;
                    }
                    else if (fruit is BananaBall)
                    {
                        ApplySlowdownToAll(0.3f);
                    }

                    fruit.Clear();
                    fruitsToRemove.Add(fruit);
                    scoreLabel.Text = (Convert.ToInt32(scoreLabel.Text) + 1).ToString();
                }
            }
            foreach (var fruit in fruitsToRemove)
            {
                fruits.Remove(fruit);
            }
        }

        private void ApplySlowdownToAll(float multiplier)
        {
            
            foreach (var ball in fruits)
            {
                if (ball.IsMovable())
                {
                    ball.ApplySlowdown(multiplier);
                }
            }
                        
            slowdownTimer.Stop(); 
            slowdownTimer.Start(); 
        }

        private void EndGame()
        {
            timer.Stop();
            slowdownTimer.Stop();
            
            foreach (var fruit in fruits)
            {
                fruit.Stop();
            }
            MessageBox.Show("Игра окончена!");

            fruits.Clear();
        }
    }
}


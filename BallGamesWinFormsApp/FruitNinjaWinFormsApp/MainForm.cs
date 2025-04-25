using BallGamesWinFormsLibrary;
using Timer = System.Windows.Forms.Timer;

namespace FruitNinjaWinFormsApp
{
    public partial class Form1 : Form
    {
        private static Random random = new Random();
        private Timer timer = new Timer();
        private List<FruitBall> fruits = new List<FruitBall>();

        public Form1()
        {
            InitializeComponent();
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
                var ball = new FruitBall(this); // Только фрукты
                fruits.Add(ball);
                ball.Start();
            }

            timer.Interval = random.Next(2000, 5000);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (var fruit in fruits)
            {
                if (fruit.IsMovable() && fruit.Contains(e.X, e.Y))
                {
                    fruit.Stop();
                    fruit.Clear();
                    scoreLabel.Text = (Convert.ToInt32(scoreLabel.Text) + 1).ToString();
                }
            }
        }

        
    }
}


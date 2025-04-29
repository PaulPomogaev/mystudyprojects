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

        private void Timer_Tick(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

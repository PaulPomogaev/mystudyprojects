using Timer = System.Windows.Forms.Timer;

namespace BallGamesWinFormsLibrary
{
    public class Ball
    {
        protected Form form;
        private Timer timer;
        protected float centerX = 150;
        protected float centerY = 150;
        protected int Size { get; set; }= 10;
        protected int Radius => Size / 2;
        protected float vx = 1;
        protected float vy = 1;
        protected Brush brush = Brushes.Aqua;
        public bool IsStoped { get; set; }

        public Ball(Form form)
        {
            this.form = form;
            timer = new Timer();
            timer.Interval = 20;
            timer.Tick += Timer_Tick;
        }

        public Ball(Form form, Brush brush)
        {
            this.form = form;
            this.brush = brush;
        }

        public Brush GetBrush()
        {
            return brush;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            Move();
        }
        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop(); // если использовать его, то выходит только одно нажатие, больше запустить шары не получится
                          //timer.Enabled = !timer.Enabled; // при использовании этого инструмента можно несколько раз останавливать и запускать, что удобнее
            IsStoped = true;
        }

        public void Show()
        {
            //var brush = Brushes.Aqua;
            Draw(brush);
        }

        public void Move()
        {
            Clear();
            Go();
            Show();
        }

        public int LeftSide()
        {
            return Radius;
        }

        public int RightSide()
        {
            return form.ClientSize.Width - Radius;
        }

        public int TopSide()
        {
            return Radius;
        }

        public int DownSide()
        {
            return form.ClientSize.Height - Radius; ;
        }

        protected virtual void Go()
        {
            centerX += vx;
            centerY += vy;
                        
        }

        public void Clear()
        {
           var brush = new SolidBrush(form.BackColor);
           Draw(brush);
        }

        public bool IsOnForm()
        {
            return centerX >= LeftSide() && centerX <= RightSide() && centerY >= TopSide() && centerY <= DownSide();
        }

        public bool Exists(int pointX, int pointY)
        {
                return (centerX - pointX) * (centerX - pointX) + (centerY - pointY) * (centerY - pointY) <= Radius * Radius;
        }

        private void Draw(Brush brush)
        {
            var graphics = form.CreateGraphics();
            var rectangle = new RectangleF(centerX - Radius, centerY - Radius, 2 * Radius, 2 * Radius);
            graphics.FillEllipse(brush, rectangle);
        }
    }
}

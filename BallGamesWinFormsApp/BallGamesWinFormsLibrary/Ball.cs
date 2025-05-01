using Timer = System.Windows.Forms.Timer;

namespace BallGamesWinFormsLibrary
{
    public class Ball
    {
        protected Form form;
        private Timer timer;
        protected float centerX = 150;
        protected float centerY = 150;
        protected int Size { get; set; } = 10;
        protected int radius;
        protected float vx = 1;
        protected float vy = 1;
        protected Brush brush = Brushes.Aqua;
        public bool IsStoped { get; set; }
        protected float originalVx;
        protected float originalVy;
        protected bool isSlowed;

        public Ball(Form form)
        {
            this.form = form;
            timer = new Timer();
            timer.Interval = 20;
            timer.Tick += Timer_Tick;
            radius = Size / 2;
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
            if (form.IsDisposed)
            {
                return;
            }
            using (var g = form.CreateGraphics())
            {
                Draw(g);
            }
        }

        public void Move()
        {
            Clear();
            Go();
            Show();
        }

        public int LeftSide()
        {
            return radius;
        }

        public int RightSide()
        {
            return form.ClientSize.Width - radius;
        }

        public int TopSide()
        {
            return radius;
        }

        public int DownSide()
        {
            return form.ClientSize.Height - radius; ;
        }

        protected virtual void Go()
        {
            centerX += vx;
            centerY += vy;
                        
        }

        public void Clear()
        {
            if (form.IsDisposed)
            {
                return;
            }

            using (var g = form.CreateGraphics())
            {
                var oldBrush = this.brush;
                this.brush = new SolidBrush(form.BackColor);
                Draw(g);
                this.brush = oldBrush;
            }
        }

        public bool IsOnForm()
        {
            return centerX >= LeftSide() && centerX <= RightSide() && centerY >= TopSide() && centerY <= DownSide();
        }

        public bool Exists(int pointX, int pointY)
        {
                return (centerX - pointX) * (centerX - pointX) + (centerY - pointY) * (centerY - pointY) <= radius * radius;
        }

        public virtual void Draw(Graphics graphics)
        {
            var rectangle = new RectangleF(centerX - radius, centerY - radius, 2 * radius, 2 * radius);
            graphics.FillEllipse(brush, rectangle);
        }

        public bool LeftOfCenter()
        {
            return centerX + radius < form.ClientSize.Width / 2;
        }

        public bool RightOfCenter()
        {
            return centerX - radius > form.ClientSize.Width / 2;
        }

        public bool Contains(int x, int y)
        {
            float dx = centerX - x;
            float dy = centerY - y;
            return dx * dx + dy * dy <= radius * radius;
        }

        public bool IsMovable()
        {
            return !IsStoped;
        }

        public virtual void ApplySlowdown(float multiplier)
        {
            if (isSlowed) return;

            originalVx = vx;
            originalVy = vy;
            vx *= multiplier;
            vy *= multiplier;
            isSlowed = true;
        }

        public virtual void ResetSpeed()
        {
            if (!isSlowed) return;

            vx = originalVx;
            vy = originalVy;
            isSlowed = false;
        }

        public int GetRadius()
        {
            return radius;
        }
    }
}

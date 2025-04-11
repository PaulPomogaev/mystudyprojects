namespace BallGamesWinFormsLibrary
{
    public class Ball
    {
        protected Form form;
        protected int x = 150;
        protected int y = 150;
        protected int size = 70;
        protected int vx = 1;
        protected int vy = 1;

        public Ball(Form form)
        {
            this.form = form;
        }

        public void Show()
        {
            var graphics = form.CreateGraphics();
            var brush = Brushes.Aqua;
            var rectangle = new Rectangle(x, y, size, size);
            graphics.FillEllipse(brush, rectangle);
        }

        public void Move()
        {
            Clear();
            Go();
            Show();
        }

        private void Go()
        {
            x += vx;
            y += vy;
        }

        public void Clear()
        {
            var graphics = form.CreateGraphics();
            var brush = new SolidBrush(form.BackColor);
            var rectangle = new Rectangle(x, y, size, size);
            graphics.FillEllipse(brush, rectangle);
        }

        public bool IsOnForm()
        {
            return x >= 0 && y >= 0 && x + size <= form.ClientSize.Width && y + size <= form.ClientSize.Height;
        }

        public bool Contains(int pointX, int pointY)
        {
            var radius = size / 2;
            var centerX = x + radius;
            var centerY = y + radius;

            return (centerX - pointX) * (centerX - pointX) + (centerY - pointY) * (centerY - pointY) <= radius * radius;
        }
    }
}

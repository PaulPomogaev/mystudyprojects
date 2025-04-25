using BallGamesWinFormsLibrary;

namespace FruitNinjaWinFormsApp
{
    public class FruitBall : MoveBall
    {
        private float g = 0.2f;

        public FruitBall(Form form, Brush brush) : base(form, brush)
        {
            InitializeBall(form);
        }

        public FruitBall(Form form) : base(form, CreateRandomBrush())
        {
            InitializeBall(form);
        }

        private void InitializeBall(Form form)
        {
            radius = 15;
            centerX = random.Next(form.ClientSize.Width);
            centerY = form.ClientSize.Height - radius;
            vy = (float)random.NextDouble() * -5 - 7;
        }

        private static Brush CreateRandomBrush()
        {
            return new SolidBrush(Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)));
        }

        protected override void Go()
        {
            base.Go();
            vx *= 0.98f;
            vy += g;

            if(centerY > DownSide() + 2*radius)
            {
                Stop();
            }
        }
    }
}

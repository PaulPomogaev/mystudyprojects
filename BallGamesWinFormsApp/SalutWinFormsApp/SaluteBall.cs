using BallGamesWinFormsLibrary;
using System.Runtime.CompilerServices;

namespace SalutWinFormsApp
{
    public class SaluteBall : MoveBall
    {
        private float g = 0.2f;

        public SaluteBall(Form form, Brush brush, int centerX, int centerY) : base(form, brush)
        {
            this.centerX = centerX;
            this.centerY = centerY;
            vy = -Math.Abs(vy);
        }
        
        protected override void Go()
        {
            base.Go();
            vy += g;
        }

    }
}

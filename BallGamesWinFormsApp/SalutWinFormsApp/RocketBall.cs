using BallGamesWinFormsLibrary;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalutWinFormsApp
{
    public class RocketBall : MoveBall
    {
        public event EventHandler<ExplosionEventArgs> Exploded;
        private float gravity = 0.2f;
        private bool hasExploded = false;

        public RocketBall(Form form, Brush brush) : base(form, brush)
        {
            radius = 12;
            centerX = form.ClientSize.Width / 2;
            centerY = form.ClientSize.Height - radius;
            vy = -11;
        }

        protected override void Go()
        {
            base.Go();

            vy += gravity;

            if(!hasExploded && vy >= -1f)
            {
                hasExploded = true;
                Stop();
                Clear();
                form.Invalidate();
                Exploded.Invoke(this, new ExplosionEventArgs(centerX, centerY));
            }

        }
    }
}

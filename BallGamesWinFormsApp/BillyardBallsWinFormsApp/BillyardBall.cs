using BallGamesWinFormsLibrary;

namespace BillyardBallsWinFormsApp
{
    public class BillyardBall : MoveBall
    {
        public BillyardBall(Form form) : base(form)
        {
        }

        protected override void Go()
        {
            base.Go();

            if (centerX <= LeftSide() || centerX >= RightSide())
            {
                vx = -vx;
            }

            if (centerY <= TopSide() || centerY >= DownSide())
            {
                vy = -vy;
            }
        }
    }
}

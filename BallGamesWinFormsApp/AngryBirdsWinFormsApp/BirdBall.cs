using BallGamesWinFormsLibrary;

namespace AngryBirdsWinFormsApp
{
    public class BirdBall : Ball
    {
        private float gravity = 0.3f;
        private float groundStrikeEnergyLoss = 0.88f;
        private float airResistance = 0.988f;
        private float groundFriction = 0.4f;
        public float GetVx
        {
            get { return vx; }
            set { vx = value; }
        }
        public float GetVy
        {
            get { return vy; }
            set { vy = value; }
        }
        public BirdBall(Form form) : base(form)
        {

            brush = Brushes.Red;
            Size = 30;
            radius = Size / 2;
            ResetPosition();
        }

        protected override void Go()
        {
            base.Go();

            vy += gravity;

            if (centerY >= DownSide())
            {
                centerY = DownSide();
                vy = -Math.Abs(vy * groundStrikeEnergyLoss);
                vx *= groundFriction;

                if (Math.Abs(vy) < 0.1f && Math.Abs(vx) < 0.1f)
                {
                    vy = 0;
                    vx = 0;
                }
            }
                        
            vy *= airResistance;
            vx *= airResistance;
        }

        public void ResetPosition()
        {
            centerX = LeftSide();
            centerY = DownSide();
            vx = 0;
            vy = 0;
            Show();
        }

        
        public float GetCenterX()
        {
            return centerX;
        }

        public float GetCenterY()
        {
            return centerY;
        }
    }
}

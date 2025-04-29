using BallGamesWinFormsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngryBirdsWinFormsApp
{
    public class BirdBall : Ball
    {
        private float Gravity = 0.5f;
        private float GroundStrikeEnergyLoss = 0.7f;
        private float AirResistance = 0.99f;
        private float GroundFriction = 0.8f;

        public BirdBall(Form form) : base(form)
        {

            centerX = LeftSide() + 20;
            centerY = DownSide() - 20;
            brush = Brushes.Red;
            Size = 20;
            radius = Size / 2;
        }

        protected override void Go()
        {
            base.Go();

            vy += Gravity;

            if (centerY >= DownSide())
            {
                centerY = DownSide();
                vy = -Math.Abs(vy * GroundStrikeEnergyLoss);
                vx *= GroundFriction;

                if(Math.Abs(vy) < 0.5f)
                {
                    vx = 0;
                    vy = 0;
                }
            }

            vx *= AirResistance;
            vy *= AirResistance;
        }

        public void ResetPosition()
        {
            centerX = LeftSide() + 20;
            centerY = DownSide() - 20;
            vx = 0;
            vy = 0;
        }

        public float GetVx()
        {
            return vx;
        }
        public float GetVy()
        {
            return vy;
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

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
        }
    }
}

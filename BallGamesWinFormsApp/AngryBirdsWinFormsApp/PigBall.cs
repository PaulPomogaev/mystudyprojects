using BallGamesWinFormsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngryBirdsWinFormsApp
{
    public class PigBall : Ball
    {
        protected static Random random = new Random();

        public PigBall(Form form) : base(form)
        {
            brush = Brushes.Red;
            Size = 30;
            radius = Size / 2;
            RandomPosition();
        }

        public void RandomPosition()
        {
            centerX = random.Next(LeftSide()+50, RightSide()-50);
            centerY = random.Next(TopSide()+50, DownSide()-100);
        }
    }
}

using BallGamesWinFormsLibrary;

namespace AngryBirdsWinFormsApp
{
    public class PigBall : Ball
    {
       protected static Random random = new Random();

        public PigBall(Form form) : base(form)
        {
            brush = Brushes.Green;
            Size = 40;
            radius = Size / 2;
            RandomPosition();
        }

        public void RandomPosition()
        {
            centerX = random.Next(LeftSide()+50, RightSide()-50);
            centerY = random.Next(TopSide()+50, DownSide()-100);
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

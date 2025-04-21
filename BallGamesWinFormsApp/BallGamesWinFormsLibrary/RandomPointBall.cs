namespace BallGamesWinFormsLibrary
{
    public class RandomPointBall : Ball
    {
        protected static Random random = new Random();
        public RandomPointBall(Form form) : base(form)
        {
            centerX = random.Next(LeftSide(), RightSide());
            centerY = random.Next(TopSide(), DownSide());
            
        }

        public RandomPointBall(Form form, Brush brush) : base(form, brush)
        {
            centerX = random.Next(LeftSide(), RightSide());
            centerY = random.Next(TopSide(), DownSide());

        }
    }
}

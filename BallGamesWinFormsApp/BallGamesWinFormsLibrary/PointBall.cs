namespace BallGamesWinFormsLibrary
{
    public class PointBall : Ball
    {
        public PointBall(Form form, int x, int y) : base(form)
        {
            this.centerX = x - Radius;
            this.centerY = y - Radius;
        }
    }
}

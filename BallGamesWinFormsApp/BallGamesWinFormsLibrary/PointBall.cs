namespace BallGamesWinFormsLibrary
{
    public class PointBall : Ball
    {
        public PointBall(Form form, int x, int y) : base(form)
        {
            this.centerX = x - size / 2;
            this.centerY = y - size / 2;
        }
    }
}

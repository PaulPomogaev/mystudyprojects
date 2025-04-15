namespace BallGamesWinFormsLibrary
{
    public class PointBall : Ball
    {
        public PointBall(Form form, int x, int y) : base(form)
        {
            this.centerX = x - 70 / 2;
            this.centerY = y - 70 / 2;
        }
    }
}

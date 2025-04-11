namespace BallGamesWinFormsLibrary
{
    public class PointBall : Ball
    {
        public PointBall(Form form, int x, int y) : base(form)
        {
            this.x = x - 70 / 2;
            this.y = y - 70 / 2;
        }
    }
}

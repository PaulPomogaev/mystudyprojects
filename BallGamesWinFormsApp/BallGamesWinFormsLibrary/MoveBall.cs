namespace BallGamesWinFormsLibrary
{
    public class MoveBall : RandomPointBall
    {
        
        public MoveBall(Form form, Brush brush) : base(form)
        {
            vx = random.Next(-5, 6);
            if (vx == 0)
            {
                vx = 1;
            }

            vy = random.Next(-5, 6);
            if (vy == 0)
            {
                vy = 1;
            }

            this.brush = brush;
        }
                      
    }
}

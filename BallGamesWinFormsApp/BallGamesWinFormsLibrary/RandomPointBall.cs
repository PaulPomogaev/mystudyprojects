namespace BallGamesWinFormsLibrary
{
    public class RandomPointBall : Ball
    {
        protected static Random random = new Random();
        public RandomPointBall(Form form) : base(form)
        {
            x = random.Next(0, form.ClientSize.Width);
            y = random.Next(0, form.ClientSize.Height);
            
        }
    }
}

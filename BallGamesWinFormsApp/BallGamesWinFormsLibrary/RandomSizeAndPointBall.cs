namespace BallGamesWinFormsLibrary
{
    public class RandomSizeAndPointBall : RandomPointBall
    {
        public RandomSizeAndPointBall(Form form) : base(form)
        {
            Radius = random.Next(10, 40);
        }
    }
}

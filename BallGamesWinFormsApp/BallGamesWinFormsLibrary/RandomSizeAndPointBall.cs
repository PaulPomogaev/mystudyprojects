namespace BallGamesWinFormsLibrary
{
    public class RandomSizeAndPointBall : RandomPointBall
    {
        public RandomSizeAndPointBall(Form form) : base(form)
        {
            radius = random.Next(10, 40);
        }
    }
}

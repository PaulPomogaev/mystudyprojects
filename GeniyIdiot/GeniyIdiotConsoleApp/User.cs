namespace GeniyIdiotConsoleApp
{
    public class User
    {
        public string Name { get; set; }
        public int rightAnswersCount { get; set; }

        public User(string name)
        {
            Name = name;
        }

        public void AcceptRightAnswer()
        {
            rightAnswersCount++;
        }
    }
}

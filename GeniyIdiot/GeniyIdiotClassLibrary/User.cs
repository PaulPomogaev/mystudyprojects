namespace GeniyIdiotClassLibrary
{
    public class User
    {
        public string Name { get; set; }
        public int RightAnswersCount { get; set; }

        public User(string name)
        {
            this.Name = name;
        }

        public User()
        {
            Name = "Гость";
            RightAnswersCount = 0;
        }

        public void AcceptRightAnswer()
        {
            RightAnswersCount++;
        }
    }
}

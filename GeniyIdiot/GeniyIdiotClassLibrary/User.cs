namespace GeniyIdiot.Common
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
            
        }

        public void AcceptRightAnswer()
        {
            RightAnswersCount++;
        }
    }
}

namespace GeniyIdiotConsoleApp
{
    public class TestResult
    {
        public User User { get; set; }
        public int CorrectAnswers { get; set; }
        public string Diagnosis { get; set; }

        public TestResult(User name, int correctAnswers, string diagnosis)
        {
            User = name;
            CorrectAnswers = correctAnswers;
            Diagnosis = diagnosis;
        }
    }
}

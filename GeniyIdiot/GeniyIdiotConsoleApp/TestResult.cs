namespace GeniyIdiotConsoleApp
{
    public class TestResult
    {
        public User User { get; set; }
        public string Diagnosis { get; set; }

        public TestResult(User name, string diagnosis)
        {
            User = name;
            Diagnosis = diagnosis;
        }
    }
}

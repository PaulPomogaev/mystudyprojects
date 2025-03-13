using System.IO;


namespace GeniyIdiotConsoleApp
{
    public class UsersResultStorage
    {
        string resultsPath = "results.csv";
        public void SaveTestResult(TestResult result)
        {
            bool needHeader = !File.Exists(resultsPath);


            using (StreamWriter writer = new StreamWriter(resultsPath, true))
            {
                if (needHeader)
                {
                    writer.WriteLine("Name,CorrectAnswers,Diagnosis");
                }

                writer.WriteLine($"{result.User.Name},{result.CorrectAnswers},{result.Diagnosis}");

            }
        }
    }
}

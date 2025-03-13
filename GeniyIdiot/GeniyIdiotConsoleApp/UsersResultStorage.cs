using System.Collections.Generic;
using System;
using System.IO;


namespace GeniyIdiotConsoleApp
{
    public class UsersResultStorage
    {
        private string resultsPath = "results.csv";
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

        public List<TestResult> ReadTestResults()
        {
           List<TestResult> results = new List<TestResult>();

            using (StreamReader reader = new StreamReader(resultsPath))
            {
                reader.ReadLine();

                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] columns = line.Split(',');

                    if (columns.Length != 3)
                    {
                        Console.WriteLine($"Ошибка в строке {line} недостаточное количество колонок");
                        continue;
                    }

                    if (!int.TryParse(columns[1], out int correctAnswers))
                    {
                        Console.WriteLine($"Некорректное число в строке {line}");
                        continue;
                    }
                    results.Add(new TestResult
                    (
                        new User(columns[0].Trim()),
                        correctAnswers,
                        columns[2].Trim()
                    ));
                }
            }
            return results;
        }
    }
}

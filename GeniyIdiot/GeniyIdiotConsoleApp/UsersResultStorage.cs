using System.Collections.Generic;
using System;
using System.IO;


namespace GeniyIdiotConsoleApp
{
    public class UsersResultStorage
    {
        private static string resultsPath = "results.csv";
        public static void SaveTestResult(TestResult result)
        {
            bool needHeader = !File.Exists(resultsPath);

            using (StreamWriter writer = new StreamWriter(resultsPath, true))
            {
                if (needHeader)
                {
                    writer.WriteLine("Name,RightAnswersCount,Diagnosis");
                }

                writer.WriteLine($"{result.User.Name},{result.User.RightAnswersCount},{result.Diagnosis}");

            }
        }

        public static List<TestResult> ReadTestResults()
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

                    if (!int.TryParse(columns[1].Trim(), out int correctAnswers))
                    {
                        Console.WriteLine($"Некорректное число в строке {line}");
                        continue;
                    }

                    var user = new User(columns[0].Trim());
                    user.RightAnswersCount = int.Parse(columns[1].Trim());

                    results.Add(new TestResult
                    (
                        user,
                        columns[2].Trim()
                    ));
                }
            }
            return results;
        }
    }
}

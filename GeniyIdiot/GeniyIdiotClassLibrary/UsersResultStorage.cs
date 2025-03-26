using System.Collections.Generic;
using System;
using System.IO;
using System.Text.Json;

namespace GeniyIdiot.Common
{
    public class UsersResultStorage
    {
        private static string resultsPath = "results.json";
        public static void SaveTestResult(TestResult result)
        {
            var results = ReadTestResults();
            results.Add(result);
            var json = JsonSerializer.Serialize(results);
            FileManager.WriteAllText(resultsPath, json);
        }

        public static List<TestResult> ReadTestResults()
        {
            var json = FileManager.ReadAllText(resultsPath);

            if (!FileManager.Exists(resultsPath) || string.IsNullOrWhiteSpace(json))
            {
                return new List<TestResult>();
            }

           var results = JsonSerializer.Deserialize<List<TestResult>>(json);
            return results;
        }
    }
}

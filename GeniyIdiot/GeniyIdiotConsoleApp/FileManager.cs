using System.Collections.Generic;
using System.IO;


namespace GeniyIdiotConsoleApp
{
    public class FileManager
    {
        public static void Append(string fileName, string value)
        {
            using (var writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(value);
            }
        }

        public static List<string> GetValue(string fileName)
        {
            var lines = new List<string>();

            using (var reader = new StreamReader(fileName))
            {
                string value;
                while ((value = reader.ReadLine()) != null)
                {
                    lines.Add(value);
                }
            }
            return lines;
        }
    }
}

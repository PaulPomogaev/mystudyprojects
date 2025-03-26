using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


namespace GeniyIdiot.Common
{
    public class FileManager
    {
        public static void Append(string fileName, string value)
        {
            File.AppendAllText(fileName, value + Environment.NewLine);
        }

        public static List<string> GetValue(string fileName)
        {
          if(File.Exists(fileName))
          {
            return File.ReadAllLines(fileName).ToList();
          }
            return new List<string>();
        }

       public static bool Exists(string fileName)
        {
            return File.Exists(fileName);
        }

        internal static void Clear(string fileName)
        {
            File.WriteAllText(fileName, string.Empty);
        }

        public static string ReadAllText(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return string.Empty;
            }
            return File.ReadAllText(fileName);
        }

        public static void WriteAllText(string fileName, string value)
        {
            File.WriteAllText(fileName, value);
        }
    }
}

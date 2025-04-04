using System.Text;

namespace _2048WinFormsApp
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

        public static void Replace(string fileName, string value)
        {
            using (var writer = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                writer.WriteLine(value);
            }

        }
    }
}

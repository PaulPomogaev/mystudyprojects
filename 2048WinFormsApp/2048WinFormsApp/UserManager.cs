using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace _2048WinFormsApp
{
    public class UserManager
    {
        public static string path = Path.Combine(Application.StartupPath, "results.json");

        public static List<User> GetAll()
        {
            try
            {
                if (!File.Exists(path)) return new List<User>();
                var jsonData = File.ReadAllText(path);
                return JsonSerializer.Deserialize<List<User>>(jsonData);
            }
            catch
            { 
                return new List<User>(); 
            }

        }

        public static void Add (User newUser)
        {
            var users = GetAll();

            users.Add(newUser);

            var options = new JsonSerializerOptions { WriteIndented = true };

            File.WriteAllText(path, JsonSerializer.Serialize(users, options));
        }
    }
}

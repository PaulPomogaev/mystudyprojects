using System;
using System.Collections.Generic;


namespace GeniyIdiotConsoleApp
{
    public class QuestionsStorage
    {
        
        public List<Question> GetAllQuestions()
        {
            var questions = new List<Question>();
            if (FileManager.Exists("questions.txt"))
            {
                var value = FileManager.GetValue("questions.txt");
                
                foreach (var line in value)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    int lastCommaIndex = line.LastIndexOf(',');
                    if (lastCommaIndex == -1)
                    {
                        Console.WriteLine($"Ошибка: нет разделителя в строке '{line}'");
                        continue;
                    }
                    var text = line.Substring(0, lastCommaIndex).Trim();
                    var answerStr = line.Substring(lastCommaIndex + 1).Trim();

                    string[] columns = line.Split(',');
                    if (columns.Length < 2)
                    {
                        Console.WriteLine($"Ошибка: некорректный формат строки '{line}'");
                        continue;
                    }

                    if (!int.TryParse(answerStr, out int answer))
                    {
                        Console.WriteLine($"Некорректное число в строке {line}");
                        continue;
                    }

                    questions.Add(new Question(text, answer));
                }

                if (questions.Count > 0) return questions;

            }
            else
            {
                questions.Add(new Question("Сколько будет два плюс два умноженное на два?",6));
                questions.Add(new Question("Бревно нужно распилить на 10 частей, сколько нужно сделать распилов?",9));
                questions.Add(new Question("На двух руках 10 пальцев, сколько пальцев на 5 руках?",25));
                questions.Add(new Question("Укол делают каждые пол часа, сколько нужно минут для трёх уколов?",60));
                questions.Add(new Question("Пять свечей горело, две потухли, сколько свечей осталось?",2));

                foreach (var question in questions)
                {
                    Add(question);
                }
            }
            return questions;
        }

        public static void Add(Question newQuestion)
        {
            var value = $"{newQuestion.Text}, {newQuestion.Answer}";
            FileManager.Append("questions.txt", value);
        }
    }
}

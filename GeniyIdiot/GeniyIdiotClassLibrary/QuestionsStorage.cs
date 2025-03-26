using GeniyIdiot.Common;
using System;
using System.Collections.Generic;
using System.Text.Json;


namespace GeniyIdiot.Common
{
    public class QuestionsStorage
    {
        private static readonly string filePath = "questions.json";

        public static List<Question> GetAllQuestions()
        {
            if (FileManager.Exists(filePath))
            {
                var json = FileManager.ReadAllText(filePath);
                var questions = JsonSerializer.Deserialize<List<Question>>(json);
                if (questions != null) return questions;
            }

            var defaultQuestions = CreateDefaultQuestions();
            SaveQuestions(defaultQuestions);
            return defaultQuestions;
        }

        private static List<Question> CreateDefaultQuestions()
        {
           
            var questions = new List<Question>();
            questions.Add(new Question("Сколько будет два плюс два умноженное на два?", 6));
            questions.Add(new Question("Бревно нужно распилить на 10 частей, сколько нужно сделать распилов?", 9));
            questions.Add(new Question("На двух руках 10 пальцев, сколько пальцев на 5 руках?", 25));
            questions.Add(new Question("Укол делают каждые пол часа, сколько нужно минут для трёх уколов?", 60));
            questions.Add(new Question("Пять свечей горело, две потухли, сколько свечей осталось?", 2));
            return questions;
        }

        private static void SaveQuestions(List<Question> questions)
        {
            var json = JsonSerializer.Serialize(questions);
            FileManager.WriteAllText(filePath, json);
        }

        public static void Add(Question newQuestion)
        {
            var questions = GetAllQuestions();
            questions.Add(newQuestion);
            SaveQuestions(questions);
        }

        public static void Remove(Question removeQuestion)
        {
            var questions = GetAllQuestions();
           
            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].Text == removeQuestion.Text)
                {
                    questions.RemoveAt(i);
                    break;
                }
            }
            SaveQuestions(questions);
        }
    }
}

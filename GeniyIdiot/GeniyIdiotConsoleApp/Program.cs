using System;
using System.Collections.Generic;
using System.Xml.Linq;
using GeniyIdiot.Common;


namespace GeniyIdiotConsoleApp
{
    public static class Program
    {
        private const string TableRowFormat = "| {0, -30} | {1, 25} | {2, -10} |";

        private const string TableSeparator = "---------------------------------------------------------------------------";

        static void Main(string[] args)
        { 
            bool repeat;
                       
            do
            {
                Console.WriteLine($"Здравствуйте, введите своё имя");
                string name = Console.ReadLine()?.Trim();
                var user = new User(name);

                List<Question> questions = QuestionsStorage.GetAllQuestions();
                List<Question> currentTestQuestions = new List<Question>(questions);

                var random = new Random();

                for (int i = 0; i < questions.Count; i++)
                {
                    Console.WriteLine($"Вопрос номер {i + 1}");
                    var randomQuestionIndex = random.Next(currentTestQuestions.Count);
                    Question currentQuestion = currentTestQuestions[randomQuestionIndex];
                    Console.WriteLine(currentQuestion.Text);

                    int userAnswer = GetNumber();
                    int rightAnswer = currentQuestion.Answer;

                    if (userAnswer == rightAnswer)
                    {
                        user.AcceptRightAnswer();
                    }
                    currentTestQuestions.RemoveAt(randomQuestionIndex);
                }

                Console.WriteLine($"{name}, количество правильных ответов: {user.RightAnswersCount}");

                var diagosisCalculator = new DiagnosesCalculation();
                string diagnosis = diagosisCalculator.GetResult(user.RightAnswersCount, questions.Count);


                Console.WriteLine($"{name}, ваш диагноз: {diagnosis}");

                var testResult = new TestResult
                (
                    user,
                    diagnosis
                );

                UsersResultStorage.SaveTestResult(testResult);

                repeat = GetUserConfirmation("Хотите пройти тест ещё раз?");
            } while (repeat);

            if (GetUserConfirmation("Хотите посмотреть на предыдущие результаты тестирования?"))
            {
                ShowTestResults();
            }

            var userChoice = GetUserConfirmation("Хотите добавить новый вопрос?");
            if(userChoice)
            {
                AddNewQuestion();
            }

            userChoice = GetUserConfirmation("Хотите удалить существующий вопрос?");
            if (userChoice)
            {
                RemoveQuestion();
            }

            Console.WriteLine("Спасибо за участие! До свидания!");
            Console.ReadKey();
        }

        static void RemoveQuestion()
        {
            Console.WriteLine("Введите номер удаляемого вопроса");
            var questions = QuestionsStorage.GetAllQuestions();
            for (var i = 0; i < questions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {questions[i].Text}");
            }
            var removeQuestionNumber = GetNumber();
            while(removeQuestionNumber < 1 || removeQuestionNumber > questions.Count)
            {
                Console.WriteLine($"Введите число от 1 до {questions.Count}");
                removeQuestionNumber = GetNumber();
            }

            var removeQuestion = questions[removeQuestionNumber - 1];
            QuestionsStorage.Remove(removeQuestion);
        }
        

        static void AddNewQuestion()
        {
            Console.WriteLine("Введите текст вопроса");
            var newQuestionText = Console.ReadLine()?.Trim();
            Console.WriteLine("Введите ответ на вопрос");
            var newQuestionAnswer = GetNumber();

            var newQuestion = new Question(newQuestionText, newQuestionAnswer);

            QuestionsStorage.Add(newQuestion);
        }

        static bool GetUserConfirmation(string question)
        {
            while (true)
            {
                Console.WriteLine($"{question} (да/нет)");
                var userRespond = Console.ReadLine()?.Trim().ToLower();
                if (userRespond == "да")
                {
                    return true;
                }
                if (userRespond == "нет")
                {
                    return false;
                }
                Console.WriteLine("Введите либо 'да' либо 'нет'!");
            }
        }
        private static int GetNumber()
        {
            while (true)
            {
                Console.WriteLine("Введите ответ в виде целого числа");
                string userAnswer = Console.ReadLine()?.Trim();

                if (int.TryParse(userAnswer, out int parsedNumber))
                {
                    return parsedNumber;
                }

                Console.WriteLine($"Ответ не соответствует заданному диапазону от -2*10^9 до 2*10^9. Пожалуйста, повторите ввод.");
            }
        }

        public class DiagnosesCalculation
        {
            private List<string> diagnosis;

            public DiagnosesCalculation()
            {
                diagnosis = new List<string>()
                {
                    "Идиот",
                    "Кретин",
                    "Дурак",
                    "Нормальный",
                    "Талант",
                    "Гений"
                };

            }

            public string GetResult(int rightAnswersCount, int totalQuestions)
            {
                double persentage = (double)rightAnswersCount / totalQuestions * 100;

                // переменная persantage показывает процентное соотношение правильных ответов к количеству заданных вопросов, что определяет диагноз
                // каждая цифра 16.66-33.33 и т.д., равномерно делит диапазон от 0% до 100% на 6 частей, каждая из которых соответствует диагнозу
                if (persentage <= 16.66)
                    return diagnosis[0];
                if (persentage <= 33.33)
                    return diagnosis[1];
                if (persentage <= 50)
                    return diagnosis[2];
                if (persentage <= 66.66)
                    return diagnosis[3];
                if (persentage <= 83.33)
                    return diagnosis[4];
                return diagnosis[5];
            }
        }

        static void ShowTestResults()
        {
            List<TestResult> results = UsersResultStorage.ReadTestResults();

            Console.WriteLine("\nПредыдущие результаты пользователей:");
            Console.WriteLine(TableSeparator);
            Console.WriteLine(TableRowFormat, "ФИО", "Кол-во правильных ответов", "Диагноз");
            Console.WriteLine(TableSeparator);
            foreach (var result in results)
            {
                Console.WriteLine(TableRowFormat,
                    result.User.Name,
                    result.User.RightAnswersCount,
                    result.Diagnosis);
            }
            Console.WriteLine(TableSeparator);
        }

     }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;


namespace GeniyIdiotConsoleApp
{

    internal class Program
    {
        private const string TableRowFormat = "| {0, -30} | {1, 25} | {2, -10} |";

        private const string TableSeparator = "---------------------------------------------------------------------------";

        static void Main(string[] args)
        {
            bool repeat;
            var questionsStorage = new QuestionsStorage();
            var resultsStorage = new UsersResultStorage();
            do
            {
                Console.WriteLine($"Здравствуйте, введите своё имя");
                string name = Console.ReadLine();


                List<Question> questions = questionsStorage.GetAllQuestions();
                List<Question> currentTestQuestions = new List<Question>(questions);

                int rightAnswersCount = 0;

                var random = new Random();

                for (int i = 0; i < questions.Count; i++)
                {
                    Console.WriteLine($"Вопрос номер {i + 1}");
                    var randomQuestionIndex = random.Next(currentTestQuestions.Count);
                    Question currentQuestion = currentTestQuestions[randomQuestionIndex];
                    Console.WriteLine(currentQuestion.Text);

                    int userAnswer = GetUserAnswer();
                    int rightAnswer = currentQuestion.Answer;

                    if (userAnswer == rightAnswer)
                    {
                        rightAnswersCount++;
                    }
                    currentTestQuestions.RemoveAt(randomQuestionIndex);
                }

                Console.WriteLine($"{name}, количество правильных ответов: {rightAnswersCount}");

                var diagosisCalculator = new DiagnosesCalculation();
                string diagnosis = diagosisCalculator.GetResult(rightAnswersCount, questions.Count);


                Console.WriteLine($"{name}, ваш диагноз: {diagnosis}");

                var testResult = new TestResult
                (
                    new User(name),
                    rightAnswersCount,
                    diagnosis
                );

                resultsStorage.SaveTestResult(testResult);

                repeat = TestRepeat();
            } while (repeat);

            if (AskToShowResults())
            {
                ShowTestResults();
            }

            Console.WriteLine("Спасибо за участие! До свидания!");
            Console.ReadKey();
        }
        static bool TestRepeat()
        {
            while (true)
            {
                Console.WriteLine("Хотите пройти тест ещё раз? (да/нет)");
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
        private static int GetUserAnswer()
        {
            while (true)
            {
                Console.WriteLine("Введите ответ в виде целого числа");
                string userAnswer = Console.ReadLine();

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

            public string GetResult(int correctAnswers, int totalQuestions)
            {
                double persentage = (double)correctAnswers / totalQuestions * 100;

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

        static List<TestResult> ReadTestResults()
        {
            string resultsPath = "results.csv";

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

        static void ShowTestResults()
        {
            List<TestResult> results = ReadTestResults();

            Console.WriteLine("\nПредыдущие результаты пользователей:");
            Console.WriteLine(TableSeparator);
            Console.WriteLine(TableRowFormat, "ФИО", "Кол-во правильных ответов", "Диагноз");
            Console.WriteLine(TableSeparator);
            foreach (var result in results)
            {
                Console.WriteLine(TableRowFormat,
                    result.User.Name,
                    result.CorrectAnswers,
                    result.Diagnosis);
            }
            Console.WriteLine(TableSeparator);
        }

        static bool AskToShowResults()
        {
            while (true)
            {
                Console.WriteLine("Показать историю результатов? (да/нет)");

                var userRespond = Console.ReadLine().Trim().ToLower();

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
    }
}

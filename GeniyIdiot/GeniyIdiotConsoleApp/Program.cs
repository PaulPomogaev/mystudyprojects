using System;
using System.Collections.Generic;



namespace GeniyIdiotConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userResponse;
            do
            {
                Console.WriteLine($"Здравствуйте, введите своё имя");
                string name = Console.ReadLine();

                int questionsCount = 5;
                string[] questions = QuestionsGet(questionsCount);


                int[] answers = AnswersGet(questionsCount);

                int countRightAnswers = 0;

                Random random = new Random();
                List<int> askedQuestions = new List<int>();

                for (int i = 0; i < questionsCount; i++)
                {
                    int randomIndex;
                    do
                    {
                        randomIndex = random.Next(questionsCount);
                    } while (askedQuestions.Contains(randomIndex));

                    askedQuestions.Add(randomIndex);
                    Console.WriteLine($"Вопрос номер {i + 1}");

                    Console.WriteLine(questions[randomIndex]);

                    int userAnswer;
                    while (!int.TryParse(Console.ReadLine(), out userAnswer))
                    {
                        Console.WriteLine("Ответ должен быть введён в форме числа, повторите ввод");
                    }

                    int rightAnswer = answers[randomIndex];

                    if (userAnswer == rightAnswer)
                    {
                        countRightAnswers++;
                    }
                }

                Console.WriteLine($"{name}, количество правильных ответов: {countRightAnswers}");

                DiagnosesGet diagosisCalculator = new DiagnosesGet();
                string diagnosis = diagosisCalculator.GetDiagnoses(countRightAnswers, questionsCount);


                Console.WriteLine($"{name}, ваш диагноз: {diagnosis}");
                Console.WriteLine("Хотите пройти тест ещё раз? (да/нет)");
                userResponse = Console.ReadLine()?.ToLower();
            } while (userResponse == "да");

            Console.WriteLine("Спасибо за участие! До свидания!");
        }
        static string[] QuestionsGet(int questionsCount) // надюсь это соотвествует постулату "Самое главное слово в конце названия" как в лекции по чистому коду?
        {
            string[] questions = new string[questionsCount];
            questions[0] = "Сколько будет два плюс два умноженное на два?";
            questions[1] = "Бревно нужно распилить на 10 частей, сколько нужно сделать распилов?";
            questions[2] = "На двух руках 10 пальцев, сколько пальцев на 5 руках?";
            questions[3] = "Укол делают каждые пол часа, сколько нужно минут для трёх уколов?";
            questions[4] = "Пять свечей горело, две потухли, сколько свечей осталось?";
            return questions;
        }

        static int[] AnswersGet(int questionsCount)
        {
            int[] answers = new int[questionsCount];
            answers[0] = 6;
            answers[1] = 9;
            answers[2] = 25;
            answers[3] = 60;
            answers[4] = 2;
            return answers;
        }
        public class DiagnosesGet
        {
            private string[] diagnosis;

            public DiagnosesGet()
            {
                diagnosis = new string[6];
                diagnosis[0] = "Идиот";
                diagnosis[1] = "Кретин";
                diagnosis[2] = "Дурак";
                diagnosis[3] = "Нормальный";
                diagnosis[4] = "Талант";
                diagnosis[5] = "Гений";
            }
            public string GetDiagnoses(int correctAnswers, int totalQuestions)
            {
                double persantage = (double)correctAnswers / totalQuestions * 100;

                if (persantage <= 16.66)
                { return diagnosis[0]; }
                if (persantage <= 33.33)
                { return diagnosis[1]; }
                if (persantage <= 50)
                { return diagnosis[2]; }
                if (persantage <= 66.66)
                { return diagnosis[3]; }
                if (persantage <= 83.33)
                { return diagnosis[4]; }
                else
                { return diagnosis[5]; }
            }
        }

    }
}

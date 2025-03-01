using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.IO.Enumeration;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GeniusIdiotConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте. Как Ваше имя ?");
            Console.WriteLine();
            string userName = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Хотите пройти тест ? Да или НЕТ ?");
            Console.WriteLine();

            while (ConveyYesOrNO())
            {
                StartPoint(userName);

                if (ConveyYesOrNO())
                {
                    ShowUserResults();
                }
                Console.WriteLine();
                Console.WriteLine("Хотите ответить на вопросы еще раз ? Да или НЕТ ?");
                Console.WriteLine();
            }
            Console.WriteLine(userName + "," + " Вы завершили тест !");
        }

        static List<string> GetQuestions()
        {
            List<string> questions = new List<string>();

            questions.Add("Сколько будет два плюс два умноженное на два ?");
            questions.Add("Бревно нужно распилить на 10 частей, сколько надо сделать распилов ?");
            questions.Add("На двух руках 10 пальцев. Сколько пальцев на 5 руках ?");
            questions.Add("Укол делают каждые полчаса, сколько нужно минут для трех уколов ?");
            questions.Add("Пять свечей горело, две потухли. Сколько свечей осталось ?");

            return questions;
        }

        static List<int> GetAnswers()
        {
            List<int> answers = new List<int>();

            answers.Add(6);
            answers.Add(9);
            answers.Add(25);
            answers.Add(60);
            answers.Add(2);

            return answers;
        }

        static int[] GetRandomIndexes(int questionsCount)
        {
            int[] randomIndex = new int[questionsCount];

            for (int i = 0; i < questionsCount; i++)
            {
                randomIndex[i] = i;
            }

            Random random = new Random();

            for (int i = 0; i < questionsCount; i++)
            {
                int ramdomQuestion = random.Next(questionsCount);

                var temp = randomIndex[ramdomQuestion];
                randomIndex[ramdomQuestion] = randomIndex[i];
                randomIndex[i] = temp;
            }
            return randomIndex;
        }

        static int GetUserAnswer()
        {
            while (true)
            {
                try
                {
                    return int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine();
                    Console.WriteLine("Ведите число....");
                    Console.WriteLine();
                }
                catch (OverflowException)
                {
                    Console.WriteLine();
                    Console.WriteLine("Введите число меньше ... ");
                    Console.WriteLine();
                }
            }
        }

        static List<string> GetDiagnoses()
        {
            List<string> diagnoses = new List<string>();

            diagnoses.Insert(0, "Идиот");
            diagnoses.Insert(1, "Кретин");
            diagnoses.Insert(2, "Дурак");
            diagnoses.Insert(3, "Нормальный");
            diagnoses.Insert(4, "Талант");
            diagnoses.Insert(5, "Гений");
            return diagnoses;
        }

        static string CalculationDiagnos(int questionsCount, int rightAnswersCount)
        {
            List<string> diagnoses = GetDiagnoses();

            int rightAnswersPercent = rightAnswersCount * 100 / questionsCount;

            if (rightAnswersPercent < 10)
                return diagnoses[0];
            if (rightAnswersPercent < 30)
                return diagnoses[1];
            if (rightAnswersPercent < 45)
                return diagnoses[2];
            if (rightAnswersPercent < 80)
                return diagnoses[3];
            if (rightAnswersPercent < 100)
                return diagnoses[4];

            return diagnoses[5];
        }

        static bool ConveyYesOrNO()
        {
            string userAnswer = Console.ReadLine().ToUpper();
            Console.WriteLine();

            if (userAnswer == "НЕТ")
                return false;

            if (userAnswer == "ДА")
                return true;

            return ConveyYesOrNO();
        }

        static void AppendToFile(string fileName, string value)
        {
            StreamWriter writer = new StreamWriter(fileName, true, Encoding.UTF8);
            writer.WriteLine(value);
            writer.Close();
        }
        static void SaveUserResult(string userName, int rightAnswersCount, string diagnos)
        {
            string value = $"{userName}#{rightAnswersCount}#{diagnos}";
            AppendToFile("userResults.txt", value);
        }

        private static void ShowUserResults()
        {
            string hatPattern = "{0,-20}{1,22}{2,21}";
            string resultPattern = "{0,-20}{1,16}{2,33}";

            StreamReader reader = new StreamReader("userResults.txt", Encoding.UTF8);

            Console.WriteLine(hatPattern, "Имя", "           Количество        ", "Диагноз");
            Console.WriteLine(hatPattern, "   ", "           правильных        ", "       ");
            Console.WriteLine(hatPattern, "   ", "            ответов          ", "       ");
            Console.WriteLine();

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split('#');
                string name = values[0];
                int countRightAnsweres = int.Parse(values[1]);
                string diagnos = values[2];

                Console.WriteLine(resultPattern, name, countRightAnsweres, diagnos);
            }
            reader.Close();
        }

        static void StartPoint(string userName)
        {
            var questions = GetQuestions();

            int questionsCount = questions.Count;

            var answers = GetAnswers();

            int rightAnswersCount = 0;

            int[] randomIndex = GetRandomIndexes(questionsCount);

            for (int i = 0; i < questionsCount; i++)
            {
                Console.WriteLine("Вопрос N№ " + (i + 1));

                Console.WriteLine(questions[randomIndex[i]]);
                Console.WriteLine();

                int userAnswer = GetUserAnswer();
                Console.WriteLine();

                int rightAnswer = answers[randomIndex[i]];

                if (userAnswer == rightAnswer)
                {
                    rightAnswersCount++;
                }
            }
            Console.WriteLine("Количество правильных ответов: " + rightAnswersCount);

            string diagnos = CalculationDiagnos(questionsCount, rightAnswersCount);

            Console.WriteLine();
            Console.WriteLine(userName + ", Ваш диагноз = " + diagnos);

            SaveUserResult(userName, rightAnswersCount, diagnos);

            Console.WriteLine();
            Console.WriteLine("Хотите посмотреть  предыдущие результаты игры ? Да или НЕТ ?");
            Console.WriteLine();
        }
    }
}
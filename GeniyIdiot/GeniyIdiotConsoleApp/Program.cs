using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;


namespace GeniyIdiotConsoleApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			bool repeat;
			do
			{
				Console.WriteLine($"Здравствуйте, введите своё имя");
				string name = Console.ReadLine();

				List<string> questions = GetQuestions();

				List<int> answers = GetAnswers();

				if (questions.Count != answers.Count)
				{
					Console.WriteLine("Ошибка конфигурации теста. Количество вопросов не соотвествует количеству ответов");
					return;
				}
				int questionsCount = questions.Count;

				int rightAnswersCount = 0;

				List<int> rundomIndices = GenerateRandomIndices(questionsCount);

				for (int i = 0; i < questionsCount; i++)
				{
					int currentIndex = rundomIndices[i];
					Console.WriteLine($"Вопрос номер {i + 1}");
					Console.WriteLine(questions[currentIndex]);

					int userAnswer = GetUserAnswer();
					int rightAnswer = answers[currentIndex];

					if (userAnswer == rightAnswer)
					{
						rightAnswersCount++;
					}
				}

				Console.WriteLine($"{name}, количество правильных ответов: {rightAnswersCount}");

				var diagosisCalculator = new DiagnosesCalculation();
				string diagnosis = diagosisCalculator.GetResults(rightAnswersCount, questionsCount);


				Console.WriteLine($"{name}, ваш диагноз: {diagnosis}");

				SaveTestResult(name, rightAnswersCount, diagnosis);

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
			string userRespond;
			while(true)
			{
				Console.WriteLine("Хотите пройти тест ещё раз? (да/нет)");
				userRespond = Console.ReadLine()?.Trim().ToLower();
				if (userRespond == "да")
				{
					return true;
				}
				if (userRespond == "нет")
				{
					return false;
				}
				else
				{
					Console.WriteLine("Введите либо 'да' либо 'нет'!");
				}
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

				Console.WriteLine($"Ответ не соответствует заданному диапазону. Пожалуйста, повторите ввод.");
			}
		}
		static List<int> GenerateRandomIndices(int questionsCount)
		{
			Random random = new Random();
			List<int> askedQuestions = new List<int>();

			for (int i = 0; i < questionsCount; i++)
			{
				int randomIndex;
				do
				{
					randomIndex = random.Next(questionsCount);
				}
				while (askedQuestions.Contains(randomIndex));

				askedQuestions.Add(randomIndex);
			}
			return askedQuestions;
		}
		static List<string> GetQuestions()
		{
			return new List<string>
			{
			"Сколько будет два плюс два умноженное на два?",
			"Бревно нужно распилить на 10 частей, сколько нужно сделать распилов?",
			"На двух руках 10 пальцев, сколько пальцев на 5 руках?",
			"Укол делают каждые пол часа, сколько нужно минут для трёх уколов?",
			"Пять свечей горело, две потухли, сколько свечей осталось?"
		    };
		}

		static List<int> GetAnswers()
		{
			return new List<int>
			{ 
			   6,
			   9,
			   25,
			   60,
			   2
		    };
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

			public string GetResults(int correctAnswers, int totalQuestions)
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

		public class TestResult
		{
			public string Name { get; set; }
			public int CorrectAnswers { get; set; }
			public string Diagnosis { get; set; }
		}

		static void SaveTestResult(string name, int correctAnswers, string diagnosis)
		{
			var result = new TestResult
			{
				Name = name,

				CorrectAnswers = correctAnswers,

				Diagnosis = diagnosis
			};

			List<TestResult> results = new List<TestResult>();

			string resultsPath = "results.csv";

			results.Add(result);

			using (StreamWriter writer = new StreamWriter(resultsPath, true))
			{
				if (!File.Exists(resultsPath))
				{
					writer.WriteLine("Name,CorrectAnswers,Diagnosis");
				}


				foreach (var data in results)
				{
					writer.WriteLine($"{data.Name},{data.CorrectAnswers},{data.Diagnosis}");
				}
			}

		}

		static List<TestResult> SaveTestResults()
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
						Console.WriteLine($"ОшибкаБ в строке {line} недостаточное количество колонок");
						continue;
					}

					if (!int.TryParse(columns[1], out int correctAnswers))
					{
						Console.WriteLine($"Некорректное число в строке {line}");
						continue;
					}
					results.Add(new TestResult
					{
						Name = columns[0].Trim(),
						CorrectAnswers = correctAnswers,
						Diagnosis = columns[2].Trim()
					});
				}
			}
			return results;
		}
		 
		static void ShowTestResults()
		{
			List<TestResult> results = SaveTestResults();


            Console.WriteLine("\nПредыдущие результаты пользователей:");
			Console.WriteLine("---------------------------------------------------------------------------");
			Console.WriteLine("| {0, -30} | {1, 25} | {2, -10} |", "ФИО", "Кол-во правильных ответов", "Диагноз");
			Console.WriteLine("---------------------------------------------------------------------------");
			foreach (var result in results)
			{
				Console.WriteLine("| {0, -30} | {1, 25} | {2, -10} |",
					result.Name,
					result.CorrectAnswers,
					result.Diagnosis);
			}
			Console.WriteLine("---------------------------------------------------------------------------");
		}

		static bool AskToShowResults()
		{
			while (true)
			{
				Console.WriteLine("Показать историю результатов? (да/нет)");

				string userRespond = Console.ReadLine().Trim().ToLower();

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

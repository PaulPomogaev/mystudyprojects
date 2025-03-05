namespace GeniyIdiotConsoleApp3_0
{
    internal class Program
    {
#pragma warning disable
        static void Main(string[] args)
        {
            Console.SetWindowSize(140, 35);
            MainMenu menu = new MainMenu();
            menu.CreatingUser();
            menu.ShowMainMenu();
        }

        public class MainMenu
        {
            private List<string> offers;
            private List<string> revies;
            private List<string> errorMessage;
            public User NewUser;
            public TextSystem Test;

            public MainMenu()
            {
                offers = new List<string>();
                revies = new List<string>();
                errorMessage = new List<string>();
                Test = new TextSystem();
                NewUser = new User("Андриянов", "Дмитрий", "Игоревич", 18);
            }

            public void CreatingUser()
            {
                Console.WriteLine("Добро пожаловать в тестирующую систему \"Гений-Идиот\"!");
                Console.WriteLine("Вам предстоит ответить на 12 коротких логических вопросов.\n" +
                "За 2 минуты вы должны дать ответ. После ответа на все вопросы система поставит вам диагноз.\n" +
                "P.S.: данная тестирующая система носит исключительно развлекательный характер, не воспринимайте всё всерьёз.");
                //Thread.Sleep(10000); Console.Clear();

                Console.WriteLine("Введите ваше имя:");
                NewUser.FirstName = Console.ReadLine();
                Console.Clear();

                Console.WriteLine("Введите вашу фамилию:");
                NewUser.ListName = Console.ReadLine();
                Console.Clear();

                Console.WriteLine("Введите ваше очество:");
                NewUser.MiddleName = Console.ReadLine();
                Console.Clear();

                Console.WriteLine("Введите ваш полный возраст:");
                int userAge = GetCorrectAnswer();
                NewUser.Age = userAge;
                Console.Clear();
            }

            public void ShowMainMenu()
            {

                while (true)
                {
                    Console.WriteLine("Выберите действие:");
                    Console.WriteLine("1.Начать новый тест.");
                    Console.WriteLine("2.Обратная связь по Telegram.");
                    Console.WriteLine("3.Изменить настройки профиля.");
                    Console.WriteLine("4.Информация о тетсирующей системе.");
                    Console.WriteLine("5.Общая статистика по всем пройденным тестам.");
                    Console.WriteLine("6.Просмотреть результаты всех пройденных тестов.");
                    Console.WriteLine("7.Выход из тестирующей системы. Завершение текущей сессии.");

                    string userAnswer = Console.ReadLine();
                    if (userAnswer == "1") StartTest();
                    else if (userAnswer == "2") { Console.Clear(); ContactFeedback(); }
                    else if (userAnswer == "3") { Console.Clear(); ChangeProfile(NewUser); }
                    else if (userAnswer == "4") { Console.Clear(); TestInformation(); }
                    else if (userAnswer == "5") { Console.Clear(); ShowStatistics(NewUser); }
                    else if (userAnswer == "6") { Console.Clear(); ShowResultsPassedTests(NewUser); }
                    else if (userAnswer == "7") { Console.Clear(); ExitTestingSystem(); }
                    else { Console.Clear(); Console.WriteLine("Ошибка, выберите действие ещё раз"); Thread.Sleep(1200); Console.Clear(); }
                }
            }

            public void StartTest()
            {
                Console.Clear();
                while (true)
                {
                    Test.OutputQuestions(NewUser);
                    if (!Test.ContinueTest()) break;
                }

                //Test.ShowAllResults(NewUser); В ДОРАБОТКЕ!

            public void ContactFeedback()
            {
                while (true)
                {
                    Console.WriteLine("Выберите действие:");
                    Console.WriteLine("1.Оставить отзыв о тестирующей системе.");
                    Console.WriteLine("2.Сообщить об ошибке в тестирующей системе.");
                    Console.WriteLine("3.Предложить новые темы для тестирующией системы.");
                    Console.WriteLine("4.Связаться с командой разаботки и задать вопросы.");
                    Console.WriteLine("5.Для выхода в главное меню нажмите любую клавишу.");

                    string userAnswer = Console.ReadLine();
                    if (userAnswer == "1") { Console.Clear(); Console.WriteLine("Для возврата в главное меня нажмите клавишу \"=\".\nНапишите свой отзыв:"); string userRevies = Console.ReadLine(); if (userRevies != "=") { revies.Add(userRevies); Console.WriteLine("Ваш отзыв успешно отправлен! Команда разработки в скором времени его рассмотрят!"); Thread.Sleep(2000); Console.Clear(); } else Console.Clear(); }
                    else if (userAnswer == "2") { Console.Clear(); Console.WriteLine("Напишите сообщение об ошибке в тестирующей системе:"); string userErrorMessage = Console.ReadLine(); if (userErrorMessage != "=") { errorMessage.Add(userErrorMessage); Console.WriteLine("Ваше сообщение об ошибке успешно отправлено! Команда разработки в скором времени его рассмотрят!"); Thread.Sleep(2000); Console.Clear(); } else Console.Clear(); }
                    else if (userAnswer == "3") { Console.Clear(); Console.WriteLine("Напишите свои предложения, идеи для тестирующей системы:"); string userOffers = Console.ReadLine(); if (userOffers != "=") { offers.Add(userOffers); Console.WriteLine("Ваше пребложения или идея успешно отпралвена!  Команда разработки в скором премени их рассмотрят!"); Thread.Sleep(2000); Console.Clear(); } else Console.Clear(); }
                    else if (userAnswer == "4") { Console.Clear(); Console.WriteLine("Телеграм для связи с разработчиками: @YummyAmNyam\nМожете задать любой вопрос, написать предложения или идеи, мы обязятально их рассмотрим!"); Thread.Sleep(6500); Console.Clear(); }
                    else { Console.Clear(); ShowMainMenu(); }
                }
            }

            public void ChangeProfile(User user)
            {
                while (true)
                {
                    Console.WriteLine($"Ваше текущее ФИО: {user.ListName} {user.FirstName} {user.MiddleName}, ваш текущий возраст: {user.Age}");
                    Console.WriteLine("Выберите, что хотите изменить:");
                    Console.WriteLine("1.Изменить имя.");
                    Console.WriteLine("2.Изменить фамилию.");
                    Console.WriteLine("3.Измиенить отчество.");
                    Console.WriteLine("4.Измиенить свой возраст.");
                    Console.WriteLine("5.Для выхода в главное меню нажмите любую клавишу.");

                    while (true)
                    {
                        string userAnswer = Console.ReadLine();
                        if (userAnswer == "1") { Console.Clear(); Console.WriteLine("Введите новое имя, для отмены нажмите \"=\""); string input = Console.ReadLine(); if (input == "=") { Console.Clear(); break; } else { user.FirstName = input; Console.WriteLine("Имя успешно обновлено"); Thread.Sleep(1200); Console.Clear(); break; } }
                        else if (userAnswer == "2") { Console.Clear(); Console.WriteLine("Введите новую фамилию, для отмены нажмите \"=\""); string input = Console.ReadLine(); if (input == "=") { Console.Clear(); break; } else { user.ListName = input; Console.WriteLine("Фамилия успешно обновлена"); Thread.Sleep(1200); Console.Clear(); break; } }
                        else if (userAnswer == "3") { Console.Clear(); Console.WriteLine("Введите новое отчество, для отмены нажмите \"=\""); string input = Console.ReadLine(); if (input == "=") { Console.Clear(); break; } else { user.MiddleName = input; Console.WriteLine("Отчество успешно обновлено"); Thread.Sleep(1200); Console.Clear(); break; } }
                        else if (userAnswer == "4") { Console.Clear(); Console.WriteLine("Введите новый возраст, для отмены нажмите \"=\""); string age = Console.ReadLine(); if (age == "=") { Console.Clear(); break; } else { while (true) { bool correct = Int32.TryParse(age, out int correctAge); if (correct) { user.Age = correctAge; Console.WriteLine("Возраст успешно обновлён"); Thread.Sleep(1200); Console.Clear(); break; } else { Console.WriteLine("Возраст не может содержать буквы!"); age = Console.ReadLine(); } } break; } } //О НЕЕЕТ, ПАЙТОН МЕНЯ ЗАГИПНОТИЗИРОВАЛ((((
                        else { Console.Clear(); ShowMainMenu(); }
                    }
                }
            }

            public void TestInformation()
            {
                Console.WriteLine("Добро пожаловать в тестирующую систему \"Гений-Идиот\"!");
                Console.WriteLine();
                Console.WriteLine("Вам предстоит ответить на 12 коротких логических вопросов.");
                Console.WriteLine("За 2 минуты вы должны дать ответ на 1 вопрос. После ответа на все вопосы тестирующая система поставит вам диагноз.");
                Console.WriteLine("P.S.: данная тестирующая система носит исключительно развлекательный характер, пожалуйста, не воспринимайте всё всерьёз ^-^");

                Console.WriteLine();
                Console.WriteLine("Общие инструкции прохождения тестирующей системы:");
                Console.WriteLine("1. На каждый вопрос у вас будет 2 минуты для ответа.");
                Console.WriteLine("2. Введите в консоль ваш окончательный ответ. На все вопросы отвечать только одним числом!");
                Console.WriteLine("3. Не переживайте, главное - это само удовольствие от процесса прохождения тестирующей системы!");
                Console.WriteLine("4. Помните, что результаты теста не являются серьёзной оценкой ваших способновтей, никто не имеет право вас оценивать!");

                Console.WriteLine();
                Console.WriteLine("Спасибо огромное, что выбрали нас, мы это очень ценим и прислушиваемся в каждому вашему предложению!♥♥♥ Удачи и приятного времяпровождения!♥♥♥");
                Console.WriteLine("Для выхода в главное меню нажмите лбую клавишу :)");
                Console.ReadKey();
                Console.Clear();
            }

            public void ShowStatistics(User user)
            {
                user.ShowAvergateStatistics(user);
            }

            public void ShowResultsPassedTests(User user)
            {
                user.ShowResulrTest();
            }

            public void ExitTestingSystem()
            {
                Console.WriteLine("Вы действительно хотите выйти из тестирующей системы с потерей данных?(\nВведите \"да\" или \"нет\":");
                string userAnswer = Console.ReadLine().ToLower();
                userAnswer = ChangeLayout(userAnswer);
                if (ProcessUserResponse(userAnswer))
                {
                    Environment.Exit(0);
                }
                Console.Clear();
            }
        }

        public class TextSystem
        {
            private readonly string[] questions = new string[]
            {
                "Сколько будет два плюс два умноженное на два?",//6
                "Чему равна утроенная половина четверти числа 96?",//36
                "На двух руках 10 пальцев, сколько пальцев на 5 руках?",//25
                "Во сколько раз секундная стрелка движется быстрее минутной?",//60
                "Укол делают каждые полчаса, сколько нужно минут для трёх уколов?",//60
                "Пять свечей горело, две потухли. Сколько свечей осталось в итоге?",//2
                "Один кирпич весит 1 кг и ещё полкирпича. Сколько весит один кирпич?",//2
                "У фермера 17 овец, и все, кроме 9, умирают. Сколько овец осталось?", //9 
                "Бревно нужно распилить на 10 частей, сколько распилов нужно сделать?",//9
                "Ученик прочитал 4 страницы за 10 минут, сколько он прочитает за 30 минут?",//12
                "У квадратного стола отпилили один угол. Сколько теперь углов у него стало?",//5
                "Иосиф зашёл в комнату и увидел в каждом углу по 3 кошки. Сколько всего ног в комнате?"//50
            };
            private readonly string[] diagnoses = new string[] { "Идиот", "Кретин", "Дурак", "Нормальный", "Талант", "Гений" };
            private readonly int[] answers = new int[] { 6, 36, 25, 60, 60, 2, 2, 9, 9, 12, 5, 50 };

            private void ShufflingArray()
            {
                Random random = new Random();
                for (int i = questions.Length - 1; i > 0; i--) //перебираем массив с конца! (на примере с числами: от 10 до 1) 
                {
                    int randomNumber = random.Next(i + 1); //i + 1 для добавления верхней границы, включения её в диапазон

                    string tempRandomQuestion = questions[randomNumber];
                    questions[randomNumber] = questions[i];
                    questions[i] = tempRandomQuestion;

                    int tempRandomAnswer = answers[randomNumber];
                    answers[randomNumber] = answers[i];
                    answers[i] = tempRandomAnswer;
                }
            }

            public void OutputQuestions(User user)
            {
                ShufflingArray();
                double countPoints = 0;
                int countRightAnswers = 0;
                Random random = new Random();
                double pointValue = (double)diagnoses.Length / questions.Length;

                for (int i = 0; i < questions.Length; i++)
                {
                    Console.WriteLine($"Вопрос {i + 1} из {questions.Length}\n{questions[i]}");
                    if (GetCorrectAnswer() == answers[i])
                    {
                        countPoints += pointValue;
                        countRightAnswers++;
                    }
                    Console.Clear();
                }

                int index;
                if (countPoints <= 1) index = 0;
                else if (countPoints > 1 && countPoints <= 2) index = 1;
                else if (countPoints > 2 && countPoints <= 3) index = 2;
                else if (countPoints > 3 && countPoints <= 4) index = 3;
                else if (countPoints > 4 && countPoints <= 5) index = 4;
                else index = 5;

                countPoints = Math.Round(countPoints, 2);
                user.AddResultTest(countRightAnswers, countPoints, diagnoses[index]);
                user.ShowResultOneTest(countRightAnswers, countPoints, diagnoses[index]);
            }

            public bool ContinueTest()
            {
                Console.WriteLine("Вы хотите пройти тест с начала? Введите \"да\" или \"нет\":");
                string userAnswer = Console.ReadLine().ToLower();
                userAnswer = ChangeLayout(userAnswer);
                Console.Clear();
                return ProcessUserResponse(userAnswer);
            }

            public void ShowAllResults(User user)
            {
                Console.WriteLine("Хотите увидеть результаты всех пройденных тестов? Введите \"да\" или \"нет\"");
                string userAnswer = Console.ReadLine().ToLower();
                userAnswer = ChangeLayout(userAnswer);
                if (ProcessUserResponse(userAnswer)) user.ShowResulrTest();
            }
        }

        public class User
        {
            private List<int> countRigntAnswers;
            private List<string> userdiagnoses;
            private List<double> points;

            private string middleName;
            private string firstName;
            private string listName;
            private int age;
            public readonly Guid Id;

            private readonly string[] diagnoses = new string[] { "Идиот", "Кретин", "Дурак", "Нормальный", "Талант", "Гений" };
            private double avergateCountCorrectAnswers;
            private double avergateCountPoints;
            private string avergateDiagnosis;
            private int countTestsPassed;

            public User(string lastName, string firstName, string middleName, int age)
            {
                MiddleName = middleName;
                FirstName = firstName;
                ListName = lastName;
                Id = new Guid();
                Age = age;

                countRigntAnswers = new List<int>();
                userdiagnoses = new List<string>();
                points = new List<double>();
            }

            public string MiddleName
            {
                get { return middleName; }
                set { middleName = GetCoorrectUserData(value, "middleName"); }
            }

            public string FirstName
            {
                get { return firstName; }
                set { firstName = GetCoorrectUserData(value, "firstName"); }
            }

            public string ListName
            {
                get { return listName; }
                set { listName = GetCoorrectUserData(value, "listName"); }
            }

            public int Age
            {
                get { return age; }
                set
                {
                    while (true)
                    {
                        Console.Clear();
                        if (value > 5 && value <= 120) { age = value; break; }
                        else { Console.WriteLine("Возраст должен быть больше 5-ти лет, возраст не может быть больше 120. Введите новый возраст:"); }
                        value = Convert.ToInt32(Console.ReadLine());
                    }
                }
            }

            public void AddResultTest(int countRigntAnswers, double countPoints, string diagnos)
            {
                this.countRigntAnswers.Add(countRigntAnswers);
                this.userdiagnoses.Add(diagnos);
                this.points.Add(countPoints);
                countTestsPassed++;
            }

            public void ShowResultOneTest(int countRigntAnswers, double countPoints, string diagnos)
            {
                Console.WriteLine($"Кол-во правильных ответов: {countRigntAnswers}\nКол-во набранных очков: {countPoints}\nВаш диагноз: {diagnos}");
            }

            public void ShowResulrTest()
            {
                if (countRigntAnswers.Count == 0) { Console.Clear(); Console.WriteLine("Данные тестов отсутствуют! Пройдите тест, чтобы узнать результат!"); Thread.Sleep(2000); Console.Clear(); }
                else
                {
                    Console.WriteLine("|| {0, -17} || {1, -14} || {2, -14} || {3, -27} || {4, -15} || {5, -12} ||", "Фамилия:", "Имя:", "Очество:", "Кол-во правильных ответов:", "Кол-во баллов:", "Диагноз:");
                    for (int i = 0; i < countRigntAnswers.Count; i++)
                        Console.WriteLine("|| {0, -17} || {1, -14} || {2, -14} || {3, -27} || {4, -15} || {5, -12} ||", ListName, FirstName, MiddleName, countRigntAnswers[i], points[i], userdiagnoses[i]);
                    Console.WriteLine("Для выхода в главное меню нажмите любую клавишу.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            public void ShowAvergateStatistics(User user)
            {
                if (countTestsPassed != 0)
                {
                    Console.WriteLine($"Кол-во всех пройденных тестов: {countTestsPassed}");

                    int sum = 0;
                    foreach (int quantity in countRigntAnswers)
                    {
                        sum += quantity;
                    }
                    Console.WriteLine($"Среднее кол-во правильных ответов: {(double)sum / countTestsPassed}");

                    sum = 0;
                    foreach (int quantity in points)
                    {
                        sum += quantity;
                    }
                    double avergateCountPoints = (double)sum / countTestsPassed;
                    Console.WriteLine($"Среднее кол-во полученных вами очков: {avergateCountPoints}");

                    int index;
                    if (avergateCountPoints <= 1) index = 0;
                    else if (avergateCountPoints > 1 && avergateCountPoints <= 2) index = 1;
                    else if (avergateCountPoints > 2 && avergateCountPoints <= 3) index = 2;
                    else if (avergateCountPoints > 3 && avergateCountPoints <= 4) index = 3;
                    else if (avergateCountPoints > 4 && avergateCountPoints <= 5) index = 4;
                    else index = 5;
                    Console.WriteLine($"Средний установленный диагноз вашим врачом: {diagnoses[index]}");

                    Console.WriteLine();
                    Console.WriteLine("Для выхода в главное меню нажмите абсолютно любую клавишу.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Пройдите хотя бы 1 раз тестирующую систему, чтобы увидеть среднюю статистику!");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }

        }

        static string CorrectRegisterLetters(string userName)
        {
            return char.ToUpper(userName[0]) + userName.Substring(1).ToLower();
        }

        static string ChangeLayout(string line)
        {
            Dictionary<char, char> changeLayout = new Dictionary<char, char>()
            {
                {'q', 'й'}, {'w', 'ц'},  {'e', 'у'}, {'r', 'к'},  {'t', 'е'},
                {'y', 'н'}, {'u', 'г'},  {'i', 'ш'}, {'o', 'щ'},  {'p', 'з'},
                {'[', 'х'}, {']', 'ъ'},  {'a', 'ф'}, {'s', 'ы'},  {'d', 'в'},
                {'f', 'а'}, {'g', 'п'},  {'h', 'р'}, {'j', 'о'},  {'k', 'л'},
                {'l', 'д'}, {';', 'ж'},  {'\'', 'э'}, {'z', 'я'}, {'x', 'ч'},
                {'c', 'с'}, {'v', 'м'},  {'b', 'и'}, {'n', 'т'},  {'m', 'ь'},
                {',', 'б'}, {'.', 'ю'},  {'`', 'ё'}, {'/', '.'},  {' ', ' '},
            };

            if (changeLayout.ContainsValue(line[0]))
                return line;

            string correctLine = string.Empty;
            for (int i = 0; i < line.Length; i++)
            {
                if (changeLayout.ContainsKey(line[i]))
                    correctLine += changeLayout[line[i]];
                else correctLine += line[i];
            }

            return correctLine;
        }

        static bool ProcessUserResponse(string userAnswer)
        {
            userAnswer = userAnswer.ToLower();

            List<string> list = new List<string>()
            {
                "да", "жа", "юа", "ба", "ла", "ща", "за",
                "дв", "дк", "де", "дп", "дм", "дс",
                "жв", "жк", "же", "жп", "жм", "жс",
                "юв", "юк", "юе", "юп", "юм", "юс",
                "бв", "бк", "бе", "бп", "бм", "бс",
                "лв", "лк", "ле", "лп", "лм", "лс",
                "щв", "щк", "ще", "щп", "щм", "щс",
                "зв", "зк", "зе", "зп", "зм", "зс"
            };

            if (list.IndexOf(userAnswer) != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static int GetCorrectAnswer()
        {
            while (true)
            {
                string answer = Console.ReadLine();
                if (int.TryParse(answer, out int number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Пожалуйста, введите число!");
                }
            }
        }

        static string GetCoorrectUserData(string data, string parameter)
        {
            while (true)
            {
                bool exitCycle = true;
                foreach (char letter in data)
                {
                    if (letter == ' ' || char.IsDigit(letter) || data.Length < 2)
                    {
                        if (parameter == "firstName") { Console.Clear(); Console.WriteLine("Имя не должно содержать цифры и проблелы. Миниальный размер имени - 2 символа\nВведите новое имя ещё раз:"); }
                        else if (parameter == "lastName") { Console.Clear(); Console.WriteLine("Фамилия не должна содержать цифры и проблелы. Миниальный размер фамилии - 2 символа\nВведите новую фамилию ещё раз:"); }
                        else { Console.Clear(); Console.WriteLine("Отчество не должно содержать цифры и проблелы. Миниальный размер отчества - 2 символа\nВведите новое отчество ещё раз:"); }
                        data = Console.ReadLine();
                        exitCycle = false;
                    }
                }
                if (exitCycle)
                {
                    Console.Clear();
                    string correctData = ChangeLayout(data);
                    return CorrectRegisterLetters(correctData);
                }
            }
        }
    }
}
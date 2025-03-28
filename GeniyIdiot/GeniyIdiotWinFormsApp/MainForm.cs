using GeniyIdiot.Common;
using static GeniyIdiotConsoleApp.Program;


namespace GeniyIdiotWinFormsApp
{
    public partial class mainForm : Form
    {
        private List<Question> questions;
        private Question currentQuestion;
        private int totalQuestionsCount;
        private User user;
        private int questionNumber;
        private string userName;
        private int timeLeft = 10;
        private const int TotalTime = 10;

        public mainForm()
        {
            InitializeComponent();
            ConfigureProgressBar();
        }

        private void ConfigureProgressBar()
        {
            timeProgressBar.Style = ProgressBarStyle.Continuous;
            timeProgressBar.ForeColor = Color.Green;
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            var wellcomeForm = new WellcomeForm();
            if (wellcomeForm.ShowDialog() != DialogResult.OK)
            {
                Close();
                return;
            }
            userName = wellcomeForm.UserName;
            user = new User(userName);
            questions = QuestionsStorage.GetAllQuestions();
            totalQuestionsCount = questions.Count;

            ShowNextQuestion();
        }

        private void ShowNextQuestion()
        {
            questionTimer.Stop();
            timeLeft = TotalTime;
            timeProgressBar.Value = 100;
            timerLabel.Text = "10 сек";

            if (questions.Count == 0)
            {
                EndTest();
                return;
            }

            var random = new Random();
            var randomIndex = random.Next(questions.Count);
            currentQuestion = questions[randomIndex];
            questionTextLabel.Text = currentQuestion.Text;
            questions.RemoveAt(randomIndex);
            questionNumber++;
            questionNumberLabel.Text = "Вопрос № " + questionNumber;

            questionTimer.Start();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            ProcessAnswer();
        }

        private void ProcessAnswer()
        {
            questionTimer.Stop();

            int userAnswer;
            if (!int.TryParse(userAnswerTextBox.Text, out userAnswer))
            {
                MessageBox.Show("Ответ не соответствует заданному диапазону от -2*10^9 до 2*10^9. Пожалуйста, повторите ввод.");
                return;
            }

            if (userAnswer == currentQuestion.Answer)
            {
                user.AcceptRightAnswer();
            }

            userAnswerTextBox.Clear();
            ShowNextQuestion();
        }

        private void EndTest()
        {
            var diagnosisCalculator = new DiagnosesCalculation();
            string diagnosis = diagnosisCalculator.GetResult(user.RightAnswersCount, totalQuestionsCount);

            var testResult = new TestResult(user, diagnosis);
            UsersResultStorage.SaveTestResult(testResult);

            MessageBox.Show($"{user.Name}, Кол-во правильных ответов: {user.RightAnswersCount}, Диагноз: {diagnosis}");

            var result = MessageBox.Show("Хотите пройти тест ещё раз?", "Повторить тест",
                                       MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                ResetTest();
            }
            else
            {
                Close();
            }
        }

        private void ResetTest()
        {
            questions = QuestionsStorage.GetAllQuestions();
            totalQuestionsCount = questions.Count;
            user = new User(userName);
            questionNumber = 0;

            ShowNextQuestion();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var resultsForm = new ResultsForm();
            resultsForm.ShowDialog();
        }

        private void manageQuestionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var manageForm = new ManageQuestionsForm();
            manageForm.ShowDialog();
            questions = QuestionsStorage.GetAllQuestions();
        }

        private void TimeExpired()
        {
            userAnswerTextBox.Clear();
            ShowNextQuestion();
        }

        private void questionTimer_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            timeProgressBar.Value = timeLeft * 10;
            timerLabel.Text = $"{timeLeft} сек";

            if (timeLeft <= 0)
            {
                questionTimer.Stop();
                TimeExpired();
            }
        }
    }
}
    


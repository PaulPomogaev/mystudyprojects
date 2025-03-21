using GeniyIdiotClassLibrary;
using static GeniyIdiotClassLibrary.Program;


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

        public mainForm()
        {
            InitializeComponent();
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
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            ProcessAnswer();
        }

        private void ProcessAnswer()
        {
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
    }
}
    


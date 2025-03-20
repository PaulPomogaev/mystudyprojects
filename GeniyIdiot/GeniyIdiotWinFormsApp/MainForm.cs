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
        private bool isTestStarted = false;
        public mainForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            userNameTextBox.Focus();
            userNameLabel.Visible = true;
            userNameTextBox.Visible = true;
            questionTextLabel.Visible = false;
            userAnswerTextBox.Visible = false;
            nextButton.Visible = false;
            resultsDataGridView.Visible = false;
            questionNumberLabel.Visible = false;
        }


        private void mainForm_Load(object sender, EventArgs e)
        {

            questions = QuestionsStorage.GetAllQuestions();
            totalQuestionsCount = questions.Count;
        }


        private void userNameTextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !isTestStarted)
            {
                StartTest();
                e.Handled = true;
            }
        }

        private void StartTest()
        {
            if (string.IsNullOrWhiteSpace(userNameTextBox.Text))
            {
                MessageBox.Show("Введите ваше имя перед началом теста!");
                return;
            }

            user = new User(userNameTextBox.Text.Trim());
            isTestStarted = true;

            userNameLabel.Visible = false;
            userNameTextBox.Visible = false;

            questionTextLabel.Visible = true;
            userAnswerTextBox.Visible = true;
            nextButton.Visible = true;

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
            user = new User(userNameTextBox.Text.Trim());
            questionNumber = 0;

            resultsDataGridView.Visible = false;
            questionTextLabel.Visible = true;
            userAnswerTextBox.Visible = true;
            nextButton.Visible = true;

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
    


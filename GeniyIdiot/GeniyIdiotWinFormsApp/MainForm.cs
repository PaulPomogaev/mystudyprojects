using GeniyIdiotClassLibrary;
using static GeniyIdiotClassLibrary.Class1;


namespace GeniyIdiotWinFormsApp
{
    public partial class mainForm : Form
    {
        private List<Question> questions;
        private Question currentQuestion;
        private int totalQuestionsCount;
        private User user;
        private int questionNumber;
        public mainForm()
        {
            InitializeComponent();
        }

        
        private void mainForm_Load(object sender, EventArgs e)
        {

            questions = QuestionsStorage.GetAllQuestions();
            totalQuestionsCount = questions.Count;
            user = new User();
            questionNumber = 0;
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

            if (questions.Count == 0)
                EndTest();
            else
                ShowNextQuestion();
        }
        

        private void EndTest()
        {
            var diagnosisCalculator = new DiagnosesCalculation();
            string diagnosis = diagnosisCalculator.GetResult(user.RightAnswersCount, totalQuestionsCount);

            var testResult = new TestResult(user, diagnosis);
            UsersResultStorage.SaveTestResult(testResult);

            MessageBox.Show($"{user.Name}, ваш диагноз: {diagnosis}");

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
            user = new User();
            questionNumber = 0;
            ShowNextQuestion();
        }


    }
}

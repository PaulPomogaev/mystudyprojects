using GeniyIdiotClassLibrary;

namespace GeniyIdiotWinFormsApp
{
    public partial class mainForm : Form
    {
        private List<Question> questions;
        private List<Question> currentTestQuestion;
        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            questions = QuestionsStorage.GetAllQuestions();
            currentTestQuestion = new List<Question>(questions);
            ShowNextQuestion();
        }

        private void ShowNextQuestion()
        {
            var random = new Random();
            var randomQuestionIndex = random.Next(currentTestQuestion.Count);
            questionTextLabel.Text = currentTestQuestion[randomQuestionIndex].Text;
            currentTestQuestion.RemoveAt(randomQuestionIndex);
        }

        private void nextButton_Click(object sender, EventArgs e)
        {

        }

        private void userAnswerTextBox_TextChanged(object sender, EventArgs e)
        {
            var userAnswer = 
        }
    }
}

using GeniyIdiotClassLibrary;

namespace GeniyIdiotWinFormsApp
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            List<Question> questions = QuestionsStorage.GetAllQuestions();
        }
    }
}

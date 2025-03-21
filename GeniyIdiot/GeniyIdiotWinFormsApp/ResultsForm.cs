using GeniyIdiot.Common;

namespace GeniyIdiotWinFormsApp
{
    public partial class ResultsForm : Form
    {
        public ResultsForm()
        {
            InitializeComponent();

        }

        private void ResultsForm_Load(object sender, EventArgs e)
        {
            ConfigureDataGridViewColumns();
            LoadResults();
        }

        private void ConfigureDataGridViewColumns()
        {
            resultsDataGridView.Columns.Add("Name", "ФИО");
            resultsDataGridView.Columns.Add("CorrectAnswers", "Кол-во правильных ответов");
            resultsDataGridView.Columns.Add("Diagnosis", "Диагноз");
        }

        private void LoadResults()
        {
            var results = UsersResultStorage.ReadTestResults();
            resultsDataGridView.Rows.Clear();

            foreach (var result in results)
            {

                resultsDataGridView.Rows.Add(
                    result.User.Name,
                    result.User.RightAnswersCount,
                    result.Diagnosis
                );
            }
        }

     }
}

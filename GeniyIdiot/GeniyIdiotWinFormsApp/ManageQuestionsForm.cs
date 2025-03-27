using GeniyIdiot.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeniyIdiotWinFormsApp
{
    public partial class ManageQuestionsForm : Form
    {
        public ManageQuestionsForm()
        {
            InitializeComponent();
        }

        private void ManageQuestionsForm_Load(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            dataGridView1.Rows.Clear();
            var questions = QuestionsStorage.GetAllQuestions();
            foreach (var question in questions)
            {
                dataGridView1.Rows.Add(question.Text, question.Answer);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Выберите вопрос, который хотите удалить");
                return;
            }

            var result = MessageBox.Show(
             "Удалить выбранный вопрос?",
             "Подтверждение",
             MessageBoxButtons.YesNo,
             MessageBoxIcon.Question
             );

            if (result == DialogResult.Yes)
            {
                var selectedText = dataGridView1.CurrentRow.Cells["QuestionText"].Value.ToString();
                var questionToRemove = new Question(selectedText, 0);
                QuestionsStorage.Remove(questionToRemove);
                RefreshDataGridView();
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(questionTextBox.Text))
            {
                MessageBox.Show("Необходимо ввести текст вопроса");
                return;
            }

            var newQuestion = new Question(
                questionTextBox.Text.Trim(),
                (int)answerNumericUpDown.Value
            );

            try
            {
                QuestionsStorage.Add(newQuestion);
                RefreshDataGridView();
                questionTextBox.Clear();
                answerNumericUpDown.Value = 0;
                
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
    }
}

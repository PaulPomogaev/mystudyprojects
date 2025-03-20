using GeniyIdiotClassLibrary;
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
    public partial class ResultsForm : Form
    {
        public ResultsForm()
        {
            InitializeComponent();
            resultsDataGridView.AutoGenerateColumns = false;
            LoadResults();
        }

        private void LoadResults()
        {
            var results = UsersResultStorage.ReadTestResults();
            resultsDataGridView.Columns.Clear();

            resultsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ФИО",
                DataPropertyName = "ФИО" 
            });

            resultsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Кол-во правильных ответов",
                DataPropertyName = "Кол_во_правильных_ответов"
            });

            resultsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Диагноз",
                DataPropertyName = "Диагноз"
            });

            resultsDataGridView.DataSource = results.Select(r => new
            {
                ФИО = r.User.Name,
                Кол_во_правильных_ответов = r.User.RightAnswersCount,
                Диагноз = r.Diagnosis
            }).ToList();
        }

       
    }
}

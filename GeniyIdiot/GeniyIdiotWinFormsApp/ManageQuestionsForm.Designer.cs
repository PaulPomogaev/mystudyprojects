namespace GeniyIdiotWinFormsApp
{
    partial class ManageQuestionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            deleteButton = new Button();
            questionTextBox = new TextBox();
            answerNumericUpDown = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            addButton = new Button();
            dataGridView1 = new DataGridView();
            QuestionText = new DataGridViewTextBoxColumn();
            Answer = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)answerNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // deleteButton
            // 
            deleteButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            deleteButton.Location = new Point(461, 109);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(98, 39);
            deleteButton.TabIndex = 1;
            deleteButton.Text = "Удалить";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // questionTextBox
            // 
            questionTextBox.Location = new Point(24, 191);
            questionTextBox.Name = "questionTextBox";
            questionTextBox.Size = new Size(399, 23);
            questionTextBox.TabIndex = 2;
            // 
            // answerNumericUpDown
            // 
            answerNumericUpDown.Location = new Point(439, 191);
            answerNumericUpDown.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            answerNumericUpDown.Minimum = new decimal(new int[] { 100000, 0, 0, int.MinValue });
            answerNumericUpDown.Name = "answerNumericUpDown";
            answerNumericUpDown.Size = new Size(120, 23);
            answerNumericUpDown.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(153, 167);
            label1.Name = "label1";
            label1.Size = new Size(125, 21);
            label1.TabIndex = 4;
            label1.Text = "Новый вопрос";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(434, 167);
            label2.Name = "label2";
            label2.Size = new Size(137, 21);
            label2.TabIndex = 5;
            label2.Text = "Ответ к вопросу";
            // 
            // addButton
            // 
            addButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            addButton.Location = new Point(445, 220);
            addButton.Name = "addButton";
            addButton.Size = new Size(114, 35);
            addButton.TabIndex = 6;
            addButton.Text = "Добавить";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { QuestionText, Answer });
            dataGridView1.Location = new Point(24, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(535, 91);
            dataGridView1.TabIndex = 7;
            // 
            // QuestionText
            // 
            QuestionText.HeaderText = "Вопрос";
            QuestionText.Name = "QuestionText";
            // 
            // Answer
            // 
            Answer.HeaderText = "Ответ";
            Answer.Name = "Answer";
            // 
            // ManageQuestionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(583, 267);
            Controls.Add(dataGridView1);
            Controls.Add(addButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(answerNumericUpDown);
            Controls.Add(questionTextBox);
            Controls.Add(deleteButton);
            Name = "ManageQuestionsForm";
            Load += ManageQuestionsForm_Load;
            ((System.ComponentModel.ISupportInitialize)answerNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button deleteButton;
        private TextBox questionTextBox;
        private NumericUpDown answerNumericUpDown;
        private Label label1;
        private Label label2;
        private Button addButton;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn QuestionText;
        private DataGridViewTextBoxColumn Answer;
    }
}
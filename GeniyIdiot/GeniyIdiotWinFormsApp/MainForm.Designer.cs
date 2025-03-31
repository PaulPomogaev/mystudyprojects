namespace GeniyIdiotWinFormsApp
{
    partial class mainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            nextButton = new Button();
            questionNumberLabel = new Label();
            questionTextLabel = new Label();
            userAnswerTextBox = new TextBox();
            fileToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem1 = new ToolStripMenuItem();
            restartToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            resultsToolStripMenuItem = new ToolStripMenuItem();
            showHistoryToolStripMenuItem = new ToolStripMenuItem();
            manageQuestionsToolStripMenuItem = new ToolStripMenuItem();
            questionTimer = new System.Windows.Forms.Timer(components);
            timeProgressBar = new ProgressBar();
            timerLabel = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // nextButton
            // 
            nextButton.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            nextButton.Location = new Point(27, 181);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(285, 127);
            nextButton.TabIndex = 0;
            nextButton.Text = "Далее";
            nextButton.UseVisualStyleBackColor = true;
            nextButton.Click += nextButton_Click;
            // 
            // questionNumberLabel
            // 
            questionNumberLabel.AutoSize = true;
            questionNumberLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            questionNumberLabel.Location = new Point(27, 51);
            questionNumberLabel.Name = "questionNumberLabel";
            questionNumberLabel.Size = new Size(100, 21);
            questionNumberLabel.TabIndex = 1;
            questionNumberLabel.Text = "Вопрос №1";
            // 
            // questionTextLabel
            // 
            questionTextLabel.AutoSize = true;
            questionTextLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            questionTextLabel.Location = new Point(27, 82);
            questionTextLabel.Name = "questionTextLabel";
            questionTextLabel.Size = new Size(143, 25);
            questionTextLabel.TabIndex = 2;
            questionTextLabel.Text = "Текст вопроса";
            // 
            // userAnswerTextBox
            // 
            userAnswerTextBox.Location = new Point(27, 122);
            userAnswerTextBox.Name = "userAnswerTextBox";
            userAnswerTextBox.Size = new Size(403, 23);
            userAnswerTextBox.TabIndex = 3;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(32, 19);
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem1, resultsToolStripMenuItem, manageQuestionsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(627, 24);
            menuStrip1.TabIndex = 7;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            fileToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { restartToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            fileToolStripMenuItem1.Size = new Size(48, 20);
            fileToolStripMenuItem1.Text = "Файл";
            // 
            // restartToolStripMenuItem
            // 
            restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            restartToolStripMenuItem.Size = new Size(155, 22);
            restartToolStripMenuItem.Text = "Перезапустить";
            restartToolStripMenuItem.Click += restartToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(155, 22);
            exitToolStripMenuItem.Text = "Выход";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // resultsToolStripMenuItem
            // 
            resultsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { showHistoryToolStripMenuItem });
            resultsToolStripMenuItem.Name = "resultsToolStripMenuItem";
            resultsToolStripMenuItem.Size = new Size(81, 20);
            resultsToolStripMenuItem.Text = "Результаты";
            // 
            // showHistoryToolStripMenuItem
            // 
            showHistoryToolStripMenuItem.Name = "showHistoryToolStripMenuItem";
            showHistoryToolStripMenuItem.Size = new Size(176, 22);
            showHistoryToolStripMenuItem.Text = "Показать историю";
            showHistoryToolStripMenuItem.Click += showHistoryToolStripMenuItem_Click;
            // 
            // manageQuestionsToolStripMenuItem
            // 
            manageQuestionsToolStripMenuItem.Name = "manageQuestionsToolStripMenuItem";
            manageQuestionsToolStripMenuItem.Size = new Size(150, 20);
            manageQuestionsToolStripMenuItem.Text = "Управление вопросами";
            manageQuestionsToolStripMenuItem.Click += manageQuestionsToolStripMenuItem_Click;
            // 
            // questionTimer
            // 
            questionTimer.Interval = 1000;
            questionTimer.Tick += questionTimer_Tick;
            // 
            // timeProgressBar
            // 
            timeProgressBar.Location = new Point(27, 334);
            timeProgressBar.Name = "timeProgressBar";
            timeProgressBar.Size = new Size(574, 12);
            timeProgressBar.TabIndex = 8;
            timeProgressBar.Value = 100;
            // 
            // timerLabel
            // 
            timerLabel.AutoSize = true;
            timerLabel.Location = new Point(536, 298);
            timerLabel.Name = "timerLabel";
            timerLabel.Size = new Size(40, 15);
            timerLabel.TabIndex = 9;
            timerLabel.Text = "10 сек";
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(627, 357);
            Controls.Add(timerLabel);
            Controls.Add(timeProgressBar);
            Controls.Add(userAnswerTextBox);
            Controls.Add(questionTextLabel);
            Controls.Add(questionNumberLabel);
            Controls.Add(nextButton);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "mainForm";
            Text = "Гений Идиот";
            Load += mainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button nextButton;
        private Label questionNumberLabel;
        private Label questionTextLabel;
        private TextBox userAnswerTextBox;
        private ToolStripMenuItem fileToolStripMenuItem;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem1;
        private ToolStripMenuItem restartToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem resultsToolStripMenuItem;
        private ToolStripMenuItem showHistoryToolStripMenuItem;
        private ToolStripMenuItem manageQuestionsToolStripMenuItem;
        private System.Windows.Forms.Timer questionTimer;
        private ProgressBar timeProgressBar;
        private Label timerLabel;
    }
}

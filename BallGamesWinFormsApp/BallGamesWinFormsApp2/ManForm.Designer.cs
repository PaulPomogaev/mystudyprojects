namespace BallGamesWinFormsApp2
{
    partial class ManForm
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
            startButton = new Button();
            labelScore = new Label();
            label1 = new Label();
            clearButton = new Button();
            SuspendLayout();
            // 
            // startButton
            // 
            startButton.Location = new Point(382, 12);
            startButton.Name = "startButton";
            startButton.Size = new Size(112, 23);
            startButton.TabIndex = 0;
            startButton.Text = "Начать игру";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += button2_Click;
            // 
            // labelScore
            // 
            labelScore.AutoSize = true;
            labelScore.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelScore.Location = new Point(53, 26);
            labelScore.Name = "labelScore";
            labelScore.Size = new Size(19, 21);
            labelScore.TabIndex = 1;
            labelScore.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(186, 15);
            label1.TabIndex = 2;
            label1.Text = "Количество пойманых шариков";
            // 
            // clearButton
            // 
            clearButton.Location = new Point(403, 41);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(75, 23);
            clearButton.TabIndex = 3;
            clearButton.Text = "Очистить";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // ManForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(506, 365);
            Controls.Add(clearButton);
            Controls.Add(label1);
            Controls.Add(labelScore);
            Controls.Add(startButton);
            Name = "ManForm";
            Text = "Шарики тормозим мышкой";
            MouseDown += ManForm_MouseDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button startButton;
        private Label labelScore;
        private Label label1;
        private Button clearButton;
    }
}

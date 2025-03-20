namespace GeniyIdiotWinFormsApp
{
    partial class WellcomeForm
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
            label1 = new Label();
            label2 = new Label();
            userNameTextBox = new TextBox();
            startButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(132, 23);
            label1.Name = "label1";
            label1.Size = new Size(257, 25);
            label1.TabIndex = 0;
            label1.Text = "Добро пожаловать в игру";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(132, 83);
            label2.Name = "label2";
            label2.Size = new Size(149, 21);
            label2.TabIndex = 1;
            label2.Text = "Введите своё имя";
            // 
            // userNameTextBox
            // 
            userNameTextBox.Location = new Point(135, 116);
            userNameTextBox.Name = "userNameTextBox";
            userNameTextBox.Size = new Size(217, 23);
            userNameTextBox.TabIndex = 2;
            // 
            // startButton
            // 
            startButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            startButton.Location = new Point(132, 158);
            startButton.Name = "startButton";
            startButton.Size = new Size(229, 51);
            startButton.TabIndex = 3;
            startButton.Text = "Начать тест";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // WellcomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(498, 269);
            Controls.Add(startButton);
            Controls.Add(userNameTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "WellcomeForm";
            Text = "WellcomeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        public TextBox userNameTextBox;
        private Button startButton;
    }
}
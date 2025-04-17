namespace BillyardBallsWinFormsApp
{
    partial class MainForm
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
            leftLabel = new Label();
            rightLabel = new Label();
            topLabel = new Label();
            downLabel = new Label();
            createBallButton = new Button();
            stopButton = new Button();
            topLabel2 = new Label();
            rightLabel2 = new Label();
            downLabel2 = new Label();
            leftLabel2 = new Label();
            SuspendLayout();
            // 
            // leftLabel
            // 
            leftLabel.AutoSize = true;
            leftLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            leftLabel.ForeColor = SystemColors.HotTrack;
            leftLabel.Location = new Point(12, 173);
            leftLabel.Name = "leftLabel";
            leftLabel.Size = new Size(15, 17);
            leftLabel.TabIndex = 0;
            leftLabel.Text = "0";
            // 
            // rightLabel
            // 
            rightLabel.AutoSize = true;
            rightLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            rightLabel.ForeColor = SystemColors.Highlight;
            rightLabel.Location = new Point(628, 173);
            rightLabel.Name = "rightLabel";
            rightLabel.Size = new Size(15, 17);
            rightLabel.TabIndex = 1;
            rightLabel.Text = "0";
            // 
            // topLabel
            // 
            topLabel.AutoSize = true;
            topLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            topLabel.ForeColor = Color.DodgerBlue;
            topLabel.Location = new Point(313, 9);
            topLabel.Name = "topLabel";
            topLabel.Size = new Size(15, 17);
            topLabel.TabIndex = 2;
            topLabel.Text = "0";
            // 
            // downLabel
            // 
            downLabel.AutoSize = true;
            downLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            downLabel.ForeColor = SystemColors.HotTrack;
            downLabel.Location = new Point(313, 333);
            downLabel.Name = "downLabel";
            downLabel.Size = new Size(15, 17);
            downLabel.TabIndex = 3;
            downLabel.Text = "0";
            // 
            // createBallButton
            // 
            createBallButton.Location = new Point(557, 12);
            createBallButton.Name = "createBallButton";
            createBallButton.Size = new Size(75, 23);
            createBallButton.TabIndex = 4;
            createBallButton.Text = "Шарики";
            createBallButton.UseVisualStyleBackColor = true;
            createBallButton.Click += createBallButton_Click;
            // 
            // stopButton
            // 
            stopButton.Location = new Point(557, 41);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(75, 23);
            stopButton.TabIndex = 5;
            stopButton.Text = "Стоп";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // topLabel2
            // 
            topLabel2.AutoSize = true;
            topLabel2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            topLabel2.ForeColor = Color.Red;
            topLabel2.Location = new Point(334, 9);
            topLabel2.Name = "topLabel2";
            topLabel2.Size = new Size(15, 17);
            topLabel2.TabIndex = 6;
            topLabel2.Text = "0";
           
            // 
            // rightLabel2
            // 
            rightLabel2.AutoSize = true;
            rightLabel2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            rightLabel2.ForeColor = Color.Red;
            rightLabel2.Location = new Point(628, 201);
            rightLabel2.Name = "rightLabel2";
            rightLabel2.Size = new Size(15, 17);
            rightLabel2.TabIndex = 7;
            rightLabel2.Text = "0";
            // 
            // downLabel2
            // 
            downLabel2.AutoSize = true;
            downLabel2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            downLabel2.ForeColor = Color.Red;
            downLabel2.Location = new Point(334, 333);
            downLabel2.Name = "downLabel2";
            downLabel2.Size = new Size(15, 17);
            downLabel2.TabIndex = 8;
            downLabel2.Text = "0";
            // 
            // leftLabel2
            // 
            leftLabel2.AutoSize = true;
            leftLabel2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            leftLabel2.ForeColor = Color.Red;
            leftLabel2.Location = new Point(12, 201);
            leftLabel2.Name = "leftLabel2";
            leftLabel2.Size = new Size(15, 17);
            leftLabel2.TabIndex = 9;
            leftLabel2.Text = "0";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(655, 359);
            Controls.Add(leftLabel2);
            Controls.Add(downLabel2);
            Controls.Add(rightLabel2);
            Controls.Add(topLabel2);
            Controls.Add(stopButton);
            Controls.Add(createBallButton);
            Controls.Add(downLabel);
            Controls.Add(topLabel);
            Controls.Add(rightLabel);
            Controls.Add(leftLabel);
            Name = "MainForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label leftLabel;
        private Label rightLabel;
        private Label topLabel;
        private Label downLabel;
        private Button createBallButton;
        private Button stopButton;
        private Label topLabel2;
        private Label rightLabel2;
        private Label downLabel2;
        private Label leftLabel2;
    }
}

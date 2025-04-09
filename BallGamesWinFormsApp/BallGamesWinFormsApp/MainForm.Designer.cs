namespace BallGamesWinFormsApp
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
            components = new System.ComponentModel.Container();
            stopBallsButton = new Button();
            timer = new System.Windows.Forms.Timer(components);
            createBallsbutton = new Button();
            SuspendLayout();
            // 
            // stopBallsButton
            // 
            stopBallsButton.Location = new Point(546, 41);
            stopBallsButton.Name = "stopBallsButton";
            stopBallsButton.Size = new Size(140, 23);
            stopBallsButton.TabIndex = 2;
            stopBallsButton.Text = "Остановка";
            stopBallsButton.UseVisualStyleBackColor = true;
            stopBallsButton.Click += button3_Click;
            // 
            // timer
            // 
            timer.Interval = 15;
            timer.Tick += timer_Tick;
            // 
            // createBallsbutton
            // 
            createBallsbutton.Location = new Point(400, 41);
            createBallsbutton.Name = "createBallsbutton";
            createBallsbutton.Size = new Size(140, 23);
            createBallsbutton.TabIndex = 3;
            createBallsbutton.Text = "Создать";
            createBallsbutton.UseVisualStyleBackColor = true;
            createBallsbutton.Click += button4_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(698, 370);
            Controls.Add(createBallsbutton);
            Controls.Add(stopBallsButton);
            Name = "MainForm";
            Text = "Мячики";
            MouseDown += MainForm_MouseDown;
            ResumeLayout(false);
        }

        #endregion
        private Button stopBallsButton;
        private System.Windows.Forms.Timer timer;
        private Button createBallsbutton;
    }
}

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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            timer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(546, 12);
            button1.Name = "button1";
            button1.Size = new Size(140, 23);
            button1.TabIndex = 0;
            button1.Text = "Двигать шарик ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(360, 12);
            button2.Name = "button2";
            button2.Size = new Size(180, 23);
            button2.TabIndex = 1;
            button2.Text = "Рисовать случайный шарик";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(546, 41);
            button3.Name = "button3";
            button3.Size = new Size(140, 23);
            button3.TabIndex = 2;
            button3.Text = "Двигать шарик ";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // timer
            // 
            timer.Interval = 15;
            timer.Tick += timer_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(698, 370);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "MainForm";
            Text = "Мячики";
            MouseDown += MainForm_MouseDown;
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private System.Windows.Forms.Timer timer;
    }
}

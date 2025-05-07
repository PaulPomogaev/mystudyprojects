namespace FrogWinFormsApp
{
    partial class WinForm
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
            pictureBox1 = new PictureBox();
            messageLabel = new Label();
            yesButton = new Button();
            noButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.frog;
            pictureBox1.Location = new Point(0, -2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(249, 225);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // messageLabel
            // 
            messageLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            messageLabel.Location = new Point(0, 226);
            messageLabel.Name = "messageLabel";
            messageLabel.Size = new Size(249, 53);
            messageLabel.TabIndex = 1;
            messageLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // yesButton
            // 
            yesButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            yesButton.Location = new Point(0, 282);
            yesButton.Name = "yesButton";
            yesButton.Size = new Size(123, 23);
            yesButton.TabIndex = 2;
            yesButton.Text = "Да";
            yesButton.UseVisualStyleBackColor = true;
            yesButton.Click += yesButton_Click_1;
            // 
            // noButton
            // 
            noButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            noButton.Location = new Point(121, 282);
            noButton.Name = "noButton";
            noButton.Size = new Size(128, 23);
            noButton.TabIndex = 4;
            noButton.Text = "Нет";
            noButton.UseVisualStyleBackColor = true;
            noButton.Click += noButton_Click_1;
            // 
            // WinForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(248, 305);
            Controls.Add(noButton);
            Controls.Add(yesButton);
            Controls.Add(messageLabel);
            Controls.Add(pictureBox1);
            Name = "WinForm";
            Text = "WinForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Label messageLabel;
        private Button yesButton;
        private Button noButton;
    }
}
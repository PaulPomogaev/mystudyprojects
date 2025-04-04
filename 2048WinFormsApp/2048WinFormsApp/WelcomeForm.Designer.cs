namespace _2048WinFormsApp
{
    partial class WelcomeForm
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
            txtName = new TextBox();
            btnStart = new Button();
            label2 = new Label();
            radio4x4 = new RadioButton();
            radio5x5 = new RadioButton();
            radio6x6 = new RadioButton();
            radio7x7 = new RadioButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(127, 9);
            label1.Name = "label1";
            label1.Size = new Size(188, 25);
            label1.TabIndex = 0;
            label1.Text = "Введите ваше имя:";
            // 
            // txtName
            // 
            txtName.Location = new Point(127, 37);
            txtName.Name = "txtName";
            txtName.Size = new Size(188, 23);
            txtName.TabIndex = 1;
            // 
            // btnStart
            // 
            btnStart.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnStart.Location = new Point(137, 180);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(166, 37);
            btnStart.TabIndex = 2;
            btnStart.Text = "Начать игру";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(109, 83);
            label2.Name = "label2";
            label2.Size = new Size(233, 25);
            label2.TabIndex = 3;
            label2.Text = "Выберите размер поля:";
            // 
            // radio4x4
            // 
            radio4x4.AutoSize = true;
            radio4x4.Checked = true;
            radio4x4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            radio4x4.Location = new Point(102, 125);
            radio4x4.Name = "radio4x4";
            radio4x4.Size = new Size(46, 19);
            radio4x4.TabIndex = 4;
            radio4x4.TabStop = true;
            radio4x4.Text = "4x4";
            radio4x4.UseVisualStyleBackColor = true;
            // 
            // radio5x5
            // 
            radio5x5.AutoSize = true;
            radio5x5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            radio5x5.Location = new Point(291, 125);
            radio5x5.Name = "radio5x5";
            radio5x5.Size = new Size(46, 19);
            radio5x5.TabIndex = 5;
            radio5x5.Text = "5x5";
            radio5x5.UseVisualStyleBackColor = true;
            // 
            // radio6x6
            // 
            radio6x6.AutoSize = true;
            radio6x6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            radio6x6.Location = new Point(102, 155);
            radio6x6.Name = "radio6x6";
            radio6x6.Size = new Size(46, 19);
            radio6x6.TabIndex = 6;
            radio6x6.Text = "6x6";
            radio6x6.UseVisualStyleBackColor = true;
            // 
            // radio7x7
            // 
            radio7x7.AutoSize = true;
            radio7x7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            radio7x7.Location = new Point(291, 155);
            radio7x7.Name = "radio7x7";
            radio7x7.Size = new Size(46, 19);
            radio7x7.TabIndex = 7;
            radio7x7.Text = "7x7";
            radio7x7.UseVisualStyleBackColor = true;
            // 
            // WelcomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(457, 229);
            Controls.Add(radio7x7);
            Controls.Add(radio6x6);
            Controls.Add(radio5x5);
            Controls.Add(radio4x4);
            Controls.Add(label2);
            Controls.Add(btnStart);
            Controls.Add(txtName);
            Controls.Add(label1);
            Name = "WelcomeForm";
            Text = "WelcomeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtName;
        private Button btnStart;
        private Label label2;
        private RadioButton radio4x4;
        private RadioButton radio5x5;
        private RadioButton radio6x6;
        private RadioButton radio7x7;
    }
}
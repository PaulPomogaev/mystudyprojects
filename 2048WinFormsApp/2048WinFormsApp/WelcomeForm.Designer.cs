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
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(127, 24);
            label1.Name = "label1";
            label1.Size = new Size(188, 25);
            label1.TabIndex = 0;
            label1.Text = "Введите ваше имя:";
            // 
            // txtName
            // 
            txtName.Location = new Point(127, 79);
            txtName.Name = "txtName";
            txtName.Size = new Size(188, 23);
            txtName.TabIndex = 1;
            // 
            // btnStart
            // 
            btnStart.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnStart.Location = new Point(139, 122);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(166, 37);
            btnStart.TabIndex = 2;
            btnStart.Text = "Начать игру";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click_1;
            // 
            // WelcomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(457, 229);
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
    }
}
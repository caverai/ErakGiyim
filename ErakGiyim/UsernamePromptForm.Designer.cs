namespace ErakGiyim
{
    partial class UsernamePromptForm
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
            UsernameTextBox = new TextBox();
            UsernameLabel = new Label();
            OkButton = new Button();
            PasswordLabel = new Label();
            PasswordTextBox = new TextBox();
            SuspendLayout();
            // 
            // UsernameTextBox
            // 
            UsernameTextBox.Location = new Point(81, 12);
            UsernameTextBox.Name = "UsernameTextBox";
            UsernameTextBox.Size = new Size(177, 23);
            UsernameTextBox.TabIndex = 0;
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Location = new Point(12, 15);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(63, 15);
            UsernameLabel.TabIndex = 1;
            UsernameLabel.Text = "Username:";
            // 
            // OkButton
            // 
            OkButton.Location = new Point(12, 91);
            OkButton.Name = "OkButton";
            OkButton.Size = new Size(120, 35);
            OkButton.TabIndex = 2;
            OkButton.Text = "OK";
            OkButton.UseVisualStyleBackColor = true;
            OkButton.Click += OkButton_Click;
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Location = new Point(12, 44);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(60, 15);
            PasswordLabel.TabIndex = 4;
            PasswordLabel.Text = "Password:";
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(81, 41);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(177, 23);
            PasswordTextBox.TabIndex = 5;
            // 
            // UsernamePromptForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(272, 137);
            Controls.Add(PasswordTextBox);
            Controls.Add(PasswordLabel);
            Controls.Add(OkButton);
            Controls.Add(UsernameLabel);
            Controls.Add(UsernameTextBox);
            Name = "UsernamePromptForm";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public TextBox UsernameTextBox;
        private Label UsernameLabel;
        private Button OkButton;
        private Label PasswordLabel;
        public TextBox PasswordTextBox;
    }
}
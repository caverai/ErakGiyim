namespace ErakGiyim
{
    partial class CreateCustomerForm
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
            CustomerNameLabel = new Label();
            CustomerNameTextBox = new TextBox();
            EmailTextBox = new TextBox();
            PhoneNumberTextBox = new TextBox();
            CountryTextBox = new TextBox();
            CityTextBox = new TextBox();
            AddressTextBox = new TextBox();
            EmailLabel = new Label();
            PhoneNumberLabel = new Label();
            AddressLabel = new Label();
            CityLabel = new Label();
            CountryLabel = new Label();
            AddButton = new Button();
            CancelButton = new Button();
            SuspendLayout();
            // 
            // CustomerNameLabel
            // 
            CustomerNameLabel.AutoSize = true;
            CustomerNameLabel.Location = new Point(12, 12);
            CustomerNameLabel.Name = "CustomerNameLabel";
            CustomerNameLabel.Size = new Size(94, 15);
            CustomerNameLabel.TabIndex = 0;
            CustomerNameLabel.Text = "Customer Name";
            // 
            // CustomerNameTextBox
            // 
            CustomerNameTextBox.Location = new Point(112, 9);
            CustomerNameTextBox.Name = "CustomerNameTextBox";
            CustomerNameTextBox.Size = new Size(225, 23);
            CustomerNameTextBox.TabIndex = 1;
            // 
            // EmailTextBox
            // 
            EmailTextBox.Location = new Point(112, 38);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(225, 23);
            EmailTextBox.TabIndex = 2;
            // 
            // PhoneNumberTextBox
            // 
            PhoneNumberTextBox.Location = new Point(112, 67);
            PhoneNumberTextBox.Name = "PhoneNumberTextBox";
            PhoneNumberTextBox.Size = new Size(225, 23);
            PhoneNumberTextBox.TabIndex = 3;
            // 
            // CountryTextBox
            // 
            CountryTextBox.Location = new Point(112, 154);
            CountryTextBox.Name = "CountryTextBox";
            CountryTextBox.Size = new Size(225, 23);
            CountryTextBox.TabIndex = 6;
            // 
            // CityTextBox
            // 
            CityTextBox.Location = new Point(112, 125);
            CityTextBox.Name = "CityTextBox";
            CityTextBox.Size = new Size(225, 23);
            CityTextBox.TabIndex = 5;
            // 
            // AddressTextBox
            // 
            AddressTextBox.Location = new Point(112, 96);
            AddressTextBox.Name = "AddressTextBox";
            AddressTextBox.Size = new Size(225, 23);
            AddressTextBox.TabIndex = 4;
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Location = new Point(12, 41);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(41, 15);
            EmailLabel.TabIndex = 7;
            EmailLabel.Text = "E-Mail";
            // 
            // PhoneNumberLabel
            // 
            PhoneNumberLabel.AutoSize = true;
            PhoneNumberLabel.Location = new Point(14, 70);
            PhoneNumberLabel.Name = "PhoneNumberLabel";
            PhoneNumberLabel.Size = new Size(88, 15);
            PhoneNumberLabel.TabIndex = 8;
            PhoneNumberLabel.Text = "Phone Number";
            // 
            // AddressLabel
            // 
            AddressLabel.AutoSize = true;
            AddressLabel.Location = new Point(14, 99);
            AddressLabel.Name = "AddressLabel";
            AddressLabel.Size = new Size(49, 15);
            AddressLabel.TabIndex = 9;
            AddressLabel.Text = "Address";
            // 
            // CityLabel
            // 
            CityLabel.AutoSize = true;
            CityLabel.Location = new Point(14, 128);
            CityLabel.Name = "CityLabel";
            CityLabel.Size = new Size(28, 15);
            CityLabel.TabIndex = 10;
            CityLabel.Text = "City";
            // 
            // CountryLabel
            // 
            CountryLabel.AutoSize = true;
            CountryLabel.Location = new Point(14, 157);
            CountryLabel.Name = "CountryLabel";
            CountryLabel.Size = new Size(50, 15);
            CountryLabel.TabIndex = 11;
            CountryLabel.Text = "Country";
            // 
            // AddButton
            // 
            AddButton.Location = new Point(112, 196);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(106, 53);
            AddButton.TabIndex = 12;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(224, 196);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(106, 53);
            CancelButton.TabIndex = 13;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // CreateCustomerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 261);
            Controls.Add(CancelButton);
            Controls.Add(AddButton);
            Controls.Add(CountryLabel);
            Controls.Add(CityLabel);
            Controls.Add(AddressLabel);
            Controls.Add(PhoneNumberLabel);
            Controls.Add(EmailLabel);
            Controls.Add(CountryTextBox);
            Controls.Add(CityTextBox);
            Controls.Add(AddressTextBox);
            Controls.Add(PhoneNumberTextBox);
            Controls.Add(EmailTextBox);
            Controls.Add(CustomerNameTextBox);
            Controls.Add(CustomerNameLabel);
            Name = "CreateCustomerForm";
            Text = "Add Customer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CustomerNameLabel;
        private TextBox CustomerNameTextBox;
        private TextBox EmailTextBox;
        private TextBox PhoneNumberTextBox;
        private TextBox CountryTextBox;
        private TextBox CityTextBox;
        private TextBox AddressTextBox;
        private Label EmailLabel;
        private Label PhoneNumberLabel;
        private Label AddressLabel;
        private Label CityLabel;
        private Label CountryLabel;
        private Button AddButton;
        private Button CancelButton;
    }
}
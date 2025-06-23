namespace ErakGiyim
{
    partial class CreateSupplierForm
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
            CountryLabel = new Label();
            CityLabel = new Label();
            AddressLabel = new Label();
            PhoneNumberLabel = new Label();
            EmailLabel = new Label();
            CustomerNameLabel = new Label();
            SupplierNameTextBox = new TextBox();
            EmailTextBox = new TextBox();
            AddressTextBox = new TextBox();
            PhoneNumberTextBox = new TextBox();
            CountryTextBox = new TextBox();
            CityTextBox = new TextBox();
            CancelButton = new Button();
            AddButton = new Button();
            SuspendLayout();
            // 
            // CountryLabel
            // 
            CountryLabel.AutoSize = true;
            CountryLabel.Location = new Point(14, 157);
            CountryLabel.Name = "CountryLabel";
            CountryLabel.Size = new Size(50, 15);
            CountryLabel.TabIndex = 17;
            CountryLabel.Text = "Country";
            // 
            // CityLabel
            // 
            CityLabel.AutoSize = true;
            CityLabel.Location = new Point(14, 128);
            CityLabel.Name = "CityLabel";
            CityLabel.Size = new Size(28, 15);
            CityLabel.TabIndex = 16;
            CityLabel.Text = "City";
            // 
            // AddressLabel
            // 
            AddressLabel.AutoSize = true;
            AddressLabel.Location = new Point(14, 99);
            AddressLabel.Name = "AddressLabel";
            AddressLabel.Size = new Size(49, 15);
            AddressLabel.TabIndex = 15;
            AddressLabel.Text = "Address";
            // 
            // PhoneNumberLabel
            // 
            PhoneNumberLabel.AutoSize = true;
            PhoneNumberLabel.Location = new Point(14, 70);
            PhoneNumberLabel.Name = "PhoneNumberLabel";
            PhoneNumberLabel.Size = new Size(88, 15);
            PhoneNumberLabel.TabIndex = 14;
            PhoneNumberLabel.Text = "Phone Number";
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Location = new Point(12, 41);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(41, 15);
            EmailLabel.TabIndex = 13;
            EmailLabel.Text = "E-Mail";
            // 
            // CustomerNameLabel
            // 
            CustomerNameLabel.AutoSize = true;
            CustomerNameLabel.Location = new Point(12, 12);
            CustomerNameLabel.Name = "CustomerNameLabel";
            CustomerNameLabel.Size = new Size(85, 15);
            CustomerNameLabel.TabIndex = 12;
            CustomerNameLabel.Text = "Supplier Name";
            // 
            // SupplierNameTextBox
            // 
            SupplierNameTextBox.Location = new Point(112, 9);
            SupplierNameTextBox.Name = "SupplierNameTextBox";
            SupplierNameTextBox.Size = new Size(225, 23);
            SupplierNameTextBox.TabIndex = 18;
            // 
            // EmailTextBox
            // 
            EmailTextBox.Location = new Point(112, 38);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(225, 23);
            EmailTextBox.TabIndex = 19;
            // 
            // AddressTextBox
            // 
            AddressTextBox.Location = new Point(112, 96);
            AddressTextBox.Name = "AddressTextBox";
            AddressTextBox.Size = new Size(225, 23);
            AddressTextBox.TabIndex = 21;
            // 
            // PhoneNumberTextBox
            // 
            PhoneNumberTextBox.Location = new Point(112, 67);
            PhoneNumberTextBox.Name = "PhoneNumberTextBox";
            PhoneNumberTextBox.Size = new Size(225, 23);
            PhoneNumberTextBox.TabIndex = 20;
            // 
            // CountryTextBox
            // 
            CountryTextBox.Location = new Point(112, 154);
            CountryTextBox.Name = "CountryTextBox";
            CountryTextBox.Size = new Size(225, 23);
            CountryTextBox.TabIndex = 23;
            // 
            // CityTextBox
            // 
            CityTextBox.Location = new Point(112, 125);
            CityTextBox.Name = "CityTextBox";
            CityTextBox.Size = new Size(225, 23);
            CityTextBox.TabIndex = 22;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(224, 196);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(106, 53);
            CancelButton.TabIndex = 25;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(112, 196);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(106, 53);
            AddButton.TabIndex = 24;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // CreateSupplierForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 261);
            Controls.Add(CancelButton);
            Controls.Add(AddButton);
            Controls.Add(CountryTextBox);
            Controls.Add(CityTextBox);
            Controls.Add(AddressTextBox);
            Controls.Add(PhoneNumberTextBox);
            Controls.Add(EmailTextBox);
            Controls.Add(SupplierNameTextBox);
            Controls.Add(CountryLabel);
            Controls.Add(CityLabel);
            Controls.Add(AddressLabel);
            Controls.Add(PhoneNumberLabel);
            Controls.Add(EmailLabel);
            Controls.Add(CustomerNameLabel);
            Name = "CreateSupplierForm";
            Text = "Add Supplier";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CountryLabel;
        private Label CityLabel;
        private Label AddressLabel;
        private Label PhoneNumberLabel;
        private Label EmailLabel;
        private Label CustomerNameLabel;
        private TextBox SupplierNameTextBox;
        private TextBox EmailTextBox;
        private TextBox AddressTextBox;
        private TextBox PhoneNumberTextBox;
        private TextBox CountryTextBox;
        private TextBox CityTextBox;
        private Button CancelButton;
        private Button AddButton;
    }
}
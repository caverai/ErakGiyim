namespace ErakGiyim
{
    partial class CreateStorageForm
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
            StorageNameTextBox = new TextBox();
            StorageNameLabel = new Label();
            LocationLabel = new Label();
            LocationTextBox = new TextBox();
            CapacityLabel = new Label();
            CapacityTextBox = new TextBox();
            AddButton = new Button();
            CancelButton = new Button();
            SuspendLayout();
            // 
            // StorageNameTextBox
            // 
            StorageNameTextBox.Location = new Point(112, 9);
            StorageNameTextBox.Name = "StorageNameTextBox";
            StorageNameTextBox.Size = new Size(225, 23);
            StorageNameTextBox.TabIndex = 2;
            // 
            // StorageNameLabel
            // 
            StorageNameLabel.AutoSize = true;
            StorageNameLabel.Location = new Point(12, 12);
            StorageNameLabel.Name = "StorageNameLabel";
            StorageNameLabel.Size = new Size(82, 15);
            StorageNameLabel.TabIndex = 3;
            StorageNameLabel.Text = "Storage Name";
            // 
            // LocationLabel
            // 
            LocationLabel.AutoSize = true;
            LocationLabel.Location = new Point(13, 41);
            LocationLabel.Name = "LocationLabel";
            LocationLabel.Size = new Size(53, 15);
            LocationLabel.TabIndex = 5;
            LocationLabel.Text = "Location";
            // 
            // LocationTextBox
            // 
            LocationTextBox.Location = new Point(113, 38);
            LocationTextBox.Name = "LocationTextBox";
            LocationTextBox.Size = new Size(225, 23);
            LocationTextBox.TabIndex = 4;
            // 
            // CapacityLabel
            // 
            CapacityLabel.AutoSize = true;
            CapacityLabel.Location = new Point(13, 70);
            CapacityLabel.Name = "CapacityLabel";
            CapacityLabel.Size = new Size(53, 15);
            CapacityLabel.TabIndex = 7;
            CapacityLabel.Text = "Capacity";
            // 
            // CapacityTextBox
            // 
            CapacityTextBox.Location = new Point(113, 67);
            CapacityTextBox.Name = "CapacityTextBox";
            CapacityTextBox.Size = new Size(225, 23);
            CapacityTextBox.TabIndex = 6;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(113, 96);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(106, 53);
            AddButton.TabIndex = 13;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(225, 96);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(106, 53);
            CancelButton.TabIndex = 14;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // CreateStorageForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 163);
            Controls.Add(CancelButton);
            Controls.Add(AddButton);
            Controls.Add(CapacityLabel);
            Controls.Add(CapacityTextBox);
            Controls.Add(LocationLabel);
            Controls.Add(LocationTextBox);
            Controls.Add(StorageNameLabel);
            Controls.Add(StorageNameTextBox);
            Name = "CreateStorageForm";
            Text = "Add Storage";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox StorageNameTextBox;
        private Label StorageNameLabel;
        private Label LocationLabel;
        private TextBox LocationTextBox;
        private Label CapacityLabel;
        private TextBox CapacityTextBox;
        private Button AddButton;
        private Button CancelButton;
    }
}
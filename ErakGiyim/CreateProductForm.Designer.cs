namespace ErakGiyim
{
    partial class CreateProductForm
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
            CreateButton = new Button();
            CancelButton = new Button();
            ProductNameTextBox = new TextBox();
            ProductNameLabel = new Label();
            PriceLabel = new Label();
            PriceTextBox = new TextBox();
            AmountInStockLabel = new Label();
            AmountInStockTextBox = new TextBox();
            SizeLabel = new Label();
            ColorLabel = new Label();
            SizeComboBox = new ComboBox();
            ColorComboBox = new ComboBox();
            SuspendLayout();
            // 
            // CreateButton
            // 
            CreateButton.Location = new Point(120, 176);
            CreateButton.Name = "CreateButton";
            CreateButton.Size = new Size(106, 53);
            CreateButton.TabIndex = 0;
            CreateButton.Text = "Create";
            CreateButton.UseVisualStyleBackColor = true;
            CreateButton.Click += CreateButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(232, 176);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(106, 53);
            CancelButton.TabIndex = 1;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // ProductNameTextBox
            // 
            ProductNameTextBox.Location = new Point(120, 12);
            ProductNameTextBox.Name = "ProductNameTextBox";
            ProductNameTextBox.Size = new Size(218, 23);
            ProductNameTextBox.TabIndex = 2;
            // 
            // ProductNameLabel
            // 
            ProductNameLabel.AutoSize = true;
            ProductNameLabel.Location = new Point(12, 15);
            ProductNameLabel.Name = "ProductNameLabel";
            ProductNameLabel.Size = new Size(84, 15);
            ProductNameLabel.TabIndex = 3;
            ProductNameLabel.Text = "Product Name";
            // 
            // PriceLabel
            // 
            PriceLabel.AutoSize = true;
            PriceLabel.Location = new Point(12, 44);
            PriceLabel.Name = "PriceLabel";
            PriceLabel.Size = new Size(33, 15);
            PriceLabel.TabIndex = 5;
            PriceLabel.Text = "Price";
            // 
            // PriceTextBox
            // 
            PriceTextBox.Location = new Point(120, 41);
            PriceTextBox.Name = "PriceTextBox";
            PriceTextBox.Size = new Size(218, 23);
            PriceTextBox.TabIndex = 4;
            // 
            // AmountInStockLabel
            // 
            AmountInStockLabel.AutoSize = true;
            AmountInStockLabel.Location = new Point(12, 73);
            AmountInStockLabel.Name = "AmountInStockLabel";
            AmountInStockLabel.Size = new Size(96, 15);
            AmountInStockLabel.TabIndex = 7;
            AmountInStockLabel.Text = "Amount In Stock";
            // 
            // AmountInStockTextBox
            // 
            AmountInStockTextBox.Location = new Point(120, 70);
            AmountInStockTextBox.Name = "AmountInStockTextBox";
            AmountInStockTextBox.Size = new Size(218, 23);
            AmountInStockTextBox.TabIndex = 6;
            // 
            // SizeLabel
            // 
            SizeLabel.AutoSize = true;
            SizeLabel.Location = new Point(12, 102);
            SizeLabel.Name = "SizeLabel";
            SizeLabel.Size = new Size(27, 15);
            SizeLabel.TabIndex = 9;
            SizeLabel.Text = "Size";
            // 
            // ColorLabel
            // 
            ColorLabel.AutoSize = true;
            ColorLabel.Location = new Point(12, 131);
            ColorLabel.Name = "ColorLabel";
            ColorLabel.Size = new Size(36, 15);
            ColorLabel.TabIndex = 11;
            ColorLabel.Text = "Color";
            // 
            // SizeComboBox
            // 
            SizeComboBox.FormattingEnabled = true;
            SizeComboBox.Location = new Point(120, 102);
            SizeComboBox.Name = "SizeComboBox";
            SizeComboBox.Size = new Size(218, 23);
            SizeComboBox.TabIndex = 12;
            // 
            // ColorComboBox
            // 
            ColorComboBox.FormattingEnabled = true;
            ColorComboBox.Location = new Point(120, 131);
            ColorComboBox.Name = "ColorComboBox";
            ColorComboBox.Size = new Size(218, 23);
            ColorComboBox.TabIndex = 13;
            // 
            // CreateProductForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 241);
            Controls.Add(ColorComboBox);
            Controls.Add(SizeComboBox);
            Controls.Add(ColorLabel);
            Controls.Add(SizeLabel);
            Controls.Add(AmountInStockLabel);
            Controls.Add(AmountInStockTextBox);
            Controls.Add(PriceLabel);
            Controls.Add(PriceTextBox);
            Controls.Add(ProductNameLabel);
            Controls.Add(ProductNameTextBox);
            Controls.Add(CancelButton);
            Controls.Add(CreateButton);
            Name = "CreateProductForm";
            Text = "Create Product";
            Load += CreateForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button CreateButton;
        private Button CancelButton;
        private TextBox ProductNameTextBox;
        private Label ProductNameLabel;
        private Label PriceLabel;
        private TextBox PriceTextBox;
        private Label AmountInStockLabel;
        private TextBox AmountInStockTextBox;
        private Label SizeLabel;
        private Label ColorLabel;
        private ComboBox SizeComboBox;
        private ComboBox ColorComboBox;
    }
}
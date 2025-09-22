namespace ErakGiyim
{
    partial class CreateOrderForm
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
            OrderTypeComboBox = new ComboBox();
            OrderTypeLabel = new Label();
            CustomerComboBox = new ComboBox();
            CustomerLabel = new Label();
            SupplierComboBox = new ComboBox();
            SupplierLabel = new Label();
            TotalLabel = new Label();
            TotalAmount = new Label();
            CancelButton = new Button();
            SaveButton = new Button();
            OrderDetailsGridView = new DataGridView();
            OrderDateTextBox = new TextBox();
            OrderDateLabel = new Label();
            PaidCheckBox = new CheckBox();
            StatusLabel = new Label();
            StatusComboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)OrderDetailsGridView).BeginInit();
            SuspendLayout();
            // 
            // OrderTypeComboBox
            // 
            OrderTypeComboBox.FormattingEnabled = true;
            OrderTypeComboBox.Location = new Point(83, 12);
            OrderTypeComboBox.Name = "OrderTypeComboBox";
            OrderTypeComboBox.Size = new Size(121, 23);
            OrderTypeComboBox.TabIndex = 0;
            OrderTypeComboBox.SelectedIndexChanged += OrderTypeComboBox_SelectedIndexChanged;
            // 
            // OrderTypeLabel
            // 
            OrderTypeLabel.AutoSize = true;
            OrderTypeLabel.Location = new Point(12, 15);
            OrderTypeLabel.Name = "OrderTypeLabel";
            OrderTypeLabel.Size = new Size(65, 15);
            OrderTypeLabel.TabIndex = 1;
            OrderTypeLabel.Text = "Order Type";
            // 
            // CustomerComboBox
            // 
            CustomerComboBox.FormattingEnabled = true;
            CustomerComboBox.Location = new Point(83, 41);
            CustomerComboBox.Name = "CustomerComboBox";
            CustomerComboBox.Size = new Size(121, 23);
            CustomerComboBox.TabIndex = 2;
            // 
            // CustomerLabel
            // 
            CustomerLabel.AutoSize = true;
            CustomerLabel.Location = new Point(12, 44);
            CustomerLabel.Name = "CustomerLabel";
            CustomerLabel.Size = new Size(59, 15);
            CustomerLabel.TabIndex = 3;
            CustomerLabel.Text = "Customer";
            // 
            // SupplierComboBox
            // 
            SupplierComboBox.FormattingEnabled = true;
            SupplierComboBox.Location = new Point(83, 70);
            SupplierComboBox.Name = "SupplierComboBox";
            SupplierComboBox.Size = new Size(121, 23);
            SupplierComboBox.TabIndex = 4;
            // 
            // SupplierLabel
            // 
            SupplierLabel.AutoSize = true;
            SupplierLabel.Location = new Point(12, 73);
            SupplierLabel.Name = "SupplierLabel";
            SupplierLabel.Size = new Size(50, 15);
            SupplierLabel.TabIndex = 5;
            SupplierLabel.Text = "Supplier";
            // 
            // TotalLabel
            // 
            TotalLabel.AutoSize = true;
            TotalLabel.Location = new Point(83, 165);
            TotalLabel.Name = "TotalLabel";
            TotalLabel.Size = new Size(36, 15);
            TotalLabel.TabIndex = 6;
            TotalLabel.Text = "Total:";
            // 
            // TotalAmount
            // 
            TotalAmount.AutoSize = true;
            TotalAmount.Location = new Point(119, 165);
            TotalAmount.Name = "TotalAmount";
            TotalAmount.Size = new Size(0, 15);
            TotalAmount.TabIndex = 7;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(109, 196);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(95, 53);
            CancelButton.TabIndex = 9;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += cancelButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(12, 196);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(95, 53);
            SaveButton.TabIndex = 8;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // OrderDetailsGridView
            // 
            OrderDetailsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            OrderDetailsGridView.Location = new Point(210, 11);
            OrderDetailsGridView.Name = "OrderDetailsGridView";
            OrderDetailsGridView.Size = new Size(603, 238);
            OrderDetailsGridView.TabIndex = 10;
            OrderDetailsGridView.CellValueChanged += OrderDetailsGridView_CellValueChanged;
            // 
            // OrderDateTextBox
            // 
            OrderDateTextBox.Location = new Point(83, 99);
            OrderDateTextBox.Name = "OrderDateTextBox";
            OrderDateTextBox.Size = new Size(121, 23);
            OrderDateTextBox.TabIndex = 11;
            // 
            // OrderDateLabel
            // 
            OrderDateLabel.AutoSize = true;
            OrderDateLabel.Location = new Point(12, 102);
            OrderDateLabel.Name = "OrderDateLabel";
            OrderDateLabel.Size = new Size(64, 15);
            OrderDateLabel.TabIndex = 12;
            OrderDateLabel.Text = "Order Date";
            // 
            // PaidCheckBox
            // 
            PaidCheckBox.AutoSize = true;
            PaidCheckBox.CheckAlign = ContentAlignment.MiddleRight;
            PaidCheckBox.Location = new Point(13, 164);
            PaidCheckBox.Name = "PaidCheckBox";
            PaidCheckBox.Size = new Size(49, 19);
            PaidCheckBox.TabIndex = 14;
            PaidCheckBox.Text = "Paid";
            PaidCheckBox.UseVisualStyleBackColor = true;
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.Location = new Point(12, 131);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(39, 15);
            StatusLabel.TabIndex = 15;
            StatusLabel.Text = "Status";
            // 
            // StatusComboBox
            // 
            StatusComboBox.FormattingEnabled = true;
            StatusComboBox.Location = new Point(83, 128);
            StatusComboBox.Name = "StatusComboBox";
            StatusComboBox.Size = new Size(121, 23);
            StatusComboBox.TabIndex = 16;
            // 
            // CreateOrderForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(825, 261);
            Controls.Add(StatusComboBox);
            Controls.Add(StatusLabel);
            Controls.Add(PaidCheckBox);
            Controls.Add(OrderDateLabel);
            Controls.Add(OrderDateTextBox);
            Controls.Add(OrderDetailsGridView);
            Controls.Add(CancelButton);
            Controls.Add(SaveButton);
            Controls.Add(TotalAmount);
            Controls.Add(TotalLabel);
            Controls.Add(SupplierLabel);
            Controls.Add(SupplierComboBox);
            Controls.Add(CustomerLabel);
            Controls.Add(CustomerComboBox);
            Controls.Add(OrderTypeLabel);
            Controls.Add(OrderTypeComboBox);
            Name = "CreateOrderForm";
            Text = "Add Order";
            Load += CreateOrderForm_Load;
            ((System.ComponentModel.ISupportInitialize)OrderDetailsGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox OrderTypeComboBox;
        private Label OrderTypeLabel;
        private ComboBox CustomerComboBox;
        private Label CustomerLabel;
        private ComboBox SupplierComboBox;
        private Label SupplierLabel;
        private Label TotalLabel;
        private Label TotalAmount;
        private Button CancelButton;
        private Button SaveButton;
        private DataGridView OrderDetailsGridView;
        private TextBox OrderDateTextBox;
        private Label OrderDateLabel;
        private CheckBox PaidCheckBox;
        private Label StatusLabel;
        private ComboBox StatusComboBox;
    }
}
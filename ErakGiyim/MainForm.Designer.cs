namespace ErakGiyim
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
            GridView = new DataGridView();
            Create = new Button();
            Update = new Button();
            Delete = new Button();
            Refresh = new Button();
            Exit = new Button();
            TableBox = new ComboBox();
            ViewStorageButton = new Button();
            TotalSaleLabel = new Label();
            TotalPurchaseLabel = new Label();
            TotalPurchaseDisplay = new Label();
            TotalSaleDisplay = new Label();
            UnpaidPurchaseLabel = new Label();
            UnpaidSaleLabel = new Label();
            UnpaidPurchaseDisplay = new Label();
            UnpaidSaleDisplay = new Label();
            ExportButton = new Button();
            CancelOrderButton = new Button();
            ((System.ComponentModel.ISupportInitialize)GridView).BeginInit();
            SuspendLayout();
            // 
            // GridView
            // 
            GridView.AllowUserToOrderColumns = true;
            GridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridView.Location = new Point(159, 12);
            GridView.Name = "GridView";
            GridView.Size = new Size(848, 498);
            GridView.TabIndex = 0;
            GridView.CellValueChanged += GridView_CellValueChanged;
            GridView.ColumnHeaderMouseClick += GridView_ColumnHeaderMouseClick;
            // 
            // Create
            // 
            Create.Location = new Point(12, 216);
            Create.Name = "Create";
            Create.Size = new Size(141, 54);
            Create.TabIndex = 1;
            Create.Text = "Add";
            Create.UseVisualStyleBackColor = true;
            Create.Click += Create_Click;
            // 
            // Update
            // 
            Update.Location = new Point(12, 276);
            Update.Name = "Update";
            Update.Size = new Size(141, 54);
            Update.TabIndex = 2;
            Update.Text = "Update";
            Update.UseVisualStyleBackColor = true;
            Update.Click += Update_Click;
            // 
            // Delete
            // 
            Delete.Location = new Point(12, 336);
            Delete.Name = "Delete";
            Delete.Size = new Size(141, 54);
            Delete.TabIndex = 3;
            Delete.Text = "Delete";
            Delete.UseVisualStyleBackColor = true;
            Delete.Click += Delete_Click;
            // 
            // Refresh
            // 
            Refresh.Location = new Point(12, 396);
            Refresh.Name = "Refresh";
            Refresh.Size = new Size(141, 54);
            Refresh.TabIndex = 4;
            Refresh.Text = "Refresh";
            Refresh.UseVisualStyleBackColor = true;
            Refresh.Click += Refresh_Click;
            // 
            // Exit
            // 
            Exit.Location = new Point(12, 456);
            Exit.Name = "Exit";
            Exit.Size = new Size(141, 54);
            Exit.TabIndex = 5;
            Exit.Text = "Exit";
            Exit.UseVisualStyleBackColor = true;
            Exit.Click += Exit_Click;
            // 
            // TableBox
            // 
            TableBox.FormattingEnabled = true;
            TableBox.Location = new Point(12, 12);
            TableBox.Name = "TableBox";
            TableBox.Size = new Size(141, 23);
            TableBox.TabIndex = 6;
            TableBox.SelectedIndexChanged += TableBox_SelectedIndexChanged;
            // 
            // ViewStorageButton
            // 
            ViewStorageButton.Location = new Point(12, 156);
            ViewStorageButton.Name = "ViewStorageButton";
            ViewStorageButton.Size = new Size(141, 54);
            ViewStorageButton.TabIndex = 7;
            ViewStorageButton.Text = "View Storage";
            ViewStorageButton.UseVisualStyleBackColor = true;
            ViewStorageButton.Click += ViewStorageButton_Click;
            // 
            // TotalSaleLabel
            // 
            TotalSaleLabel.AutoSize = true;
            TotalSaleLabel.Location = new Point(-1, 123);
            TotalSaleLabel.Name = "TotalSaleLabel";
            TotalSaleLabel.Size = new Size(60, 15);
            TotalSaleLabel.TabIndex = 8;
            TotalSaleLabel.Text = "Total Sale:";
            // 
            // TotalPurchaseLabel
            // 
            TotalPurchaseLabel.AutoSize = true;
            TotalPurchaseLabel.Location = new Point(-1, 93);
            TotalPurchaseLabel.Name = "TotalPurchaseLabel";
            TotalPurchaseLabel.Size = new Size(87, 15);
            TotalPurchaseLabel.TabIndex = 9;
            TotalPurchaseLabel.Text = "Total Purchase:";
            // 
            // TotalPurchaseDisplay
            // 
            TotalPurchaseDisplay.AutoSize = true;
            TotalPurchaseDisplay.Location = new Point(86, 93);
            TotalPurchaseDisplay.Name = "TotalPurchaseDisplay";
            TotalPurchaseDisplay.Size = new Size(0, 15);
            TotalPurchaseDisplay.TabIndex = 10;
            // 
            // TotalSaleDisplay
            // 
            TotalSaleDisplay.AutoSize = true;
            TotalSaleDisplay.Location = new Point(59, 123);
            TotalSaleDisplay.Name = "TotalSaleDisplay";
            TotalSaleDisplay.Size = new Size(0, 15);
            TotalSaleDisplay.TabIndex = 11;
            // 
            // UnpaidPurchaseLabel
            // 
            UnpaidPurchaseLabel.AutoSize = true;
            UnpaidPurchaseLabel.Location = new Point(-1, 108);
            UnpaidPurchaseLabel.Name = "UnpaidPurchaseLabel";
            UnpaidPurchaseLabel.Size = new Size(48, 15);
            UnpaidPurchaseLabel.TabIndex = 12;
            UnpaidPurchaseLabel.Text = "Unpaid:";
            // 
            // UnpaidSaleLabel
            // 
            UnpaidSaleLabel.AutoSize = true;
            UnpaidSaleLabel.Location = new Point(-1, 138);
            UnpaidSaleLabel.Name = "UnpaidSaleLabel";
            UnpaidSaleLabel.Size = new Size(48, 15);
            UnpaidSaleLabel.TabIndex = 13;
            UnpaidSaleLabel.Text = "Unpaid:";
            // 
            // UnpaidPurchaseDisplay
            // 
            UnpaidPurchaseDisplay.AutoSize = true;
            UnpaidPurchaseDisplay.Location = new Point(48, 108);
            UnpaidPurchaseDisplay.Name = "UnpaidPurchaseDisplay";
            UnpaidPurchaseDisplay.Size = new Size(0, 15);
            UnpaidPurchaseDisplay.TabIndex = 14;
            // 
            // UnpaidSaleDisplay
            // 
            UnpaidSaleDisplay.AutoSize = true;
            UnpaidSaleDisplay.Location = new Point(48, 138);
            UnpaidSaleDisplay.Name = "UnpaidSaleDisplay";
            UnpaidSaleDisplay.Size = new Size(0, 15);
            UnpaidSaleDisplay.TabIndex = 15;
            // 
            // ExportButton
            // 
            ExportButton.Location = new Point(12, 36);
            ExportButton.Name = "ExportButton";
            ExportButton.Size = new Size(141, 54);
            ExportButton.TabIndex = 16;
            ExportButton.Text = "Export";
            ExportButton.UseVisualStyleBackColor = true;
            ExportButton.Click += ExportButton_Click;
            // 
            // CancelOrderButton
            // 
            CancelOrderButton.Location = new Point(12, 156);
            CancelOrderButton.Name = "CancelOrderButton";
            CancelOrderButton.Size = new Size(141, 54);
            CancelOrderButton.TabIndex = 17;
            CancelOrderButton.Text = "Cancel Order";
            CancelOrderButton.UseVisualStyleBackColor = true;
            CancelOrderButton.Click += CancelOrderButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1019, 522);
            Controls.Add(CancelOrderButton);
            Controls.Add(ExportButton);
            Controls.Add(UnpaidSaleDisplay);
            Controls.Add(UnpaidPurchaseDisplay);
            Controls.Add(UnpaidSaleLabel);
            Controls.Add(UnpaidPurchaseLabel);
            Controls.Add(TotalSaleDisplay);
            Controls.Add(TotalPurchaseDisplay);
            Controls.Add(TotalPurchaseLabel);
            Controls.Add(TotalSaleLabel);
            Controls.Add(ViewStorageButton);
            Controls.Add(TableBox);
            Controls.Add(Exit);
            Controls.Add(Refresh);
            Controls.Add(Delete);
            Controls.Add(Update);
            Controls.Add(Create);
            Controls.Add(GridView);
            Name = "MainForm";
            Text = "Erak Giyim";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)GridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView GridView;
        private Button Create;
        private Button Update;
        private Button Delete;
        private Button Refresh;
        private Button Exit;
        private ComboBox TableBox;
        private Button ViewStorageButton;
        private Label TotalSaleLabel;
        private Label TotalPurchaseLabel;
        private Label TotalPurchaseDisplay;
        private Label TotalSaleDisplay;
        private Label UnpaidPurchaseLabel;
        private Label UnpaidSaleLabel;
        private Label UnpaidPurchaseDisplay;
        private Label UnpaidSaleDisplay;
        private Button ExportButton;
        private Button CancelOrderButton;
    }
}

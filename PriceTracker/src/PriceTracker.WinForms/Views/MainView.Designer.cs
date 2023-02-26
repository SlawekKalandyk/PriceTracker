namespace PriceTracker.WinForms.Views
{
    partial class MainView
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
            MainPanel = new Panel();
            AddProductPanel = new Panel();
            RemoveSelectedProductButton = new Button();
            AddProductButton = new Button();
            AddProductLabel = new Label();
            AddProductTextBox = new TextBox();
            ProductsDataGridView = new DataGridView();
            NameColumn = new DataGridViewTextBoxColumn();
            UrlColumn = new DataGridViewLinkColumn();
            CurrentPriceColumn = new DataGridViewTextBoxColumn();
            LastUpdateTimeColumn = new DataGridViewTextBoxColumn();
            MainPanel.SuspendLayout();
            AddProductPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ProductsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.Controls.Add(AddProductPanel);
            MainPanel.Controls.Add(ProductsDataGridView);
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 0);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(1243, 669);
            MainPanel.TabIndex = 0;
            // 
            // AddProductPanel
            // 
            AddProductPanel.Controls.Add(RemoveSelectedProductButton);
            AddProductPanel.Controls.Add(AddProductButton);
            AddProductPanel.Controls.Add(AddProductLabel);
            AddProductPanel.Controls.Add(AddProductTextBox);
            AddProductPanel.Location = new Point(3, 3);
            AddProductPanel.Name = "AddProductPanel";
            AddProductPanel.Size = new Size(1237, 72);
            AddProductPanel.TabIndex = 1;
            // 
            // RemoveSelectedProductButton
            // 
            RemoveSelectedProductButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            RemoveSelectedProductButton.Location = new Point(1153, 9);
            RemoveSelectedProductButton.Name = "RemoveSelectedProductButton";
            RemoveSelectedProductButton.Size = new Size(75, 23);
            RemoveSelectedProductButton.TabIndex = 4;
            RemoveSelectedProductButton.Text = "Remove";
            RemoveSelectedProductButton.UseVisualStyleBackColor = true;
            RemoveSelectedProductButton.Click += RemoveSelectedProductButton_Click;
            // 
            // AddProductButton
            // 
            AddProductButton.Location = new Point(513, 3);
            AddProductButton.Name = "AddProductButton";
            AddProductButton.Size = new Size(62, 23);
            AddProductButton.TabIndex = 2;
            AddProductButton.Text = "Add";
            AddProductButton.UseVisualStyleBackColor = true;
            AddProductButton.Click += AddProductButton_Click;
            // 
            // AddProductLabel
            // 
            AddProductLabel.AutoSize = true;
            AddProductLabel.Location = new Point(9, 6);
            AddProductLabel.Name = "AddProductLabel";
            AddProductLabel.Size = new Size(109, 15);
            AddProductLabel.TabIndex = 1;
            AddProductLabel.Text = "Add product (URL):";
            // 
            // AddProductTextBox
            // 
            AddProductTextBox.Location = new Point(124, 3);
            AddProductTextBox.Name = "AddProductTextBox";
            AddProductTextBox.Size = new Size(383, 23);
            AddProductTextBox.TabIndex = 0;
            // 
            // ProductsDataGridView
            // 
            ProductsDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ProductsDataGridView.BorderStyle = BorderStyle.None;
            ProductsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ProductsDataGridView.Columns.AddRange(new DataGridViewColumn[] { NameColumn, UrlColumn, CurrentPriceColumn, LastUpdateTimeColumn });
            ProductsDataGridView.Location = new Point(0, 158);
            ProductsDataGridView.Name = "ProductsDataGridView";
            ProductsDataGridView.ReadOnly = true;
            ProductsDataGridView.RowTemplate.Height = 25;
            ProductsDataGridView.Size = new Size(1243, 511);
            ProductsDataGridView.TabIndex = 0;
            ProductsDataGridView.CellContentClick += ProductsDataGridView_CellContentClick;
            ProductsDataGridView.CellMouseDoubleClick += ProductsDataGridView_CellMouseDoubleClick;
            // 
            // NameColumn
            // 
            NameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            NameColumn.HeaderText = "Name";
            NameColumn.Name = "NameColumn";
            NameColumn.ReadOnly = true;
            NameColumn.Width = 64;
            // 
            // UrlColumn
            // 
            UrlColumn.HeaderText = "Url";
            UrlColumn.Name = "UrlColumn";
            UrlColumn.ReadOnly = true;
            UrlColumn.Width = 500;
            // 
            // CurrentPriceColumn
            // 
            CurrentPriceColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            CurrentPriceColumn.HeaderText = "Current price";
            CurrentPriceColumn.Name = "CurrentPriceColumn";
            CurrentPriceColumn.ReadOnly = true;
            CurrentPriceColumn.Width = 93;
            // 
            // LastUpdateTimeColumn
            // 
            LastUpdateTimeColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            LastUpdateTimeColumn.HeaderText = "Last update time";
            LastUpdateTimeColumn.Name = "LastUpdateTimeColumn";
            LastUpdateTimeColumn.ReadOnly = true;
            LastUpdateTimeColumn.Width = 110;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1243, 669);
            Controls.Add(MainPanel);
            Name = "MainView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PriceTracker";
            MainPanel.ResumeLayout(false);
            AddProductPanel.ResumeLayout(false);
            AddProductPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ProductsDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel MainPanel;
        private DataGridView ProductsDataGridView;
        private Panel AddProductPanel;
        private Button AddProductButton;
        private Label AddProductLabel;
        private TextBox AddProductTextBox;
        private Button RemoveSelectedProductButton;
        private DataGridViewTextBoxColumn NameColumn;
        private DataGridViewLinkColumn UrlColumn;
        private DataGridViewTextBoxColumn CurrentPriceColumn;
        private DataGridViewTextBoxColumn LastUpdateTimeColumn;
    }
}
namespace PriceTracker.WinForms
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
            this.MainPanel = new System.Windows.Forms.Panel();
            this.AddProductPanel = new System.Windows.Forms.Panel();
            this.AddProductProgressLabel = new System.Windows.Forms.Label();
            this.AddProductButton = new System.Windows.Forms.Button();
            this.AddProductLabel = new System.Windows.Forms.Label();
            this.AddProductTextBox = new System.Windows.Forms.TextBox();
            this.ProductsDataGridView = new System.Windows.Forms.DataGridView();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UrlColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.CurrentPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RemoveSelectedProductButton = new System.Windows.Forms.Button();
            this.MainPanel.SuspendLayout();
            this.AddProductPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.AddProductPanel);
            this.MainPanel.Controls.Add(this.ProductsDataGridView);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1243, 669);
            this.MainPanel.TabIndex = 0;
            // 
            // AddProductPanel
            // 
            this.AddProductPanel.Controls.Add(this.RemoveSelectedProductButton);
            this.AddProductPanel.Controls.Add(this.AddProductProgressLabel);
            this.AddProductPanel.Controls.Add(this.AddProductButton);
            this.AddProductPanel.Controls.Add(this.AddProductLabel);
            this.AddProductPanel.Controls.Add(this.AddProductTextBox);
            this.AddProductPanel.Location = new System.Drawing.Point(3, 3);
            this.AddProductPanel.Name = "AddProductPanel";
            this.AddProductPanel.Size = new System.Drawing.Size(1237, 72);
            this.AddProductPanel.TabIndex = 1;
            // 
            // AddProductProgressLabel
            // 
            this.AddProductProgressLabel.AutoSize = true;
            this.AddProductProgressLabel.Location = new System.Drawing.Point(513, 29);
            this.AddProductProgressLabel.Name = "AddProductProgressLabel";
            this.AddProductProgressLabel.Size = new System.Drawing.Size(74, 15);
            this.AddProductProgressLabel.TabIndex = 3;
            this.AddProductProgressLabel.Text = "In progress...";
            this.AddProductProgressLabel.Visible = false;
            // 
            // AddProductButton
            // 
            this.AddProductButton.Location = new System.Drawing.Point(513, 3);
            this.AddProductButton.Name = "AddProductButton";
            this.AddProductButton.Size = new System.Drawing.Size(62, 23);
            this.AddProductButton.TabIndex = 2;
            this.AddProductButton.Text = "Add";
            this.AddProductButton.UseVisualStyleBackColor = true;
            this.AddProductButton.Click += new System.EventHandler(this.AddProductButton_Click);
            // 
            // AddProductLabel
            // 
            this.AddProductLabel.AutoSize = true;
            this.AddProductLabel.Location = new System.Drawing.Point(9, 6);
            this.AddProductLabel.Name = "AddProductLabel";
            this.AddProductLabel.Size = new System.Drawing.Size(109, 15);
            this.AddProductLabel.TabIndex = 1;
            this.AddProductLabel.Text = "Add product (URL):";
            // 
            // AddProductTextBox
            // 
            this.AddProductTextBox.Location = new System.Drawing.Point(124, 3);
            this.AddProductTextBox.Name = "AddProductTextBox";
            this.AddProductTextBox.Size = new System.Drawing.Size(383, 23);
            this.AddProductTextBox.TabIndex = 0;
            // 
            // ProductsDataGridView
            // 
            this.ProductsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProductsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProductsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColumn,
            this.UrlColumn,
            this.CurrentPriceColumn});
            this.ProductsDataGridView.Location = new System.Drawing.Point(0, 158);
            this.ProductsDataGridView.Name = "ProductsDataGridView";
            this.ProductsDataGridView.RowTemplate.Height = 25;
            this.ProductsDataGridView.Size = new System.Drawing.Size(1243, 511);
            this.ProductsDataGridView.TabIndex = 0;
            this.ProductsDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProductsDataGridView_CellClick);
            // 
            // NameColumn
            // 
            this.NameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.NameColumn.HeaderText = "Name";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.Width = 64;
            // 
            // UrlColumn
            // 
            this.UrlColumn.HeaderText = "Url";
            this.UrlColumn.Name = "UrlColumn";
            this.UrlColumn.Width = 500;
            // 
            // CurrentPriceColumn
            // 
            this.CurrentPriceColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CurrentPriceColumn.HeaderText = "Current price";
            this.CurrentPriceColumn.Name = "CurrentPriceColumn";
            this.CurrentPriceColumn.Width = 101;
            // 
            // RemoveSelectedProductButton
            // 
            this.RemoveSelectedProductButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveSelectedProductButton.Location = new System.Drawing.Point(1153, 9);
            this.RemoveSelectedProductButton.Name = "RemoveSelectedProductButton";
            this.RemoveSelectedProductButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveSelectedProductButton.TabIndex = 4;
            this.RemoveSelectedProductButton.Text = "Remove";
            this.RemoveSelectedProductButton.UseVisualStyleBackColor = true;
            this.RemoveSelectedProductButton.Click += new System.EventHandler(this.RemoveSelectedProductButton_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 669);
            this.Controls.Add(this.MainPanel);
            this.Name = "MainView";
            this.Text = "PriceTracker";
            this.MainPanel.ResumeLayout(false);
            this.AddProductPanel.ResumeLayout(false);
            this.AddProductPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel MainPanel;
        private DataGridView ProductsDataGridView;
        private Panel AddProductPanel;
        private Button AddProductButton;
        private Label AddProductLabel;
        private TextBox AddProductTextBox;
        private Label AddProductProgressLabel;
        private DataGridViewTextBoxColumn NameColumn;
        private DataGridViewLinkColumn UrlColumn;
        private DataGridViewTextBoxColumn CurrentPriceColumn;
        private Button RemoveSelectedProductButton;
    }
}
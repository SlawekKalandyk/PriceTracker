using PriceTracker.WinForms.Controls;

namespace PriceTracker.WinForms.Views
{
    partial class ProductDetailView
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
            ProductDetailsFlowLayoutPanel = new FlowLayoutPanel();
            InformationGroupBox = new GroupBox();
            OpenUrlButton = new Button();
            LastUpdateTimeTextBox = new TextBox();
            LastUpdateTimeLabel = new Label();
            UpdateButton = new Button();
            IsTrackedCheckBox = new CheckBox();
            ShopTextBox = new TextBox();
            ShopLabel = new Label();
            UrlTextBox = new TextBox();
            NameTextBox = new TextBox();
            UrlLabel = new Label();
            NameLabel = new Label();
            PriceGroupBox = new GroupBox();
            DiscountSpin = new CurrencySpin();
            OriginalPriceSpin = new CurrencySpin();
            CurrentPriceSpin = new CurrencySpin();
            ThresholdSpin = new CurrencySpin();
            ThresholdLabel = new Label();
            DiscountLabel = new Label();
            OriginalPriceLabel = new Label();
            CurrentPriceLabel = new Label();
            MainPanel = new Panel();
            AvailabilityLabel = new Label();
            ProductDetailsFlowLayoutPanel.SuspendLayout();
            InformationGroupBox.SuspendLayout();
            PriceGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DiscountSpin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)OriginalPriceSpin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CurrentPriceSpin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ThresholdSpin).BeginInit();
            MainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // ProductDetailsFlowLayoutPanel
            // 
            ProductDetailsFlowLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ProductDetailsFlowLayoutPanel.Controls.Add(InformationGroupBox);
            ProductDetailsFlowLayoutPanel.Controls.Add(PriceGroupBox);
            ProductDetailsFlowLayoutPanel.Location = new Point(0, 0);
            ProductDetailsFlowLayoutPanel.Name = "ProductDetailsFlowLayoutPanel";
            ProductDetailsFlowLayoutPanel.Size = new Size(800, 450);
            ProductDetailsFlowLayoutPanel.TabIndex = 0;
            // 
            // InformationGroupBox
            // 
            InformationGroupBox.Controls.Add(AvailabilityLabel);
            InformationGroupBox.Controls.Add(OpenUrlButton);
            InformationGroupBox.Controls.Add(LastUpdateTimeTextBox);
            InformationGroupBox.Controls.Add(LastUpdateTimeLabel);
            InformationGroupBox.Controls.Add(UpdateButton);
            InformationGroupBox.Controls.Add(IsTrackedCheckBox);
            InformationGroupBox.Controls.Add(ShopTextBox);
            InformationGroupBox.Controls.Add(ShopLabel);
            InformationGroupBox.Controls.Add(UrlTextBox);
            InformationGroupBox.Controls.Add(NameTextBox);
            InformationGroupBox.Controls.Add(UrlLabel);
            InformationGroupBox.Controls.Add(NameLabel);
            InformationGroupBox.Location = new Point(3, 3);
            InformationGroupBox.Name = "InformationGroupBox";
            InformationGroupBox.Size = new Size(794, 128);
            InformationGroupBox.TabIndex = 0;
            InformationGroupBox.TabStop = false;
            InformationGroupBox.Text = "General information";
            // 
            // OpenUrlButton
            // 
            OpenUrlButton.Location = new Point(312, 54);
            OpenUrlButton.Name = "OpenUrlButton";
            OpenUrlButton.Size = new Size(59, 23);
            OpenUrlButton.TabIndex = 10;
            OpenUrlButton.Text = "Open";
            OpenUrlButton.UseVisualStyleBackColor = true;
            OpenUrlButton.Click += OpenUrlButton_Click;
            // 
            // LastUpdateTimeTextBox
            // 
            LastUpdateTimeTextBox.Location = new Point(531, 55);
            LastUpdateTimeTextBox.Name = "LastUpdateTimeTextBox";
            LastUpdateTimeTextBox.ReadOnly = true;
            LastUpdateTimeTextBox.Size = new Size(113, 23);
            LastUpdateTimeTextBox.TabIndex = 9;
            // 
            // LastUpdateTimeLabel
            // 
            LastUpdateTimeLabel.AutoSize = true;
            LastUpdateTimeLabel.Location = new Point(427, 58);
            LastUpdateTimeLabel.Name = "LastUpdateTimeLabel";
            LastUpdateTimeLabel.Size = new Size(98, 15);
            LastUpdateTimeLabel.TabIndex = 8;
            LastUpdateTimeLabel.Text = "Last update time:";
            // 
            // UpdateButton
            // 
            UpdateButton.Location = new Point(650, 55);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(75, 23);
            UpdateButton.TabIndex = 7;
            UpdateButton.Text = "Update";
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // IsTrackedCheckBox
            // 
            IsTrackedCheckBox.AutoSize = true;
            IsTrackedCheckBox.Location = new Point(427, 28);
            IsTrackedCheckBox.Name = "IsTrackedCheckBox";
            IsTrackedCheckBox.Size = new Size(92, 19);
            IsTrackedCheckBox.TabIndex = 6;
            IsTrackedCheckBox.Text = "Auto update";
            IsTrackedCheckBox.UseVisualStyleBackColor = true;
            IsTrackedCheckBox.CheckedChanged += IsTrackedCheckBox_CheckedChanged;
            // 
            // ShopTextBox
            // 
            ShopTextBox.Location = new Point(58, 84);
            ShopTextBox.Name = "ShopTextBox";
            ShopTextBox.ReadOnly = true;
            ShopTextBox.Size = new Size(313, 23);
            ShopTextBox.TabIndex = 5;
            // 
            // ShopLabel
            // 
            ShopLabel.AutoSize = true;
            ShopLabel.Location = new Point(10, 87);
            ShopLabel.Name = "ShopLabel";
            ShopLabel.Size = new Size(37, 15);
            ShopLabel.TabIndex = 4;
            ShopLabel.Text = "Shop:";
            // 
            // UrlTextBox
            // 
            UrlTextBox.Location = new Point(58, 55);
            UrlTextBox.Name = "UrlTextBox";
            UrlTextBox.ReadOnly = true;
            UrlTextBox.Size = new Size(248, 23);
            UrlTextBox.TabIndex = 3;
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(58, 26);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.ReadOnly = true;
            NameTextBox.Size = new Size(313, 23);
            NameTextBox.TabIndex = 2;
            // 
            // UrlLabel
            // 
            UrlLabel.AutoSize = true;
            UrlLabel.Location = new Point(10, 58);
            UrlLabel.Name = "UrlLabel";
            UrlLabel.Size = new Size(25, 15);
            UrlLabel.TabIndex = 1;
            UrlLabel.Text = "Url:";
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(10, 29);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(42, 15);
            NameLabel.TabIndex = 0;
            NameLabel.Text = "Name:";
            // 
            // PriceGroupBox
            // 
            PriceGroupBox.Controls.Add(DiscountSpin);
            PriceGroupBox.Controls.Add(OriginalPriceSpin);
            PriceGroupBox.Controls.Add(CurrentPriceSpin);
            PriceGroupBox.Controls.Add(ThresholdSpin);
            PriceGroupBox.Controls.Add(ThresholdLabel);
            PriceGroupBox.Controls.Add(DiscountLabel);
            PriceGroupBox.Controls.Add(OriginalPriceLabel);
            PriceGroupBox.Controls.Add(CurrentPriceLabel);
            PriceGroupBox.Location = new Point(3, 137);
            PriceGroupBox.Name = "PriceGroupBox";
            PriceGroupBox.Size = new Size(794, 128);
            PriceGroupBox.TabIndex = 1;
            PriceGroupBox.TabStop = false;
            PriceGroupBox.Text = "Price details";
            // 
            // DiscountSpin
            // 
            DiscountSpin.DecimalPlaces = 2;
            DiscountSpin.Location = new Point(97, 81);
            DiscountSpin.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            DiscountSpin.Name = "DiscountSpin";
            DiscountSpin.ReadOnly = true;
            DiscountSpin.Size = new Size(120, 23);
            DiscountSpin.TabIndex = 17;
            DiscountSpin.ThousandsSeparator = true;
            // 
            // OriginalPriceSpin
            // 
            OriginalPriceSpin.DecimalPlaces = 2;
            OriginalPriceSpin.Location = new Point(97, 52);
            OriginalPriceSpin.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            OriginalPriceSpin.Name = "OriginalPriceSpin";
            OriginalPriceSpin.ReadOnly = true;
            OriginalPriceSpin.Size = new Size(120, 23);
            OriginalPriceSpin.TabIndex = 16;
            OriginalPriceSpin.ThousandsSeparator = true;
            // 
            // CurrentPriceSpin
            // 
            CurrentPriceSpin.DecimalPlaces = 2;
            CurrentPriceSpin.Location = new Point(97, 23);
            CurrentPriceSpin.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            CurrentPriceSpin.Name = "CurrentPriceSpin";
            CurrentPriceSpin.ReadOnly = true;
            CurrentPriceSpin.Size = new Size(120, 23);
            CurrentPriceSpin.TabIndex = 15;
            CurrentPriceSpin.ThousandsSeparator = true;
            // 
            // ThresholdSpin
            // 
            ThresholdSpin.DecimalPlaces = 2;
            ThresholdSpin.Location = new Point(559, 23);
            ThresholdSpin.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            ThresholdSpin.Name = "ThresholdSpin";
            ThresholdSpin.Size = new Size(120, 23);
            ThresholdSpin.TabIndex = 14;
            ThresholdSpin.ThousandsSeparator = true;
            ThresholdSpin.ValueChanged += ThresholdSpin_ValueChanged;
            // 
            // ThresholdLabel
            // 
            ThresholdLabel.AutoSize = true;
            ThresholdLabel.Location = new Point(427, 25);
            ThresholdLabel.Name = "ThresholdLabel";
            ThresholdLabel.Size = new Size(126, 15);
            ThresholdLabel.TabIndex = 13;
            ThresholdLabel.Text = "Notification threshold:";
            // 
            // DiscountLabel
            // 
            DiscountLabel.AutoSize = true;
            DiscountLabel.Location = new Point(10, 83);
            DiscountLabel.Name = "DiscountLabel";
            DiscountLabel.Size = new Size(57, 15);
            DiscountLabel.TabIndex = 12;
            DiscountLabel.Text = "Discount:";
            // 
            // OriginalPriceLabel
            // 
            OriginalPriceLabel.AutoSize = true;
            OriginalPriceLabel.Location = new Point(10, 54);
            OriginalPriceLabel.Name = "OriginalPriceLabel";
            OriginalPriceLabel.Size = new Size(81, 15);
            OriginalPriceLabel.TabIndex = 9;
            OriginalPriceLabel.Text = "Original price:";
            // 
            // CurrentPriceLabel
            // 
            CurrentPriceLabel.AutoSize = true;
            CurrentPriceLabel.Location = new Point(10, 25);
            CurrentPriceLabel.Name = "CurrentPriceLabel";
            CurrentPriceLabel.Size = new Size(79, 15);
            CurrentPriceLabel.TabIndex = 8;
            CurrentPriceLabel.Text = "Current Price:";
            // 
            // MainPanel
            // 
            MainPanel.Controls.Add(ProductDetailsFlowLayoutPanel);
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 0);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(800, 450);
            MainPanel.TabIndex = 0;
            // 
            // AvailabilityLabel
            // 
            AvailabilityLabel.AutoSize = true;
            AvailabilityLabel.ForeColor = Color.Green;
            AvailabilityLabel.Location = new Point(427, 87);
            AvailabilityLabel.Name = "AvailabilityLabel";
            AvailabilityLabel.Size = new Size(55, 15);
            AvailabilityLabel.TabIndex = 11;
            AvailabilityLabel.Text = "Available";
            // 
            // ProductDetailView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(MainPanel);
            Name = "ProductDetailView";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Product details";
            ProductDetailsFlowLayoutPanel.ResumeLayout(false);
            InformationGroupBox.ResumeLayout(false);
            InformationGroupBox.PerformLayout();
            PriceGroupBox.ResumeLayout(false);
            PriceGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DiscountSpin).EndInit();
            ((System.ComponentModel.ISupportInitialize)OriginalPriceSpin).EndInit();
            ((System.ComponentModel.ISupportInitialize)CurrentPriceSpin).EndInit();
            ((System.ComponentModel.ISupportInitialize)ThresholdSpin).EndInit();
            MainPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel ProductDetailsFlowLayoutPanel;
        private GroupBox InformationGroupBox;
        private Label NameLabel;
        private Panel MainPanel;
        private TextBox UrlTextBox;
        private TextBox NameTextBox;
        private Label UrlLabel;
        private Label ShopLabel;
        private TextBox ShopTextBox;
        private CheckBox IsTrackedCheckBox;
        private Button UpdateButton;
        private GroupBox PriceGroupBox;
        private Label OriginalPriceLabel;
        private Label CurrentPriceLabel;
        private Label DiscountLabel;
        private TextBox LastUpdateTimeTextBox;
        private Label LastUpdateTimeLabel;
        private CurrencySpin DiscountSpin;
        private CurrencySpin OriginalPriceSpin;
        private CurrencySpin CurrentPriceSpin;
        private CurrencySpin ThresholdSpin;
        private Label ThresholdLabel;
        private Button OpenUrlButton;
        private Label AvailabilityLabel;
    }
}
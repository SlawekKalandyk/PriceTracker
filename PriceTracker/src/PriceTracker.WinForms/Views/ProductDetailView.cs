using MediatR;
using PriceTracker.Api.Features.Commands;
using PriceTracker.Domain.Entities;
using PriceTracker.WinForms.Helpers;

namespace PriceTracker.WinForms.Views
{
    public partial class ProductDetailView : Form
    {
        private readonly IMediator _mediator;
        private readonly bool _initialized = false;

        public ProductDetailView()
        {
            InitializeComponent();
        }

        public ProductDetailView(IMediator mediator, Product product)
        {
            InitializeComponent();
            _mediator = mediator;
            Product = product;

            ConfigureControls();
            LoadProductIntoView(product);
            _initialized = true;
        }

        public Product Product { get; private set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ActiveControl = ProductDetailsFlowLayoutPanel;
        }

        private void ConfigureControls()
        {
            CurrentPriceSpin.Controls[0].Enabled = false;
            OriginalPriceSpin.Controls[0].Enabled = false;
            DiscountSpin.Controls[0].Enabled = false;
        }

        private void LoadProductIntoView(Product product)
        {
            Text = $"{product.Shop.Name} - {product.Name}";
            NameTextBox.Text = product.Name;
            UrlTextBox.Text = product.Url;
            ShopTextBox.Text = product.Shop.Name;
            IsTrackedCheckBox.Checked = product.IsTracked;
            ThresholdSpin.Value = product.PriceNotificationThreshold;
            LastUpdateTimeTextBox.Text = product.LastUpdateTime?.ToString();

            var lastAvailability = Product.LastRecordedAvailability;
            if (lastAvailability != null)
            {
                if (lastAvailability.IsAvailable)
                {
                    AvailabilityLabel.ForeColor = Color.DarkGreen;
                    AvailabilityLabel.Text = "Available";
                }
                else
                {
                    AvailabilityLabel.ForeColor = Color.Red;
                    AvailabilityLabel.Text = "Unavailable";
                }
            }

            var lastPrice = Product.LastRecordedPrice;
            if (lastPrice != null && lastAvailability is { IsAvailable: true })
            {
                CurrentPriceSpin.Value = lastPrice.CurrentPrice;
                OriginalPriceSpin.Value = lastPrice.OriginalPrice;
                DiscountSpin.Value = lastPrice.Discount;
            }
            else
            {
                CurrentPriceSpin.Value = 0m;
                OriginalPriceSpin.Value = 0m;
                DiscountSpin.Value = 0m;
            }
        }

        private async void UpdateButton_Click(object sender, EventArgs e)
        {
            ProductDetailsFlowLayoutPanel.Enabled = false;
            Product = (await _mediator.Send(new UpdateProductCommand(Product))).UpdatedProduct;
            LoadProductIntoView(Product);
            ProductDetailsFlowLayoutPanel.Enabled = true;
        }

        private async void IsTrackedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_initialized)
                await _mediator.Send(new ChangeProductTrackedStateCommand(Product, IsTrackedCheckBox.Checked));
        }

        private void OpenUrlButton_Click(object sender, EventArgs e)
        {
            UrlRunner.Run(UrlTextBox.Text);
        }

        private async void ThresholdSpin_ValueChanged(object sender, EventArgs e)
        {
            if (_initialized)
                await _mediator.Send(new ChangeProductNotificationThresholdCommand(Product, ThresholdSpin.Value));
        }
    }
}

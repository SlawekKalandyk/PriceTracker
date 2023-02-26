using MediatR;
using PriceTracker.Api.Application.Features.Commands;
using PriceTracker.Domain.Entities;
using PriceTracker.WinForms.Helpers;

namespace PriceTracker.WinForms.Views
{
    public partial class ProductDetailView : Form
    {
        private readonly IMediator _mediator;

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
        }

        public Product Product { get; private set; }

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

            var lastPrice = Product.PriceHistory.MaxBy(p => p.TimeStamp);
            if (lastPrice != null)
            {
                CurrentPriceSpin.Value = lastPrice.CurrentPrice;
                OriginalPriceSpin.Value = lastPrice.OriginalPrice;
                DiscountSpin.Value = lastPrice.Discount;
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
            await _mediator.Send(new ChangeProductTrackedStateCommand(Product, IsTrackedCheckBox.Checked));
        }

        private void OpenUrlButton_Click(object sender, EventArgs e)
        {
            UrlRunner.Run(UrlTextBox.Text);
        }
    }
}

using MediatR;
using PriceTracker.Api.Application.Features.Commands;
using PriceTracker.Shared.Application.Common.Interfaces;
using PriceTracker.Shared.Application.Features.Queries;

namespace PriceTracker.WinForms
{
    public partial class MainView : Form
    {
        private readonly IMediator _mediator;
        private readonly IApplicationDbContext _context;

        public MainView(IMediator mediator, IApplicationDbContext context)
        {
            _mediator = mediator;
            _context = context;

            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadTrackedProducts();

        }

        private void LoadTrackedProducts()
        {
            var trackedProducts = _mediator.Send(new GetTrackedProductsQuery()).Result.Products;

            foreach (var product in trackedProducts)
            {
                ProductsDataGridView.Rows.Add(
                    product.Name, 
                    product.Url, 
                    product.PriceHistory.MaxBy(p => p.TimeStamp)?.CurrentPrice
                    );
            }
        }

        private async void AddProductButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AddProductTextBox.Text))
                return;

            AddProductProgressLabel.Visible = true;
            AddProductButton.Enabled = false;
            AddProductTextBox.ReadOnly = true;
            await _mediator.Send(new AddProductCommand
            {
                Url = AddProductTextBox.Text
            }).ContinueWith(_ =>
            {
                AddProductPanel.Invoke(() =>
                {
                    AddProductProgressLabel.Visible = false;
                    AddProductButton.Enabled = true;
                    AddProductTextBox.ReadOnly = false;
                });
            });
        }
    }
}
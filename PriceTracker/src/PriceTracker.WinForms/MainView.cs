using MediatR;
using PriceTracker.Api.Application.Features.Commands;
using PriceTracker.Domain.Entities;
using PriceTracker.Shared.Application.Features.Queries;

namespace PriceTracker.WinForms
{
    public partial class MainView : Form
    {
        private readonly IMediator _mediator;

        public MainView(IMediator mediator)
        {
            _mediator = mediator;

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
                AddProduct(product);
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
            });
            var trackedProducts = await _mediator.Send(new GetTrackedProductsQuery());
            var newProduct = trackedProducts.Products.SingleOrDefault(p => p.Url == AddProductTextBox.Text);
            if (newProduct != null)
            {
                AddProduct(newProduct);
            }

            AddProductProgressLabel.Visible = false;
            AddProductButton.Enabled = true;
            AddProductTextBox.ReadOnly = false;
            AddProductTextBox.Clear();
        }

        private void AddProduct(Product product)
        {
            ProductsDataGridView.Invoke(() =>
            {
                var rowIndex = ProductsDataGridView.Rows.Add(
                    product.Name,
                    product.Url,
                    product.PriceHistory.MaxBy(p => p.TimeStamp)?.CurrentPrice
                );
                var row = ProductsDataGridView.Rows[rowIndex];
                row.Tag = product.Id;
                ProductsDataGridView.Refresh();
            });
        }

        private void ProductsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ProductsDataGridView.Columns.IndexOf(UrlColumn))
            {
                var url = ProductsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                if (url != null)
                {
                    System.Diagnostics.Process.Start("explorer", url);
                }
            }
        }

        private async void RemoveSelectedProductButton_Click(object sender, EventArgs e)
        {
            var removedRowIndexes = new List<int>();
            foreach (DataGridViewCell cell in ProductsDataGridView.SelectedCells)
            {
                if (removedRowIndexes.Contains(cell.RowIndex))
                    continue;
                
                removedRowIndexes.Add(cell.RowIndex);
                var row = ProductsDataGridView.Rows[cell.RowIndex];
                var trackedProducts = await _mediator.Send(new GetTrackedProductsQuery());
                var product = trackedProducts.Products.SingleOrDefault(p => p.Id == (int)row.Tag);
                if (product != null)
                {
                    await _mediator.Send(new RemoveProductCommand
                    {
                        Product = product
                    }).ContinueWith(_ =>
                    {
                        ProductsDataGridView.Invoke(() =>
                        {
                            ProductsDataGridView.Rows.Remove(row);
                            ProductsDataGridView.Refresh();
                        });
                    });
                }
            }
        }
    }
}
using MediatR;
using PriceTracker.Api.Application.Features.Commands;
using PriceTracker.Api.Application.Features.Queries;
using PriceTracker.Domain.Entities;
using PriceTracker.Shared.Application.Features.Queries;
using PriceTracker.WinForms.Helpers;

namespace PriceTracker.WinForms.Views
{
    public partial class MainView : Form
    {
        private readonly IMediator _mediator;

        public MainView(IMediator mediator)
        {
            InitializeComponent();
            _mediator = mediator;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadTrackedProducts();
        }

        private void LoadTrackedProducts()
        {
            var products = _mediator.Send(new GetProductsQuery()).Result.Products;

            foreach (var product in products)
            {
                AddProduct(product);
            }
        }

        private async void AddProductButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AddProductTextBox.Text))
                return;

            AddProductButton.Enabled = false;
            AddProductTextBox.ReadOnly = true;
            var addProductResponse = await _mediator.Send(new AddProductCommand(AddProductTextBox.Text));
            if (addProductResponse.Product != null)
            {
                AddProduct(addProductResponse.Product);
            }

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
                    product.LastRecordedAvailability?.IsAvailable ?? false
                        ? product.LastRecordedPrice?.CurrentPrice
                        : null,
                    product.LastUpdateTime?.ToString()
                );
                var row = ProductsDataGridView.Rows[rowIndex];
                row.Tag = product.Id;
                ProductsDataGridView.Refresh();
            });
        }

        private void ProductsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ProductsDataGridView.Columns.IndexOf(UrlColumn) && e.RowIndex > -1)
            {
                var url = ProductsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                if (url != null)
                {
                    UrlRunner.Run(url);
                }
            }
        }

        private async void RemoveSelectedProductButton_Click(object sender, EventArgs e)
        {
            var removedRowIndexes = new List<int>();
            foreach (DataGridViewCell cell in ProductsDataGridView.SelectedCells)
            {
                if (removedRowIndexes.Contains(cell.RowIndex) || cell.RowIndex < 0)
                    continue;

                removedRowIndexes.Add(cell.RowIndex);
                var row = ProductsDataGridView.Rows[cell.RowIndex];
                if (row.Tag is not int productId) 
                    continue;

                var product = (await _mediator.Send(new GetProductByIdQuery(productId))).Product;
                if (product != null)
                {
                    await _mediator.Send(new RemoveProductCommand(product));
                    ProductsDataGridView.Rows.Remove(row);
                    ProductsDataGridView.Refresh();
                }
            }
        }

        private async void ProductsDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != ProductsDataGridView.Columns.IndexOf(UrlColumn) && e.RowIndex > -1)
            {
                var row = ProductsDataGridView.Rows[e.RowIndex];
                if (row.Tag == null)
                    return;

                var product = (await _mediator.Send(new GetProductByIdQuery((int)row.Tag))).Product;
                if (product == null)
                    return;

                using (var detailView = new ProductDetailView(_mediator, product))
                {
                    detailView.ShowDialog(this);
                    product = detailView.Product;
                }

                UpdateProductRow(product, e.RowIndex);
            }
        }

        private void UpdateProductRow(Product product, int rowIndex)
        {
            ProductsDataGridView.Rows[rowIndex].Cells[NameColumn.Name].Value = product.Name;
            ProductsDataGridView.Rows[rowIndex].Cells[UrlColumn.Name].Value = product.Url;
            ProductsDataGridView.Rows[rowIndex].Cells[CurrentPriceColumn.Name].Value = 
                product.LastRecordedAvailability?.IsAvailable ?? false 
                ? product.LastRecordedPrice?.CurrentPrice
                : null;
            ProductsDataGridView.Rows[rowIndex].Cells[LastUpdateTimeColumn.Name].Value = product.LastUpdateTime?.ToString();
        }
    }
}
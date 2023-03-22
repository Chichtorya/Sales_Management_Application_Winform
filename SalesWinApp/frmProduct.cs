using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesWinApp
{
    public partial class frmProduct : Form
    {
        private ProductRepository _productRepository;
        DataAccess.DbContext dbContext = new DataAccess.DbContext();
        public frmProduct()
        {
            InitializeComponent();
            _productRepository = new ProductRepository(dbContext);
            

            var products = _productRepository.GetProducts();

            dgvProduct.DataSource = products;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var createProductForm = new addProduct();

           
                var productRepository = new ProductRepository(new DataAccess.DbContext());


            if (createProductForm.ShowDialog() == DialogResult.OK)
            {

                dgvProduct.DataSource = productRepository.GetProducts();
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMain form1 = new frmMain();
            form1.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedProduct = dgvProduct.SelectedRows[0].DataBoundItem as Product;

            var confirmResult = MessageBox.Show("Are you sure to delete this product?",
                                             "Confirm Delete!!",
                                             MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                var productRepository = new ProductRepository(new DataAccess.DbContext());

                productRepository.DeleteProduct(selectedProduct.ProductId);

                dgvProduct.DataSource = productRepository.GetProducts();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var selectedProduct = dgvProduct.SelectedRows[0].DataBoundItem as Product;

            var updateProductForm = new updateProduct(selectedProduct);

            if (updateProductForm.ShowDialog() == DialogResult.OK)
            {
                var productRepository = new ProductRepository(new DataAccess.DbContext());

              

                dgvProduct.DataSource = productRepository.GetProducts();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var selectedValue = cbSerachBox.SelectedItem.ToString();
            var searchValue = txtValue.Text.Trim();
         
            IEnumerable<Product> products;

            switch (selectedValue)
            {
                case "ID":
                    if (int.TryParse(searchValue, out var id))
                    {
                        products = _productRepository.SearchProducts(null, id, null, null);
                    }
                    else
                    {
                        MessageBox.Show("Invalid ID value!");
                        return;
                    }
                    break;
                case "ProductName":
                    products = _productRepository.SearchProducts(searchValue, null, null, null);
                    break;
                case "UnitPrice":
                    if (int.TryParse(searchValue, out var unitPrice))
                    {
                        products = _productRepository.SearchProducts(null, null, unitPrice, null);
                    }
                    else
                    {
                        MessageBox.Show("Invalid Unit Price value!");
                        return;
                    }
                    break;
                case "UnitInStock":
                    if (int.TryParse(searchValue, out var unitInStock))
                    {
                        products = _productRepository.SearchProducts(null, null, null, unitInStock);
                    }
                    else
                    {
                        MessageBox.Show("Invalid Unit In Stock value!");
                        return;
                    }
                    break;
                default:
                    MessageBox.Show("Please select a search condition!");
                    return;
            }

            // Display the search results in the DataGridView
            dgvProduct.DataSource = products.ToList();
        }
    }
}

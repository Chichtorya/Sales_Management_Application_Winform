using BusinessObject;
using DataAccess;
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
using System.Xml.Linq;

namespace SalesWinApp
{
    public partial class updateProduct : Form
    {



        public Product SelectedProduct { get; set; }
        public updateProduct(Product selectedProduct)
        
        {
            InitializeComponent();
            SelectedProduct = selectedProduct;

            // Set the form controls to display the selected product's data
            txtName.Text = SelectedProduct.ProductName;
            txtId.Text = SelectedProduct.CategoryId.ToString();
            txtWeight.Text = SelectedProduct.Weight;
            txtPrice.Text = SelectedProduct.UnitPrice.ToString();
            txtStock.Text = SelectedProduct.UnitsInStock.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Product data = new Product
            {
                ProductId= SelectedProduct.ProductId,
                CategoryId = Int32.Parse(txtId.Text),
                ProductName = txtName.Text,
                
                Weight = txtWeight.Text,
                UnitPrice = decimal.Parse(txtPrice.Text),
                UnitsInStock = Int32.Parse(txtStock.Text)
            };
            var pRepository = new ProductRepository(new DataAccess.DbContext());
            ProductDao a = new ProductDao();

                a.UpdateProduct(data);

                this.Tag = data;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
    }


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

namespace SalesWinApp
{
    public partial class addProduct : Form
    {
       

      
        public addProduct()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var pRepository = new ProductRepository(new DataAccess.DbContext());
            Product data = new Product
            {
                ProductName = ProductName.Text,
                CategoryId = Int32.Parse(CategoryId.Text),
                Weight = Weight.Text,
                UnitPrice = decimal.Parse(UnitPrice.Text),
                UnitsInStock = Int32.Parse(UnitInStock.Text)
            };
           


            ProductDao a = new ProductDao();
            
                a.addProduct(data);

           

            this.Tag = data;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

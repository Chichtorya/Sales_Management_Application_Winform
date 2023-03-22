using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SalesWinApp
{
    public partial class HandleOrder : Form
    {
        public int OrderID { get; set; }
        public int MemberId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public int Freight { get; set; }
        public Order SelectedOrder { get; set; }

        public HandleOrder(Order selectedOrder)
        {
            InitializeComponent();
           
            // Set the form controls to display the selected member's data
            
           
            // Set the form controls to display the selected order's data
            txtOrderId.Text = selectedOrder.OrderId.ToString();
            txtMemberId.Text = selectedOrder.MemberId.ToString();
            dtpOrderDate.Text = selectedOrder.OrderDate.ToString("yyyy-MM-dd");
            dtpRequiredDate.Text = selectedOrder.RequiredDate != DateTime.MinValue ? selectedOrder.RequiredDate.ToString("yyyy-MM-dd") : "";
            dtpShippedDate.Text = selectedOrder.ShippedDate != DateTime.MinValue ? selectedOrder.ShippedDate.ToString("yyyy-MM-dd") : "";
            txtFreight.Text = selectedOrder.Freight.ToString();
        }
        
        public HandleOrder()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtOrderId.Text))
            {
                SelectedOrder = new Order
                {
                    OrderId = Int32.Parse(txtOrderId.Text),
                    MemberId = int.Parse(txtMemberId.Text),
                    OrderDate = dtpOrderDate.Value  ,
                    RequiredDate = dtpRequiredDate.Value,
                    ShippedDate =dtpShippedDate.Value,
                    Freight = decimal.Parse(txtFreight.Text)
                };
                var orderRepository = new OrderRepository(new DataAccess.DbContext());


                string mess = orderRepository.UpdateOrder(SelectedOrder);
                MessageBox.Show(mess);

            }
            else
            {
                SelectedOrder = new Order
                {

                    MemberId = int.Parse(txtMemberId.Text),
                    OrderDate = dtpOrderDate.Value,
                    RequiredDate = dtpRequiredDate.Value,
                    ShippedDate = dtpShippedDate.Value,
                    Freight = decimal.Parse(txtFreight.Text)
                };
            }


                this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

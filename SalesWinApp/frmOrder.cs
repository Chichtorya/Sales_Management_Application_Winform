using BusinessObject;
using DataAccess;
using DataAccess.Repository;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design.Behavior;

namespace SalesWinApp
{
    public partial class frmOrder : Form
    {

        private OrderRepository _orderRepository;
        DataAccess.DbContext dbContext = new DataAccess.DbContext();
        public frmOrder()
        {
            InitializeComponent();
            _orderRepository = new OrderRepository(dbContext);


            var order = _orderRepository.GetAllOrders();

            dgvOrder.DataSource = order;
            foreach (var orders in order)
            {
                DateTime? orderDate = orders.OrderDate;
                DateTime? requiredDate = orders.RequiredDate;
                DateTime? shippedDate = orders.ShippedDate;

                // check for DateTime.MinValue and display "not yet"
                string actualOrderDate = orderDate == DateTime.MinValue ? "not yet" : orderDate?.ToString("MM/dd/yyyy");
                string actualRequiredDate = requiredDate == DateTime.MinValue ? "not yet" : requiredDate?.ToString("MM/dd/yyyy");
                string actualShippedDate = shippedDate == DateTime.MinValue ? "not yet" : shippedDate?.ToString("MM/dd/yyyy");

                orders.OrderDate = DateTime.Parse(actualOrderDate);
                orders.RequiredDate = DateTime.Parse(actualRequiredDate);
                orders.ShippedDate = DateTime.Parse(actualShippedDate);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            
            OrderDao od = new OrderDao();
            var orderRepository = new OrderRepository(new DataAccess.DbContext());

            using (var dialog = new HandleOrder())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Order newOrder = dialog.SelectedOrder;
                    od.AddOrder(newOrder);
                }
            }

            dgvOrder.DataSource = orderRepository.GetAllOrders();
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            var selectedOrder = dgvOrder.SelectedRows[0].DataBoundItem as Order;

            var confirmResult = MessageBox.Show("Are you sure to delete this order?",
                                                 "Confirm Delete!!",
                                                 MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                var orderRepository = new OrderRepository(new DataAccess.DbContext());

                orderRepository.DeleteOrder(selectedOrder.OrderId);

                dgvOrder.DataSource = orderRepository.GetAllOrders();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var selectedOrder = dgvOrder.SelectedRows[0].DataBoundItem as Order;
            var orderRepository = new OrderRepository(new DataAccess.DbContext());


            string mess = _orderRepository.UpdateOrder(selectedOrder);
            var updateOrderForm = new HandleOrder(selectedOrder);
            OrderDao a = new();
            if (updateOrderForm.ShowDialog() == DialogResult.OK)
            {
               
                
                dgvOrder.DataSource = orderRepository.GetAllOrders();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {



            this.Close();
            frmMain form1 = new frmMain();
            form1.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            OrderDao odb = new OrderDao();

            var startDate = dtpStart.Value;
            var endDate = dtpEnd.Value;


            var salesByPeriod = odb.GetSalesReport(startDate, endDate);

            // Display the results in a DataGridView control
            dgvOrder.DataSource = salesByPeriod;
           
           
        }
    }
}

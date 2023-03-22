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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmProduct product= new frmProduct();
            product.Show();
        }

        private void btnMember_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMember member = new frmMember();
            member.Show();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmOrder order = new frmOrder();
            order.Show();
        }
    }
}

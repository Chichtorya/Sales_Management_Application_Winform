using DataAccess;
using System;
using System.Windows.Forms;


namespace SalesWinApp
{
    public partial class UserForm : Form
    {
        private readonly OrderDao orderService;

        public BusinessObject.Member AuthenticateMember { get; set; }

        public UserForm(OrderDao orderService)
        {
            InitializeComponent();
            this.orderService = orderService;
        }

        private void UserForm_Load(object sender, EventArgs e)

        {
            txtidUser.Text = AuthenticateMember.MemberId.ToString();
            txtEmailUser.Text = AuthenticateMember.Email;
            txtCity.Text= AuthenticateMember.City;
            txtCompanyName.Text = AuthenticateMember.CompanyName;
            txtCountry.Text = AuthenticateMember.Country;   
            txtPass.Text = AuthenticateMember.Password;
            dgvUserOrder.DataSource = orderService.GetOrderListById(AuthenticateMember.MemberId);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AuthenticateMember.Email = txtEmailUser.Text;
            AuthenticateMember.CompanyName = txtCompanyName.Text;
            AuthenticateMember.City = txtCity.Text;
            AuthenticateMember.Country = txtCountry.Text;
            AuthenticateMember.Password = txtPass.Text;

            // Update the user's information in the database
            MemberDao memberDao = new MemberDao();
            memberDao.UpdateMember(AuthenticateMember);

            // Show a message to the user indicating that their information has been updated
            MessageBox.Show("Your information has been updated.");
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}

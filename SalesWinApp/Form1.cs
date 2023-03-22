using BusinessObject;
using DataAccess;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
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
    public partial class Form1 : Form
    {
        private MemberRepository _memberRepository;
        DataAccess.DbContext dbContext = new DataAccess.DbContext();
        public Form1()
        {
            InitializeComponent();
            _memberRepository = new MemberRepository(dbContext);
        }

        private void btvLogin_Click(object sender, EventArgs e)
        {

            string email = txtEmail.Text;
            string password = txtPass.Text;

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            var defaultAccountConfig = configuration.GetSection("DefaultAccount");
            string defaultEmail = defaultAccountConfig["Email"];
            string defaultPassword = defaultAccountConfig["Password"];

            if (email == defaultEmail && password == defaultPassword)
            {
               
            
                this.Hide();
         
                frmMain userForm = new frmMain();

                userForm.Show();
                }
            else
            {
                BusinessObject.Member member = _memberRepository.Authenticate(email, password);
                if (member == null)
                {

                    MessageBox.Show("Invalid email or password.");
                }
                else
                {
                    this.Hide();
                    OrderDao orderDao = new OrderDao();
                    UserForm userForm = new UserForm(orderDao);

                    userForm.AuthenticateMember = member;
                    userForm.Show();
                }
            }
                

               
                
            
        }

    }
}

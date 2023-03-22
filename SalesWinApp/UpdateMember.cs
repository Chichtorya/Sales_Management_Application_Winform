using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SalesWinApp
{
    public partial class UpdateMember : Form
    {
       
        public Member SelectedMember { get; set; }
        public UpdateMember(Member selectedMember)
        {
            InitializeComponent();
            SelectedMember = selectedMember;

            // Set the form controls to display the selected member's data
            txtEmail.Text = SelectedMember.Email;
            txtCompanyName.Text = SelectedMember.CompanyName;
            txtCity.Text = SelectedMember.City;
            txtCountry.Text = SelectedMember.Country;
            txtPassword.Text = SelectedMember.Password;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var data = new Member
            {MemberId = SelectedMember.MemberId,
                Email = txtEmail.Text,
                CompanyName = txtCompanyName.Text,
                City = txtCity.Text,
                Country = txtCountry.Text,
                Password = txtPassword.Text
            };
            MemberDao a = new MemberDao();
            a.UpdateMember(data);

            this.Tag = data;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

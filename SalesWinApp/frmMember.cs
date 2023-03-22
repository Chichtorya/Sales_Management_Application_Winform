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
    public partial class frmMember : Form
    {
        private MemberRepository _memberRepository;
        DataAccess.DbContext dbContext = new DataAccess.DbContext();
        public frmMember()
        {
            InitializeComponent();
            _memberRepository = new MemberRepository(dbContext);


            var members = _memberRepository.GetMembers();

            dgvMember.DataSource = members;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var createMemberForm = new AddMember();
            var memberRepository = new MemberRepository(new DataAccess.DbContext());
            if (createMemberForm.ShowDialog() == DialogResult.OK)
            {
                dgvMember.DataSource = memberRepository.GetMembers();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedMember = dgvMember.SelectedRows[0].DataBoundItem as Member;

            var confirmResult = MessageBox.Show("Are you sure to delete this member?",
                                             "Confirm Delete!!",
                                             MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                var memberRepository = new MemberRepository(new DataAccess.DbContext());

                memberRepository.DeleteMember(selectedMember.MemberId);

                dgvMember.DataSource = memberRepository.GetMembers();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var selectedMember = dgvMember.SelectedRows[0].DataBoundItem as Member;

            var updateMemberForm = new UpdateMember(selectedMember);

            if (updateMemberForm.ShowDialog() == DialogResult.OK)
            {
                var memberRepository = new MemberRepository(new DataAccess.DbContext());

              

                dgvMember.DataSource = memberRepository.GetMembers();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {



            this.Close();
            frmMain form1 = new frmMain();
            form1.Show();
        }
    }
}

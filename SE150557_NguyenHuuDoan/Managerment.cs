using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SE150557_NguyenHuuDoanRepo.BussinessObject.Models;
using SE150557_NguyenHuuDoanRepo.DataAccess.Repository;

namespace SE150557_NguyenHuuDoan
{
    public partial class Managerment : Form
    {
        public Managerment()
        {
            InitializeComponent();
        }
        BindingSource source;

        ICustomerRepo customerRepo = new CustomerRepo();

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void LoadUserList(IEnumerable<BankAccount> cs)
        {
            try
            {
                txtAccountId.Text = null;
                txtAccountName.Text = null;
                txtBranchName.Text = null;
                txtOpenDate.Text = null;
                txtTypeID.Text = null;
                

                source = new BindingSource();


                source.DataSource = cs.ToList();

                txtAccountId.DataBindings.Clear();
                txtAccountName.DataBindings.Clear();
                txtBranchName.DataBindings.Clear();
                txtOpenDate.DataBindings.Clear();
                txtTypeID.DataBindings.Clear();

                txtAccountId.DataBindings.Add("Text", source, "AccountID");
                txtAccountName.DataBindings.Add("Text", source, "AccountName");
                txtBranchName.DataBindings.Add("Text", source, "BranchName");
                txtOpenDate.DataBindings.Add("Text", source, "OpenDate");
                txtTypeID.DataBindings.Add("Text", source, "OpenDate");

                dgvAccount.DataSource = source;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

        }
    }
}

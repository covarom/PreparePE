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
    public partial class NewForm : Form
    {
        public NewForm()
        {
            InitializeComponent();
        }
        public BankAccount cs { get; set; }
        public bool InsertOrUpdate { get; set; }

        public ICustomerRepo customerRepo = new CustomerRepo();
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
 
                 var BankAccount = new BankAccount()
                {
                    AccountId = txtAccountID.Text,
                    AccountName = txtAccountName.Text,
                    BranchName = txtBranchName.Text,
                    OpenDate = DateTime.Parse(txtOpenDate.Text),
                    TypeId = txtTypeID.Text,
                };   
                if (InsertOrUpdate == false)
                {
                    customerRepo.Add(BankAccount);
                    MessageBox.Show("Thêm khách hàng thành công !!");
                }
                else
                {
                    customerRepo.Update(BankAccount);
                    MessageBox.Show("Cập nhật khách hàng thành công !!");
                }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewForm_Load(object sender, EventArgs e)
        {
            if (InsertOrUpdate == true)//update mode
            {
                txtAccountID.Text = cs.AccountId.ToString();
                txtAccountName.Text = cs.AccountName.ToString();
                txtBranchName.Text = cs.BranchName.ToString();
                txtOpenDate.Text = cs.OpenDate.ToString();
                txtTypeID.Text = cs.TypeId.ToString();
               
            }
        }
    }
}

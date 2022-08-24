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
                txtTypeID.DataBindings.Add("Text", source, "TypeID");


                dgvAccount.DataSource = source;
                if(dgvAccount.Columns["Type"] != null)
                {
                    dgvAccount.Columns["Type"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadUserList(customerRepo.GetAll());
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewForm formInsert = new NewForm()
            {
                Text = " Thêm khách hàng mới",
                InsertOrUpdate = false,
                customerRepo = customerRepo
            };
            if (formInsert.ShowDialog() == DialogResult.OK)
            {
                LoadUserList(customerRepo.GetAll());
                source.Position = source.Position - 1;
            }
            LoadUserList(customerRepo.GetAll());
        }
        public BankAccount getCustomer()
        {
            BankAccount cs = null;
            try
            {

                cs = new BankAccount()
                {
                    AccountId = txtAccountId.Text,
                    AccountName = txtAccountName.Text,
                    BranchName = txtBranchName.Text,
                    OpenDate = DateTime.Parse(txtOpenDate.Text),
                    TypeId = txtTypeID.Text,

                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            return cs;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            NewForm formInsert = new NewForm()
            {
                Text = "Cập nhật thông tin khách hàng",
                InsertOrUpdate = true,
                cs = getCustomer(),
                customerRepo = customerRepo
            };
            if (formInsert.ShowDialog() == DialogResult.OK)
            {
                LoadUserList(customerRepo.GetAll());
                source.Position = source.Position - 1;
            }
            LoadUserList(customerRepo.GetAll());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var cs = getCustomer();
                customerRepo.Delete(cs);
                MessageBox.Show("Xoá thành công !");
                LoadUserList(customerRepo.GetAll());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void Managerment_Load(object sender, EventArgs e)
        {
            LoadUserList(customerRepo.GetAll());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var name = txtSearch.Text;
            if (name == " ")
            {
                MessageBox.Show("Không để trống !");
            }
            else
            {
                LoadUserList(customerRepo.Search(name));
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}

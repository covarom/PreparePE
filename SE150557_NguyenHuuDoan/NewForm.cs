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
        static bool checkCapital(string abc)
        {
            string[] listcheck = new string[10];

            string[] listWord = abc.Split(" ");
            for (int i = 0; i < listWord.Length; i++)
            {
                if (Char.IsUpper(listWord[i], 0))
                {

                    listcheck[i] = "a";
                }
                else
                {
                    listcheck[i] = "b";
                }
            }
            var check = true;
            if (Array.Exists(listcheck, element => element == "b"))
            {
                check = false;
            }
            return check;
        }
        static bool checkYear(DateTime abc)
        {
            Console.WriteLine(abc);
            bool check = false;
           
            if(abc.Year <=2022 && abc.Year >= 2000)
            {
                check = true;
            }
            return check;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtAccountID.Text) || String.IsNullOrEmpty(txtAccountName.Text) 
                || String.IsNullOrEmpty(txtBranchName.Text) || String.IsNullOrEmpty(txtOpenDate.Text)
                || String.IsNullOrEmpty(txtTypeID.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else
            {
                if (checkCapital(txtBranchName.Text))
                {
                  
                    if (checkYear(DateTime.Parse(txtOpenDate.Text)))
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
                    else
                    {
                        MessageBox.Show("Năm nằm trong khoản 2000 tới 2022");
                    }
                }
                else
                {
                    MessageBox.Show("Viết hoa chữ cái đầu của Branch Name !!");
                }
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Extensions.Configuration;
using SE150557_NguyenHuuDoanRepo.BussinessObject.Models;

namespace SE150557_NguyenHuuDoan
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            var strConn = config["ConnectionStrings:BankAccountTypeDB"];
            return strConn;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserId.Text == "" && txtPwd.Text == "")
            {
                MessageBox.Show("Please input UserName && Password !");
            }
            
            else if (txtPwd.Text == "")
            {
                MessageBox.Show("Please input Password !");
            }
            else if (txtUserId.Text == "")
            {
                MessageBox.Show("Please input UserId !");
            }
            else if (txtUserId.Text != "" && txtPwd.Text != "")
            {
                string cs = GetConnectionString();
                using (var db = new BankAccountTypeContext(cs))
                {
                    var user = db.Users.Where(a => a.UserId == txtUserId.Text
                    && a.Password == txtPwd.Text && a.UserRole == 1).FirstOrDefault();
                    if (user == null)
                    {
                        MessageBox.Show("Invalid Username or password !");
                    }
                    else
                    {
                        Managerment mc = new Managerment()
                        {

                        };
                        this.Hide();
                        mc.Show();
                    }
                }
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using System.IO;
using SE150557_NguyenHuuDoanRepo.BussinessObject.Models;


namespace SE150557_NguyenHuuDoanRepo.DataAccess.Repository
{ 
    public class CustomerDAO
    {
        private static CustomerDAO instance = null;
        private static readonly object instanceLock = new object();
        private CustomerDAO() { }
        public string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            var strConn = config["ConnectionStrings:BankAccountTypeDB"];
            return strConn;
        }
        public static CustomerDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CustomerDAO();
                    }
                    return instance;
                }
            }
        }

        ///Get infor
        public IEnumerable<BankAccount> GetAllInfor()
        {
            string cs = GetConnectionString();
            var db = new BankAccountTypeContext(cs);
            var kh = from BankAccount in db.BankAccounts select BankAccount;    
            return kh.ToList();
        }
        ///
        public IEnumerable<BankAccount> Search(string name)
        {
            string cs = GetConnectionString();
            var db = new BankAccountTypeContext(cs);
            var kh = from BankAccount in db.BankAccounts where BankAccount.AccountName.Contains(name) select BankAccount;
            return kh.ToList();
        }

        //New Customer

        public void New(BankAccount kh)
        {
            try
            {
                string cs = GetConnectionString();

                using (var db = new BankAccountTypeContext(cs))
                {
                    db.BankAccounts.Add(kh);
                    db.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void Update(BankAccount kh)
        {
            try
            {
                string cs = GetConnectionString();
                
                using (var db = new BankAccountTypeContext(cs))
                {
                    db.BankAccounts.Update(kh);
                    db.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete(BankAccount kh)
        {
            try
            {
                string cs = GetConnectionString();

                using (var db = new BankAccountTypeContext(cs))
                {
                    var Customer = db.BankAccounts.SingleOrDefault(x => x.AccountId == kh.AccountId);
                    db.BankAccounts.Remove(Customer);
                    db.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

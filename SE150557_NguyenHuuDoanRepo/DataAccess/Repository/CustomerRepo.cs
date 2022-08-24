using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SE150557_NguyenHuuDoanRepo.BussinessObject.Models;

namespace SE150557_NguyenHuuDoanRepo.DataAccess.Repository
{
    public class CustomerRepo:ICustomerRepo
    {
         IEnumerable<BankAccount> ICustomerRepo.GetAll() => CustomerDAO.Instance.GetAllInfor();

        IEnumerable<BankAccount> ICustomerRepo.Search(string name) => CustomerDAO.Instance.Search(name);

        void ICustomerRepo.Add(BankAccount kh) => CustomerDAO.Instance.New(kh);
        void ICustomerRepo.Delete(BankAccount kh) => CustomerDAO.Instance.Delete(kh);

        void ICustomerRepo.Update(BankAccount kh) => CustomerDAO.Instance.Update(kh);
    }
}

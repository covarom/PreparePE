using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SE150557_NguyenHuuDoanRepo.BussinessObject.Models;
namespace SE150557_NguyenHuuDoanRepo.DataAccess.Repository
{
    public interface ICustomerRepo
    {
        IEnumerable<BankAccount> GetAll();

        IEnumerable<BankAccount> Search(string name);
        void Add(BankAccount kh);
        void Update(BankAccount kh);
        void Delete(BankAccount kh);
    }
}

using System;
using System.Collections.Generic;

namespace SE150557_NguyenHuuDoanRepo.BussinessObject.Models
{
    public partial class AccountType
    {
        public AccountType()
        {
            BankAccounts = new HashSet<BankAccount>();
        }

        public string TypeId { get; set; }
        public string TypeName { get; set; }
        public string TypeDesc { get; set; }

        public virtual ICollection<BankAccount> BankAccounts { get; set; }
    }
}

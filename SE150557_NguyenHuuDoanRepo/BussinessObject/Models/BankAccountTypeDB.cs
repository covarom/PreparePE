using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE150557_NguyenHuuDoanRepo.BussinessObject.Models
{
    public partial class BankAccountTypeContext : DbContext
    {
        public BankAccountTypeContext(string connectionString)
        {
            this.Database.SetConnectionString(connectionString);
        }
    }
}


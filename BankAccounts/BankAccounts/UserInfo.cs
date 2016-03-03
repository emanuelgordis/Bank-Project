using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.Entity;

namespace BankAccounts
{
    public class UserInfo
    {

        public string userName { get; set; }
        public string userPassword { get; set; }

        public virtual List<AccountInfo> AccountInfo { get; set; }
    }

    public class AccountInfo
    {
        public double accountBalance { get; set; }

        public virtual UserInfo UserInfo { get; set; }
    }

    public class UserContext : DbContext
    {
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<AccountInfo> AccountInfo { get; set; }
    }


}

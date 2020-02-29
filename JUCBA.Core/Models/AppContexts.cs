using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JUCBA.Core.Models
{
    public class AppContext : DbContext
    {
        public AppContext() : base("name=DefaultConnection")//base("name=NewContext")
        {

        }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleClaim> RoleClaims { get; set; }

        public DbSet<GlCategory> GlCategories { get; set; }

        public System.Data.Entity.DbSet<JUCBA.Core.Models.GlAccount> GlAccounts { get; set; }

        public System.Data.Entity.DbSet<JUCBA.Core.Models.TillToUser> TillToUsers { get; set; }

        public System.Data.Entity.DbSet<JUCBA.Core.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<JUCBA.Core.Models.AccountConfiguration> AccountConfigurations { get; set; }

        public System.Data.Entity.DbSet<JUCBA.Core.Models.CustomerAccount> CustomerAccounts { get; set; }

        public System.Data.Entity.DbSet<JUCBA.Core.Models.GlPosting> GlPostings { get; set; }

        public System.Data.Entity.DbSet<JUCBA.Core.Models.TellerPosting> TellerPostings { get; set; }

        public DbSet<ExpenseIncomeEntry> ExpenseIncomeEntries { get; set; }

        public DbSet<Transaction> Transactions { get; set; }
        //public DbSet<User> Users { get; set; }
    }

   }

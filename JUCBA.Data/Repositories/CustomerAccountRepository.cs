using JUCBA.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JUCBA.Data.Repositories
{
    public class CustomerAccountRepository 
    {
        private AppContext db = new AppContext();

        public bool AnyAccountOfType(AccountType type)
        {
            
            return db.CustomerAccounts.Any(a => a.AccountType == type);
        }
        public CustomerAccount GetByAccountNumber(long actNo)
        {
            return db.CustomerAccounts.Where(a => a.AccountNumber == actNo).SingleOrDefault();

        }
        public List<CustomerAccount> GetByType(AccountType actType)
        {
            return db.CustomerAccounts.Where(a => a.AccountType == actType).ToList();
        }

        public int GetCountByCustomerActType(AccountType actType, int customerId)
        {
            return db.CustomerAccounts.Where(a => a.AccountType == actType && a.Customer.ID == customerId).Count();
        }
    }
}

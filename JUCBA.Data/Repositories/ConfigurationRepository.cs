using JUCBA.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JUCBA.Data.Repositories
{
    public class ConfigurationRepository
    {
        private AppContext db = new AppContext();

        public void Initialize()
        {
            if (db.AccountConfigurations.Count() < 1)    //no configuration yet
            {
                db.AccountConfigurations.Add(new AccountConfiguration() { FinancialDate = DateTime.Now, IsBusinessOpen = false });
                db.SaveChanges();
            }
        }

        public AccountConfiguration GetFirst()
        {
            return db.AccountConfigurations.First();
        }
    }
}

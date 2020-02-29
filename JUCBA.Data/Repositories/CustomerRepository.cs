
using JUCBA.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JUCBA.Data.Repositories
{
    public class CustomerRepository 
    {
        private AppContext db = new AppContext();
        public Customer GetById(string custId)
        {
            return db.Customers.Where(c => c.CustId.ToLower().Equals(custId.ToLower())).FirstOrDefault();
        }

        public List<Customer> GetAll()
        {
            return db.Customers.ToList();
        }
    }
}

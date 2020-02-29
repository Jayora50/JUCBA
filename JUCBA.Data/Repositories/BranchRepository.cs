using JUCBA.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JUCBA.Data.Repositories
{
    public class BranchRepository 
    {

        private AppContext db = new AppContext();

        public Branch GetByName(string name)
        {
            return db.Branches.Where(b => b.Name.ToLower().Equals(name.ToLower())).FirstOrDefault();
        }

        public List<Branch> GetAll()
        {
            return db.Branches.ToList();
        }

    }
}

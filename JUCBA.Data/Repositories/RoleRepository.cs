using JUCBA.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JUCBA.Data.Repositories
{
    public class RoleRepository 
    {
        private AppContext db = new AppContext();

        public Role GetByName(string name)
        {
            return db.Roles.Where(r => r.Name.ToLower().Equals(name.ToLower())).FirstOrDefault();
        }
    }
}

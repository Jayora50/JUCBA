using JUCBA.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JUCBA.Logic
{
    public interface IBranchLogic
    {
        long GetSortCode();
        bool IsBranchNameExists(string name);
    }
}

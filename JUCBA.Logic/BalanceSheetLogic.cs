using JUCBA.Core.Models;
using JUCBA.Core.ViewModels.FinancialReportViewModel;
using JUCBA.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JUCBA.Logic
{
    public class BalanceSheetLogic
    {
        BalanceSheetRepository bsRepo = new BalanceSheetRepository();

        public List<GlAccount> GetAssetAccounts()
        {
            return bsRepo.GetAssetAccounts();
        }

        public List<GlAccount> GetCapitalAccounts()
        {
            return bsRepo.GetCapitalAccounts();
        }

        public List<GlAccount> GetIncomeAccounts()
        {
            return bsRepo.GetIncomeAccounts();
        }

        public List<GlAccount> GetExpenseAccounts()
        {
            return bsRepo.GetExpenseAccounts();
        }
        public List<LiabilityViewModel> GetLiabilityAccounts()
        {
            return bsRepo.GetLiabilityAccounts();
        }
    }
}

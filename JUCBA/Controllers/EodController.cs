using JUCBA.Logic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using JUCBA.Core.Models;
using WebGrease.Css.Extensions;
using AppContext = JUCBA.Core.Models.AppContext;

namespace JUCBA.Controllers
{
    [ClaimsAuthorize("DynamicClaim", "RunEOD")]
    public class EodController : Controller
    {
        EodLogic logic = new EodLogic();

        public ActionResult Index(string message)
        {
            ViewBag.Msg = message;
            return View();
        }

        public ActionResult RunEOD()
        {
            if (logic.isBusinessClosed())
            {
                string result = logic.RunEOD();
                return RedirectToAction("Index", new { message = result });
            }

            return RedirectToAction("Index", new { message = "Cannot Run EOD" });

        }

        public ActionResult OpenOrCloseBusiness()
        {
            try
            {
                if (logic.isBusinessClosed())
                {
                    logic.OpenBusiness();
                    return RedirectToAction("Index", new {message = "Business Opened"});
                }
                else
                {
                    CloseAllBranches();
                    logic.CloseBusiness();

                    return RedirectToAction("Index", new { message = "Business Closed" });
                }
            }
            catch (Exception)
            {
                //ErrorLogger.Log("Message= " + ex.Message + "\nInner Exception= " + ex.InnerException + "\n");
                return PartialView("Error");
            }
        }

        public ActionResult CloseAllBranches()
        {
            // code to close all branches
            using (var db = new AppContext())
            {
                List<Branch> branches = db.Branches.Where(b => b.Status == BranchStatus.Open).ToList();
                branches.ForEach(b => { b.Status = BranchStatus.Closed; });
                db.SaveChanges();
            }

            return RedirectToAction("Index", new {message = "All branches closed, you can now proceed to run EOD"});
        }
    }
}
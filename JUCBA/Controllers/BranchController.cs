using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JUCBA.Core.Models;
using JUCBA.Data.Repositories;
using JUCBA.Logic;
using AppContext = JUCBA.Core.Models.AppContext;

namespace JUCBA.Controllers
{
    [ClaimsAuthorize("DynamicClaim", "BranchMgt")]
    public class BranchController : Controller
    {
        private AppContext db;
        private BranchLogic branchLogic;
        private EodLogic eodLogic;

        public BranchController()
        {
            db = new AppContext();
            branchLogic = new BranchLogic(new BranchRepository());
            eodLogic = new EodLogic();
        }
        public BranchController(AppContext dbParam, IBranchLogic branchLogicParam)
        {
            db = new AppContext();
            branchLogic = new BranchLogic(new BranchRepository());
        }

        // GET: Branch
        public ActionResult Index()
        {
            ViewBag.BusinessIsOpen = !eodLogic.isBusinessClosed();
            return View(db.Branches.ToList());
        }

        // GET: Branch/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch branch = db.Branches.Find(id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        // GET: Branch/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Branch/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Address")] Branch branch)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (branchLogic.IsBranchNameExists(branch.Name))
                    {
                        // use model state for now, change to pop up later
                        ModelState.AddModelError("", "Branch name must be unique");
                        return View(branch);
                    }
                    branch.SortCode = branchLogic.GetSortCode();
                    branch.Status = BranchStatus.Closed;

                    db.Branches.Add(branch);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    // partial view error ?
                    // for now all error to model state and return view model
                    ModelState.AddModelError("", ex.ToString());
                    return View(branch);
                }
                
            }
            ModelState.AddModelError("", "Please enter valid data");
            return View(branch);
        }

        // GET: Branch/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch branch = db.Branches.Find(id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        // POST: Branch/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Address,SortCode,Status")] Branch branch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(branch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(branch);
        }

        public ActionResult OpenOrCloseBranch(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch branch = db.Branches.Find(id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            if (branch.Status == BranchStatus.Closed)
            {
                branch.Status = BranchStatus.Open;
            }
            else
            {
                branch.Status = BranchStatus.Closed;
            }           
            db.Entry(branch).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Branch/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch branch = db.Branches.Find(id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        // POST: Branch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Branch branch = db.Branches.Find(id);
            db.Branches.Remove(branch);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

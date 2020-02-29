using JUCBA.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace JUCBA.Controllers
{
    public class ClaimsController : Controller
    {
        // GET: Claims
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult GetClaims()
        {
            // getting the Identity of the authenticated user using "User.Identity" which returns “ClaimsIdentity”
            var identity = User.Identity as ClaimsIdentity;

            var claims = from c in identity.Claims
                         select new ClaimsViewModel
                         {
                             subject = c.Subject.Name,//unique identifier such as Username
                             type = c.Type,//type of the information contained in the claim.
                             value = c.Value//information about this claim.
                         };

            return View(claims);
        }
    }
}
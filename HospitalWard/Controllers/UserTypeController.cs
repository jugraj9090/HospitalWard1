using HospitalWard.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalWard.Controllers
{
    public class UserTypeController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        // GET: AspNeRoles
        public ActionResult ListUserType()
        {
            var list = _db.Roles.ToList();
            return View(list);
        }

        public ActionResult CreateUserType()
        {
            var userType = new IdentityRole();
            return View(userType);
        }

        [HttpPost]
        public ActionResult CreateUserType(IdentityRole identityRole)
        {
            _db.Roles.Add(identityRole);
            _db.SaveChanges();
            return RedirectToAction("ListUserType");
        }
    }
}
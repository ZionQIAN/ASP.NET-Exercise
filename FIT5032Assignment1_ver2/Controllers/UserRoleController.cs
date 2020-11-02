using FIT5032Assignment1_ver2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace FIT5032Assignment1_ver2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserRoleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private UserManager<ApplicationUser> UserManager;
        public UserRoleController()
        {
            var userStore = new UserStore<ApplicationUser>(db);
            UserManager = new UserManager<ApplicationUser>(userStore);
        }

        public ActionResult Index() 
        
        {
            return View();
        }

        // GET: UserRole
        public ActionResult AddRoleToUser()
        {
            var roles = db.Roles.OrderBy(r => r.Name).ToList().Select(r => new SelectListItem { Value = r.Name.ToString(), Text = r.Name }).ToList();
            ViewBag.Roles = roles;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRoleToUser(FormCollection formCollection)
        {
            try
            {
                string UserName = Request.Form["UserName"];
                string RoleName = Request.Form["RoleName"];
                var roles = db.Roles.OrderBy(r => r.Name).ToList().Select(r => new SelectListItem { Value = r.Name.ToString(), Text = r.Name }).ToList();
                ViewBag.Roles = roles;
                ApplicationUser user = db.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                this.UserManager.AddToRole(user.Id, RoleName);
                return View("Index");
            }
            catch
            {
                return View();
            }

        }

        public ActionResult GetUserRoles()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetUserRoles(string UserName)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(UserName))
                {
                    ApplicationUser user = db.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

                    ViewBag.RolesForTheUser = this.UserManager.GetRoles(user.Id);
                }

                return View();
            }
            catch
            {
                return View();
            }

        }

        public ActionResult DeleteRoleToUser()
        {
            var list = db.Roles.OrderBy(r => r.Name).ToList().Select(r => new SelectListItem { Value = r.Name.ToString(), Text = r.Name }).ToList();
            ViewBag.roles = list;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleToUser(string UserName, string RoleName)
        {
            try
            {
                ApplicationUser user = db.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

                var list = db.Roles.OrderBy(r => r.Name).ToList().Select(r => new SelectListItem { Value = r.Name.ToString(), Text = r.Name }).ToList();
                ViewBag.roles = list;

                if (this.UserManager.IsInRole(user.Id, RoleName))
                {
                    this.UserManager.RemoveFromRole(user.Id, RoleName);
                    ViewBag.ResultMessage = "Role removed from this user successfully !";
                }
                else
                {
                    ViewBag.ResultMessage = "This user doesn't belong to selected role.";
                }
                return View("Index");

            }
            catch
            {
                return View();
            }
        }
    }
}
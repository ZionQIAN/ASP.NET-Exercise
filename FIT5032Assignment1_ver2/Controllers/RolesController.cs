using FIT5032Assignment1_ver2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace FIT5032Assignment1_ver2.Controllers
{
    public class RolesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Roles
        public ActionResult Index()
        {
            return View(db.Roles.ToList());
        }

        // Get : Create

        public ActionResult Create() 
        {
            return View();
        }

        // Get : Create new Role

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection fromCollection) 
        {
            try
            {
                db.Roles.Add
                    (new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
                    {
                        Name = fromCollection["Rolename"]
                    });
                db.SaveChanges();
                return RedirectToAction("Index");
            } 
            catch 
            {
                return View();
            }
        }

        // Get : Edit

        public ActionResult Edit(String roleName)
        {
            var role = db.Roles.Where(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                return View(role);
        }

        // Post : Edit Role
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Microsoft.AspNet.Identity.EntityFramework.IdentityRole role) 
        {
            try
            {
                db.Entry(role).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(String roleName) 
        {
            var role = db.Roles.Where(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            db.Roles.Remove(role);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
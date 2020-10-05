using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032Assignment1_ver2.Models;

namespace FIT5032Assignment1_ver2.Controllers
{
    public class LoginedCoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LoginedCourses
        public ActionResult Index()
        {
            var loginCourses = db.LoginCourses.Include(l => l.Course).Include(l => l.Student);
            return View(loginCourses.ToList());
        }

        // GET: LoginedCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginedCourse loginedCourse = db.LoginCourses.Find(id);
            if (loginedCourse == null)
            {
                return HttpNotFound();
            }
            return View(loginedCourse);
        }

        // GET: LoginedCourses/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Course, "Id", "CourseName");
            ViewBag.StudentId = new SelectList(db.Student, "Id", "Name");
            return View();
        }

        // POST: LoginedCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CourseId,StudentId")] LoginedCourse loginedCourse)
        {
            if (ModelState.IsValid)
            {
                db.LoginCourses.Add(loginedCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Course, "Id", "CourseName", loginedCourse.CourseId);
            ViewBag.StudentId = new SelectList(db.Student, "Id", "Name", loginedCourse.StudentId);
            return View(loginedCourse);
        }

        // GET: LoginedCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginedCourse loginedCourse = db.LoginCourses.Find(id);
            if (loginedCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Course, "Id", "CourseName", loginedCourse.CourseId);
            ViewBag.StudentId = new SelectList(db.Student, "Id", "Name", loginedCourse.StudentId);
            return View(loginedCourse);
        }

        // POST: LoginedCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CourseId,StudentId")] LoginedCourse loginedCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loginedCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Course, "Id", "CourseName", loginedCourse.CourseId);
            ViewBag.StudentId = new SelectList(db.Student, "Id", "Name", loginedCourse.StudentId);
            return View(loginedCourse);
        }

        // GET: LoginedCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginedCourse loginedCourse = db.LoginCourses.Find(id);
            if (loginedCourse == null)
            {
                return HttpNotFound();
            }
            return View(loginedCourse);
        }

        // POST: LoginedCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoginedCourse loginedCourse = db.LoginCourses.Find(id);
            db.LoginCourses.Remove(loginedCourse);
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

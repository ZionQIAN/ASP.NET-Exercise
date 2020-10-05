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
    public class LikeCoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LikeCourses
        public ActionResult Index()
        {
            var likeCourses = db.LikeCourses.Include(l => l.Course).Include(l => l.Student);
            return View(likeCourses.ToList());
        }

        // GET: LikeCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LikeCourse likeCourse = db.LikeCourses.Find(id);
            if (likeCourse == null)
            {
                return HttpNotFound();
            }
            return View(likeCourse);
        }

        // GET: LikeCourses/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Course, "Id", "CourseName");
            ViewBag.StudentId = new SelectList(db.Student, "Id", "Name");
            return View();
        }

        // POST: LikeCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CourseId,StudentId")] LikeCourse likeCourse)
        {
            if (ModelState.IsValid)
            {
                db.LikeCourses.Add(likeCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Course, "Id", "CourseName", likeCourse.CourseId);
            ViewBag.StudentId = new SelectList(db.Student, "Id", "Name", likeCourse.StudentId);
            return View(likeCourse);
        }

        // GET: LikeCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LikeCourse likeCourse = db.LikeCourses.Find(id);
            if (likeCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Course, "Id", "CourseName", likeCourse.CourseId);
            ViewBag.StudentId = new SelectList(db.Student, "Id", "Name", likeCourse.StudentId);
            return View(likeCourse);
        }

        // POST: LikeCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CourseId,StudentId")] LikeCourse likeCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(likeCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Course, "Id", "CourseName", likeCourse.CourseId);
            ViewBag.StudentId = new SelectList(db.Student, "Id", "Name", likeCourse.StudentId);
            return View(likeCourse);
        }

        // GET: LikeCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LikeCourse likeCourse = db.LikeCourses.Find(id);
            if (likeCourse == null)
            {
                return HttpNotFound();
            }
            return View(likeCourse);
        }

        // POST: LikeCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LikeCourse likeCourse = db.LikeCourses.Find(id);
            db.LikeCourses.Remove(likeCourse);
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

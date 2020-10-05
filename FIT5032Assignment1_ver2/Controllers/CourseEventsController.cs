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
    public class CourseEventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CourseEvents
        public ActionResult Index()
        {
            var courseEvents = db.CourseEvents.Include(c => c.Course).Include(c => c.Event);
            return View(courseEvents.ToList());
        }

        // GET: CourseEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseEvent courseEvent = db.CourseEvents.Find(id);
            if (courseEvent == null)
            {
                return HttpNotFound();
            }
            return View(courseEvent);
        }

        // GET: CourseEvents/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Course, "Id", "CourseName");
            ViewBag.EventId = new SelectList(db.Event, "Id", "EventName");
            return View();
        }

        // POST: CourseEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CourseTime,Address,CourseId,EventId")] CourseEvent courseEvent)
        {
            if (ModelState.IsValid)
            {
                db.CourseEvents.Add(courseEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Course, "Id", "CourseName", courseEvent.CourseId);
            ViewBag.EventId = new SelectList(db.Event, "Id", "EventName", courseEvent.EventId);
            return View(courseEvent);
        }

        // GET: CourseEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseEvent courseEvent = db.CourseEvents.Find(id);
            if (courseEvent == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Course, "Id", "CourseName", courseEvent.CourseId);
            ViewBag.EventId = new SelectList(db.Event, "Id", "EventName", courseEvent.EventId);
            return View(courseEvent);
        }

        // POST: CourseEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CourseTime,Address,CourseId,EventId")] CourseEvent courseEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Course, "Id", "CourseName", courseEvent.CourseId);
            ViewBag.EventId = new SelectList(db.Event, "Id", "EventName", courseEvent.EventId);
            return View(courseEvent);
        }

        // GET: CourseEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseEvent courseEvent = db.CourseEvents.Find(id);
            if (courseEvent == null)
            {
                return HttpNotFound();
            }
            return View(courseEvent);
        }

        // POST: CourseEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseEvent courseEvent = db.CourseEvents.Find(id);
            db.CourseEvents.Remove(courseEvent);
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

using FIT5032Assignment1_ver2.Models;
using FIT5032Assignment1_ver2.Utils;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace FIT5032Assignment1_ver2.Controllers
{
    public class LoginedCourseController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: LoginedCourse
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginCourse(int id)
        {
            var userId = User.Identity.GetUserId();
            var check = db.LoginCourses.Where(p => p.CourseId == id && p.ApplicationUserId.Equals(userId)).FirstOrDefault();

            if (check == null)
            {
                LoginedCourse loginedCourse = new LoginedCourse { ApplicationUserId = userId, CourseId = id };
                db.LoginCourses.Add(loginedCourse);
                db.SaveChanges();
                SendEmail();
                var userLogining = db.LoginCourses.Include(p => p.Course).Include(p => p.ApplicationUser).Where(m => m.ApplicationUserId == userId);
                return View("index", userLogining.ToList());
            }
            else
            {
                return Content("<script>alert('You has been book this course before, you cannot book twice.'); window.location.href='/Courses' </script>");
            }


        }

        public ActionResult UserLoginCourse()
        {

            var userId = User.Identity.GetUserId();
            var userBooking = db.LoginCourses.Include(p => p.Course).Include(p => p.ApplicationUser).Where(m => m.ApplicationUserId == userId);
            return View(userBooking.ToList());
        }

        public void SendEmail()
        {
            string toEmail = User.Identity.GetUserName();
            string subject = "Course Confirmation";
            string contents = "You have successfully book the course";

            EmailSend es = new EmailSend();
            es.SendAttach(toEmail, subject, contents);
        }
    }
}
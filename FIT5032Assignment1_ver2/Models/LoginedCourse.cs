using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FIT5032Assignment1_ver2.Models
{
    public class LoginedCourse
    {
        public int Id { get; set; }

        public Course Course { get; set; }

        public int CourseId { get; set; }

        public Student Student { get; set; }

        public int StudentId { get; set; }
    }
}
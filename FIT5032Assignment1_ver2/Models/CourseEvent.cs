using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FIT5032Assignment1_ver2.Models
{
    public class CourseEvent
    {
        public int Id { get; set; }

        public DateTime CourseTime { get; set; }

        public String Address { get; set; }

        public Course Course {get; set;}

        public int CourseId { get; set; }

        public Event Event { get; set;}

        public int EventId { get; set;}
    }
}
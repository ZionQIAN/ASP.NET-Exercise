using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FIT5032Assignment1_ver2.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        public String CourseName { get; set; }

        public String Discription { get; set; }

        public String Image { get; set; }
    }
}
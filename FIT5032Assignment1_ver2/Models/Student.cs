using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FIT5032Assignment1_ver2.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        public String Email { get; set; }

        public String PhoneNo { get; set; }
    }
}
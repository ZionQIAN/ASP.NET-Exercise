using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace FIT5032WK4_CodeFirst_2rd.Models
{
    public class Student
    {
        [Key]
        public String FirstName { get; set; }

        public String LastName { get; set; }

        public virtual Unit Uint { get; set; }

    }
}
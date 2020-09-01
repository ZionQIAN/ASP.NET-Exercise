using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FIT5032WK4_CodeFirst_2rd.Models
{
    public class Unit
    {
        [Key]

        public String Name { get; set; }

        public String Description { get; set; }
    }
}
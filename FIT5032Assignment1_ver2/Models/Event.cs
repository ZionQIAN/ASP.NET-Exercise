using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FIT5032Assignment1_ver2.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        public String EventName { set; get; }

        public String Disciption { get; set; }

        public String Color { get; set; }
    }
}
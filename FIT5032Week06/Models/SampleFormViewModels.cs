using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace FIT5032Week06.Models
{
    public class SampleFormViewModels
    {
    }

    public class FormOneViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

}
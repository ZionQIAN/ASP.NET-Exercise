using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FIT5032WK4_CodeFirst_2rd.Models
{
    public class ContextTest : DbContext

    {
        public ContextTest() : base("TestConection") { }

        public DbSet<Student> Student { get; set; }

        public DbSet<Unit> Unit { get; set; }

    }
}
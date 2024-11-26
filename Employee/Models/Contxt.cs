using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Employee.Models
{
    public class Contxt : DbContext
    {
        public virtual DbSet<User> User { get; set; }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
    }
}
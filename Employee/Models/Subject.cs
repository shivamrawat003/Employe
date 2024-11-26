using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Employee.Models
{
    [Table("Subject")]
    public class Subject
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public string Sub_Name { get; set; }
        public int? Sem { get; set; }


    }
}
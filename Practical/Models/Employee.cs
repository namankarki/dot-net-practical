using System;
using System.ComponentModel.DataAnnotations;

namespace Practical.Models
{
    public class Employee
    {
        [Key]
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public Int32 Pay { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MoveoTaskOsherNati.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [RegularExpression("[a-zA-Z\\s]+")] // english validtion on server
        [DisplayName("Name")]
        public string name { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone Number")]
        public int phoneNumber { get; set; }

        [DisplayName("Gender")]
        public Gender gender { get;  set;}

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Start Date")]
        public string startDate { get; set; }

        [Required]
        [DisplayName("Level")]
        public Level type { get; set; }

        [DisplayName("Base Salary")]
        public int baseSalary { get; set; }
    }
  
}

public enum Gender
{
    Male,
    Female
}

public enum Level
{
    Manager,
    Junior,
    Senior
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MoveoTaskOsherNati.Models
{
    public class MyDB : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
    }
}
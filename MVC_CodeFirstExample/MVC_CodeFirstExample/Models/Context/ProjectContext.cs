using MVC_CodeFirstExample.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_CodeFirstExample.Models.Context
{
    public class ProjectContext:DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = "server=.\\SQLEXPRESS;database=MvcCodeFirstSampleDB;Trusted_Connection=True;";
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCMail.Models
{
    public class ProjeContext : DbContext
    {
        public ProjeContext()
        {
            Database.Connection.ConnectionString = "server=.\\SQLEXPRESS;Database=MailOdevDB;Trusted_Connection=true;";
        }


        public DbSet<Register> Registers { get; set; }
    }
}
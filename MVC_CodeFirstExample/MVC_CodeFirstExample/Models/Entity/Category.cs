using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_CodeFirstExample.Models.Entity
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public List<Product> Products { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_CodeFirstExample.Models.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
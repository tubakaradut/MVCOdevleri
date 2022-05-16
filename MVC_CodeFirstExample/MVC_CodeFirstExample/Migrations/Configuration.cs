namespace MVC_CodeFirstExample.Migrations
{
    using MVC_CodeFirstExample.Models.Entity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC_CodeFirstExample.Models.Context.ProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MVC_CodeFirstExample.Models.Context.ProjectContext context)
        {
            if (!context.Categories.Any())
            {
                List<Category> categories = new List<Category>
                {
                    new Category{CategoryName="Giyim"},
                    new Category{CategoryName="Teknoloji"},
                    new Category{CategoryName="Kitap"}
                };

                foreach (Category category in categories)
                {
                    context.Categories.Add(category);
                    context.SaveChanges();
                }

            }

            if (!context.Products.Any())
            {
                List<Product> products = new List<Product>
                {
                    new Product{ProductName="Nike Air",UnitPrice=1200,CategoryId=context.Categories.FirstOrDefault(x=>x.CategoryName=="Giyim").Id},
                    new Product{ProductName="Tshirt",UnitPrice=200,CategoryId=context.Categories.FirstOrDefault(x=>x.CategoryName=="Giyim").Id},
                    new Product{ProductName="Macbook pro",UnitPrice=21000,CategoryId=context.Categories.FirstOrDefault(x=>x.CategoryName=="Teknoloji").Id},
                    new Product{ProductName="Televizyon",UnitPrice=15000,CategoryId=context.Categories.FirstOrDefault(x=>x.CategoryName=="Teknoloji").Id},
                    new Product{ProductName="Devlet",UnitPrice=15,CategoryId=context.Categories.FirstOrDefault(x=>x.CategoryName=="Kitap").Id},
                    new Product{ProductName="Aşkın Metafiziği",UnitPrice=20,CategoryId=context.Categories.FirstOrDefault(x=>x.CategoryName=="Kitap").Id}
                };
                foreach (Product product in products)
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                }
            }
        }
    }
}

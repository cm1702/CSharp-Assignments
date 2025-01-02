using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Assessment_1.Models
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext() : base("name=NorthwindConnectionString") 
        {
        }

        public DbSet<Product> Products { get; set; } 
        public DbSet<Category> Categories { get; set; } 
 
    }

    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
   
    }

    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
   
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Assessment1_ques2.Models
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext() : base("connstr") 
        {
        }

        public DbSet<Movie> Movies { get; set; } 
    }
}
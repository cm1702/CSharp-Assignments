using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVC_Assignment_1.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext() : base("conStr") 
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
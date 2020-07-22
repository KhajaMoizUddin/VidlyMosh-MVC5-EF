using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VidlyMain.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {
                
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }

        public DbSet<Movies> Movies { get; set; }
        public DbSet<Genres> Genres { get; set; }

    }
}
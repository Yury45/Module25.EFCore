using Microsoft.EntityFrameworkCore;
using Module25.Homework.Models;
using Module25.Homework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module25.Homework
{
    internal class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Book> Books { get; set; }

        public AppContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-OJBC2LR\SQLEXPRESS01;
            Database=Library; Trusted_Connection=True; TrustServerCertificate=True");
        }
    }
}

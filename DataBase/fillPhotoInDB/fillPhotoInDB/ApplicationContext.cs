using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fillPhotoInDB
{
    public class ApplicationContext : DbContext
    {
        private string _serverConnection = "server=localhost;user=root;password=root;database=mis;";
        public DbSet<User> User { get; set; }

        public ApplicationContext() 
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_serverConnection, ServerVersion.AutoDetect(_serverConnection));
        }
    }
}

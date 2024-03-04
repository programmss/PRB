using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace directionPacientToEvent
{
    public class ApplicationContext : DbContext
    {

        private string _serverConnection = "server=localhost;user=root;password=root;database=mis";
        public DbSet<Doctor> doctor { get; set; }
        public DbSet<User> user { get; set; }
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

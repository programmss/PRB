using Microsoft.EntityFrameworkCore;
using WinFormsTest2024.Models;

namespace WinFormsTest2024
{
	public class ApplicationContext : DbContext
	{
		private string _serverConnection = "server=localhost;user=root;password=root;database=testdb;";

		public DbSet<User> User { get; set; } = null!;

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

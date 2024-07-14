using Microsoft.EntityFrameworkCore;
using Template.Common;
using Template.Models;

namespace Template.DataAccess
{
    /// <summary>
    /// SQLlite db context
    /// </summary>
    public class DatabaseContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public DbSet<User> User { get; set; }


        /// <summary>   |
        /// Initializes sqlite
        /// </summary>
        public DatabaseContext()
        {
            SQLitePCL.Batteries_V2.Init();
            this.Database.EnsureCreated();
        }


        /// <summary>
        /// Configure the database
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), Constants.DatabaseName);
            optionsBuilder.UseSqlite($"Filename={databasePath}");
        }


    }
}

using Microsoft.EntityFrameworkCore;
using Template.Common;
using Template.Models;

namespace Template.DataAccess
{
    /// <summary>
    /// SQLlite db context
    /// </summary>
    public class AzureDatabaseContext : DbContext
    {
        public DbSet<User> User { get; set; }


        /// <summary>   |
        /// Initializes sqlite
        /// </summary>
        public AzureDatabaseContext()
        {
            SQLitePCL.Batteries_V2.Init();
            this.Database.EnsureCreated();
        }




        /// <summary>
        /// Configure the database
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Constants.ConnectionString);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Backend.Models;

namespace Backend.DataAccess
{

    /// <summary>
    /// SQL Data context   
    /// </summary>
    public class DatabaseContext : DbContext
    {
        private readonly IConfiguration config;

        public DbSet<Document> Documents { get; set; }


        /// <summary>
        /// EF Core constructor
        /// </summary>
        public DatabaseContext()
        {
        }


        /// <summary>
        /// EF Core constructor
        /// </summary>
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }


        /// <summary>
        /// Contrustor used when a configuration is passed
        /// </summary>
        public DatabaseContext(IConfiguration config)
        {
            this.config = config;
        }


        /// <summary>
        /// Configures the data context
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder == null) return;
            base.OnConfiguring(optionsBuilder);

            var databaseName = string.Empty;
            var connectionString = string.Empty;
            if (this.config != null)
            {
                databaseName = config.GetConnectionString("DatabaseName");
                connectionString = config.GetConnectionString("DatabaseConnectionString");
                if (string.IsNullOrEmpty(connectionString))
                {
                    databaseName = config["DatabaseName"]?.ToString();
                    connectionString = config["DatabaseConnectionString"]?.ToString();
                }
            }

            if (!string.IsNullOrEmpty(connectionString))
            {
#if DEBUG
                optionsBuilder.EnableSensitiveDataLogging(true);
#endif
                optionsBuilder.UseCosmos(connectionString, databaseName);
            }
        }


        /// <summary>
        /// Seeds the BD
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>().ToContainer("documents");
            modelBuilder.Entity<Document>().HasNoDiscriminator();
            modelBuilder.Entity<Document>().HasKey(x => x.DocumentId);
            modelBuilder.Entity<Document>().HasPartitionKey(x => x.DocumentId);            
        }
    }
}

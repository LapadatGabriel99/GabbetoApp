using Fasseto.Word.Core;
using Microsoft.EntityFrameworkCore;
using System;

namespace Gabbeto.Word.Relational
{
    ///<sumary>
    /// The database context for the client data store
    /// using Entity Framework and SQLite
    ///</sumary>
    public class ClientDataStoreDbContext : DbContext
    {
        #region DBSets

        /// <summary>
        /// The client login credentials
        /// </summary>
        public DbSet<LoginCredentialsDataModel> LoginCredentials { get; set; }

        #endregion

        #region Constructors

        ///<sumary>
        ///Default Constructor
        ///</sumary>
        public ClientDataStoreDbContext(DbContextOptions<ClientDataStoreDbContext> options) : base(options)
        {

        }

        #endregion

        #region Model Creating

        /// <summary>
        /// Configures the database structure and relationships
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Fluent API

            // Configure LoginCredentials
            // --------------------------
            //
            // Set Id as primary key
            modelBuilder.Entity<LoginCredentialsDataModel>().HasKey(p => p.Id);
                
            // TODO: set up limits
        }

        #endregion
    }
}

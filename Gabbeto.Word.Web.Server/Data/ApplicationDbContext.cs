using Gabbetto.Word.Web.Server;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Gabbetto.Word.Web.Server
{
    /// <summary>
    /// The database representational model for our application
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        #region Public Properties

        public string Id { get; set; } 
            = Guid.NewGuid().ToString("N");

        /// <summary>
        /// The settings for the application
        /// </summary>
        public DbSet<SettingsDataModel> Settings { get; set; }

        /// <summary>
        /// The messages for the application
        /// </summary>
        public DbSet<Message> Messages { get; set; }

        /// <summary>
        /// The conversations that the user has in this application
        /// </summary>
        public DbSet<Conversation> Conversations { get; set; }

        /// <summary>
        /// The table representing the friendship relations
        /// between application users
        /// </summary>
        public DbSet<Friendship> Friendships { get; set; }

        /// <summary>
        /// A data model that defines the state of a friendship relation
        /// </summary>
        public DbSet<FriendshipStatus> FriendshipStatuses { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor, expecting database options passed in
        /// </summary>
        /// <param name="options">The database context options</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        #endregion

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //    optionsBuilder.UseSqlServer("Server=DESKTOP-VOI712J\\BIGBOSSSQL;Database=entityFramework;Trusted_Connection=True;MultipleActiveResultSets=true");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Fluent API
            
            // Set name property to be an index
            modelBuilder.Entity<SettingsDataModel>().HasIndex(s => s.Name);

            // Set name property to be an index
            modelBuilder.Entity<Conversation>().HasIndex(c => c.Name);

            // Set one to many relationship between
            // ApplicationUser and Conversation tables
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(a => a.Conversations)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);

            // Set one to many relationship between
            // ApplicationUser and Message tables
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(a => a.Friends)
                .WithOne(f => f.User)
                .HasForeignKey(f => f.UserId);

            // Set one to many relationship between
            // Conversation and Message tables
            modelBuilder.Entity<Conversation>()
                .HasMany(c => c.Messages)
                .WithOne(m => m.Conversation)
                .HasForeignKey(m => m.ConversationId);

            // Set one to one relationship between
            // Friendship and FriendshipStatus tables
            // Where Friendship is the dependent entity
            modelBuilder.Entity<FriendshipStatus>()
                .HasOne(f => f.Friendship)
                .WithOne(f => f.Status)
                .HasForeignKey<Friendship>(f => f.StatusId);

            #endregion
        }
    }
}

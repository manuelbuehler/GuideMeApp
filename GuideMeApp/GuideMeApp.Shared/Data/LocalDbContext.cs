// https://medium.com/@taublast/entity-framework-with-code-first-migrations-in-net-maui-3efbdb765592
using GuideMeApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace GuideMeApp.Shared.Data
{
    public class LocalDbContext : DbContext
    {
        #region TABLES
        public DbSet<User> Users { get; set; }

        public DbSet<UserSetting> UserSettings { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Trip> Trips { get; set; }

        public DbSet<TripDetail> TripDetails { get; set; }
        #endregion

        #region CONSTRUCTOR
        public static string File { get; protected set; }
        public static bool Initialized { get; protected set; }

        //public LocalDbContext(DbContextOptions<LocalDbContext> options)
        //: base(options)
        //{
        //    File = Path.Combine("../", "UsedByMigratorOnly1.db3");
        //    Init();
        //}

        public LocalDbContext()
        {
            File = Path.Combine("../", "UsedByMigratorOnly1.db3");
            Init();
        }

        public LocalDbContext(string filenameWithPath)
        {
            File = filenameWithPath;
            Init();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite($"Filename={File}");
        }

        void Init()
        {
            if (!Initialized)
            {
                Initialized = true;

                SQLitePCL.Batteries_V2.Init();

                Database.Migrate();
            }
        }
        #endregion

        #region RELATIONS
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>(entity =>
            {
                entity.ToTable("Trip");
                entity.HasKey(e => e.Id);
                //entity.Property(e => e.Date).HasColumnType("datetime");
                //entity.HasOne(e => e.Guide)
                //      .WithOne()
                //      .HasForeignKey(e => e.GuideId);
                entity.OwnsOne(e => e.Address);
                entity.HasOne(e => e.Guide)
                    .WithMany() 
                    .HasForeignKey(e => e.GuideId)
                .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<TripDetail>(entity =>
            {
                entity.ToTable("TripDetail");
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.User)
                      .WithMany()
                      .HasForeignKey(e => e.UserId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.OwnsOne(e => e.Address);
            });

            //modelBuilder.Entity<User>(entity =>
            //{
            //    entity.ToTable("User");
            //    entity.HasKey(e => e.Id);
            //    entity.HasIndex(e => new { e.FirstName, e.LastName });
            //    entity.Has(e => e.Role);
            //    entity.HasOne(e => e.UserSetting)
            //          .WithMany()
            //          .HasForeignKey(e => e.UserSettingId);
            //    entity.OwnsOne(e => e.Address);
            //});

            //modelBuilder.Entity<UserSetting>(entity =>
            //{
            //    entity.ToTable("UserSetting");
            //    entity.HasKey(e => e.Id);
            //});

            modelBuilder.HasDefaultSchema("dbo");

            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}

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
        public static string? File { get; protected set; }
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
                entity.OwnsOne(e => e.Address);
                entity.HasOne(e => e.Guide)
                    .WithMany()
                    .HasForeignKey(e => e.GuideId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TripDetail>(entity =>
            {
                entity.HasOne(e => e.User)
                    .WithMany()
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Trip)
                    .WithMany()
                    .HasForeignKey(e => e.TripId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.OwnsOne(e => e.Address);
                entity.HasOne(e => e.Role)
                    .WithMany()
                    .HasForeignKey(e => e.RoleId)
                    .OnDelete(DeleteBehavior.SetNull);
                entity.HasOne(e => e.UserSetting)
                    .WithMany()
                    .HasForeignKey(e => e.UserSettingId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.HasDefaultSchema("dbo");

            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}

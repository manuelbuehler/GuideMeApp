using GuideMeApp.Models;
using Microsoft.EntityFrameworkCore;
namespace GuideMeApp.Data
{
    public class GuideMeContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<UserSetting> UserSettings { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<TripDetail> TripDetails { get; set; }


        //    public GuideMeContext(DbContextOptions<GuideMeContext> options)
        //: base(options)
        //    {
        //    }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"DataSource=Data\guideme.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.ToTable("Trip");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Date).HasColumnType("datetime");
                entity.HasOne(e => e.Guide)
                      .WithMany()
                      .HasForeignKey(e => e.GuideId);
                entity.HasOne(e => e.Address)
                      .WithMany()
                      .HasForeignKey(e => e.AddressId);
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
                entity.ToTable("User");
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => new { e.FirstName, e.LastName });
                entity.HasOne(e => e.Role)
                      .WithMany()
                      .HasForeignKey(e => e.RoleId);
                entity.HasOne(e => e.UserSetting)
                      .WithMany()
                      .HasForeignKey(e => e.UserSettingId);
                entity.HasOne(e => e.Address)
                      .WithMany()
                      .HasForeignKey(e => e.AddressId);
            });

            modelBuilder.Entity<UserSetting>(entity =>
            {
                entity.ToTable("UserSetting");
                entity.HasKey(e => e.Id);
            });

            modelBuilder.HasDefaultSchema("dbo");

            base.OnModelCreating(modelBuilder);
        }
    }
}
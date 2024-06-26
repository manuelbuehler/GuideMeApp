using GuideMeApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GuideMeApp
{
    public class GuideMeContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<UserSetting> UserSettings { get; set; }
       
        public DbSet<Role> Roles { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<TripDetail> TripDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=GuideMe;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FirstName)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.LastName)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.BirthDate)
                      .IsRequired();

                entity.Property(e => e.UserGroup)
                      .IsRequired();

                entity.HasOne(e => e.Role)
                      .WithMany()
                      .HasForeignKey(e => e.RoleId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.UserSetting)
                      .WithMany()
                      .HasForeignKey(e => e.UserSettingId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Address)
                      .WithMany()
                      .HasForeignKey(e => e.AddressId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<UserSetting>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(50);
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Title)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Description)
                      .IsRequired()
                      .HasMaxLength(500);

                entity.HasOne(e => e.Guide)
                      .WithMany()
                      .HasForeignKey(e => e.GuideId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TripDetail>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Date)
                      .IsRequired();

                entity.Property(e => e.Rating)
                      .IsRequired();

                entity.HasOne(e => e.User)
                      .WithMany()
                      .HasForeignKey(e => e.UserId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Street)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.City)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.State)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.Country)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.PostalCode)
                      .IsRequired()
                      .HasMaxLength(20);
            });
        }
    }
}

﻿// <auto-generated />
using System;
using GuideMeApp.Shared.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GuideMeApp.Shared.Migrations
{
    [DbContext(typeof(LocalDbContext))]
    [Migration("20240717071340_Update")]
    partial class Update
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("GuideMeApp.Shared.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Roles", "dbo");
                });

            modelBuilder.Entity("GuideMeApp.Shared.Models.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<int>("GuideId")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GuideId");

                    b.ToTable("Trips", "dbo");
                });

            modelBuilder.Entity("GuideMeApp.Shared.Models.TripDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TripId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.HasIndex("UserId");

                    b.ToTable("TripDetails", "dbo");
                });

            modelBuilder.Entity("GuideMeApp.Shared.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Image")
                        .HasColumnType("BLOB");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserGroup")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserSettingId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserSettingId");

                    b.ToTable("Users", "dbo");
                });

            modelBuilder.Entity("GuideMeApp.Shared.Models.UserSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("BlinkBlocker")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HighContrast")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ScreenReader")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("TextEnlargement")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("TextReader")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("VoiceCommands")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("UserSettings", "dbo");
                });

            modelBuilder.Entity("GuideMeApp.Shared.Models.Trip", b =>
                {
                    b.HasOne("GuideMeApp.Shared.Models.User", "Guide")
                        .WithMany()
                        .HasForeignKey("GuideId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("GuideMeApp.Shared.Models.Address", "Address", b1 =>
                        {
                            b1.Property<int>("TripId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("AddressLine1")
                                .HasColumnType("TEXT");

                            b1.Property<string>("AddressLine2")
                                .HasColumnType("TEXT");

                            b1.Property<string>("AddressLine3")
                                .HasColumnType("TEXT");

                            b1.Property<string>("City")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Country")
                                .HasColumnType("TEXT");

                            b1.Property<string>("PostalCode")
                                .HasColumnType("TEXT");

                            b1.Property<string>("State")
                                .HasColumnType("TEXT");

                            b1.HasKey("TripId");

                            b1.ToTable("Trips", "dbo");

                            b1.WithOwner()
                                .HasForeignKey("TripId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Guide");
                });

            modelBuilder.Entity("GuideMeApp.Shared.Models.TripDetail", b =>
                {
                    b.HasOne("GuideMeApp.Shared.Models.Trip", "Trip")
                        .WithMany()
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GuideMeApp.Shared.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trip");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GuideMeApp.Shared.Models.User", b =>
                {
                    b.HasOne("GuideMeApp.Shared.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("GuideMeApp.Shared.Models.UserSetting", "UserSetting")
                        .WithMany()
                        .HasForeignKey("UserSettingId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.OwnsOne("GuideMeApp.Shared.Models.Address", "Address", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("AddressLine1")
                                .HasColumnType("TEXT");

                            b1.Property<string>("AddressLine2")
                                .HasColumnType("TEXT");

                            b1.Property<string>("AddressLine3")
                                .HasColumnType("TEXT");

                            b1.Property<string>("City")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Country")
                                .HasColumnType("TEXT");

                            b1.Property<string>("PostalCode")
                                .HasColumnType("TEXT");

                            b1.Property<string>("State")
                                .HasColumnType("TEXT");

                            b1.HasKey("UserId");

                            b1.ToTable("Users", "dbo");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("UserSetting");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tunify_Platform.Data;

#nullable disable

namespace Tunify_Platform.Migrations
{
    [DbContext(typeof(TunifyDbContext))]
    [Migration("20240809113207_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tunify_Platform.Models.Album", b =>
                {
                    b.Property<int>("AlbumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlbumId"));

                    b.Property<string>("AlbumName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("AlbumId");

                    b.HasIndex("ArtistId");

                    b.ToTable("Albums");

                    b.HasData(
                        new
                        {
                            AlbumId = 1,
                            AlbumName = "Album 1",
                            ArtistId = 1,
                            ReleaseDate = new DateTime(2024, 8, 9, 14, 32, 7, 789, DateTimeKind.Local).AddTicks(9810)
                        },
                        new
                        {
                            AlbumId = 2,
                            AlbumName = "Album 2",
                            ArtistId = 2,
                            ReleaseDate = new DateTime(2024, 8, 9, 14, 32, 7, 789, DateTimeKind.Local).AddTicks(9812)
                        });
                });

            modelBuilder.Entity("Tunify_Platform.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArtistId"));

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArtistId");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            ArtistId = 1,
                            Bio = "This is a bio",
                            Name = "Artist 1"
                        },
                        new
                        {
                            ArtistId = 2,
                            Bio = "This is a bio",
                            Name = "Artist 2"
                        });
                });

            modelBuilder.Entity("Tunify_Platform.Models.Playlist", b =>
                {
                    b.Property<int>("PlaylistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaylistId"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PlaylistName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PlaylistId");

                    b.HasIndex("UserId");

                    b.ToTable("Playlists");

                    b.HasData(
                        new
                        {
                            PlaylistId = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PlaylistName = "Playlist 1",
                            UserId = 1
                        },
                        new
                        {
                            PlaylistId = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PlaylistName = "Playlist 2",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("Tunify_Platform.Models.PlaylistSongs", b =>
                {
                    b.Property<int>("PlaylistId")
                        .HasColumnType("int");

                    b.Property<int>("SongId")
                        .HasColumnType("int");

                    b.HasKey("PlaylistId", "SongId");

                    b.HasIndex("SongId");

                    b.ToTable("PlaylistSongs");

                    b.HasData(
                        new
                        {
                            PlaylistId = 1,
                            SongId = 1
                        },
                        new
                        {
                            PlaylistId = 1,
                            SongId = 2
                        },
                        new
                        {
                            PlaylistId = 2,
                            SongId = 1
                        });
                });

            modelBuilder.Entity("Tunify_Platform.Models.Song", b =>
                {
                    b.Property<int>("SongId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SongId"));

                    b.Property<int>("AlbumId")
                        .HasColumnType("int");

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SongId");

                    b.HasIndex("AlbumId");

                    b.HasIndex("ArtistId");

                    b.ToTable("Songs");

                    b.HasData(
                        new
                        {
                            SongId = 1,
                            AlbumId = 1,
                            ArtistId = 1,
                            Duration = new TimeSpan(0, 0, 3, 45, 0),
                            Genre = "Pop",
                            Title = "Song 1"
                        },
                        new
                        {
                            SongId = 2,
                            AlbumId = 2,
                            ArtistId = 2,
                            Duration = new TimeSpan(0, 0, 4, 20, 0),
                            Genre = "Rock",
                            Title = "Song 2"
                        });
                });

            modelBuilder.Entity("Tunify_Platform.Models.Subscription", b =>
                {
                    b.Property<int>("SubscriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubscriptionId"));

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SubscriptionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubscriptionId");

                    b.ToTable("Subscriptions");

                    b.HasData(
                        new
                        {
                            SubscriptionId = 1,
                            Price = 0.00m,
                            SubscriptionType = "Free"
                        },
                        new
                        {
                            SubscriptionId = 2,
                            Price = 9.99m,
                            SubscriptionType = "Premium"
                        });
                });

            modelBuilder.Entity("Tunify_Platform.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Join_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "john@example.com",
                            Join_Date = new DateTime(2024, 8, 9, 14, 32, 7, 789, DateTimeKind.Local).AddTicks(9765),
                            SubscriptionId = 1,
                            Username = "john_doe"
                        },
                        new
                        {
                            UserId = 2,
                            Email = "jane@example.com",
                            Join_Date = new DateTime(2024, 8, 9, 14, 32, 7, 789, DateTimeKind.Local).AddTicks(9780),
                            SubscriptionId = 2,
                            Username = "jane_doe"
                        });
                });

            modelBuilder.Entity("Tunify_Platform.Models.Album", b =>
                {
                    b.HasOne("Tunify_Platform.Models.Artist", "Artist")
                        .WithMany("Albums")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Playlist", b =>
                {
                    b.HasOne("Tunify_Platform.Models.User", "User")
                        .WithMany("Playlists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Tunify_Platform.Models.PlaylistSongs", b =>
                {
                    b.HasOne("Tunify_Platform.Models.Playlist", "Playlist")
                        .WithMany("PlaylistSongs")
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tunify_Platform.Models.Song", "Song")
                        .WithMany("PlaylistSongs")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Playlist");

                    b.Navigation("Song");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Song", b =>
                {
                    b.HasOne("Tunify_Platform.Models.Album", "Album")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tunify_Platform.Models.Artist", "Artist")
                        .WithMany("Songs")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("Tunify_Platform.Models.User", b =>
                {
                    b.HasOne("Tunify_Platform.Models.Subscription", "Subscription")
                        .WithMany("Users")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Album", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Artist", b =>
                {
                    b.Navigation("Albums");

                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Playlist", b =>
                {
                    b.Navigation("PlaylistSongs");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Song", b =>
                {
                    b.Navigation("PlaylistSongs");
                });

            modelBuilder.Entity("Tunify_Platform.Models.Subscription", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Tunify_Platform.Models.User", b =>
                {
                    b.Navigation("Playlists");
                });
#pragma warning restore 612, 618
        }
    }
}

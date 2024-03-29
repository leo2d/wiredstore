﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wired.Data.Contexts;

namespace Wired.Migrations
{
    [DbContext(typeof(WiredContext))]
    [Migration("20181020132537_initialA")]
    partial class initialA
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Wired.Models.Entities.Administrator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .IsFixedLength(true)
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("wired_admin");
                });

            modelBuilder.Entity("Wired.Models.Entities.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerId");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("Wired.Models.Entities.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int>("CartID");

                    b.Property<int>("GameID");

                    b.HasKey("Id");

                    b.HasIndex("CartID");

                    b.HasIndex("GameID")
                        .IsUnique();

                    b.ToTable("wired_cart_item");
                });

            modelBuilder.Entity("Wired.Models.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .IsFixedLength(true)
                        .HasMaxLength(11);

                    b.Property<string>("Email")
                        .IsRequired()
                        .IsFixedLength(true)
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.Property<string>("Password")
                        .IsRequired()
                        .IsFixedLength(true)
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("wired_customer");
                });

            modelBuilder.Entity("Wired.Models.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("GenreId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<double>("Price");

                    b.Property<string>("Producer")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("ReleaseYear")
                        .IsRequired()
                        .IsFixedLength(true)
                        .HasMaxLength(4);

                    b.Property<string>("ShortDescription")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("wired_game");
                });

            modelBuilder.Entity("Wired.Models.Entities.GameKey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GameId");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("boolean");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("wired_keys_game");
                });

            modelBuilder.Entity("Wired.Models.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45);

                    b.HasKey("Id");

                    b.ToTable("wired_genre_game");
                });

            modelBuilder.Entity("Wired.Models.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GameId");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("wired_images_game");
                });

            modelBuilder.Entity("Wired.Models.Entities.Cart", b =>
                {
                    b.HasOne("Wired.Models.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Wired.Models.Entities.CartItem", b =>
                {
                    b.HasOne("Wired.Models.Entities.Cart", "Cart")
                        .WithMany("Games")
                        .HasForeignKey("CartID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Wired.Models.Entities.Game", "Game")
                        .WithOne()
                        .HasForeignKey("Wired.Models.Entities.CartItem", "GameID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Wired.Models.Entities.Game", b =>
                {
                    b.HasOne("Wired.Models.Entities.Genre", "Genre")
                        .WithMany("Games")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Wired.Models.Entities.GameKey", b =>
                {
                    b.HasOne("Wired.Models.Entities.Game", "Game")
                        .WithMany("Keys")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Wired.Models.Entities.Image", b =>
                {
                    b.HasOne("Wired.Models.Entities.Game", "Game")
                        .WithMany("Images")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using BookStoreVer4.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookStoreVer4.Migrations
{
    [DbContext(typeof(BookStoreContext))]
    [Migration("20210508070847_addClientRole")]
    partial class addClientRole
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BookStoreVer4.Models.Books.Author", b =>
                {
                    b.Property<int>("authorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("nameAuthor")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("authorId");

                    b.ToTable("authors");
                });

            modelBuilder.Entity("BookStoreVer4.Models.Books.Book", b =>
                {
                    b.Property<int>("bookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("amout")
                        .HasColumnType("int");

                    b.Property<int>("authorId")
                        .HasColumnType("int");

                    b.Property<string>("bookDescription")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("genreId")
                        .HasColumnType("int");

                    b.Property<string>("imagePath")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("bookId");

                    b.HasIndex("authorId");

                    b.HasIndex("genreId");

                    b.ToTable("books");
                });

            modelBuilder.Entity("BookStoreVer4.Models.Books.Genre", b =>
                {
                    b.Property<int>("genreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("nameGenre")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("genreId");

                    b.ToTable("genres");
                });

            modelBuilder.Entity("BookStoreVer4.Models.Clients.Client", b =>
                {
                    b.Property<int>("clientid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("clientPassword")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("firstName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("lastName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("phoneNumber")
                        .HasColumnType("int");

                    b.Property<string>("role")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("clientid");

                    b.ToTable("clients");
                });

            modelBuilder.Entity("BookStoreVer4.Models.Books.Book", b =>
                {
                    b.HasOne("BookStoreVer4.Models.Books.Author", "Author")
                        .WithMany()
                        .HasForeignKey("authorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreVer4.Models.Books.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("genreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
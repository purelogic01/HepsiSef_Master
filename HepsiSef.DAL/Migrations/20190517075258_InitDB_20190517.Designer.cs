﻿// <auto-generated />
using System;
using HepsiSef.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HepsiSef.DAL.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20190517075258_InitDB_20190517")]
    partial class InitDB_20190517
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("HepsiSef.Entity.App.Bookmark", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<Guid>("RecipeID");

                    b.Property<int>("RecordStatus");

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<Guid>("UserID");

                    b.HasKey("Id");

                    b.HasIndex("RecipeID");

                    b.HasIndex("UserID");

                    b.ToTable("Bookmark");
                });

            modelBuilder.Entity("HepsiSef.Entity.App.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description");

                    b.Property<Guid?>("ParentID");

                    b.Property<int>("RecordStatus");

                    b.Property<bool>("ShowOnMenu");

                    b.Property<string>("Slug");

                    b.Property<string>("Title");

                    b.Property<DateTime?>("UpdateDate");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("HepsiSef.Entity.App.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("IPAddress");

                    b.Property<string>("LastName");

                    b.Property<string>("Message");

                    b.Property<Guid>("RecipeID");

                    b.Property<int>("RecordStatus");

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<Guid?>("UserID");

                    b.HasKey("Id");

                    b.HasIndex("RecipeID");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("HepsiSef.Entity.App.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Email");

                    b.Property<string>("FullName");

                    b.Property<string>("IPAddress");

                    b.Property<string>("Message");

                    b.Property<string>("PhoneNumber");

                    b.Property<int>("RecordStatus");

                    b.Property<DateTime?>("UpdateDate");

                    b.HasKey("Id");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("HepsiSef.Entity.App.Newsletter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Email");

                    b.Property<string>("IPAddress");

                    b.Property<int>("RecordStatus");

                    b.Property<DateTime?>("UpdateDate");

                    b.HasKey("Id");

                    b.ToTable("Newsletter");
                });

            modelBuilder.Entity("HepsiSef.Entity.Definition.Recipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("AvarageRate");

                    b.Property<int>("Calories");

                    b.Property<int>("CookingTime");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Details");

                    b.Property<int>("PrepareTime");

                    b.Property<int>("RecordStatus");

                    b.Property<int>("ServiceCount");

                    b.Property<string>("Slug");

                    b.Property<string>("Title");

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<Guid>("UserID");

                    b.Property<string>("VideoLink");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("HepsiSef.Entity.Definition.RecipeCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategoryID");

                    b.Property<DateTime>("CreateDate");

                    b.Property<Guid>("RecipeID");

                    b.Property<int>("RecordStatus");

                    b.Property<DateTime?>("UpdateDate");

                    b.HasKey("Id");

                    b.HasIndex("CategoryID");

                    b.HasIndex("RecipeID");

                    b.ToTable("RecipeCategory");
                });

            modelBuilder.Entity("HepsiSef.Entity.Definition.RecipeImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<bool>("ISCover");

                    b.Property<string>("Image");

                    b.Property<Guid>("RecipeID");

                    b.Property<int>("RecordStatus");

                    b.Property<DateTime?>("UpdateDate");

                    b.HasKey("Id");

                    b.HasIndex("RecipeID");

                    b.ToTable("RecipeImage");
                });

            modelBuilder.Entity("HepsiSef.Entity.Definition.RecipeIngredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<Guid>("RecipeID");

                    b.Property<int>("RecordStatus");

                    b.Property<string>("Title");

                    b.Property<DateTime?>("UpdateDate");

                    b.HasKey("Id");

                    b.HasIndex("RecipeID");

                    b.ToTable("RecipeIngredient");
                });

            modelBuilder.Entity("HepsiSef.Entity.Definition.RecipeRate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Email");

                    b.Property<string>("FullName");

                    b.Property<decimal>("Rate");

                    b.Property<Guid>("RecipeID");

                    b.Property<int>("RecordStatus");

                    b.Property<int>("Status");

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<Guid?>("UserID");

                    b.HasKey("Id");

                    b.HasIndex("RecipeID");

                    b.ToTable("RecipeRate");
                });

            modelBuilder.Entity("HepsiSef.Entity.Definition.Step", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<Guid>("RecipeID");

                    b.Property<int>("RecordStatus");

                    b.Property<string>("Title");

                    b.Property<DateTime?>("UpdateDate");

                    b.HasKey("Id");

                    b.HasIndex("RecipeID");

                    b.ToTable("Step");
                });

            modelBuilder.Entity("HepsiSef.Entity.SystemUser.ExternalLogin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("ProviderKey");

                    b.Property<int>("ProviderName");

                    b.Property<int>("RecordStatus");

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<Guid>("UserID");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("ExternalLogin");
                });

            modelBuilder.Entity("HepsiSef.Entity.SystemUser.ForgatPassword", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Key");

                    b.Property<int>("RecordStatus");

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<Guid>("UserID");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("ForgatPassword");
                });

            modelBuilder.Entity("HepsiSef.Entity.SystemUser.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<int>("RecordStatus");

                    b.Property<int>("Role");

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("HepsiSef.Entity.App.Bookmark", b =>
                {
                    b.HasOne("HepsiSef.Entity.Definition.Recipe", "Recipe")
                        .WithMany("Bookmarks")
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HepsiSef.Entity.SystemUser.User", "User")
                        .WithMany("Bookmarks")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HepsiSef.Entity.App.Comment", b =>
                {
                    b.HasOne("HepsiSef.Entity.Definition.Recipe", "Recipe")
                        .WithMany("Comments")
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HepsiSef.Entity.Definition.Recipe", b =>
                {
                    b.HasOne("HepsiSef.Entity.SystemUser.User", "User")
                        .WithMany("Recipes")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HepsiSef.Entity.Definition.RecipeCategory", b =>
                {
                    b.HasOne("HepsiSef.Entity.App.Category", "Category")
                        .WithMany("RecipeCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HepsiSef.Entity.Definition.Recipe", "Recipe")
                        .WithMany("RecipeCategories")
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HepsiSef.Entity.Definition.RecipeImage", b =>
                {
                    b.HasOne("HepsiSef.Entity.Definition.Recipe", "Recipe")
                        .WithMany("Images")
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HepsiSef.Entity.Definition.RecipeIngredient", b =>
                {
                    b.HasOne("HepsiSef.Entity.Definition.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HepsiSef.Entity.Definition.RecipeRate", b =>
                {
                    b.HasOne("HepsiSef.Entity.Definition.Recipe", "Recipe")
                        .WithMany("Rates")
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HepsiSef.Entity.Definition.Step", b =>
                {
                    b.HasOne("HepsiSef.Entity.Definition.Recipe", "Recipe")
                        .WithMany("Steps")
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HepsiSef.Entity.SystemUser.ExternalLogin", b =>
                {
                    b.HasOne("HepsiSef.Entity.SystemUser.User", "User")
                        .WithMany("ExternalLogins")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HepsiSef.Entity.SystemUser.ForgatPassword", b =>
                {
                    b.HasOne("HepsiSef.Entity.SystemUser.User", "User")
                        .WithMany("ForgatPasswords")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}

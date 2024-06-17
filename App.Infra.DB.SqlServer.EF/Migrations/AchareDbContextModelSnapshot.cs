﻿// <auto-generated />
using System;
using App.Infra.DB.SqlServer.EF.DB_Achare.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.Infra.DB.SqlServer.EF.Migrations
{
    [DbContext(typeof(AchareDbContext))]
    partial class AchareDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("App.Domain.Core.Adress.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("App.Domain.Core.Adress.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("App.Domain.Core.CategoryService.Entities.MainCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("Id");

                    b.ToTable("MainCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "تمیزکاری"
                        },
                        new
                        {
                            Id = 2,
                            Title = "ساختمان"
                        },
                        new
                        {
                            Id = 3,
                            Title = "تعمیرات اشیا"
                        },
                        new
                        {
                            Id = 4,
                            Title = "اسباب کسی"
                        },
                        new
                        {
                            Id = 5,
                            Title = "خودورو"
                        },
                        new
                        {
                            Id = 6,
                            Title = "سلامت و زیبایی"
                        });
                });

            modelBuilder.Entity("App.Domain.Core.CategoryService.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            SubCategoryId = 1,
                            Title = "سرویس عادی نظافت"
                        },
                        new
                        {
                            Id = 2,
                            SubCategoryId = 1,
                            Title = "سرویس ویزه نظافت"
                        },
                        new
                        {
                            Id = 3,
                            SubCategoryId = 1,
                            Title = "سرویس لوکس نظافت"
                        },
                        new
                        {
                            Id = 4,
                            SubCategoryId = 1,
                            Title = "نظافت راه پله"
                        },
                        new
                        {
                            Id = 5,
                            SubCategoryId = 1,
                            Title = "سرویس نظافت فوری"
                        },
                        new
                        {
                            Id = 6,
                            SubCategoryId = 1,
                            Title = "پذیرایی"
                        },
                        new
                        {
                            Id = 7,
                            SubCategoryId = 2,
                            Title = "شست و شو در محل"
                        },
                        new
                        {
                            Id = 8,
                            SubCategoryId = 2,
                            Title = "قالیشویی"
                        },
                        new
                        {
                            Id = 9,
                            SubCategoryId = 2,
                            Title = "خشکشویی"
                        },
                        new
                        {
                            Id = 10,
                            SubCategoryId = 2,
                            Title = "پرده شویی"
                        },
                        new
                        {
                            Id = 11,
                            SubCategoryId = 3,
                            Title = "تعمیر و سرویس کولر آبی"
                        },
                        new
                        {
                            Id = 12,
                            SubCategoryId = 3,
                            Title = "تعمیر کولر گازی و داکت اسپیلت"
                        },
                        new
                        {
                            Id = 13,
                            SubCategoryId = 3,
                            Title = "تعمیر و سرویس پکیج"
                        },
                        new
                        {
                            Id = 14,
                            SubCategoryId = 3,
                            Title = "تعمیر و سرویس آبگرمکن"
                        });
                });

            modelBuilder.Entity("App.Domain.Core.CategoryService.Entities.SubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MainCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("MainCategoryId");

                    b.ToTable("SubCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MainCategoryId = 1,
                            Title = "نظافت و پذیرایی"
                        },
                        new
                        {
                            Id = 2,
                            MainCategoryId = 1,
                            Title = "شستشو"
                        },
                        new
                        {
                            Id = 3,
                            MainCategoryId = 2,
                            Title = "سرمایش و گرمایش"
                        },
                        new
                        {
                            Id = 4,
                            MainCategoryId = 2,
                            Title = "تعمیرات ساختمان"
                        },
                        new
                        {
                            Id = 5,
                            MainCategoryId = 2,
                            Title = "لوله کشی"
                        },
                        new
                        {
                            Id = 6,
                            MainCategoryId = 2,
                            Title = "طراحی و بازسازی ساختمان"
                        },
                        new
                        {
                            Id = 7,
                            MainCategoryId = 2,
                            Title = "برقکاری"
                        },
                        new
                        {
                            Id = 8,
                            MainCategoryId = 2,
                            Title = "چوب و کابینت"
                        },
                        new
                        {
                            Id = 9,
                            MainCategoryId = 2,
                            Title = "باغبانی و فضای سبز"
                        },
                        new
                        {
                            Id = 10,
                            MainCategoryId = 3,
                            Title = "نصب و تعمیر لوازم خانگی"
                        },
                        new
                        {
                            Id = 11,
                            MainCategoryId = 3,
                            Title = "خدمات کامپیوتری"
                        },
                        new
                        {
                            Id = 12,
                            MainCategoryId = 3,
                            Title = "تعمیرات موبایل"
                        },
                        new
                        {
                            Id = 13,
                            MainCategoryId = 4,
                            Title = "باربری و جابجایی"
                        },
                        new
                        {
                            Id = 14,
                            MainCategoryId = 5,
                            Title = "خدمات و تعمیرات خودرو"
                        },
                        new
                        {
                            Id = 15,
                            MainCategoryId = 5,
                            Title = "کارواش و دیتیلینگ"
                        },
                        new
                        {
                            Id = 16,
                            MainCategoryId = 6,
                            Title = "زیبایی بانوان"
                        },
                        new
                        {
                            Id = 17,
                            MainCategoryId = 6,
                            Title = "پزشکی و پرستاری"
                        },
                        new
                        {
                            Id = 18,
                            MainCategoryId = 6,
                            Title = "حیوانات خانگی"
                        },
                        new
                        {
                            Id = 19,
                            MainCategoryId = 6,
                            Title = "پیرایش و زیبایی آقایان"
                        },
                        new
                        {
                            Id = 20,
                            MainCategoryId = 6,
                            Title = "تندرستی و ورزش"
                        });
                });

            modelBuilder.Entity("App.Domain.Core.Member.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("App.Domain.Core.OrderAgg.Entities.Bid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ExpertId")
                        .HasColumnType("int");

                    b.Property<string>("ExprtSujestFee")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExpertId");

                    b.HasIndex("OrderId");

                    b.ToTable("Bids");
                });

            modelBuilder.Entity("App.Domain.Core.OrderAgg.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("ExpertId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAccept")
                        .HasColumnType("bit");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ExpertId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("App.Domain.Core.OrderAgg.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int>("ServiseId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ExpertService", b =>
                {
                    b.Property<int>("ExpertsId")
                        .HasColumnType("int");

                    b.Property<int>("ServicesId")
                        .HasColumnType("int");

                    b.HasKey("ExpertsId", "ServicesId");

                    b.HasIndex("ServicesId");

                    b.ToTable("ExpertService");
                });

            modelBuilder.Entity("App.Domain.Core.Member.Entities.Customer", b =>
                {
                    b.HasBaseType("App.Domain.Core.Member.Entities.User");

                    b.HasDiscriminator().HasValue("Customer");
                });

            modelBuilder.Entity("App.Domain.Core.Member.Entities.Expert", b =>
                {
                    b.HasBaseType("App.Domain.Core.Member.Entities.User");

                    b.HasDiscriminator().HasValue("Expert");
                });

            modelBuilder.Entity("App.Domain.Core.Adress.Entities.Address", b =>
                {
                    b.HasOne("App.Domain.Core.Adress.Entities.City", "City")
                        .WithOne("Address")
                        .HasForeignKey("App.Domain.Core.Adress.Entities.Address", "CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Domain.Core.Member.Entities.User", "User")
                        .WithOne("Address")
                        .HasForeignKey("App.Domain.Core.Adress.Entities.Address", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("User");
                });

            modelBuilder.Entity("App.Domain.Core.CategoryService.Entities.Service", b =>
                {
                    b.HasOne("App.Domain.Core.CategoryService.Entities.SubCategory", "SubCategory")
                        .WithMany("Services")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("App.Domain.Core.CategoryService.Entities.SubCategory", b =>
                {
                    b.HasOne("App.Domain.Core.CategoryService.Entities.MainCategory", "MainCategory")
                        .WithMany("SubCategories")
                        .HasForeignKey("MainCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MainCategory");
                });

            modelBuilder.Entity("App.Domain.Core.OrderAgg.Entities.Bid", b =>
                {
                    b.HasOne("App.Domain.Core.Member.Entities.Expert", "Expert")
                        .WithMany()
                        .HasForeignKey("ExpertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Domain.Core.OrderAgg.Entities.Order", "Order")
                        .WithMany("Bids")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Expert");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("App.Domain.Core.OrderAgg.Entities.Comment", b =>
                {
                    b.HasOne("App.Domain.Core.Member.Entities.Customer", "Customer")
                        .WithMany("Comments")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("App.Domain.Core.Member.Entities.Expert", "Expert")
                        .WithMany("Comments")
                        .HasForeignKey("ExpertId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Expert");
                });

            modelBuilder.Entity("App.Domain.Core.OrderAgg.Entities.Order", b =>
                {
                    b.HasOne("App.Domain.Core.Member.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Domain.Core.CategoryService.Entities.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("ExpertService", b =>
                {
                    b.HasOne("App.Domain.Core.Member.Entities.Expert", null)
                        .WithMany()
                        .HasForeignKey("ExpertsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Domain.Core.CategoryService.Entities.Service", null)
                        .WithMany()
                        .HasForeignKey("ServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("App.Domain.Core.Adress.Entities.City", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("App.Domain.Core.CategoryService.Entities.MainCategory", b =>
                {
                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("App.Domain.Core.CategoryService.Entities.SubCategory", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("App.Domain.Core.Member.Entities.User", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("App.Domain.Core.OrderAgg.Entities.Order", b =>
                {
                    b.Navigation("Bids");
                });

            modelBuilder.Entity("App.Domain.Core.Member.Entities.Customer", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("App.Domain.Core.Member.Entities.Expert", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}

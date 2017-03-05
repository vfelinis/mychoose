using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MyChoose.Models;

namespace MyChoose.Migrations
{
    [DbContext(typeof(GiftContext))]
    [Migration("20170226152639_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyChoose.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CategoryName")
                        .IsUnique();

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MyChoose.Models.CategoryDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryId");

                    b.Property<int?>("GiftId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("GiftId");

                    b.ToTable("CategoryDetails");
                });

            modelBuilder.Entity("MyChoose.Models.Gift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("GiftName")
                        .IsRequired();

                    b.Property<int?>("PriceFromId");

                    b.Property<int?>("PriceToId");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("Id");

                    b.HasIndex("GiftName")
                        .IsUnique();

                    b.HasIndex("PriceFromId");

                    b.HasIndex("PriceToId");

                    b.ToTable("Gifts");
                });

            modelBuilder.Entity("MyChoose.Models.Price", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.HasIndex("Value")
                        .IsUnique();

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("MyChoose.Models.CategoryDetail", b =>
                {
                    b.HasOne("MyChoose.Models.Category", "Category")
                        .WithMany("CategoryDetails")
                        .HasForeignKey("CategoryId");

                    b.HasOne("MyChoose.Models.Gift", "Gift")
                        .WithMany("CategoryDetails")
                        .HasForeignKey("GiftId");
                });

            modelBuilder.Entity("MyChoose.Models.Gift", b =>
                {
                    b.HasOne("MyChoose.Models.Price", "PriceFrom")
                        .WithMany("GiftsPriceFrom")
                        .HasForeignKey("PriceFromId");

                    b.HasOne("MyChoose.Models.Price", "PriceTo")
                        .WithMany("GiftsPriceTo")
                        .HasForeignKey("PriceToId");
                });
        }
    }
}

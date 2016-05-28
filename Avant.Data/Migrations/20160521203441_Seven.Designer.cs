using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Avant.Data;

namespace Avant.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20160521203441_Seven")]
    partial class Seven
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Avant.Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Avant.Domain.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Mail");

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Avant.Domain.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CustomerId");

                    b.Property<DateTime>("Data");

                    b.Property<decimal>("Total");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Avant.Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryId");

                    b.Property<string>("Description");

                    b.Property<decimal>("Discount");

                    b.Property<bool>("Featured");

                    b.Property<string>("Name");

                    b.Property<string>("Photo");

                    b.Property<decimal>("Price");

                    b.Property<bool>("Promotion");

                    b.Property<int>("Stock");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Avant.Domain.ProductOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("OrderId");

                    b.Property<int>("ProductId");

                    b.Property<decimal>("Quantity");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Avant.Domain.Order", b =>
                {
                    b.HasOne("Avant.Domain.Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("Avant.Domain.Product", b =>
                {
                    b.HasOne("Avant.Domain.Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("Avant.Domain.ProductOrder", b =>
                {
                    b.HasOne("Avant.Domain.Order")
                        .WithMany()
                        .HasForeignKey("OrderId");

                    b.HasOne("Avant.Domain.Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ShangBao.Data;

namespace ShangBao.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20170311015540_efcore")]
    partial class efcore
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("ShangBao.Model.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Name");

                    b.Property<Guid?>("OwnerId");

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ShangBao.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("Age");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ShangBao.Model.Product", b =>
                {
                    b.HasOne("ShangBao.Model.User", "Owner")
                        .WithMany("Products")
                        .HasForeignKey("OwnerId");
                });
        }
    }
}

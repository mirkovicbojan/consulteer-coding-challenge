// <auto-generated />
using System;
using MainAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MainAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220806154318_NullableForeignKeys")]
    partial class NullableForeignKeys
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("MainAPI.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("CanViewAllUsers")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("roleName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("MainAPI.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("email")
                        .HasColumnType("TEXT");

                    b.Property<string>("password")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("roleID")
                        .HasColumnType("TEXT");

                    b.Property<string>("username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("roleID");

                    b.ToTable("users");
                });

            modelBuilder.Entity("MainAPI.Models.User", b =>
                {
                    b.HasOne("MainAPI.Models.Role", "role")
                        .WithMany()
                        .HasForeignKey("roleID");

                    b.Navigation("role");
                });
#pragma warning restore 612, 618
        }
    }
}

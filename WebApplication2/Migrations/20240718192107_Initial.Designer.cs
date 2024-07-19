﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication2.Models.DB;

#nullable disable

namespace WebApplication2.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240718192107_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication2.Models.DB.PlaySession", b =>
                {
                    b.Property<string>("GameId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("MinesCount")
                        .HasColumnType("int");

                    b.Property<bool>("OneMove")
                        .HasColumnType("bit");

                    b.Property<string>("ServerField")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserField")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("GameId");

                    b.ToTable("playSessions");
                });
#pragma warning restore 612, 618
        }
    }
}

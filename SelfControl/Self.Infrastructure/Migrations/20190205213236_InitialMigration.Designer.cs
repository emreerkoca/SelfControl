﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Self.Infrastructure.Data;

namespace Self.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190205213236_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Self.Core.Entities.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("WordContentId");

                    b.HasKey("Id");

                    b.HasIndex("WordContentId");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("Self.Core.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Self.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UserName")
                        .HasMaxLength(50);

                    b.Property<int?>("UserRoleId");

                    b.HasKey("Id");

                    b.HasIndex("UserRoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Self.Core.Entities.Word", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OriginalWord")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Sentence");

                    b.Property<string>("TranslatedWord")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("ViewCount");

                    b.HasKey("Id");

                    b.ToTable("Word");
                });

            modelBuilder.Entity("Self.Core.Entities.Notification", b =>
                {
                    b.HasOne("Self.Core.Entities.Word", "WordContent")
                        .WithMany()
                        .HasForeignKey("WordContentId");
                });

            modelBuilder.Entity("Self.Core.Entities.User", b =>
                {
                    b.HasOne("Self.Core.Entities.Role", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleId");
                });
#pragma warning restore 612, 618
        }
    }
}

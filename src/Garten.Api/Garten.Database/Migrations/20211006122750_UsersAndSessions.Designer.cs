// <auto-generated />
using System;
using Garten.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Garten.Database.Migrations
{
    [DbContext(typeof(GartenContext))]
    [Migration("20211006122750_UsersAndSessions")]
    partial class UsersAndSessions
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Garten.Database.Entities.Admin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<long>("Phone")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Phone")
                        .IsUnique()
                        .HasFilter("\"IsDeleted\" != true");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Garten.Database.Entities.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("\"IsDeleted\" != true");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Garten.Database.Entities.Kid", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Patronymic")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Kids");
                });

            modelBuilder.Entity("Garten.Database.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateLastLogin")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<long>("Phone")
                        .HasColumnType("bigint");

                    b.Property<int[]>("Roles")
                        .HasColumnType("integer[]");

                    b.HasKey("Id");

                    b.HasIndex("Phone")
                        .IsUnique()
                        .HasFilter("\"IsDeleted\" != true");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Garten.Database.Entities.UserKid", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("KidId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("KidId");

                    b.HasIndex("UserId", "KidId")
                        .IsUnique()
                        .HasFilter("\"IsDeleted\" != true");

                    b.ToTable("UserKids");
                });

            modelBuilder.Entity("Garten.Database.Entities.UserSession", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("UserSessions");
                });

            modelBuilder.Entity("Garten.Database.Entities.Kid", b =>
                {
                    b.HasOne("Garten.Database.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Garten.Database.Entities.UserKid", b =>
                {
                    b.HasOne("Garten.Database.Entities.Kid", "Kid")
                        .WithMany()
                        .HasForeignKey("KidId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Garten.Database.Entities.User", "User")
                        .WithMany("Kids")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kid");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Garten.Database.Entities.User", b =>
                {
                    b.Navigation("Kids");
                });
#pragma warning restore 612, 618
        }
    }
}

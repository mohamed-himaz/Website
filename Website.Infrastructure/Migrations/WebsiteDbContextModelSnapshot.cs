﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Website.Infrastructure;

namespace Website.Infrastructure.Migrations
{
    [DbContext(typeof(WebsiteDbContext))]
    partial class WebsiteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Website.Infrastructure.Entities.DepartmentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("175f26be-6bbf-45be-932d-9b312f545c94"),
                            Name = "ИУ-2 КФ"
                        });
                });

            modelBuilder.Entity("Website.Infrastructure.Entities.DepartmentTeacherRelations.DepartmentTeacherRelationEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDepartmentHead")
                        .HasColumnType("boolean");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uuid");

                    b.Property<int>("TeachingType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("TeacherId")
                        .IsUnique();

                    b.ToTable("DepartmentTeacherRelations");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d956fe49-59a3-4221-90b7-c1b8c1bd18e6"),
                            DepartmentId = new Guid("175f26be-6bbf-45be-932d-9b312f545c94"),
                            IsDepartmentHead = false,
                            TeacherId = new Guid("c8051737-f9fe-4532-97fe-7030d2e5609d"),
                            TeachingType = 0
                        },
                        new
                        {
                            Id = new Guid("1fd6747e-e987-4a5a-b152-6040307eefd4"),
                            DepartmentId = new Guid("175f26be-6bbf-45be-932d-9b312f545c94"),
                            IsDepartmentHead = false,
                            TeacherId = new Guid("b0a631e3-0c97-4bc5-88c0-718ed77d7e94"),
                            TeachingType = 0
                        },
                        new
                        {
                            Id = new Guid("44557e25-d2c8-4b74-b1bb-e0fc73bd0c7d"),
                            DepartmentId = new Guid("175f26be-6bbf-45be-932d-9b312f545c94"),
                            IsDepartmentHead = true,
                            TeacherId = new Guid("c6fc9241-51f2-467c-9f59-23f73b358e3f"),
                            TeachingType = 0
                        });
                });

            modelBuilder.Entity("Website.Infrastructure.Entities.MediaContentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FileName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MediaContents");
                });

            modelBuilder.Entity("Website.Infrastructure.Entities.QuestionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("QuestionerName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Website.Infrastructure.Entities.TeacherEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AdditionalInfo")
                        .HasColumnType("text");

                    b.Property<string>("Degree")
                        .HasColumnType("text");

                    b.Property<Guid?>("DepartmentRelationId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .HasColumnType("text");

                    b.Property<Guid?>("PictureId")
                        .HasColumnType("uuid");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c8051737-f9fe-4532-97fe-7030d2e5609d"),
                            Degree = "кандидат технических наук, доцент",
                            Name = "Борсук",
                            Patronymic = "Александровна",
                            Surname = "Наталья"
                        },
                        new
                        {
                            Id = new Guid("b0a631e3-0c97-4bc5-88c0-718ed77d7e94"),
                            Degree = "кандидат технических наук, доцент",
                            Name = "Дерюгина",
                            Patronymic = "Олеговна",
                            Surname = "Елена"
                        },
                        new
                        {
                            Id = new Guid("c6fc9241-51f2-467c-9f59-23f73b358e3f"),
                            Degree = "кандидат технических наук, доцент",
                            Name = "Игорь",
                            Patronymic = "Владимирович",
                            Surname = "Чухраев"
                        });
                });

            modelBuilder.Entity("Website.Infrastructure.Entities.DepartmentTeacherRelations.DepartmentTeacherRelationEntity", b =>
                {
                    b.HasOne("Website.Infrastructure.Entities.DepartmentEntity", "Department")
                        .WithMany("TeacherRelations")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Website.Infrastructure.Entities.TeacherEntity", "Teacher")
                        .WithOne("DepartmentRelation")
                        .HasForeignKey("Website.Infrastructure.Entities.DepartmentTeacherRelations.DepartmentTeacherRelationEntity", "TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

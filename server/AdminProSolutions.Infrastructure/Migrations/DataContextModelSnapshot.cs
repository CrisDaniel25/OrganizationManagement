﻿// <auto-generated />
using System;
using AdminProSolutions.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AdminProSolutions.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AdminProSolutions.Domain.Entities.Authentication.AccessTypes", b =>
                {
                    b.Property<int>("AccessTypeId")
                        .HasColumnType("int");

                    b.Property<string>("AccessTypeDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<bool?>("AccessTypeIsDefault")
                        .HasColumnType("bit");

                    b.Property<string>("AccessTypeStatus")
                        .IsRequired()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("char(1)")
                        .IsFixedLength();

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2024, 2, 27, 16, 50, 22, 645, DateTimeKind.Utc).AddTicks(5854));

                    b.Property<int?>("CreatedUser")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2024, 2, 27, 16, 50, 22, 645, DateTimeKind.Utc).AddTicks(7336));

                    b.Property<int?>("UpdatedUser")
                        .HasColumnType("int");

                    b.HasKey("AccessTypeId");

                    b.HasIndex("CreatedUser")
                        .HasDatabaseName("IX_AccessTypes, UserId");

                    b.ToTable("AccessTypes");
                });

            modelBuilder.Entity("AdminProSolutions.Domain.Entities.Authentication.Forms", b =>
                {
                    b.Property<int>("FormId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2024, 2, 27, 16, 50, 22, 646, DateTimeKind.Utc).AddTicks(3600));

                    b.Property<int?>("CreatedUser")
                        .HasColumnType("int");

                    b.Property<string>("FormDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FormModule")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("FormName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2024, 2, 27, 16, 50, 22, 646, DateTimeKind.Utc).AddTicks(5902));

                    b.Property<int?>("UpdatedUser")
                        .HasColumnType("int");

                    b.HasKey("FormId");

                    b.ToTable("Forms");
                });

            modelBuilder.Entity("AdminProSolutions.Domain.Entities.Authentication.FormsAccessTypes", b =>
                {
                    b.Property<int>("FormAccessTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FormAccessTypeId"));

                    b.Property<int>("AccessTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2024, 2, 27, 16, 50, 22, 647, DateTimeKind.Utc).AddTicks(2811));

                    b.Property<int?>("CreatedUser")
                        .HasColumnType("int");

                    b.Property<int>("FormId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2024, 2, 27, 16, 50, 22, 647, DateTimeKind.Utc).AddTicks(4333));

                    b.Property<int?>("UpdatedUser")
                        .HasColumnType("int");

                    b.HasKey("FormAccessTypeId");

                    b.HasIndex("FormId");

                    b.ToTable("FormsAccessTypes");
                });

            modelBuilder.Entity("AdminProSolutions.Domain.Entities.Authentication.GroupFormsAccessTypes", b =>
                {
                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("FormAccessTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2024, 2, 27, 16, 50, 22, 649, DateTimeKind.Utc).AddTicks(568));

                    b.Property<int?>("CreatedUser")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2024, 2, 27, 16, 50, 22, 649, DateTimeKind.Utc).AddTicks(2469));

                    b.Property<int?>("UpdatedUser")
                        .HasColumnType("int");

                    b.HasKey("GroupId", "FormAccessTypeId");

                    b.HasIndex("FormAccessTypeId");

                    b.ToTable("GroupFormsAccessTypes");
                });

            modelBuilder.Entity("AdminProSolutions.Domain.Entities.Authentication.Groups", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupId"));

                    b.Property<string>("ActiveDirectoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2024, 2, 27, 16, 50, 22, 650, DateTimeKind.Utc).AddTicks(6069));

                    b.Property<int?>("CreatedUser")
                        .HasColumnType("int");

                    b.Property<string>("GroupDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("GroupStatus")
                        .IsRequired()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("char(1)")
                        .IsFixedLength();

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2024, 2, 27, 16, 50, 22, 650, DateTimeKind.Utc).AddTicks(8068));

                    b.Property<int?>("UpdatedUser")
                        .HasColumnType("int");

                    b.HasKey("GroupId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("AdminProSolutions.Domain.Entities.Authentication.GroupsUsers", b =>
                {
                    b.Property<int>("GroupUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupUserId"));

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2024, 2, 27, 16, 50, 22, 651, DateTimeKind.Utc).AddTicks(1145));

                    b.Property<int?>("CreatedUser")
                        .HasColumnType("int");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsSendAllTimeMail")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsSendInitialMail")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsSendTimeMail")
                        .HasColumnType("bit");

                    b.Property<int?>("TimeToSendMail")
                        .HasColumnType("int");

                    b.Property<string>("TimeType")
                        .IsRequired()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("char(1)")
                        .IsFixedLength();

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2024, 2, 27, 16, 50, 22, 651, DateTimeKind.Utc).AddTicks(3057));

                    b.Property<int?>("UpdatedUser")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserOrder")
                        .HasColumnType("int");

                    b.HasKey("GroupUserId");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("GroupsUsers");
                });

            modelBuilder.Entity("AdminProSolutions.Domain.Entities.Authentication.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateTime?>("ActiveDateBegin")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("ActiveDateEnd")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2024, 2, 27, 16, 50, 22, 652, DateTimeKind.Utc).AddTicks(7084));

                    b.Property<int?>("CreatedUser")
                        .HasColumnType("int");

                    b.Property<byte[]>("HashPassword")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varbinary(250)");

                    b.Property<bool?>("IsPasswordExpires")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("PasswordExpiresDate")
                        .HasColumnType("datetime");

                    b.Property<int>("PasswordFailedQuantity")
                        .HasColumnType("int");

                    b.Property<string>("TypeAutentication")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("char(2)")
                        .HasDefaultValueSql("('AD')")
                        .IsFixedLength();

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2024, 2, 27, 16, 50, 22, 653, DateTimeKind.Utc).AddTicks(1200));

                    b.Property<int?>("UpdatedUser")
                        .HasColumnType("int");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("UserLogin")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .IsUnicode(false)
                        .HasColumnType("varchar(75)");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<bool?>("UserPasswordHasBeenReset")
                        .HasColumnType("bit");

                    b.Property<string>("UserPhone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("UserSecretAnswer")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("UserSecretQuestion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("UserStatus")
                        .IsRequired()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("char(1)")
                        .IsFixedLength();

                    b.HasKey("UserId");

                    b.HasIndex("UserLogin")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AdminProSolutions.Domain.Entities.Miscellaneous.Audit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ChangeBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("KeyValues")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewValues")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OldValues")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Operation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Audits");
                });

            modelBuilder.Entity("AdminProSolutions.Domain.Entities.Organization.Clients", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"));

                    b.Property<int>("CompanySize")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2024, 2, 27, 16, 50, 22, 654, DateTimeKind.Utc).AddTicks(7292));

                    b.Property<int?>("CreatedUser")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Founded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Headquarters")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Industry")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2024, 2, 27, 16, 50, 22, 654, DateTimeKind.Utc).AddTicks(8207));

                    b.Property<int?>("UpdatedUser")
                        .HasColumnType("int");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ClientId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("AdminProSolutions.Domain.Entities.Organization.Employees", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2024, 2, 27, 16, 50, 22, 656, DateTimeKind.Utc).AddTicks(8817));

                    b.Property<int?>("CreatedUser")
                        .HasColumnType("int");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("char(1)")
                        .IsFixedLength();

                    b.Property<string>("IdentityDocument")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("StartDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2024, 2, 27, 16, 50, 22, 656, DateTimeKind.Utc).AddTicks(1107));

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2024, 2, 27, 16, 50, 22, 657, DateTimeKind.Utc).AddTicks(625));

                    b.Property<int?>("UpdatedUser")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("ClientId");

                    b.HasIndex("IdentityDocument")
                        .IsUnique();

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("AdminProSolutions.Domain.Entities.Authentication.FormsAccessTypes", b =>
                {
                    b.HasOne("AdminProSolutions.Domain.Entities.Authentication.Forms", "Form")
                        .WithMany("FormsAccessTypes")
                        .HasForeignKey("FormId")
                        .IsRequired()
                        .HasConstraintName("FK_FormsAccessTypes_Forms");

                    b.Navigation("Form");
                });

            modelBuilder.Entity("AdminProSolutions.Domain.Entities.Authentication.GroupFormsAccessTypes", b =>
                {
                    b.HasOne("AdminProSolutions.Domain.Entities.Authentication.FormsAccessTypes", "FormAccessType")
                        .WithMany("GroupFormsAccessTypes")
                        .HasForeignKey("FormAccessTypeId")
                        .IsRequired()
                        .HasConstraintName("FK_GroupFormsAccessTypes_FormsAccessTypes");

                    b.HasOne("AdminProSolutions.Domain.Entities.Authentication.Groups", "Group")
                        .WithMany("GroupFormsAccessTypes")
                        .HasForeignKey("GroupId")
                        .IsRequired()
                        .HasConstraintName("FK_GroupFormsAccessTypes_Groups");

                    b.Navigation("FormAccessType");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("AdminProSolutions.Domain.Entities.Authentication.GroupsUsers", b =>
                {
                    b.HasOne("AdminProSolutions.Domain.Entities.Authentication.Groups", "Group")
                        .WithMany("GroupsUsers")
                        .HasForeignKey("GroupId")
                        .IsRequired()
                        .HasConstraintName("FK_GroupsUsers_Groups");

                    b.HasOne("AdminProSolutions.Domain.Entities.Authentication.Users", "User")
                        .WithMany("GroupUsers")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_GroupsUsers_Users");

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AdminProSolutions.Domain.Entities.Organization.Employees", b =>
                {
                    b.HasOne("AdminProSolutions.Domain.Entities.Organization.Clients", "Client")
                        .WithMany("Employees")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Employees_Client");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("AdminProSolutions.Domain.Entities.Authentication.Forms", b =>
                {
                    b.Navigation("FormsAccessTypes");
                });

            modelBuilder.Entity("AdminProSolutions.Domain.Entities.Authentication.FormsAccessTypes", b =>
                {
                    b.Navigation("GroupFormsAccessTypes");
                });

            modelBuilder.Entity("AdminProSolutions.Domain.Entities.Authentication.Groups", b =>
                {
                    b.Navigation("GroupFormsAccessTypes");

                    b.Navigation("GroupsUsers");
                });

            modelBuilder.Entity("AdminProSolutions.Domain.Entities.Authentication.Users", b =>
                {
                    b.Navigation("GroupUsers");
                });

            modelBuilder.Entity("AdminProSolutions.Domain.Entities.Organization.Clients", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}

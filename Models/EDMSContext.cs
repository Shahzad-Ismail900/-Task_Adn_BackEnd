using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CRUD.Models
{
    public partial class EDMSContext : DbContext
    {
        public EDMSContext()
        {
        }

        public EDMSContext(DbContextOptions<EDMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppUser> AppUser { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeStatus> EmployeeStatus { get; set; }
        public virtual DbSet<EmployeeType> EmployeeType { get; set; }
        public virtual DbSet<LogUserActivity> LogUserActivity { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=KHILT-7862;Database=EDMS;Trusted_Connection=False;User Id =sa; Password=12345;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__AppUser__1788CC4CB18A2A81");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName).HasMaxLength(100);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptId)
                    .HasName("PK__Departme__014881AE78086B21");

                entity.Property(e => e.Code).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__Employee__AF2DBB9942947968");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.ContactNo).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.DeptId)
                    .HasConstraintName("FK_Employee_Department");

                entity.HasOne(d => d.EmpStatus)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.EmpStatusId)
                    .HasConstraintName("FK_Employee_EmployeeStatus");

                entity.HasOne(d => d.EmpType)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.EmpTypeId)
                    .HasConstraintName("FK_Employee_EmployeeType");
            });

            modelBuilder.Entity<EmployeeStatus>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(100);
            });

            modelBuilder.Entity<EmployeeType>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(100);
            });

            modelBuilder.Entity<LogUserActivity>(entity =>
            {
                entity.Property(e => e.Action).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.FormName).HasMaxLength(100);

                entity.Property(e => e.LogTime).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

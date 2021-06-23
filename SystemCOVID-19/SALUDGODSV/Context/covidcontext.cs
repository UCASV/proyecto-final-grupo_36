using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SALUDGODSV.Models;

#nullable disable

namespace SALUDGODSV.Context
{
    public partial class covidcontext : DbContext
    {
        public covidcontext()
        {
        }

        public covidcontext(DbContextOptions<covidcontext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccessLog> AccessLogs { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Cabin> Cabins { get; set; }
        public virtual DbSet<Citizen> Citizens { get; set; }
        public virtual DbSet<CitizenxsecondaryEffect> CitizenxsecondaryEffects { get; set; }
        public virtual DbSet<Citizenxsickness> Citizenxsicknesses { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<GobInstitution> GobInstitutions { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<SecondaryEffect> SecondaryEffects { get; set; }
        public virtual DbSet<SecurityQuestion> SecurityQuestions { get; set; }
        public virtual DbSet<Sickness> Sicknesses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;database=systemcovid_19db;user=root;password=admin");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessLog>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PRIMARY");

                entity.ToTable("access_log");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Hour).HasColumnName("hour");
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PRIMARY");

                entity.ToTable("appointment");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("city");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Departament)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("departament")
                    .IsFixedLength(true);

                entity.Property(e => e.Dose)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("dose")
                    .IsFixedLength(true);

                entity.Property(e => e.Hour).HasColumnName("hour");
            });

            modelBuilder.Entity<Cabin>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PRIMARY");

                entity.ToTable("cabin");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Caretaker)
                    .IsRequired()
                    .HasMaxLength(75)
                    .HasColumnName("caretaker");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("city");

                entity.Property(e => e.Departament)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("departament")
                    .IsFixedLength(true);

                entity.Property(e => e.EmployeeCode).HasColumnName("employee_code");

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(75)
                    .HasColumnName("mail");

                entity.Property(e => e.Phone).HasColumnName("phone");
            });

            modelBuilder.Entity<Citizen>(entity =>
            {
                entity.HasKey(e => e.Dui)
                    .HasName("PRIMARY");

                entity.ToTable("citizen");

                entity.HasIndex(e => e.AppointmentId, "FK_citizen_appointment");

                entity.HasIndex(e => e.GobInstitutionId, "FK_citizen_gob");

                entity.Property(e => e.Dui).HasColumnName("DUI");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.AppointmentId).HasColumnName("Appointment_id");

                entity.Property(e => e.AssociateNumber).HasColumnName("associate_number");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("city");

                entity.Property(e => e.Departament)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("departament")
                    .IsFixedLength(true);

                entity.Property(e => e.GobInstitutionId).HasColumnName("GOB_institution_id");

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(75)
                    .HasColumnName("mail");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(75)
                    .HasColumnName("name");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.Citizens)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK_citizen_appointment");

                entity.HasOne(d => d.GobInstitution)
                    .WithMany(p => p.Citizens)
                    .HasForeignKey(d => d.GobInstitutionId)
                    .HasConstraintName("FK_citizen_gob");
            });

            modelBuilder.Entity<CitizenxsecondaryEffect>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PRIMARY");

                entity.ToTable("citizenxsecondary_effect");

                entity.HasIndex(e => e.SecondaryeffectCode, "FK_citizenxseccondary_effect_code");

                entity.HasIndex(e => e.CitizenDui, "FK_citizenxseccondary_effect_dui");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.CitizenDui).HasColumnName("citizen_dui");

                entity.Property(e => e.SecondaryeffectCode).HasColumnName("secondaryeffect_code");

                entity.HasOne(d => d.CitizenDuiNavigation)
                    .WithMany(p => p.CitizenxsecondaryEffects)
                    .HasForeignKey(d => d.CitizenDui)
                    .HasConstraintName("FK_citizenxseccondary_effect_dui");

                entity.HasOne(d => d.SecondaryeffectCodeNavigation)
                    .WithMany(p => p.CitizenxsecondaryEffects)
                    .HasForeignKey(d => d.SecondaryeffectCode)
                    .HasConstraintName("FK_citizenxseccondary_effect_code");
            });

            modelBuilder.Entity<Citizenxsickness>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PRIMARY");

                entity.ToTable("citizenxsickness");

                entity.HasIndex(e => e.SicknessCode, "FK_citizenxsickeness_code");

                entity.HasIndex(e => e.CitizenDui, "FK_citizenxsickeness_dui");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.CitizenDui).HasColumnName("citizen_dui");

                entity.Property(e => e.SicknessCode).HasColumnName("sickness_code");

                entity.HasOne(d => d.CitizenDuiNavigation)
                    .WithMany(p => p.Citizenxsicknesses)
                    .HasForeignKey(d => d.CitizenDui)
                    .HasConstraintName("FK_citizenxsickeness_dui");

                entity.HasOne(d => d.SicknessCodeNavigation)
                    .WithMany(p => p.Citizenxsicknesses)
                    .HasForeignKey(d => d.SicknessCode)
                    .HasConstraintName("FK_citizenxsickeness_code");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PRIMARY");

                entity.ToTable("employee");

                entity.HasIndex(e => e.CodeAccesslog, "FK_employee_accesslog");

                entity.HasIndex(e => e.CodeAppointment, "FK_employee_appointment");

                entity.HasIndex(e => e.CodeSecurityQuestion, "FK_employee_securityquestion");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("city");

                entity.Property(e => e.CodeAccesslog).HasColumnName("code_accesslog");

                entity.Property(e => e.CodeAppointment).HasColumnName("code_appointment");

                entity.Property(e => e.CodeSecurityQuestion).HasColumnName("code_security_question");

                entity.Property(e => e.Departament)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("departament")
                    .IsFixedLength(true);

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(75)
                    .HasColumnName("mail");

                entity.Property(e => e.Occupation)
                    .IsRequired()
                    .HasMaxLength(75)
                    .HasColumnName("occupation");

                entity.Property(e => e.SecurityAnswer)
                    .IsRequired()
                    .HasMaxLength(90)
                    .HasColumnName("security_answer");

                entity.HasOne(d => d.CodeAccesslogNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.CodeAccesslog)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_employee_accesslog");

                entity.HasOne(d => d.CodeAppointmentNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.CodeAppointment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_employee_appointment");

                entity.HasOne(d => d.CodeSecurityQuestionNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.CodeSecurityQuestion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_employee_securityquestion");
            });

            modelBuilder.Entity<GobInstitution>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PRIMARY");

                entity.ToTable("gob_institution");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Institution)
                    .IsRequired()
                    .HasMaxLength(75)
                    .HasColumnName("institution");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PRIMARY");

                entity.ToTable("manager");

                entity.HasIndex(e => e.CodeCabin, "FK_manager_cabin");

                entity.HasIndex(e => e.CodeEmployee, "FK_manager_employee");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.CodeCabin).HasColumnName("code_cabin");

                entity.Property(e => e.CodeEmployee).HasColumnName("code_employee");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(75)
                    .HasColumnName("password");

                entity.Property(e => e.User)
                    .IsRequired()
                    .HasMaxLength(75)
                    .HasColumnName("user");

                entity.HasOne(d => d.CodeCabinNavigation)
                    .WithMany(p => p.Managers)
                    .HasForeignKey(d => d.CodeCabin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_manager_cabin");

                entity.HasOne(d => d.CodeEmployeeNavigation)
                    .WithMany(p => p.Managers)
                    .HasForeignKey(d => d.CodeEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_manager_employee");
            });

            modelBuilder.Entity<SecondaryEffect>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PRIMARY");

                entity.ToTable("secondary_effect");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.SecondaryEffect1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("secondary_effect");
            });

            modelBuilder.Entity<SecurityQuestion>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PRIMARY");

                entity.ToTable("security_question");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.SecurityQuestion1)
                    .IsRequired()
                    .HasMaxLength(90)
                    .HasColumnName("security_question");
            });

            modelBuilder.Entity<Sickness>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PRIMARY");

                entity.ToTable("sickness");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Sickness1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("sickness");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

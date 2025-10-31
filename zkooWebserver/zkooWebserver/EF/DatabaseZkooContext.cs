using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using zkooWebserver.Models;

namespace zkooWebserver.EF;

public partial class DatabaseZkooContext : DbContext
{
    public DatabaseZkooContext()
    {
    }

    public DatabaseZkooContext(DbContextOptions<DatabaseZkooContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("PK__Doctors__2DC00EDF1FD11B57");

            entity.Property(e => e.DoctorId).HasColumnName("DoctorID");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PatientId).HasColumnName("PatientID");

            entity.HasOne(d => d.Patient).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_Doctor_Patient");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patients__970EC346D0935B96");

            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.Diagnosis).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<zkooWebserver.Models.Appointment> Appointment { get; set; } = default!;
}

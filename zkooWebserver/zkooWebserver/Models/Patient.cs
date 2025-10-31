using System;
using System.Collections.Generic;

namespace zkooWebserver.Models;

public partial class Patient
{
    public int PatientId { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public string? Diagnosis { get; set; }

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}

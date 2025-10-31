using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace zkooWebserver.Models;

public partial class Doctor : IdentityUser
{
    public int DoctorId { get; set; }

    public string Name { get; set; } = null!;

    public int? PatientId { get; set; }

    public virtual Patient? Patient { get; set; }
}

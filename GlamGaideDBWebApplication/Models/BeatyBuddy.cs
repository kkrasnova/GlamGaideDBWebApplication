using System;
using System.Collections.Generic;

namespace GlamGaideDBWebApplication.Models;

public partial class BeatyBuddy
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public virtual ICollection<Consultation> Consultations { get; } = new List<Consultation>();
}

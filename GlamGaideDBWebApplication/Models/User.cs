using System;
using System.Collections.Generic;

namespace GlamGaideDBWebApplication.Models;

public partial class User
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public string? SkinTypeId { get; set; }

    public string? Email { get; set; }

    public string? Bio { get; set; }

    public virtual ICollection<Consultation> Consultations { get; } = new List<Consultation>();

    public virtual SkinType? SkinType { get; set; }

    public virtual ICollection<VideoTutorial> VideoTutorials { get; } = new List<VideoTutorial>();
}

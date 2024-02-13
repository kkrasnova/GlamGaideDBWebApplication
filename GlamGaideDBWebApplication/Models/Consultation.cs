using System;
using System.Collections.Generic;

namespace GlamGaideDBWebApplication.Models;

public partial class Consultation
{
    public string Id { get; set; } = null!;

    public string? UserId { get; set; }

    public string? BeatyBuddyId { get; set; }

    public TimeSpan? Date { get; set; }

    public string? Question { get; set; }

    public string? Response { get; set; }

    public virtual BeatyBuddy? BeatyBuddy { get; set; }

    public virtual ICollection<ConsultationTip> ConsultationTips { get; } = new List<ConsultationTip>();

    public virtual User? User { get; set; }
}

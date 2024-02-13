using System;
using System.Collections.Generic;

namespace GlamGaideDBWebApplication.Models;

public partial class ConsultationTip
{
    public string Id { get; set; } = null!;

    public string? ConsultationId { get; set; }

    public string? TipId { get; set; }

    public virtual Consultation? Consultation { get; set; }

    public virtual Tip? Tip { get; set; }
}

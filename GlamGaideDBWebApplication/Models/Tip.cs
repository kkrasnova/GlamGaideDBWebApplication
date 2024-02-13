using System;
using System.Collections.Generic;

namespace GlamGaideDBWebApplication.Models;

public partial class Tip
{
    public string Id { get; set; } = null!;

    public string? Title { get; set; }

    public string? Content { get; set; }

    public string? TipType { get; set; }

    public virtual ICollection<ConsultationTip> ConsultationTips { get; } = new List<ConsultationTip>();

    public virtual ICollection<ProductTip> ProductTips { get; } = new List<ProductTip>();
}

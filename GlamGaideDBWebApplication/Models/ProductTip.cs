using System;
using System.Collections.Generic;

namespace GlamGaideDBWebApplication.Models;

public partial class ProductTip
{
    public string Id { get; set; } = null!;

    public string? ProductId { get; set; }

    public string? TipId { get; set; }

    public virtual CosmeticProduct? Product { get; set; }

    public virtual Tip? Tip { get; set; }
}

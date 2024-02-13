using System;
using System.Collections.Generic;

namespace GlamGaideDBWebApplication.Models;

public partial class CosmeticProduct
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public string? Brand { get; set; }

    public string? SkinTypeId { get; set; }

    public virtual ICollection<ProductTip> ProductTips { get; } = new List<ProductTip>();

    public virtual SkinType? SkinType { get; set; }
}

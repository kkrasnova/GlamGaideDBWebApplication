using System;
using System.Collections.Generic;

namespace GlamGaideDBWebApplication.Models;

public partial class SkinType
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<CosmeticProduct> CosmeticProducts { get; } = new List<CosmeticProduct>();

    public virtual ICollection<User> Users { get; } = new List<User>();
}

using System;
using System.Collections.Generic;

namespace GlamGaideDBWebApplication.Models;

public partial class VideoTutorial
{
    public string Id { get; set; } = null!;

    public string? Type { get; set; }

    public string? VideoLink { get; set; }

    public string? Description { get; set; }

    public string? Category { get; set; }

    public string? AuthorId { get; set; }

    public virtual User? Author { get; set; }
}

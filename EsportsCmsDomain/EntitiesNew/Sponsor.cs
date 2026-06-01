using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EsportsCmsDomain.EntitiesNew;

public partial class Sponsor
{
    [Key]

    public int SponsorId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string SponsorTier { get; set; } = null!;
}

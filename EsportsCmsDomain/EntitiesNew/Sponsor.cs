using System;
using System.Collections.Generic;

namespace EsportsCmsDomain.EntitiesNew;

public partial class Sponsor
{
    public int SponsorId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string SponsorTier { get; set; } = null!;
}

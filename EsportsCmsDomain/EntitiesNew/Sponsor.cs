using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EsportsCmsDomain.EntitiesNew;

[Keyless]
public partial class Sponsor
{
    public int SponsorId { get; set; }

    [StringLength(100)]
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    [StringLength(500)]
    public string? SponsorImageUrl { get; set; }

    [StringLength(50)]
    public string SponsorTier { get; set; } = null!;
}

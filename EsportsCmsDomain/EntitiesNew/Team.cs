using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EsportsCmsDomain.EntitiesNew;

[Keyless]
public partial class Team
{
    public int TeamId { get; set; }

    public int CollegeId { get; set; }

    [StringLength(100)]
    public string Title { get; set; } = null!;
}

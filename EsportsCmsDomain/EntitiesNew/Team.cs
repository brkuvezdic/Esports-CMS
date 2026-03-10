using System;
using System.Collections.Generic;

namespace EsportsCmsDomain.EntitiesNew;

public partial class Team
{
    public int TeamId { get; set; }

    public int CollegeId { get; set; }

    public string Title { get; set; } = null!;
}

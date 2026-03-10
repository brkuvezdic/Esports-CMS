using System;
using System.Collections.Generic;

namespace EsportsCmsDomain.EntitiesNew;

public partial class College
{
    public int CollegeId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public int Sequence { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}

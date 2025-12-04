using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EsportsCmsDomain.EntitiesNew;

public partial class College
{
    [Key]
    public int CollegeId { get; set; }

    [StringLength(100)]
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public int CreatedBy { get; set; }
    public int Sequence { get; set; } = 9999;
    public DateTime CreatedOn { get; set; }
}

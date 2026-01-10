using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EsportsCmsDomain.EntitiesNew;

[Table("CalendarEvents")]
public partial class CalendarEvent
{
    [Key]
    public Guid Id { get; set; }

    [StringLength(200)]
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTimeOffset StartDate { get; set; }

    public DateTimeOffset EndDate { get; set; }

    public bool AllDay { get; set; }

    [StringLength(20)]
    public string? ColorPrimary { get; set; }

    [StringLength(20)]
    public string? ColorSecondary { get; set; }

    public bool IsPublished { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }
}

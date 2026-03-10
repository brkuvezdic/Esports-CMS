using System;
using System.Collections.Generic;

namespace EsportsCmsDomain.EntitiesNew;

public partial class CalendarEvent
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTimeOffset StartDate { get; set; }

    public DateTimeOffset EndDate { get; set; }

    public bool AllDay { get; set; }

    public string? ColorPrimary { get; set; }

    public string? ColorSecondary { get; set; }

    public bool IsPublished { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }
}

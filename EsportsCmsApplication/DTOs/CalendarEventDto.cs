using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsCmsApplication.DTOs
{
    public class CalendarEventDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public bool AllDay { get; set; }
        public string? ColorPrimary { get; set; }
        public bool IsPublished { get; set; }
    }

    public class CreateCalendarEventDto
    {
        [Required, MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public bool AllDay { get; set; }
        public string? ColorPrimary { get; set; }
        public bool IsPublished { get; set; }
    }

    public class UpdateCalendarEventDto : CreateCalendarEventDto
    {
        [Required]
        public Guid Id { get; set; }
    }


}

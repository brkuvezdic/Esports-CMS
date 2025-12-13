using System;

namespace EsportsCmsApplication.DTOs
{
    public class PandaScoreMatchDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? BeginAt { get; set; }
        public string Status { get; set; }

        public string StreamUrl { get; set; }
    }
}

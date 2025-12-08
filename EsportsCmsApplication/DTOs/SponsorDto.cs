using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsCmsApplication.DTOs
{
    public class SponsorDto
    {

            public int SponsorId { get; set; }
            public required string Title { get; set; }
            public string Description { get; set; } = string.Empty;
            public string SponsorTier { get; set; } = null!;
    }

    public class CreateSponsorDto
    {
        [Required]
        [MaxLength(100)]
        public required string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public string SponsorTier { get; set; } = null!;

    }

}


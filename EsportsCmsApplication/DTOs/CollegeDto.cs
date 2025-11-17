using System;
using System.ComponentModel.DataAnnotations;

namespace EsportsCmsApplication.DTOs
{
    public class CollegeDto
    {
        public int CollegeId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
    }

    // DTO for creating a new college
    public class CreateCollegeDto
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }
        public string? LogoPath { get; set; }
    }

    // DTO for updating an entire college
    public class UpdateCollegeDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }
        public string? LogoPath { get; set; }
    }

    // DTO for updating only the college description
    public class UpdateCollegeDescriptionDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;
    }
}

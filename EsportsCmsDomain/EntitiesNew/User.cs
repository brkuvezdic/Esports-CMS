using System;
using System.Collections.Generic;

namespace EsportsCmsDomain.EntitiesNew;

public partial class User
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string? RefreshToken { get; set; }

    public DateTime? RefreshTokenExpiryTime { get; set; }

    public int? CollegeId { get; set; }

    public virtual College? College { get; set; }
}

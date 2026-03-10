using System;
using System.Collections.Generic;

namespace EsportsCmsDomain.EntitiesNew;

public partial class UserProfile
{
    public int UserId { get; set; }

    public string DisplayName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string AdObjId { get; set; } = null!;

    public string? ProfileImageUrl { get; set; }

    public DateTime CreatedOn { get; set; }

    public virtual ICollection<UserActivityLog> UserActivityLogs { get; set; } = new List<UserActivityLog>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}

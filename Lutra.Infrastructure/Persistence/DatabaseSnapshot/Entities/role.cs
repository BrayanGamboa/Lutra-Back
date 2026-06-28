using System;
using System.Collections.Generic;

namespace Lutra.Infrastructure.Persistence.DatabaseSnapshot.Entities;

public partial class role
{
    public int role_id { get; set; }

    public string name { get; set; } = null!;

    public string? description { get; set; }

    public DateTime? create_at { get; set; }

    public DateTime? update_at { get; set; }

    public virtual ICollection<role_users_detail> role_users_details { get; set; } = new List<role_users_detail>();
}

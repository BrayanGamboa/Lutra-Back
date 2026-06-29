using System;
using System.Collections.Generic;

namespace Lutra.Infrastructure.Persistence.DatabaseSnapshot.Entities;

public partial class user
{
    public Guid user_id { get; set; }

    public string name { get; set; } = null!;

    public string email { get; set; } = null!;

    public string password_hash { get; set; } = null!;

    public bool? is_active { get; set; }

    public DateTime? create_at { get; set; }

    public DateTime? update_at { get; set; }

    public string? user_name { get; set; }

    public DateTime? last_login_at { get; set; }

    public string? lastname { get; set; }

    public virtual ICollection<customer_details_info> customer_details_infos { get; set; } = new List<customer_details_info>();

    public virtual ICollection<role_users_detail> role_users_details { get; set; } = new List<role_users_detail>();

    public virtual ICollection<sale> sales { get; set; } = new List<sale>();
}

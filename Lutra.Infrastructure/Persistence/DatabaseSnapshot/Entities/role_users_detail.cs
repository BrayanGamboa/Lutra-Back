using System;
using System.Collections.Generic;

namespace Lutra.Infrastructure.Persistence.DatabaseSnapshot.Entities;

public partial class role_users_detail
{
    public int role_user_detail_id { get; set; }

    public Guid user_id { get; set; }

    public int role_id { get; set; }

    public DateTime? create_at { get; set; }

    public DateTime? update_at { get; set; }

    public virtual role role { get; set; } = null!;

    public virtual user user { get; set; } = null!;
}

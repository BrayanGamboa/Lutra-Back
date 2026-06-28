using System;
using System.Collections.Generic;

namespace Lutra.Infrastructure.Persistence.DatabaseSnapshot.Entities;

public partial class supplier
{
    public int supplier_id { get; set; }

    public string name { get; set; } = null!;

    public string? contact_name { get; set; }

    public string? email { get; set; }

    public string? phone { get; set; }

    public string? address { get; set; }

    public DateTime? create_at { get; set; }

    public DateTime? update_at { get; set; }

    public virtual ICollection<product> products { get; set; } = new List<product>();
}

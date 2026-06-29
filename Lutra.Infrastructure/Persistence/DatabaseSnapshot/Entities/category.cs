using System;
using System.Collections.Generic;

namespace Lutra.Infrastructure.Persistence.DatabaseSnapshot.Entities;

public partial class category
{
    public int category_id { get; set; }

    public string name { get; set; } = null!;

    public string? description { get; set; }

    public DateTime? create_at { get; set; }

    public DateTime? update_at { get; set; }

    public virtual ICollection<product> products { get; set; } = new List<product>();
}

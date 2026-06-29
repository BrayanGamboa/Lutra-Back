using System;
using System.Collections.Generic;

namespace Lutra.Infrastructure.Persistence.DatabaseSnapshot.Entities;

public partial class country1
{
    public int country_id { get; set; }

    public string name { get; set; } = null!;

    public DateTime? create_at { get; set; }

    public DateTime? update_at { get; set; }

    public virtual ICollection<department1> department1s { get; set; } = new List<department1>();
}

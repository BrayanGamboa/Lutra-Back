using System;
using System.Collections.Generic;

namespace Lutra.Infrastructure.Persistence.DatabaseSnapshot.Entities;

public partial class country
{
    public int country_id { get; set; }

    public string name { get; set; } = null!;

    public virtual ICollection<department> departments { get; set; } = new List<department>();
}

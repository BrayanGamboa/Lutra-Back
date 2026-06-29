using System;
using System.Collections.Generic;

namespace Lutra.Infrastructure.Persistence.DatabaseSnapshot.Entities;

public partial class department1
{
    public int department_id { get; set; }

    public string name { get; set; } = null!;

    public int country_id { get; set; }

    public DateTime? create_at { get; set; }

    public DateTime? update_at { get; set; }

    public virtual ICollection<city> cities { get; set; } = new List<city>();

    public virtual country1 country { get; set; } = null!;
}

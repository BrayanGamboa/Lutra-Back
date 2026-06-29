using System;
using System.Collections.Generic;

namespace Lutra.Infrastructure.Persistence.DatabaseSnapshot.Entities;

public partial class department
{
    public int department_id { get; set; }

    public string name { get; set; } = null!;

    public int country_id { get; set; }

    public virtual ICollection<city1> city1s { get; set; } = new List<city1>();

    public virtual country country { get; set; } = null!;
}

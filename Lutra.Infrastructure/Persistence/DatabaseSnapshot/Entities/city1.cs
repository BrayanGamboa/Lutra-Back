using System;
using System.Collections.Generic;

namespace Lutra.Infrastructure.Persistence.DatabaseSnapshot.Entities;

public partial class city1
{
    public int city_id { get; set; }

    public string name { get; set; } = null!;

    public int department_id { get; set; }

    public virtual department department { get; set; } = null!;
}

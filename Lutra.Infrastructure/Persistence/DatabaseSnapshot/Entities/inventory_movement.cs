using System;
using System.Collections.Generic;

namespace Lutra.Infrastructure.Persistence.DatabaseSnapshot.Entities;

public partial class inventory_movement
{
    public int movement_id { get; set; }

    public int product_id { get; set; }

    public int quantity { get; set; }

    public string movement_type { get; set; } = null!;

    public int reference_id { get; set; }

    public DateTime? create_at { get; set; }

    public DateTime? update_at { get; set; }

    public virtual product product { get; set; } = null!;

    public virtual references_type reference { get; set; } = null!;
}

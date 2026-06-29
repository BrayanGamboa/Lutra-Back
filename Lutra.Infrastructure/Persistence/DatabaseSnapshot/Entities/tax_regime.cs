using System;
using System.Collections.Generic;

namespace Lutra.Infrastructure.Persistence.DatabaseSnapshot.Entities;

public partial class tax_regime
{
    public int tax_regime_id { get; set; }

    public string name { get; set; } = null!;

    public string? description { get; set; }

    public DateTime? create_at { get; set; }

    public DateTime? update_at { get; set; }

    public virtual ICollection<customer_details_info> customer_details_infos { get; set; } = new List<customer_details_info>();
}

using System;
using System.Collections.Generic;

namespace Lutra.Infrastructure.Persistence.DatabaseSnapshot.Entities;

public partial class sale_detail
{
    public int sale_detail_id { get; set; }

    public Guid sale_id { get; set; }

    public int product_id { get; set; }

    public int quantity { get; set; }

    public decimal unit_price { get; set; }

    public decimal? subtotal { get; set; }

    public DateTime? create_at { get; set; }

    public DateTime? update_at { get; set; }

    public virtual product product { get; set; } = null!;

    public virtual sale sale { get; set; } = null!;
}

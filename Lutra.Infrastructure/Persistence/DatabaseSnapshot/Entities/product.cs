using System;
using System.Collections.Generic;

namespace Lutra.Infrastructure.Persistence.DatabaseSnapshot.Entities;

public partial class product
{
    public int product_id { get; set; }

    public string name { get; set; } = null!;

    public string? description { get; set; }

    public string sku { get; set; } = null!;

    public decimal price { get; set; }

    public decimal? cost { get; set; }

    public int? supplier_id { get; set; }

    public int? category_id { get; set; }

    public bool? is_active { get; set; }

    public DateTime? create_at { get; set; }

    public DateTime? update_at { get; set; }

    public virtual category? category { get; set; }

    public virtual ICollection<inventory_movement> inventory_movements { get; set; } = new List<inventory_movement>();

    public virtual ICollection<sale_detail> sale_details { get; set; } = new List<sale_detail>();

    public virtual supplier? supplier { get; set; }
}

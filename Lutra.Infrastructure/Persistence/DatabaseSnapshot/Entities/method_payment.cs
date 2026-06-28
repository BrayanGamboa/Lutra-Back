using System;
using System.Collections.Generic;

namespace Lutra.Infrastructure.Persistence.DatabaseSnapshot.Entities;

public partial class method_payment
{
    public int payment_method_id { get; set; }

    public string name { get; set; } = null!;

    public DateTime? create_at { get; set; }

    public DateTime? update_at { get; set; }

    public virtual ICollection<sale> sales { get; set; } = new List<sale>();
}

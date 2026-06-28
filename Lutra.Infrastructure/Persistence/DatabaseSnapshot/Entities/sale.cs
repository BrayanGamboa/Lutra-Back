using System;
using System.Collections.Generic;

namespace Lutra.Infrastructure.Persistence.DatabaseSnapshot.Entities;

public partial class sale
{
    public Guid sale_id { get; set; }

    public Guid customer_id { get; set; }

    public decimal total_amount { get; set; }

    public int? payment_method_id { get; set; }

    public DateTime? sale_date { get; set; }

    public string? status { get; set; }

    public DateTime? create_at { get; set; }

    public DateTime? update_at { get; set; }

    public virtual user customer { get; set; } = null!;

    public virtual method_payment? payment_method { get; set; }

    public virtual ICollection<sale_detail> sale_details { get; set; } = new List<sale_detail>();
}

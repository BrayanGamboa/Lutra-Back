using System;
using System.Collections.Generic;

namespace Lutra.Infrastructure.Persistence.DatabaseSnapshot.Entities;

public partial class customer_details_info
{
    public int customer_detail_id { get; set; }

    public Guid user_id { get; set; }

    public int? document_type_id { get; set; }

    public string? document_number { get; set; }

    public string? business_name { get; set; }

    public string? billing_address { get; set; }

    public string? phone { get; set; }

    public int? city_id { get; set; }

    public int? tax_regime_id { get; set; }

    public string? customer_name { get; set; }

    public string? customer_document { get; set; }

    public DateTime? create_at { get; set; }

    public DateTime? update_at { get; set; }

    public virtual city? city { get; set; }

    public virtual document_type? document_type { get; set; }

    public virtual tax_regime? tax_regime { get; set; }

    public virtual user user { get; set; } = null!;
}

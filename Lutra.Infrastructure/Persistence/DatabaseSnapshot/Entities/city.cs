using System;
using System.Collections.Generic;

namespace Lutra.Infrastructure.Persistence.DatabaseSnapshot.Entities;

public partial class city
{
    public int city_id { get; set; }

    public string name { get; set; } = null!;

    public int department_id { get; set; }

    public DateTime? create_at { get; set; }

    public DateTime? update_at { get; set; }

    public virtual ICollection<customer_details_info> customer_details_infos { get; set; } = new List<customer_details_info>();

    public virtual department1 department { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace product_sales.Models;

public partial class Manager
{
    public int ManagerId { get; set; }

    public string? ManagerName { get; set; }

    public string? Qualification { get; set; }

    public virtual ICollection<Store> Stores { get; set; } = new List<Store>();
}

using System;
using System.Collections.Generic;

namespace product_sales.Models;

public partial class OrderItem
{
    public int ItemId { get; set; }
    public int? Quantity { get; set; }
    public decimal? Price { get; set; }
    public decimal? Discount { get; set; }
    public int? OrderId { get; set; }
    public int? ProductId { get; set; }

    public virtual Order? Order { get; set; }
    public virtual Product? Product { get; set; }

}

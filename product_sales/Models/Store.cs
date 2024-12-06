﻿using System;
using System.Collections.Generic;

namespace product_sales.Models;

public partial class Store
{
    public int StoreId { get; set; }

    public string? StoreName { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? ZipCode { get; set; }

    public int? ManagerId { get; set; }

    public virtual Manager? Manager { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}

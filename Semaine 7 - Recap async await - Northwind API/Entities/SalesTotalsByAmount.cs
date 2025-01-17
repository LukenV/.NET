﻿using System;
using System.Collections.Generic;

namespace Semaine_7___Recap_async_await___Northwind_API.Entities;

public partial class SalesTotalsByAmount
{
    public decimal? SaleAmount { get; set; }

    public int OrderId { get; set; }

    public string CompanyName { get; set; } = null!;

    public DateTime? ShippedDate { get; set; }
}

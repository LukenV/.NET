﻿using System;
using System.Collections.Generic;

namespace Semaine_7___Recap_async_await___Northwind_API.Entities;

public partial class SummaryOfSalesByQuarter
{
    public DateTime? ShippedDate { get; set; }

    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}

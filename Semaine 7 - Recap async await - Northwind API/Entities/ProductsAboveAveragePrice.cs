using System;
using System.Collections.Generic;

namespace Semaine_7___Recap_async_await___Northwind_API.Entities;

public partial class ProductsAboveAveragePrice
{
    public string ProductName { get; set; } = null!;

    public decimal? UnitPrice { get; set; }
}

using System;
using System.Collections.Generic;

namespace Semaine_3___LINQ_EF.Models;

public partial class ProductsAboveAveragePrice
{
    public string ProductName { get; set; } = null!;

    public decimal? UnitPrice { get; set; }
}

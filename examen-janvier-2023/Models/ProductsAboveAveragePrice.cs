﻿using System;
using System.Collections.Generic;

namespace examen_janvier_2023.Model;

public partial class ProductsAboveAveragePrice
{
    public string ProductName { get; set; } = null!;

    public decimal? UnitPrice { get; set; }
}

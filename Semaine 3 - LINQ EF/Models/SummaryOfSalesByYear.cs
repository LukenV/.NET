﻿using System;
using System.Collections.Generic;

namespace Semaine_3___LINQ_EF.Models;

public partial class SummaryOfSalesByYear
{
    public DateTime? ShippedDate { get; set; }

    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}

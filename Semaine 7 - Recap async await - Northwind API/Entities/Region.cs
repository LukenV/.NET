﻿using System;
using System.Collections.Generic;

namespace Semaine_7___Recap_async_await___Northwind_API.Entities;

public partial class Region
{
    public int RegionId { get; set; }

    public string RegionDescription { get; set; } = null!;

    public virtual ICollection<Territory> Territories { get; set; } = new List<Territory>();
}

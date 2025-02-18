﻿using System;
using System.Collections.Generic;

namespace Semaine_5___Repository___UnitOfWork___SchoolApp.Models;

public partial class Professor
{
    public int ProfessorId { get; set; }

    public string Name { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public int SectionId { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual Section Section { get; set; } = null!;
}

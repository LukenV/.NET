using System;
using System.Collections.Generic;

namespace Semaine_5___Repository___UnitOfWork___SchoolApp.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string Name { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public long YearResult { get; set; }

    public int? SectionId { get; set; }

    public virtual Section? Section { get; set; }
}

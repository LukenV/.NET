using System;
using System.Collections.Generic;

namespace Semaine_5___Repository___UnitOfWork___SchoolApp.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string Name { get; set; } = null!;

    public int ProfessorId { get; set; }

    public virtual Professor Professor { get; set; } = null!;
}

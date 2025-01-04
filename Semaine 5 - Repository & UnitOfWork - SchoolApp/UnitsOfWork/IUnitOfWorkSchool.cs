using School.Repository;
using Semaine_5___Repository___UnitOfWork___SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semaine_5___Repository___UnitOfWork___SchoolApp.UnitsOfWork
{
    internal interface IUnitOfWorkSchool
    {
        IRepository<Course> CoursesRepository { get; }
        IRepository<Student> StudentsRepository { get; }
        IRepository<Section> SectionsRepository { get; }
        IRepository<Professor> ProfessorsRepository { get; }
    }
}

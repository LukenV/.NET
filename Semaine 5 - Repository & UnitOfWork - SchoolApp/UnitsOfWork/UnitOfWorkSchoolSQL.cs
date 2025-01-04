using School.Repository;
using Semaine_5___Repository___UnitOfWork___SchoolApp.Models;
using Semaine_5___Repository___UnitOfWork___SchoolApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semaine_5___Repository___UnitOfWork___SchoolApp.UnitsOfWork
{
    internal class UnitOfWorkSchoolSQL : IUnitOfWorkSchool
    {
        private readonly SchoolContext _context;
        private BaseRepositorySQL<Course> _coursesRepository;
        private BaseRepositorySQL<Student> _studentsRepository;
        private BaseRepositorySQL<Section> _sectionsRepository;
        private BaseRepositorySQL<Professor> _professorsRepository;

        public UnitOfWorkSchoolSQL(SchoolContext context)
        {
            _context = context;
            _coursesRepository = new BaseRepositorySQL<Course>(context);
            _studentsRepository = new BaseRepositorySQL<Student>(context);
            _sectionsRepository = new BaseRepositorySQL<Section>(context);
            _professorsRepository = new BaseRepositorySQL<Professor>(context);
        }

        public IRepository<Course> CoursesRepository { get { return _coursesRepository; } }
        public IRepository<Student> StudentsRepository { get { return _studentsRepository; } }
        public IRepository<Section> SectionsRepository { get { return _sectionsRepository; } }
        public IRepository<Professor> ProfessorsRepository { get { return _professorsRepository; } }

    }
}

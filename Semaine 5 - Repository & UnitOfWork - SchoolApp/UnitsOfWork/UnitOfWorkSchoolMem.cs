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
    internal class UnitOfWorkSchoolMem : IUnitOfWorkSchool
    {
        private CourseRepositoryMem _coursesRepository;
        private StudentRepositoryMem _studentsRepository;
        private SectionRepositoryMem _sectionsRepository;
        private ProfessorRepositoryMem _professorsRepository;

        public UnitOfWorkSchoolMem()
        {
            _coursesRepository = new CourseRepositoryMem();
            _studentsRepository = new StudentRepositoryMem();
            _sectionsRepository = new SectionRepositoryMem();
            _professorsRepository = new ProfessorRepositoryMem();
        }

        public IRepository<Course> CoursesRepository { get { return _coursesRepository; } }
        public IRepository<Student> StudentsRepository { get { return _studentsRepository; } }
        public IRepository<Section> SectionsRepository { get { return _sectionsRepository; } }
        public IRepository<Professor> ProfessorsRepository { get { return _professorsRepository; } }
    }
}

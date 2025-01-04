using School.Repository;
using Semaine_5___Repository___UnitOfWork___SchoolApp.Models;
using System.Linq.Expressions;

namespace Semaine_5___Repository___UnitOfWork___SchoolApp.Repository
{
    internal class StudentRepositoryMem : IRepository<Student>
    {
        private List<Student> _students;
        public StudentRepositoryMem()
        {
            _students = new List<Student>();
        }

        public void Delete(Student entity)
        {
            _students.Remove(entity);
        }

        public IList<Student> GetAll()
        {
            return _students;
        }

        public Student GetById(int id)
        {
            return _students[id];
        }

        public void Insert(Student entity)
        {
            _students.Add(entity);
        }

        public bool Save(Student entity, Expression<Func<Student, bool>> predicate)
        {
            Student findStudent = (SearchFor(predicate)).FirstOrDefault();

            if (findStudent == null)
            {
                Insert(entity);
                return true;
            }
            return false;
        }

        public IList<Student> SearchFor(Expression<Func<Student, bool>> predicate)
        {
            return _students.AsQueryable().Where(predicate).ToList();
        }
    }
}

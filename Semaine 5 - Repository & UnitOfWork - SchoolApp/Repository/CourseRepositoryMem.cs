using School.Repository;
using Semaine_5___Repository___UnitOfWork___SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Semaine_5___Repository___UnitOfWork___SchoolApp.Repository
{
    internal class CourseRepositoryMem : IRepository<Course>
    {
        private List<Course> _courses;
        public CourseRepositoryMem() { 
            _courses = new List<Course>();
        }

        public void Delete(Course entity)
        {
            _courses.Remove(entity);
        }

        public IList<Course> GetAll()
        {
            return _courses;
        }

        public Course GetById(int id)
        {
            return _courses[id];
        }

        public void Insert(Course entity)
        {
            _courses.Add(entity);
        }

        public bool Save(Course entity, Expression<Func<Course, bool>> predicate)
        {
            Course findCourse = (SearchFor(predicate)).FirstOrDefault();

            if (findCourse == null)
            {
                Insert(entity);
                return true;
            }
            return false;
        }

        public IList<Course> SearchFor(Expression<Func<Course, bool>> predicate)
        {
            return _courses.AsQueryable().Where(predicate).ToList();
        }
    }
}

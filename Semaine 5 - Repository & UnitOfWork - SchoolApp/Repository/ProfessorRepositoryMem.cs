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
    internal class ProfessorRepositoryMem : IRepository<Professor>
    {
        private List<Professor> _professors;
        public ProfessorRepositoryMem()
        {
            _professors = new List<Professor>();
        }

        public void Delete(Professor entity)
        {
            _professors.Remove(entity);
        }

        public IList<Professor> GetAll()
        {
            return _professors;
        }

        public Professor GetById(int id)
        {
            return _professors[id];
        }

        public void Insert(Professor entity)
        {
            _professors.Add(entity);
        }

        public bool Save(Professor entity, Expression<Func<Professor, bool>> predicate)
        {
            Professor findProfessor = (SearchFor(predicate)).FirstOrDefault();

            if (findProfessor == null)
            {
                Insert(entity);
                return true;
            }
            return false;
        }

        public IList<Professor> SearchFor(Expression<Func<Professor, bool>> predicate)
        {
            return _professors.AsQueryable().Where(predicate).ToList();
        }
    }
}

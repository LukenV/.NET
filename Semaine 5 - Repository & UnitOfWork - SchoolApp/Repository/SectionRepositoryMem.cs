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
    internal class SectionRepositoryMem : IRepository<Section>
    {
        private List<Section> _sections;
        public SectionRepositoryMem()
        {
            _sections = new List<Section>();
        }

        public void Delete(Section entity)
        {
            _sections.Remove(entity);
        }

        public IList<Section> GetAll()
        {
            return _sections;
        }

        public Section GetById(int id)
        {
            return _sections[id];
        }

        public void Insert(Section entity)
        {
            _sections.Add(entity);
        }

        public bool Save(Section entity, Expression<Func<Section, bool>> predicate)
        {
            Section findSection = (SearchFor(predicate)).FirstOrDefault();

            if (findSection == null)
            {
                Insert(entity);
                return true;
            }
            return false;
        }

        public IList<Section> SearchFor(Expression<Func<Section, bool>> predicate)
        {
            return _sections.AsQueryable().Where(predicate).ToList();
        }
    }
}

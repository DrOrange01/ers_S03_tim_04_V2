using Domain.Repozitorijumi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RepozitorijumServisi
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly List<T> _entities = new();

        public T GetById(int id)
        {
            // Pretpostavlja se da entitet ima svojstvo Id
            return _entities.FirstOrDefault(e => (int)e.GetType().GetProperty("Id").GetValue(e) == id);
        }

        public List<T> GetAll() => _entities;

        public void Add(T entity) => _entities.Add(entity);

        public void Update(T entity)
        {
            var id = (int)entity.GetType().GetProperty("Id").GetValue(entity);
            var existing = GetById(id);
            if (existing != null)
            {
                _entities.Remove(existing);
                _entities.Add(entity);
            }
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null) _entities.Remove(entity);
        }
    }
}

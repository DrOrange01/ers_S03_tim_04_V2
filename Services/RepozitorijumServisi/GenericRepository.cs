using Domain.Repozitorijumi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RepozitorijumServisi
{
    public class GenericRepository<T> : IRepository<T> where T : class, IAggregateRoot
    {
        private readonly List<T> _entities = new();

        public T GetById(Guid id)
        {
            // Pretpostavlja se da entitet ima svojstvo "Id" tipa Guid
            return _entities.FirstOrDefault(e => (Guid)e.GetType().GetProperty("Id")?.GetValue(e) == id);
        }

        public List<T> GetAll() => _entities;

        public void Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _entities.Add(entity);
        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var id = (Guid)entity.GetType().GetProperty("Id")?.GetValue(entity);
            var existingEntity = GetById(id);

            if (existingEntity != null)
            {
                _entities.Remove(existingEntity);
                _entities.Add(entity);
            }
        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _entities.Remove(entity);
            }
        }
    }
}

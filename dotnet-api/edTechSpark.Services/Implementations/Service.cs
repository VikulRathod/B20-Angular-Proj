using edTechSpark.Repositories.Interfaces;
using edTechSpark.Services.Interfaces;
using System.Collections.Generic;

namespace edTechSpark.Services.Implementations
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        protected IRepository<TEntity> _repo;
        public Service(IRepository<TEntity> repo)
        {
            _repo = repo;
        }
        public void Add(TEntity entity)
        {
            _repo.Add(entity);
            _repo.SaveChanges();
        }

        public void Delete(object Id)
        {
            _repo.Delete(Id);
            _repo.SaveChanges();
        }

        public TEntity Find(object Id)
        {
            return _repo.Find(Id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repo.GetAll();
        }

        public void Remove(TEntity entity)
        {
            _repo.Remove(entity);
            _repo.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _repo.Update(entity);
            _repo.SaveChanges();
        }
    }
}

using BookingApp.Data.Context;
using BookingApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookingApp.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly BookingAppDbContext _db;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(BookingAppDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            entity.CreatedData = DateTime.Now;
            _dbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            entity.ModifiedData = DateTime.Now;
            entity.IsDeleted = true;
            _dbSet.Update(entity);
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            Delete(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate is null ? _dbSet : _dbSet.Where(predicate);
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Updating(TEntity entity)
        {
            entity.ModifiedData = DateTime.Now;
            _dbSet.Update(entity);
        }

        // _db.SaveChanges()'lar transaction durumları göz önüne bulundurarak UnitOfWork adı verdiğimiz başka bir pattern içerisinde yönetilecek.

    }
}

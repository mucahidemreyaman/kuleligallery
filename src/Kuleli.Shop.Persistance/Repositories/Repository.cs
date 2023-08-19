using Kuleli.Shop.Application.Repostories;
using Kuleli.Shop.Domain.Common;
using Kuleli.Shop.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Kuleli.Shop.Persistance.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : BaseEntity       

    {
        private readonly DbSet<T> _dbSet;
        public Repository(KuleliGalleryContext dbContext)
        {
            _dbSet = dbContext.Set<T>();    
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return await  Task.FromResult(_dbSet);
        }
        public async Task<IQueryable<T>> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await Task.FromResult(_dbSet.Where(filter));    
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.AnyAsync(filter);
        }

        public async Task<T> GetById(object id)
        {
          var entity = await _dbSet.FindAsync(id);
            return entity;

        }

        public void  Add(T entity)
        {
            _dbSet.Add(entity);
          
        }

        public void  Update(T entity)
        {
            _dbSet.Update(entity);
                      
        }

        public void  Delete(T entity)
        {
            _dbSet.Remove(entity);
                   
        }

        public void  Delete(object id)
        {
            var item = _dbSet.Find(id);
            _dbSet.Remove(item);
            
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RecipeBookAPI.Data;
using RecipeBookAPI.Repositories.Interfaces;

namespace RecipeBookAPI.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected ApplicationDbContext dbContext;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Insert(TEntity entity)
        {
            this.dbContext.Set<TEntity>().Add(entity);
            this.dbContext.SaveChanges();
        }

        public void Delete (TEntity entity)
        {
            this.dbContext.Set<TEntity>().Remove(entity);
            this.dbContext.SaveChanges();
        }

        public IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return this.dbContext.Set<TEntity>().Where(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return this.dbContext.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return this.dbContext.Set<TEntity>().Find(id);
        }

        public TEntity GetById(string id)
        {
            return this.dbContext.Set<TEntity>().Find(id);
        }

    }
}

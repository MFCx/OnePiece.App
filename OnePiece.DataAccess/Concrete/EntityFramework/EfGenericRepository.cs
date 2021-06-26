using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

using OnePiece.DataAccess.Abstract;
using OnePiece.Entities.Abstract;
using OnePiece.Entities.Database;

namespace OnePiece.DataAccess.Concrete.EntityFramework
{
    public class EfGenericRepositoryDal<TEntity> : IGenericDal<TEntity>
        where TEntity : class, IEntity, new()
    {

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new OnePieceDbContext())
            {
                return context.Set<TEntity>().FirstOrDefault(filter);
            }

        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter=null)
        {
            using (var context = new OnePieceDbContext())
            {
                return filter == null ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity Add(TEntity entity)
        {
            using (var context = new OnePieceDbContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();

            }

            return entity;
        }

        public void Delete(TEntity entity)
        {
            using (var context = new OnePieceDbContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var context = new OnePieceDbContext())
            {
                var uptadedEntity = context.Entry(entity);
                uptadedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
            return entity;
        }

       
    }
}

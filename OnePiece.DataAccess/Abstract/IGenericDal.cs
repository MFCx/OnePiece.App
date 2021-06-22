using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OnePiece.Entities.Abstract;
using OnePiece.Entities.Database;

namespace OnePiece.DataAccess.Abstract
{
    public interface IGenericDal<TEntity>
        where TEntity : class, IEntity, new()
    {

        TEntity Get(Expression<Func<TEntity, bool>> filter);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter=null);
        TEntity Add(TEntity entity);
        void Delete(TEntity entity);
        TEntity Update(TEntity entity);
         
    }
}

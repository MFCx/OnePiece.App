using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OnePiece.DataAccess.Abstract;
using OnePiece.Entities.Database;


namespace OnePiece.DataAccess.Concrete.EntityFramework
{
    public class EfTayfaDal:EfGenericRepositoryDal<Tayfalar>,ITayfaDal
    {
        public Tayfalar TayfaveCharacter(Expression<Func<Tayfalar, bool>> filter)
        {
            using (var context = new OnePieceDbContext())
            {
                return context.Set<Tayfalar>().Include(x => x.Characters).FirstOrDefault(filter);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OnePiece.Entities.Database;

namespace OnePiece.DataAccess.Abstract
{
    public interface ITayfaDal : IGenericDal<Tayfalar>
    {
        Tayfalar TayfaveCharacter(Expression<Func<Tayfalar, bool>> filter);
    }
}

using OnePiece.Entities.Database;
using System;
using System.Linq.Expressions;

namespace OnePiece.Business.Abstract
{
    public interface ITayfaService : IGenericService<Tayfalar>
    {
        Tayfalar TayfaveCharacter(Expression<Func<Tayfalar, bool>> filter);
    }
}

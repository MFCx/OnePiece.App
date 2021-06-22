using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OnePiece.Entities.Database;


namespace OnePiece.DataAccess.Abstract
{
    public interface ICharacterDal:IGenericDal<Character>
    {
        List<Character> HakiKullananKarakterler(Expression<Func<Character, bool>> filter);
        List<Character> GetirCharacterTayfaIle(Expression<Func<Character, bool>> filter=null);
    }
}

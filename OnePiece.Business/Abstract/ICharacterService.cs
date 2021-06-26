using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using OnePiece.Entities.Database;

namespace OnePiece.Business.Abstract
{
    public interface ICharacterService:IGenericService<Character>
    {
        List<Character> HakiKullananKarakterler(Expression<Func<Character,bool>>filter);
        List<Character> GetirCharacterTayfaIle(Expression<Func<Character, bool>> filter=null);
        Character resimlerleCharacter(Expression<Func<Character, bool>> filter);
        Character CharacterSatinAl(Expression<Func<Character, bool>> filter);
    }
}

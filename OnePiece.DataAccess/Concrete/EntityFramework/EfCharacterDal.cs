using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using OnePiece.DataAccess.Abstract;
using OnePiece.Entities.Database;


namespace OnePiece.DataAccess.Concrete.EntityFramework
{
    public class EfCharacterDal : EfGenericRepositoryDal<Character>, ICharacterDal
    {
        public List<Character> HakiKullananKarakterler(Expression<Func<Character, bool>> filter)
        {
            using (var context = new OnePieceDbContext())
            {
                return context.Set<Character>().Where(filter).ToList();
            }
        }

        public List<Character> GetirCharacterTayfaIle(Expression<Func<Character, bool>> filter = null)
        {
            using (var context = new OnePieceDbContext())
            {
                return context.Set<Character>().
                    Include(x => x.Tayfalar).
                    Include(m => m.Images).ToList();
            }
        }

        public Character resimlerleCharacter(Expression<Func<Character, bool>> filter)
        {
            using (var context = new OnePieceDbContext())
            {
                return context.Set<Character>().Include(x=>x.Images).Include(x=>x.Tayfalar).FirstOrDefault(filter);
            }
        }  
        public Character CharacterSatinAl(Expression<Func<Character, bool>> filter)
        {
            using (var context = new OnePieceDbContext())
            {
                return context.Set<Character>().Include(x => x.Order_Details.Select(y => y.Order))
                    .FirstOrDefault(filter);
            }
        }
    }
}

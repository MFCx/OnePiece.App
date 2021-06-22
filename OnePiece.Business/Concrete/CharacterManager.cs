using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OnePiece.Business.Abstract;
using OnePiece.DataAccess.Abstract;
using OnePiece.Entities.Database;


namespace OnePiece.Business.Concrete
{
    public class CharacterManager:ICharacterService
    {
        private readonly ICharacterDal _characterDal;

        public CharacterManager(ICharacterDal characterDal)
        {
            _characterDal = characterDal;
        }

        public Character Get(Expression<Func<Character, bool>> filter)
        {
            return _characterDal.Get(filter);
        }

        public Character Add(Character entity)
        {
            return _characterDal.Add(entity);
        }

        public void Delete(Character entity)
        {
            _characterDal.Delete(entity);
        }

        public Character Update(Character entity)
        {
            return _characterDal.Update(entity);
        }

        public List<Character> HakiKullananKarakterler(Expression<Func<Character, bool>> filter)
        {
            return _characterDal.HakiKullananKarakterler(filter);
        }

        public List<Character> GetirCharacterTayfaIle(Expression<Func<Character, bool>> filter=null)
        {
            return _characterDal.GetirCharacterTayfaIle(filter);
        }

        public List<Character> GetAll(Expression<Func<Character, bool>> filter = null)
        {
            return filter == null ? _characterDal.GetAll() : _characterDal.GetAll(filter);
        }
    }
}

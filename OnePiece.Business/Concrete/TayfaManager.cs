using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using OnePiece.Business.Abstract;
using OnePiece.DataAccess.Abstract;
using OnePiece.Entities.Database;


namespace OnePiece.Business.Concrete
{
    public class TayfaManager : ITayfaService
    {
        private ITayfaDal _tayfaDal;

        public TayfaManager(ITayfaDal tayfaDal)
        {
            _tayfaDal = tayfaDal;
        }

        public Tayfalar Get(Expression<Func<Tayfalar, bool>> filter)
        {
            return _tayfaDal.Get(filter);
        }

       

        public List<Tayfalar> GetAll(Expression<Func<Tayfalar, bool>> filter=null)
        {
            return filter == null ? _tayfaDal.GetAll() : _tayfaDal.GetAll(filter);
        }

        public Tayfalar Add(Tayfalar entity)
        {
            return _tayfaDal.Add(entity);
        }

        public void Delete(Tayfalar entity)
        {
            _tayfaDal.Delete(entity);
        }

        public Tayfalar Update(Tayfalar entity)
        {
            return _tayfaDal.Update(entity);
        }
    }
}

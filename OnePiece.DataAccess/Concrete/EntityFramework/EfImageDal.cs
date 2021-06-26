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
    public class EfImageDal:EfGenericRepositoryDal<Image>,IImageDal
    {
        public List<Image> GetirImageile(Expression<Func<Image,bool>> filter = null)
        {
            using (var context = new OnePieceDbContext())
            {
                return null;

            }
        }
    }
}

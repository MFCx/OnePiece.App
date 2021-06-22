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
    public class ImageManager:IImageService
    {
        private readonly IImageDal _imageDal;

        public ImageManager(IImageDal ImageDal)
        {
            _imageDal = ImageDal;
        }

        public Image Get(Expression<Func<Image, bool>> filter)
        {
            return _imageDal.Get(filter);
        }

        public Image Add(Image entity)
        {
            return _imageDal.Add(entity);
        }

        public void Delete(Image entity)
        {
            _imageDal.Delete(entity);
        }

        public Image Update(Image entity)
        {
            return _imageDal.Update(entity);
        }

       
        

        public List<Image> GetAll(Expression<Func<Image, bool>> filter = null)
        {
            return filter == null ? _imageDal.GetAll() : _imageDal.GetAll(filter);
        }
    }
}

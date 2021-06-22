using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnePiece.Business.Abstract;
using OnePiece.Business.Concrete;
using OnePiece.DataAccess.Abstract;
using OnePiece.DataAccess.Concrete.EntityFramework;

namespace OnePiece.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {

        public override void Load()
        {
            Bind<ICharacterService>().To<CharacterManager>();
            Bind<ITayfaService>().To<TayfaManager>();
            Bind<ITayfaDal>().To<EfTayfaDal>();
            Bind<ICharacterDal>().To<EfCharacterDal>();
            Bind<IImageService>().To<ImageManager>();
            Bind<IImageDal>().To<EfImageDal>();

        }
    }
}

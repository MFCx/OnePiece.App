using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnePiece.Business.Abstract;
using OnePiece.Entities.Database;
using OnePiece.WebUI3.Models;


namespace OnePiece.WebUI3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICharacterService _characterService;
        private readonly ITayfaService _tayfalarService;
        private readonly IImageService _imageService;

        public HomeController(ICharacterService characterService, ITayfaService tayfalarService, IImageService imageService)
        {
            _characterService = characterService;
            _tayfalarService = tayfalarService;
            _imageService = imageService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var karakterList = _characterService.GetirCharacterTayfaIle();

            List<CharacterListModel> models = new List<CharacterListModel>();
            foreach (var item in karakterList)
            {
                CharacterListModel model = new CharacterListModel
                {
                    CharacterId = item.CharacterId,
                    CharacterName = item.CharacterName,
                    CharacterPower = item.CharacterPower,
                    TayfaId = item.TayfaId,
                    TayfaName = item.Tayfalar.TayfaName,
                    MainPicture = item.MainPicture
                };
                models.Add(model);
            }
            return View(models);
        }

        [HttpPost]
        public ActionResult CharacterAdd(Character characterEkle)
        {

            _characterService.Add(new Character
            {
                CharacterName=characterEkle.CharacterName,
                CharacterPower=characterEkle.CharacterPower,
                CharacterBounty=characterEkle.CharacterBounty,
                CharacterDescription=characterEkle.CharacterDescription,
                MainPicture=characterEkle.CharacterName+".jpg",
                TayfaId=characterEkle.TayfaId
            });
            
          
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult CharacterDetail(int id)
        {

            var resimlerleCharacter = _characterService.resimlerleCharacter(x => x.CharacterId == id);
            return View(resimlerleCharacter);
            //return View(karakterTek);
        }
        [HttpPost]
        public ActionResult SepeteEkle(int id)
        {
            List<AddToCartModel> sepet = new List<AddToCartModel>();
            var resimlerleCharacter = _characterService.CharacterSatinAl(x => x.CharacterId == id);
            foreach (var od in resimlerleCharacter.Order_Details)
            {
                var p1 = new AddToCartModel
                {
                    CharacterId = od.Character.CharacterId,
                    CharacterName = od.Character.CharacterName,
                    MainPicture = od.Character.MainPicture,
                    OrderId=od.Order.OrderId,
                    CharacterBounty=od.UnitPrice
                };
                sepet.Add(p1);
            }

            return View(sepet);
        }     
        [HttpPost]
        public ActionResult SepeteEkle(AddToCartModel entity)
        {
          
            var sepetiGonder = new Order_Details
            {
                CharacterId=entity.CharacterId,
                UnitPrice=entity.CharacterBounty,
                OrderId=entity.OrderId
                
            };
            return RedirectToAction("Index", sepetiGonder);
            
        }


        [HttpGet]
        public ActionResult Tayfalar()
        {
            var getirtayfalar = _tayfalarService.GetAll();
            ViewBag.TayfaMenu = getirtayfalar;
            return View(getirtayfalar);
        }
        [HttpGet]
        public ActionResult TayfalarDetail(int id)
        {
            var tayfaDetail = _tayfalarService.TayfaveCharacter(x => x.TayfaId == id);

            return View(tayfaDetail);
        }
    }
}
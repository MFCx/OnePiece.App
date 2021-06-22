using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnePiece.Business.Abstract;
using OnePiece.WebUI3.Models;
using PagedList;

namespace OnePiece.WebUI3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICharacterService _characterService;

        public HomeController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        public ActionResult Index(int? page)
        {
            var karakterList = _characterService.GetirCharacterTayfaIle();

            var res = karakterList.ToPagedList(page ?? 1, 9);

            List<CharacterListModel> models = new List<CharacterListModel>();
            foreach (var item in karakterList)
            {
                CharacterListModel model = new CharacterListModel
                {
                    CharacterName = item.CharacterName,
                    CharacterPower = item.CharacterPower,
                    TayfaId = item.TayfaId,
                    TayfaName = item.Tayfalar.TayfaName,
                    MainPicture=item.MainPicture
                };
                models.Add(model);
               
            }

            ViewBag.ToplamSayfa = karakterList.Count();

            return View(models);
        }

        public ActionResult CharacterDetail()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
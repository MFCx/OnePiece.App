using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnePiece.Business.Abstract;
using OnePiece.WebUI3.Models;

namespace OnePiece.WebUI3.Controllers
{
    public class MarketController : Controller
    {
        private ICharacterService _characterService;

        public MarketController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        // GET: Market
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

        // GET: Market/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Market/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Market/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Market/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Market/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Market/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Market/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

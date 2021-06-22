using OnePiece.Business.Abstract;
using OnePiece.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnePiece.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICharacterService _characterService;
        public HomeController(ICharacterService characterService)
        {
            _characterService = characterService;
        }
        // GET: Home
        public ActionResult Index()
        {
          var g= _characterService.GetAll();
            //var model = new CharacterListModel
            //{
            //    CharacterName = 
            //};
            return View(g);
          
        }
    }
}
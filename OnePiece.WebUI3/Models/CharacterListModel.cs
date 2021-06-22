using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnePiece.WebUI3.Models
{
    public class CharacterListModel
    {
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }
        public string CharacterPower { get; set; }
        public int TayfaId { get; set; }
        public string TayfaName { get;  set; }
        public string MainPicture { get; set; }
    }
}
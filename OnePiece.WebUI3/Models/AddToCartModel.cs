using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnePiece.WebUI3.Models
{
    public class AddToCartModel
    {
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }
        public decimal? CharacterBounty { get; set; }
        public string MainPicture { get; set; }
        public int OrderId { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnePiece.Entities.Abstract;
using OnePiece.Entities.Database;

namespace OnePiece.Entities.Dtos
{
    public class CharacterModel:IEntity
    {
     
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }
        public string CharacterPower { get; set; }
        public string TayfaName { get; set; }
    

    }
 
}

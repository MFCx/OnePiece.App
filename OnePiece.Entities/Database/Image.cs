//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using OnePiece.Entities.Abstract;

namespace OnePiece.Entities.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Image : IEntity
    {
        public int ImageId { get; set; }
        public string ImageUrl { get; set; }
        public Nullable<int> CharacterId { get; set; }
    
        public virtual Character Character { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BingoOnline.Models
{
    public class Card
    {
        [Key]
        public int CardID { get; set; }
        public string CardValues { get; set; }
        public int CardHits { get; set; }
        public virtual int BingoID { get; set; }
    } 
}
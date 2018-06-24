using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BingoOnline.Models
{
    public class Player
    {
        [Key]
        public int PlayersID { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatorio")]
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
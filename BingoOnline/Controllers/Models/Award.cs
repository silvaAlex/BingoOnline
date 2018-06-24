using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BingoOnline.Models
{
    public class Award
    {
        [Key]
        [Display(Name = "Prêmios")]
        public int AwardsID { get; set; }
        [Display(Name = "Nome do item"),MaxLength(100)]
        [Required(ErrorMessage = "O Campo Nome do Prêmio é obrigatorio ")]
        [Index("Award_Name_Index",IsUnique=true)]
        public string Name { get; set; }

        public virtual ICollection<Bingo> Bingos { get; set; }
    }
}
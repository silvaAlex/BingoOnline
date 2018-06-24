using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BingoOnline.Models
{
    public class Bingo
    {
        [Key]
        public int BingoID { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data Sorteio")]
        public DateTime RaffleDate { get; set; }
        [Display(Name = "Hora do Sorteio")]
        public TimeSpan RaffleHour { get; set; }
        public bool Status { get; set; }
        [MaxLength(100)]
        [Display(Name = "Descrição")]
        [Index("Bingo_Description_Index",IsUnique = true)]
        public string Description { get; set; }
 
        [Required, ForeignKey("Award")]
        [Display(Name = "Prêmios")]
        public int AwardsID { get; set; }
        [Display(Name = "Prêmios")]
        public virtual Award Award { get; set; }

        public virtual ICollection<Card> Cards { get; set; }
    }
}
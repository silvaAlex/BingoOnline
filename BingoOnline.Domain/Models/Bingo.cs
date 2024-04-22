namespace BingoOnline.Domain.Models
{
    public class Bingo
    {
        public Guid BingoId { get; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool Status { get; }
       
        public Guid PremioId { get; }

        public virtual ICollection<Cartelha> Cartelhas { get; }

        public Bingo(Guid premioId, bool status = false)
        {
            BingoId = Guid.NewGuid();
            Status = status;
            PremioId = premioId;
            Cartelhas = new List<Cartelha>();
        }

        public void AddCartelha(Cartelha cartelha)
        {
            Cartelhas.Add(cartelha);
        }
    }
}

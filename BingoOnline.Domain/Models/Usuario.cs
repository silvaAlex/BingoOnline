namespace BingoOnline.Domain.Models
{
    public class Usuario
    {
        public Guid UserId { get; }
        public string UserName { get; } = string.Empty;
        public string Email { get; } = string.Empty;

        public virtual ICollection<Bingo> Bingos { get; }

        public Usuario(string name, string email)
        {
            UserId = Guid.NewGuid();
            UserName = name;
            Email = email;
            Bingos = new List<Bingo>();
        }

        public void AddBingo(Bingo bingo)
        {
            Bingos.Add(bingo);
        }
    }
}

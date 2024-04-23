namespace BingoOnline.Domain.Models
{
    public class Usuario
    {
        public Guid UsuarioId { get; }
        public string UserName { get; } = string.Empty;
        public string Email { get; } = string.Empty;
        public string Password { get; } = string.Empty;

        public virtual ICollection<Cartela> Cartelas { get; }

        public Usuario(string name, string email, string password)
        {
            UsuarioId = Guid.NewGuid();
            UserName = name;
            Email = email;
            Password = password;
            Cartelas = new List<Cartela>();
        }

        public void AddCartela(Cartela cartela)
        {
            Cartelas.Add(cartela);
        }
    }
}

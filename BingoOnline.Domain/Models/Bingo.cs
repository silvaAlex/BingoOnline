namespace BingoOnline.Domain.Models
{
    public class Bingo
    {
        public Guid BingoId { get; }
        public Guid PremioId { get; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool Status { get; private set; } = false;
        public virtual ICollection<Cartela> Cartelas { get; }
        public virtual ICollection<Usuario> Usuarios { get; }

        public IList<int> NumerosSorteados { get; private set; }

        public Bingo(Guid premioId)
        {
            BingoId = Guid.NewGuid();
            PremioId = premioId;
            Cartelas = new List<Cartela>();
            Usuarios = new List<Usuario>();
            NumerosSorteados = new List<int>();
            GerarCartelhas();
        }

        private void GerarCartelhas()
        {
            for (int i = 0; i < 100; i++)
            {
                Cartela cartelha = new(PremioId);
                Cartelas.Add(cartelha);
            }
        }

        public void IsConcluido(bool status)
        {
            Status = status;
        }

        public void SortearNumeros()
        {
            List<int> numerosPossiveis = Enumerable.Range(1, 91).ToList();

            Random random = new();

            while(numerosPossiveis.Count > 0)
            {
                int sorteado = random.Next(0, numerosPossiveis.Count);

                int numeroSorteado = numerosPossiveis[sorteado];

                NumerosSorteados.Add(numeroSorteado);

                numerosPossiveis.RemoveAt(sorteado);
            }
        }

        public void AddUsuario(Usuario usuario)
        {
            Usuarios.Add(usuario);
        }
    }
}

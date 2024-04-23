using System.Text;

namespace BingoOnline.Domain.Models
{
    public class Cartela
    {
        private const int QuantidadeNumerosSorteados = 15;

        public Guid CartelaId { get; }
        public IList<int> Numeros { get; }
        public virtual Guid BingoID { get; }

        public Cartela(Guid bingoId)
        {
            CartelaId = Guid.NewGuid();
            Numeros = new List<int>();
            BingoID = bingoId;
            GerarCartelha();
        }

        private void GerarCartelha()
        {
            Random random = new();
            while(Numeros.Count < QuantidadeNumerosSorteados)
            {
                int numero = random.Next(1, 91);
                if (!Numeros.Contains(numero))
                {
                    Numeros.Add(numero);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new();

            Numeros.ToList().ForEach(numero => sb.Append(string.Join(",", numero)));

            return sb.ToString();
        }
    }
}

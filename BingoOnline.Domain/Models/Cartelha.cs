using System.Text;
using System.Linq;

namespace BingoOnline.Domain.Models
{
    public class Cartelha
    {
        public Guid CartelhaId { get; }
        public IList<int> Numeros { get; }
        public virtual Guid BingoID { get; }

        public Cartelha(Guid bingoId)
        {
            CartelhaId = Guid.NewGuid();
            Numeros = new List<int>();
            BingoID = bingoId;
        }

        public void AddNumero(int numero)
        {
            Numeros.Add(numero);
        }

        public override string ToString()
        {
            StringBuilder sb = new();

            Numeros.ToList().ForEach(numero => sb.Append(string.Join(",", numero)));

            return sb.ToString();
        }
    }
}

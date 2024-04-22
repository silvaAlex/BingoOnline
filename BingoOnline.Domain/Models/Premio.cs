namespace BingoOnline.Domain.Models
{
    public class Premio
    {
        public Guid PremioId { get; }
        public string PremioName { get; } = string.Empty;
        public DateTime Date { get; }
        public string Description { get; } = string.Empty;

        public Premio(string name, string description)
        {
            PremioId = Guid.NewGuid();
            PremioName = name;
            Description = description;
        }
    }
}
using BingoOnline.Domain.Models;

namespace BingoOnline.Domain.Repository
{
    public interface IPremioRepository
    {
        Task<IEnumerable<Premio>> GetAll();
        Task<Premio> GetById(Guid id);
        Task<Premio> GetAllByDate(DateTime date);
        Task<Premio> Create(Premio premio);
        Task<Premio> Update(string description, DateTime date);
        Task<Premio> Delete(Guid id);
    }
}

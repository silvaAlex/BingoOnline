using BingoOnline.Domain.Models;

namespace BingoOnline.Domain.Repository
{
    public interface IBingoRepository
    {
        Task<IEnumerable<Bingo>> GetAll();
        Task<Bingo> GetById(Guid id);
        Task<Bingo> Create(Bingo entity);
        Task<Bingo> Update(Bingo entity);
        Task<Bingo> Delete(Guid id);
    }
}

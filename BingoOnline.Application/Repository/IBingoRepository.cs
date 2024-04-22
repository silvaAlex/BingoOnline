using BingoOnline.Domain.Models;

namespace BingoOnline.Application.Repository
{
    public interface IBingoRepository
    {
        Task<IList<Bingo>> GetAll();
        Task<Bingo> GetById(Guid id);
        Task<Bingo> Add(Bingo entity);
        Task<Bingo> Update(Bingo entity);
        Task<Bingo> DeleteById(Guid id);
    }
}

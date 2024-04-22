using BingoOnline.Domain.Models;

namespace BingoOnline.Domain.Repository
{
    public interface IUserRepository
    {
        Task<Usuario>  GetById(Guid id);
        Task<IList<Usuario>> GetAll();
        Task<Usuario> GetByEmail(string email);
        Task<Usuario> Add(Usuario usuario);
        Task<Usuario> Update(Usuario usuario);
        Task<Usuario> Delete(Guid id);
    }
}

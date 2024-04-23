using BingoOnline.Domain.Models;

namespace BingoOnline.Domain.Repository
{
    public interface IUsuarioRepository
    {
        Task<Usuario>  GetById(Guid id);
        Task<IEnumerable<Usuario>> GetAll();
        Task<Usuario> GetByEmail(string email);
        Task<Usuario> Create(Usuario usuario);
        Task<Usuario> Update(Usuario usuario);
        Task<Usuario> Delete(Guid id);
    }
}

using TpIntegradorSofttek.DataAccess.Repositories;
using TpIntegradorSofttek.Entities;

namespace TpIntegradorSofttek.Services
{
    public interface IUnitOfWork : IDisposable
    {
        public UserRepository UserRepository { get; }
        Task<int> Complete();
    }
}

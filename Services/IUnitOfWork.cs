using TpIntegradorSofttek.DataAccess.Repositories;
using TpIntegradorSofttek.Entities;

namespace TpIntegradorSofttek.Services
{
    public interface IUnitOfWork : IDisposable
    {
        public UserRepository UserRepository { get; }
        public ServiceRepository ServiceRepository { get; }
        public ProjectRepository ProjectRepository { get; }
		public JobRepository JobRepository { get; }

		Task<int> Complete();
    }
}

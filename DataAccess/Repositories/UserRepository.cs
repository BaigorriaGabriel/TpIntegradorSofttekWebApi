using TpIntegradorSofttek.DataAccess.Repositories.Interfaces;
using TpIntegradorSofttek.Entities;

namespace TpIntegradorSofttek.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}

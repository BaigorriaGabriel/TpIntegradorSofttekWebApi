using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using TpIntegradorSofttek.DataAccess.Repositories.Interfaces;

namespace TpIntegradorSofttek.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        //va a hacer consultas por lo que llamo al DbContext
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}

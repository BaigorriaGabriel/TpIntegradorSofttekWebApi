using Microsoft.EntityFrameworkCore;

namespace TpIntegradorSofttek.DataAccess.DataBaseSeeding
{
    public interface IEntitySeeder
    {
        void SeedDatabase(ModelBuilder modelBuilder);
    }
}

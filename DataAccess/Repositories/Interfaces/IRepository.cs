namespace TpIntegradorSofttek.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public Task<List<T>> GetAll();
    }
}

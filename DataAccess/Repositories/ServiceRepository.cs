using Microsoft.EntityFrameworkCore;
using TpIntegradorSofttek.DataAccess.Repositories.Interfaces;
using TpIntegradorSofttek.Entities;

namespace TpIntegradorSofttek.DataAccess.Repositories
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        public ServiceRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override async Task<List<Service>> GetAllActive()
        {
            return await _context.Services.Where(s => s.IsActive == true).ToListAsync();
        }


        public override async Task<Service> GetById(Service serviceToGet)
        {
            var service = await _context.Services.FirstOrDefaultAsync(x => x.CodService == serviceToGet.CodService);

            return service;
        }


        public override async Task<bool> Update(Service updateService)
        {
            var service = await _context.Services.FirstOrDefaultAsync(x => x.CodService == updateService.CodService);
            if (service == null) { return false; }
            service.Description = updateService.Description;
            service.Status = updateService.Status;
            service.HourValue = updateService.HourValue;
            service.IsActive = updateService.IsActive;

            _context.Services.Update(service);
            return true;
        }

        public override async Task<bool> Delete(Service deleteService)
        {
            var service = await _context.Services.FirstOrDefaultAsync(x => x.CodService == deleteService.CodService);
            if (service == null) { return false; }

            service.IsActive = false;

            _context.Services.Update(service);
            return true;
        }
    }
}

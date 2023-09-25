using Microsoft.EntityFrameworkCore;
using TpIntegradorSofttek.DataAccess.Repositories.Interfaces;
using TpIntegradorSofttek.Entities;

namespace TpIntegradorSofttek.DataAccess.Repositories
{
	public class JobRepository : Repository<Job>, IJobRepository
	{
		public JobRepository(ApplicationDbContext context) : base(context)
		{

		}

		public override async Task<List<Job>> GetAllActive()
		{
			return await _context.Jobs.Where(s => s.IsActive == true).ToListAsync();
		}

		public override async Task<Job> GetById(Job jobToGet)
		{
			var job = await _context.Jobs.FirstOrDefaultAsync(x => x.CodJob == jobToGet.CodJob);

			return job;
		}

		public async Task<bool> JobExById(int id)
		{
			return await _context.Jobs.AnyAsync(x => x.CodJob == id);
		}

		public override async Task<bool> Update(Job updateJob)
		{
			var job = await _context.Jobs.FirstOrDefaultAsync(x => x.CodJob == updateJob.CodJob);
			if (job == null) { return false; }

			job.CodJob = updateJob.CodJob;
			job.CodProject = updateJob.CodProject;
			job.CodService = updateJob.CodService;
			job.Date = updateJob.Date;
			job.AmountHours = updateJob.AmountHours;
			job.HourValue = updateJob.HourValue;
			job.Price = updateJob.Price;
			job.IsActive = true;

			_context.Jobs.Update(job);
			return true;
		}

		public override async Task<bool> Delete(Job deleteJob)
		{
			var job = await _context.Jobs.FirstOrDefaultAsync(x => x.CodJob == deleteJob.CodJob);
			if (job == null) { return false; }

			job.IsActive = false;

			_context.Jobs.Update(job);
			return true;
		}
	}
}

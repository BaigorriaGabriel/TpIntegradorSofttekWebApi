using Microsoft.EntityFrameworkCore;
using TpIntegradorSofttek.DataAccess.Repositories.Interfaces;
using TpIntegradorSofttek.Entities;

namespace TpIntegradorSofttek.DataAccess.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override async Task<List<Project>> GetAllActive()
        {
            return await _context.Projects.Where(s => s.IsActive == true).ToListAsync();
        }

        public override async Task<Project> GetById(Project projectToGet)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.CodProject == projectToGet.CodProject);

            return project;
        }

        public async Task<bool> ProjectExById(int id)
        {
            return await _context.Projects.AnyAsync(x => x.CodProject == id);
        }

        public override async Task<bool> Update(Project updateProject)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.CodProject == updateProject.CodProject);
            if (project == null) { return false; }
            
            project.CodProject = updateProject.CodProject;
            project.Name = updateProject.Name;
            project.Address = updateProject.Address;
            project.Status = updateProject.Status;
            project.IsActive = true;
            
            _context.Projects.Update(project);
            return true;
        }

        public override async Task<bool> Delete(Project deleteProject)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.CodProject == deleteProject.CodProject);
            if (project == null) { return false; }

            project.IsActive = false;

            _context.Projects.Update(project);
            return true;
        }
    }
}

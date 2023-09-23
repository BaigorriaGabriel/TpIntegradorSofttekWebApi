using Microsoft.EntityFrameworkCore;
using TpIntegradorSofttek.DataAccess.Repositories.Interfaces;
using TpIntegradorSofttek.DTOs;
using TpIntegradorSofttek.Entities;
using TpIntegradorSofttek.Helper;

namespace TpIntegradorSofttek.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            
        }

        public async Task<User?> AuthenticateCredentials(AuthenticateDto dto)
        {
            return await _context.Users.SingleOrDefaultAsync(x=> (x.Email == dto.Email && x.Password == PasswordEncryptHelper.EncryptPassword(dto.Password)) && x.IsActive==true);
        }

        public override async Task<List<User>> GetAllActive()
        {
            return await _context.Users.Where(s => s.IsActive == true).ToListAsync();
        }

        public override async Task<User> GetById(User UserToGet)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.CodUser == UserToGet.CodUser);

            return user;
        }

        public override async Task<bool> Update(User updateUser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x=> x.CodUser == updateUser.CodUser);
            if (user == null) { return false; }
            user.Name=updateUser.Name;
            user.Dni=updateUser.Dni;
            user.Email=updateUser.Email;
            user.RoleId =updateUser.RoleId;
            user.Password=updateUser.Password;
            user.IsActive=updateUser.IsActive;

            _context.Users.Update(user);
            return true;
        }

        public override async Task<bool> Delete(User deleteUser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.CodUser == deleteUser.CodUser);
            if (user == null) { return false; }
            
            user.IsActive = false;

            _context.Users.Update(user);
            return true;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkloadApp.Models;

namespace WorkloadApp.Data.Services
{
    public class UsersService : IUsersService
    {
        private readonly AppDbContext _context;
        public UsersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ApplicationUser user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var result = await _context.Users.FirstOrDefaultAsync(n => n.Id == id);
            _context.Users.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
        {
            var result = await _context.Users.ToListAsync();
            return result;
        }

        public async Task<ApplicationUser> GetByIdAsync(string id)
        {
            var result = await _context.Users.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public async Task<ApplicationUser> UpdateAsync(string id, ApplicationUser newUser)
        {
            _context.Update(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }
    }
}

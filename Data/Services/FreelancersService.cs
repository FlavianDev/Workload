using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkloadApp.Models;

namespace WorkloadApp.Data.Services
{
    public class FreelancersService : IFreelancersService
    {
        private readonly AppDbContext _context;
        public FreelancersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Freelancer freelancer)
        {
            _context.Freelancers.Add(freelancer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Freelancers.FirstOrDefaultAsync(n => n.FreelancerId == id);
            _context.Freelancers.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Freelancer>> GetAllAsync()
        {
            var result = await _context.Freelancers.ToListAsync();
            return result;
        }

        public async Task<Freelancer> GetByIdAsync(int id)
        {
            var result = await _context.Freelancers.FirstOrDefaultAsync(n => n.FreelancerId == id);
            return result;
        }

        public async Task<Freelancer> GetByUserIdAsync(string id)
        {
            var result = await _context.Freelancers.FirstOrDefaultAsync(n => n.UserId == id);
            return result;
        }

        public async Task<Freelancer> UpdateAsync(int id, Freelancer newFreelancer)
        {
            _context.Update(newFreelancer);
            await _context.SaveChangesAsync();
            return newFreelancer;
        }
    }
}

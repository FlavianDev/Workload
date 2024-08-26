using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkloadApp.Models;

namespace WorkloadApp.Data.Services
{
    public interface IFreelancersService
    {
        Task<IEnumerable<Freelancer>> GetAllAsync();
        Task<Freelancer> GetByIdAsync(int id);
        Task<Freelancer> GetByUserIdAsync(string id);
        Task AddAsync(Freelancer freelancer);
        Task<Freelancer> UpdateAsync(int id, Freelancer newFreelancer);
        Task DeleteAsync(int id);
    }
}

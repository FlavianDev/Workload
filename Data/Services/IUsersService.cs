using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkloadApp.Models;

namespace WorkloadApp.Data.Services
{
    public interface IUsersService
    {
        Task<IEnumerable<ApplicationUser>> GetAllAsync();
        Task<ApplicationUser> GetByIdAsync(string id);
        Task AddAsync(ApplicationUser user);
        Task<ApplicationUser> UpdateAsync(string id, ApplicationUser newUser);
        Task DeleteAsync(string id);
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkloadApp.Data.ViewModels;
using WorkloadApp.Models;

namespace WorkloadApp.Data.Services
{
    public interface IServicesService
    {
        Task<IEnumerable<Service>> GetAllAsync();
        Task AddAsync(NewServiceVM newService);
        Task UpdateAsync(NewServiceVM newService);
        Task<Service> GetByIdAsync(int id);
        Task<List<Service>> GetByFreelanceIdAsync(int freelanceid);
        Task DeleteAsync(int id);
        Task<NewServiceDropdownsVM> GetParameters();
    }
}

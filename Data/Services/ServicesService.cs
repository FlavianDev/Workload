using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkloadApp.Data.ViewModels;
using WorkloadApp.Models;

namespace WorkloadApp.Data.Services
{
    public class ServicesService : IServicesService
    {
        private readonly AppDbContext _context;
        public ServicesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(NewServiceVM data)
        {
            var newService = new Service()
            {
                FreelancerId = data.FreelancerId,
                ServiceName = data.ServiceName,
                ServiceDescription = data.ServiceDescription,
                ServicePicURL = data.ServicePicURL,
                ServiceUM = data.ServiceUM,
                ServiceActive = data.ServiceActive,
                ServicePrice = data.ServicePrice
            };
            await _context.Services.AddAsync(newService);
            await _context.SaveChangesAsync();

            foreach (var cityId in data.Cities_ServicesIds)
            {
                var new_city = new City_Service()
                {
                    ServiceId = newService.ServiceId,
                    CityId = cityId
                };
                await _context.Cities_Services.AddAsync(new_city);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Services.FirstOrDefaultAsync(n => n.ServiceId == id);
            _context.Services.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Service>> GetAllAsync()
        {
            var result = await _context.Services
                .Include(f => f.Freelancer)
                .Include(cs => cs.Cities_Services).ThenInclude(c => c.City)
                .ToListAsync();
            return result;
        }

        public async Task UpdateAsync(NewServiceVM newService)
        {
            var dbService = await _context.Services.FirstOrDefaultAsync(n => n.ServiceId == newService.ServiceId);

            if (dbService != null)
            {
                dbService.FreelancerId = newService.FreelancerId;
                dbService.ServiceName = newService.ServiceName;
                dbService.ServiceDescription = newService.ServiceDescription;
                dbService.ServicePicURL = newService.ServicePicURL;
                dbService.ServiceUM = newService.ServiceUM;
                dbService.ServiceActive = newService.ServiceActive;
                dbService.ServicePrice = newService.ServicePrice;
                await _context.SaveChangesAsync();

                var existingCities = _context.Cities_Services.Where(n => n.ServiceId == newService.ServiceId).ToList();
                _context.Cities_Services.RemoveRange(existingCities);
                await _context.SaveChangesAsync();

                foreach (var city in newService.Cities_ServicesIds)
                {
                    var new_city = new City_Service()
                    {
                        ServiceId = newService.ServiceId,
                        CityId = city
                    };
                    await _context.Cities_Services.AddAsync(new_city);
                }
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Service> GetByIdAsync(int id)
        {
            var result = await _context.Services
                .Include(f => f.Freelancer)
                .Include(cs => cs.Cities_Services).ThenInclude(c => c.City)
                .FirstOrDefaultAsync(n => n.ServiceId == id);
            return result;
        }

        public async Task<List<Service>> GetByFreelanceIdAsync(int id)
        {
            var result = await _context.Services
                .Include(f => f.Freelancer)
                .Include(cs => cs.Cities_Services).ThenInclude(c => c.City)
                .Where(f => f.FreelancerId == id).ToListAsync();
            return result;
        }

        public async Task<NewServiceDropdownsVM> GetParameters()
        {
            var response = new NewServiceDropdownsVM();
            response.Cities = await _context.Cities.OrderBy(n => n.CityName).ToListAsync();

            return response;
        }
    }
}

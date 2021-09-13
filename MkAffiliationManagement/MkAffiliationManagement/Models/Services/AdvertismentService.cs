using MkAffiliationManagement.data;
using MkAffiliationManagement.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MkAffiliationManagement.Models.Services
{
    public class AdvertismentService : IAdvertismentManager
    {
        private AdvertismentDbContext _context;
        public AdvertismentService(AdvertismentDbContext context)
        {
            _context = context;
        }
        public bool AdvertismentExists(int id)
        {
            return _context.Ad.Any(m => m.ID == id);
        }

        public Task CreateAdvertisment(Advertisment Ad)
        {
            throw new NotImplementedException();
        }

        public Task<Advertisment> DeleteAdvertisment(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAdvertismentFR(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Advertisment> GetAdvertisment(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Advertisment>> GetAdvertisments()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAdvertisment(int id, Advertisment Ad)
        {
            throw new NotImplementedException();
        }
    }
}

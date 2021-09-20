using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task CreateAdvertisment(Advertisment Ad)
        {
            _context.Add(Ad);
            await _context.SaveChangesAsync();
        }

        public async Task<Advertisment> DeleteAdvertisment(int id)
        {
            var SelectedAdvert = await _context.Ad.FirstOrDefaultAsync(m => m.ID == id);
            return SelectedAdvert;
        }

        public async Task DeleteAdvertismentFR(int id)
        {
            var SelectedAdvert = await _context.Ad.FirstOrDefaultAsync(a => a.ID == id);
            _context.Remove(SelectedAdvert);
            await _context.SaveChangesAsync();
        }

        public async Task<Advertisment> GetAdvertisment(int id)
        {
            return await _context.Ad.FirstOrDefaultAsync(v => v.ID == id);
        }

        public async Task<IEnumerable<Advertisment>> GetAdvertisments()
        {
            return await _context.Ad.ToListAsync();
        }

        public async Task UpdateAdvertisment(int id, [Bind("ID, ProductName, ProductEndorsment, ProductPromotionalCode, ProductLink,Engagements, Image")] Advertisment Ad)
        {
            _context.Update(Ad);
            await _context.SaveChangesAsync();
        }
    }
}

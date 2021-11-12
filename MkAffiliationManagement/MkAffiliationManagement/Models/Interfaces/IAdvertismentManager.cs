using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MkAffiliationManagement.Models.Interfaces
{
     public interface IAdvertismentManager
    {
        Task CreateAdvertisment(Advertisment Ad);
        Task UpdateAdvertisment(int id, Advertisment Ad);
        Task<Advertisment> DeleteAdvertisment(int id);
        Task DeleteAdvertismentFR(int id);
        Task<Advertisment> GetAdvertisment(int id);
        Task<IEnumerable<Advertisment>> GetAdvertisments();

        bool AdvertismentExists(int id);
    }
}

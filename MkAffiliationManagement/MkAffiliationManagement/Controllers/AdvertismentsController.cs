using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MkAffiliationManagement.Models;
using MkAffiliationManagement.data;
using Microsoft.AspNetCore.Authorization;
using MkAffiliationManagement.Areas.Identity.Data;
using MkAffiliationManagement.Models.Interfaces;

namespace MkAffiliationManagement.Controllers
{
    
    public class AdvertismentsController : Controller
    {
        private IAdvertismentManager _context;

        public AdvertismentsController(IAdvertismentManager context)
        {
            _context = context;
        }
        // GET: Advertisments
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAdvertisments());
        }

        // GET: Advertisments/Details/5
        
        public async Task<IActionResult> Details(int id)
        {
            
            var advertisment = await _context.GetAdvertisment(id);
            if (advertisment == null)
            {
                return NotFound();
            }

            return View(advertisment);
        }

        // GET: Advertisments/Create
        [Authorize(Roles = ApplicationRoles.Admin)]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Advertisments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = ApplicationRoles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ProductName,ProductEndorsment,ProductPromotionalCode,ProductLink,Engagements,Image")] Advertisment advertisment)
        {
            if (ModelState.IsValid)
            {
                await _context.CreateAdvertisment(advertisment);
                
                return RedirectToAction(nameof(Index));
            }
            return View(advertisment);
        }

        // GET: Advertisments/Edit/5
        [Authorize(Roles = ApplicationRoles.Admin)]
        public async Task<IActionResult> Edit(int id)
        {

            var advertisment = await _context.GetAdvertisment(id);
            if (advertisment == null)
            {
                return NotFound();
            }
            return View(advertisment);
        }

        // POST: Advertisments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = ApplicationRoles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, [Bind("ID,ProductName,ProductEndorsment,ProductPromotionalCode,ProductLink,Engagements,Image")] Advertisment advertisment)
        {
          
            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateAdvertisment(id, advertisment);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdvertismentExists(advertisment.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(advertisment);
        }

        // GET: Advertisments/Delete/5
        [Authorize(Roles = ApplicationRoles.Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            var advertisment = await _context.GetAdvertisment(id);
            await _context.DeleteAdvertisment(id);
            if (advertisment == null)
            {
                return NotFound();
            }

            return View(advertisment);
        }

        // POST: Advertisments/Delete/5
        [Authorize(Roles = ApplicationRoles.Admin)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var advertisment = await _context.GetAdvertisment(id);
            await _context.DeleteAdvertismentFR(id);
          
            return RedirectToAction(nameof(Index));
        }
    /*    private async Task<IActionResult> Engaged(int id)
        {
            var ad = await _context.Ad.FindAsync(id);
            ad.Engagements++;
            await _context.SaveChangesAsync();
            return Redirect(ad.ProductLink);
        }*/

        [Authorize(Roles = ApplicationRoles.Admin)]
        private bool AdvertismentExists(int id)
        {
            return _context.AdvertismentExists(id);
        }
    }
}

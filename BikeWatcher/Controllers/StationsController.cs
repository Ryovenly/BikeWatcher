using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BikeWatcher.Data;
using BikeWatcher.Models;

namespace BikeWatcher.Controllers
{
    public class StationsController : Controller
    {
        private readonly StationContext _context;

        public StationsController(StationContext context)
        {
            _context = context;
        }

        // GET: Stations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Stations.ToListAsync());
        }

        // GET: Stations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stations = await _context.Stations
                .FirstOrDefaultAsync(m => m.id == id);
            if (stations == null)
            {
                return NotFound();
            }

            return View(stations);
        }

        // GET: Stations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,number,pole,available_bikes,code_insee,lng,availability,availabilitycode,etat,startdate,langue,bike_stands,last_update,available_bike_stands,gid,titre,status,commune,description,nature,bonus,address2,address,lat,last_update_fme,enddate,name,banking,nmarrond")] Stations stations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stations);
        }

        // GET: Stations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stations = await _context.Stations.FindAsync(id);
            if (stations == null)
            {
                return NotFound();
            }
            return View(stations);
        }

        // POST: Stations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,number,pole,available_bikes,code_insee,lng,availability,availabilitycode,etat,startdate,langue,bike_stands,last_update,available_bike_stands,gid,titre,status,commune,description,nature,bonus,address2,address,lat,last_update_fme,enddate,name,banking,nmarrond")] Stations stations)
        {
            if (id != stations.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StationsExists(stations.id))
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
            return View(stations);
        }

        // GET: Stations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stations = await _context.Stations
                .FirstOrDefaultAsync(m => m.id == id);
            if (stations == null)
            {
                return NotFound();
            }

            return View(stations);
        }

        // POST: Stations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stations = await _context.Stations.FindAsync(id);
            _context.Stations.Remove(stations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StationsExists(int id)
        {
            return _context.Stations.Any(e => e.id == id);
        }
    }
}

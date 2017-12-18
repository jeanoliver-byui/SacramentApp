﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentApp.Data;
using SacramentApp.Models;

namespace SacramentApp.Controllers
{
    public class PrayersController : Controller
    {
        private readonly MeetingContext _context;

        public PrayersController(MeetingContext context)
        {
            _context = context;
        }

        // GET: Prayers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Prayers.ToListAsync());
        }

        // GET: Prayers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prayer = await _context.Prayers
                .SingleOrDefaultAsync(m => m.PrayerID == id);
            if (prayer == null)
            {
                return NotFound();
            }

            return View(prayer);
        }

        // GET: Prayers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prayers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrayerID,MeetingID,PrayerName,Order")] Prayer prayer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prayer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prayer);
        }

        // GET: Prayers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prayer = await _context.Prayers.SingleOrDefaultAsync(m => m.PrayerID == id);
            if (prayer == null)
            {
                return NotFound();
            }
            return View(prayer);
        }

        // POST: Prayers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrayerID,MeetingID,PrayerName,Order")] Prayer prayer)
        {
            if (id != prayer.PrayerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prayer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrayerExists(prayer.PrayerID))
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
            return View(prayer);
        }

        // GET: Prayers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prayer = await _context.Prayers
                .SingleOrDefaultAsync(m => m.PrayerID == id);
            if (prayer == null)
            {
                return NotFound();
            }

            return View(prayer);
        }

        // POST: Prayers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prayer = await _context.Prayers.SingleOrDefaultAsync(m => m.PrayerID == id);
            _context.Prayers.Remove(prayer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrayerExists(int id)
        {
            return _context.Prayers.Any(e => e.PrayerID == id);
        }
    }
}

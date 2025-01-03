using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL;
using WebApp.Models;

namespace WebApp.Areas.AdminPanel.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("AdminPanel")]
    public class DateTanimlarController : Controller
    {
        private readonly hospitalDB _context;

        public DateTanimlarController(hospitalDB context)
        {
            _context = context;
        }

        // GET: AdminPanel/DateTanimlar
        public async Task<IActionResult> Index()
        {
            var hospitalDB = _context.DateDetails.Include(r => r.Day).Include(r => r.Polyclinics).Include(r => r.Hour);
            return View(await hospitalDB.ToListAsync());
        }

        // GET: AdminPanel/DateTanimlar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DateDetails == null)
            {
                return NotFound();
            }

            var AppointmentDetails = await _context.DateDetails
                .Include(r => r.Day)
                .Include(r => r.Polyclinics)
                .Include(r => r.Hour)
                .FirstOrDefaultAsync(m => m.AppointmentDetailsID == id);
            if (AppointmentDetails == null)
            {
                return NotFound();
            }

            return View(AppointmentDetails);
        }

        // GET: AdminPanel/DateTanimlar/Create
        public IActionResult Create()
        {
            ViewData["DayID"] = new SelectList(_context.Days, "DayID", "DayName");
            ViewData["PolyclinicID"] = new SelectList(_context.Polyclinics, "PolyclinicID", "PolyclinicName");
            ViewData["HourID"] = new SelectList(_context.Hours, "HourID", "DateHouri");
            return View();
        }

        // POST: AdminPanel/DateTanimlar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppointmentDetailsID,PolyclinicID,DayID,HourID,DateStatus")] AppointmentDetails AppointmentDetails)
        {
            if (ModelState.IsValid)
            {
                _context.DateDetails.Add(AppointmentDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DayID"] = new SelectList(_context.Days, "DayID", "DayID", AppointmentDetails.DayID);
            ViewData["PolyclinicID"] = new SelectList(_context.Polyclinics, "PolyclinicID", "PolyclinicID", AppointmentDetails.PolyclinicID);
            ViewData["HourID"] = new SelectList(_context.Hours, "HourID", "HourID", AppointmentDetails.HourID);
            return View(AppointmentDetails);
        }

        // GET: AdminPanel/DateTanimlar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DateDetails == null)
            {
                return NotFound();
            }

            var AppointmentDetails = await _context.DateDetails.FindAsync(id);
            if (AppointmentDetails == null)
            {
                return NotFound();
            }
            ViewData["DayID"] = new SelectList(_context.Days, "DayID", "DayID", AppointmentDetails.DayID);
            ViewData["PolyclinicID"] = new SelectList(_context.Polyclinics, "PolyclinicID", "PolyclinicID", AppointmentDetails.PolyclinicID);
            ViewData["HourID"] = new SelectList(_context.Hours, "HourID", "HourID", AppointmentDetails.HourID);
            return View(AppointmentDetails);
        }

        // POST: AdminPanel/DateTanimlar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppointmentDetailsID,PolyclinicID,DayID,HourID,DateStatus")] AppointmentDetails AppointmentDetails)
        {
            if (id != AppointmentDetails.AppointmentDetailsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(AppointmentDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentDetailsExists(AppointmentDetails.AppointmentDetailsID))
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
            ViewData["DayID"] = new SelectList(_context.Days, "DayID", "DayID", AppointmentDetails.DayID);
            ViewData["PolyclinicID"] = new SelectList(_context.Polyclinics, "PolyclinicID", "PolyclinicID", AppointmentDetails.PolyclinicID);
            ViewData["HourID"] = new SelectList(_context.Hours, "HourID", "HourID", AppointmentDetails.HourID);
            return View(AppointmentDetails);
        }

        // GET: AdminPanel/DateTanimlar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DateDetails == null)
            {
                return NotFound();
            }

            var AppointmentDetails = await _context.DateDetails
                .Include(r => r.Day)
                .Include(r => r.Polyclinics)
                .Include(r => r.Hour)
                .FirstOrDefaultAsync(m => m.AppointmentDetailsID == id);
            if (AppointmentDetails == null)
            {
                return NotFound();
            }

            return View(AppointmentDetails);
        }

        // POST: AdminPanel/DateTanimlar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DateDetails == null)
            {
                return Problem("Entity set 'hospitalDB.DateDetails'  is null.");
            }
            var AppointmentDetails = await _context.DateDetails.FindAsync(id);
            if (AppointmentDetails != null)
            {
                _context.DateDetails.Remove(AppointmentDetails);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentDetailsExists(int id)
        {
            return _context.DateDetails.Any(e => e.AppointmentDetailsID == id);
        }
    }
}

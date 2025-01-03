using System.Security.Claims;
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
    public class AppointmentsController : Controller
    {
        private readonly hospitalDB _context;

        public AppointmentsController(hospitalDB context)
        {
            _context = context;
        }

        // GET: AdminPanel/Randevlar
        public async Task<IActionResult> Index()
        {
            var hospitalDB = _context.Appointments.Include(r => r.AppointmentDetails).Include(r => r.Patient);
            return View(await hospitalDB.ToListAsync());
        }

        // GET: AdminPanel/Randevlar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Appointments == null)
            {
                return NotFound();
            }

            var date = await _context.Appointments
                .Include(r => r.AppointmentDetails)
                .Include(r => r.Patient)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (date == null)
            {
                return NotFound();
            }

            return View(date);
        }

        // GET: AdminPanel/Randevlar/Create
        public IActionResult Create()
        {
            var patients = _context.Users.Select(u => new
            {
                u.Id,
                FullName = u.Name + " " + u.Surname
            }).ToList();
            ViewData["AppointmentDetailsID"] = new SelectList(_context.DateDetails, "AppointmentDetailsID", "AppointmentDetailsID");
            ViewData["PatientID"] = new SelectList(patients, "Id", "FullName");
            return View();
        }

        // POST: AdminPanel/Randevlar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserID,AppointmentDetailsID,AppointmentDate,DidUserArrive")] Date date)
        {
            var doctorId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            date.DoctorID = doctorId;

            if (ModelState.IsValid)
            {
                await _context.Appointments.AddAsync(date);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var patients = _context.Users.Select(u => new
            {
                u.Id,
                FullName = u.Name + " " + u.Surname
            }).ToList();
            ViewData["AppointmentDetailsID"] = new SelectList(_context.DateDetails, "AppointmentDetailsID", "AppointmentDetailsID", date.AppointmentDetailsID);
            ViewData["PatientID"] = new SelectList(patients, "Id", "FullName", date.PatientID);
            return View(date);
        }


        // GET: AdminPanel/Randevlar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Appointments == null)
            {
                return NotFound();
            }

            var date = await _context.Appointments.FindAsync(id);
            if (date == null)
            {
                return NotFound();
            }
            var patients = _context.Users.Select(u => new
            {
                u.Id,
                FullName = u.Name + " " + u.Surname
            }).ToList();
            ViewData["AppointmentDetailsID"] = new SelectList(_context.DateDetails, "AppointmentDetailsID", "AppointmentDetailsID", date.AppointmentDetailsID);
            ViewData["PatientID"] = new SelectList(patients, "Id", "FullName", date.PatientID);
            return View(date);
        }

        // POST: AdminPanel/Randevlar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserID,AppointmentDetailsID,AppointmentDate,DidUserArrive")] Date date)
        {
            if (id != date.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(date);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DateExists(date.ID))
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
            var patients = _context.Users.Select(u => new
            {
                u.Id,
                FullName = u.Name + " " + u.Surname
            }).ToList();
            ViewData["AppointmentDetailsID"] = new SelectList(_context.DateDetails, "AppointmentDetailsID", "AppointmentDetailsID", date.AppointmentDetailsID);
            ViewData["PatientID"] = new SelectList(patients, "Id", "FullName", date.PatientID);
            return View(date);
        }

        // GET: AdminPanel/Randevlar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Appointments == null)
            {
                return NotFound();
            }

            var date = await _context.Appointments
                .Include(r => r.AppointmentDetails)
                .Include(r => r.Patient)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (date == null)
            {
                return NotFound();
            }

            return View(date);
        }

        // POST: AdminPanel/Randevlar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Appointments == null)
            {
                return Problem("Entity set 'hospitalDB.Appointments'  is null.");
            }
            var date = await _context.Appointments.FindAsync(id);
            if (date != null)
            {
                _context.Appointments.Remove(date);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DateExists(int id)
        {
            return _context.Appointments.Any(e => e.ID == id);
        }
    }
}

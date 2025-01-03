using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL;
using WebApp.Models;

namespace WebApp.Areas.DoctorPanel.Controllers
{
    [Authorize(Roles = "Doctor")]
    [Area("DoctorPanel")]
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
            var hospitalDB = _context.Appointments.Include(r => r.AppointmentDetails).Include(r => r.Patient).Include(r => r.Doctor)
                .Include(r => r.AppointmentDetails).ThenInclude(ad => ad.Room);
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
                    .ThenInclude(ad => ad.Room)
                .Include(r => r.Patient)
                .Include(r => r.Doctor)
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
            var appointmentDetails = _context.DateDetails
                .Include(ad => ad.Room)
                .Where(ad => ad.DateStatus == true && ad.DoctorID == null && ad.PatientID == null)
                .Select(ad => new
                {
                    ad.AppointmentDetailsID,
                    DisplayText = $"Room {ad.Room.RoomNumber}"
                })
                .ToList();
            ViewData["PatientID"] = new SelectList(patients, "Id", "FullName");
            ViewData["AppointmentDetailsID"] = new SelectList(appointmentDetails, "AppointmentDetailsID", "DisplayText");
            return View();
        }

        // POST: AdminPanel/Randevlar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PatientID,AppointmentDetailsID,AppointmentDate,DidUserArrive")] Date date)
        {
            var doctorId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            date.DoctorID = doctorId;
            if (ModelState.IsValid)
            {
                // Update AppointmentDetails with DoctorID and PatientID
                var appointmentDetail = await _context.DateDetails.FindAsync(date.AppointmentDetailsID);
                if (appointmentDetail == null)
                {
                    ModelState.AddModelError("AppointmentDetailsID", "Selected appointment slot does not exist.");
                    return View(date);
                }

                appointmentDetail.DoctorID = doctorId;
                appointmentDetail.PatientID = date.PatientID;
                appointmentDetail.DateStatus = false; // Mark as booked

                // Optionally, you might want to update the AppointmentDate based on the AppointmentDetails
                date.AppointmentDate = DateTime.Now.AddDays(7);

                _context.Update(appointmentDetail);

                await _context.Appointments.AddAsync(date);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var patients = _context.Users.Select(u => new
            {
                u.Id,
                FullName = u.Name + " " + u.Surname
            }).ToList();

            ViewData["PatientID"] = new SelectList(patients, "Id", "FullName", date.PatientID);
            ViewData["AppointmentDetailsID"] = new SelectList(_context.DateDetails, "AppointmentDetailsID", "AppointmentDetailsID", date.AppointmentDetailsID);
            return View(date);
        }


        // GET: AdminPanel/Randevlar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Appointments == null)
            {
                return NotFound();
            }

            var date = await _context.Appointments
                .Include(r => r.AppointmentDetails)
                .ThenInclude(ad => ad.Room)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (date == null)
            {
                return NotFound();
            }
            var doctorId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            date.DoctorID = doctorId;
            ViewData["AppointmentDetailsID"] = new SelectList(_context.DateDetails, "AppointmentDetailsID", "AppointmentDetailsID", date.AppointmentDetailsID);
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", date.PatientID);
            return View(date);
        }

        // POST: AdminPanel/Randevlar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PatientID,AppointmentDetailsID,AppointmentDate,DidUserArrive")] Date date)
        {
            if (id != date.ID)
            {
                return NotFound();
            }
            var doctorId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            date.DoctorID = doctorId;
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

            ViewData["AppointmentDetailsID"] = new SelectList(_context.DateDetails, "AppointmentDetailsID", "AppointmentDetailsID", date.AppointmentDetailsID);
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", date.PatientID);
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
                .ThenInclude(ad => ad.Room)
                .Include(r => r.Patient)
                .Include(r => r.Doctor)

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
            var appointment = await _context.Appointments
                .Include(a => a.AppointmentDetails)
                .FirstOrDefaultAsync(a => a.ID == id);

            if (appointment != null)
            {
                var appointmentDetail = appointment.AppointmentDetails;
                if (appointmentDetail != null)
                {
                    appointmentDetail.DateStatus = true;
                    appointmentDetail.DoctorID = null;
                    appointmentDetail.PatientID = null;

                    _context.Update(appointmentDetail);
                }
                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool DateExists(int id)
        {
            return _context.Appointments.Any(e => e.ID == id);
        }
        private IEnumerable<object> GetAvailableAppointmentDetails()
        {
            var appointmentDetails = _context.DateDetails
                .Include(ad => ad.Day)
                .Include(ad => ad.Hour)
                .Include(ad => ad.Room)
                .Where(ad => ad.DateStatus == true && ad.DoctorID == null && ad.PatientID == null)
                .Select(ad => new
                {
                    ad.AppointmentDetailsID,
                    DisplayText = $"{ad.Day.DayName} at {ad.Hour.DateHouri} in Room {ad.Room.RoomNumber}"
                })
                .ToList();

            return appointmentDetails;
        }
    }
}

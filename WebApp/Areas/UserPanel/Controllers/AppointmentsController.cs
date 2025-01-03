using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL;
using WebApp.Models;
using WebApplication1.Models;

namespace WebApp.Areas.UserPanel.Controllers
{
    [Authorize(Roles = "User")]
    [Area("UserPanel")]
    public class AppointmentsController : Controller
    {
        private readonly hospitalDB _context;
        private readonly UserManager<User> _userManager;

        public AppointmentsController(hospitalDB context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: UserPanel/Appointments
        public async Task<IActionResult> Index()
        {
            var UserID = GetUserID();
            var Appointments = await _context.Appointments
                .Include(r => r.AppointmentDetails)
                .Include(r => r.Patient)
                .Where(x => x.PatientID == UserID)
                .ToListAsync();
            return View(Appointments);
        }

        // GET: UserPanel/Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
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

        // GET: UserPanel/Appointments/Create
        public IActionResult Create(int? id = 1)
        {
            DateTime today = DateTime.Now;
            int dayIndex = ((int)today.DayOfWeek + 1) % 7;

            var gun = _context.Days.Find(dayIndex)?.DayName;
            if (gun == null)
            {
                return NotFound("Day info foundName.");
            }
            ViewBag.Day = gun;

            var availableAppointments = _context.DateDetails
                .Include(r => r.Hour)
                .Where(x => x.PolyclinicID == id && x.DayID == dayIndex && x.DateStatus != true)
                .Select(x => new Date_VM { ID = x.AppointmentDetailsID, DayID = x.DayID, Hour = x.Hour.DateHouri })
                .ToList();

            if (availableAppointments.Count == 0)
            {
                ViewData["AppointmentMessage"] = "No available appointment can be made";
                ViewData["AppointmentDetailsID"] = new SelectList(Enumerable.Empty<SelectListItem>());
            }
            else
            {
                ViewData["AppointmentMessage"] = null;
                ViewData["AppointmentDetailsID"] = new SelectList(availableAppointments, "ID", "Hour");
            }
            //ViewData["AppointmentDetailsID"] = new SelectList(availableAppointments, "ID", "Hour");
            ViewBag.Polyclinics = new SelectList(_context.Polyclinics, "PolyclinicID", "PolyclinicName", id);

            return View();
        }

        // POST: UserPanel/Appointments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int AppointmentDetailsID)
        {
            var UserID = GetUserID();

            var date = new Date
            {
                AppointmentDetailsID = AppointmentDetailsID,
                AppointmentDate = DateTime.Now.AddDays(1),
                PatientID = UserID
            };

            _context.Appointments.Add(date);
            await _context.SaveChangesAsync();

            var AppointmentDetails = await _context.DateDetails.FindAsync(AppointmentDetailsID);
            if (AppointmentDetails != null)
            {
                AppointmentDetails.DateStatus = true;
                _context.DateDetails.Update(AppointmentDetails);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: UserPanel/Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
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

        // POST: UserPanel/Appointments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PatientID,AppointmentDetailsID,AppointmentDate,DidUserArrive")] Date date)
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

        // GET: UserPanel/Appointments/Delete/5
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

        private int GetUserID()
        {
            return int.Parse(_userManager.GetUserId(User));
        }

        private bool DateExists(int id)
        {
            return _context.Appointments.Any(e => e.ID == id);
        }
    }
}

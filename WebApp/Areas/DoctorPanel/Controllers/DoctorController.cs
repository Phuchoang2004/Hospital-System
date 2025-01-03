using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL;
using WebApp.Models;

namespace WebApp.Areas.DoctorPanel.Controllers
{
    [Authorize(Roles = "Admin, Doctor")]
    [Area("DoctorPanel")]
    public class DoctorController : Controller
    {
        private readonly hospitalDB _context;
        private readonly UserManager<User> _userManager;

        public DoctorController(hospitalDB context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ViewPatient()
        {
            var users = _context.Users.ToList();
            var patients = new List<User>();
            foreach (var user in users)
            {
                var role = await _userManager.GetRolesAsync(user);
                if (role.Contains("User"))
                {
                    patients.Add(user);
                }
            }
            return View(patients);
        }

        public async Task<IActionResult> ViewRecord(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }
            var User = await _context.Users.FindAsync(id);
            if (User == null)
            {
                return NotFound();
            }
            var medicalRecords = await _context.MedicalRecords
                                        .Include(mr => mr.User)
                                        .Where(mr => mr.UserID == id)
                                        .ToListAsync();
            ViewBag.UserId = id;
            return View(medicalRecords);
        }

        public IActionResult AddRecord(int userId)
        {
            ViewBag.UserId = userId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord(MedicalRecord medicalRecord)
        {
            if (ModelState.IsValid)
            {
                _context.MedicalRecords.Add(medicalRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ViewRecord), new { id = medicalRecord.UserID });
            }
            ViewBag.UserId = medicalRecord.UserID;
            return View(medicalRecord);
        }
    }
}

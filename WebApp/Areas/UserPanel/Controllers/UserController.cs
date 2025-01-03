using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApp.DAL;
using WebApp.Models;

namespace WebApp.Areas.UserPanel.Controllers
{
    [Authorize(Roles = "User")]
    [Area("UserPanel")]
    public class UserController : Controller
    {
        UserManager<User> _userManager;
        hospitalDB _db;
        public UserController(UserManager<User> userManager, hospitalDB db)
        {
            _userManager = userManager;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult MedicalRecord()
        {
            int userId = GetUserID();
            var medicalRecords = _db.MedicalRecords
                                   .Include(mr => mr.User)
                                   .Where(mr => mr.UserID == userId)
                                   .ToList();

            return View(medicalRecords);
        }

        private int GetUserID()
        {
            return int.Parse(_userManager.GetUserId(User));
        }

    }
}

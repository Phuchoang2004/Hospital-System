using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL;
using WebApp.Models;

namespace WebApp.Areas.AdminPanel.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("AdminPanel")]
    public class UserController : Controller
    {
        private readonly hospitalDB _context;

        public UserController(hospitalDB context)
        {
            _context = context;
        }

        // GET: AdminPanel/User
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: AdminPanel/User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var User = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (User == null)
            {
                return NotFound();
            }

            return View(User);
        }

        // GET: AdminPanel/User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Surname,Nameres,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] User User)
        {
            if (ModelState.IsValid)
            {
                _context.Add(User);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(User);
        }

        // GET: AdminPanel/User/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            return View(User);
        }

        // POST: AdminPanel/User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Surname,Nameres,Id,UserName,PhoneNumber")] User User)
        {
            if (id != User.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingUser = await _context.Users.FindAsync(id);
                    if (existingUser == null)
                    {
                        return NotFound();
                    }
                    existingUser.Name = User.Name;
                    existingUser.Surname = User.Surname;
                    existingUser.Nameres = User.Nameres;
                    existingUser.UserName = User.UserName;
                    existingUser.PhoneNumber = User.PhoneNumber;

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                    //_context.Update(User);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(User.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(User);
        }

        // GET: AdminPanel/User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var User = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (User == null)
            {
                return NotFound();
            }

            return View(User);
        }

        // POST: AdminPanel/User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'hospitalDB.Users'  is null.");
            }
            var User = await _context.Users.FindAsync(id);
            if (User != null)
            {
                _context.Users.Remove(User);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}

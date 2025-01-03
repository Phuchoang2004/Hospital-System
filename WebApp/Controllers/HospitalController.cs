using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL;

namespace WebApp.Controllers
{
    public class hospitalController : Controller
    {
        hospitalDB _db;
        public hospitalController(hospitalDB db)
        {
            _db = db;
            _db.Database.EnsureCreated();
        }
    }
}

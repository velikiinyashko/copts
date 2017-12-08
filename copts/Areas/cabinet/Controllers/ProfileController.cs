using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using copts.Models;

namespace copts.Areas.cabinet.Controllers
{
    [Area("Cabinet")]
    public class ProfileController : Controller
    {
        private BaseContext _context;

        public ProfileController(BaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string Name)
        {
            if (Name != null)
            {
                User user = await _context.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Login == Name);
                return View(user);
            }
            else
            {
                return View("Error");
            }
        }
    }
}
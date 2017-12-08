using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using copts.Models;
using copts.Areas.cabinet.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace copts.Areas.cabinet.Controllers
{
    [Area("cabinet")]
    public class AdminController : Controller
    {
        private BaseContext _context;

        public AdminController(BaseContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Users
                .Include(u => u.Role)
                .ToListAsync());
        }
    }
}
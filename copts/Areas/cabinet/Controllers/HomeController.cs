using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using copts.Models;
using copts.Areas.cabinet.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace copts.Areas.cabinet.Controllers
{
    [Area("cabinet")]
    public class HomeController : Controller
    {
        private BaseContext _context;

        public HomeController(BaseContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                Users user = await _context.Users
                    .Include(u => u.Roles)
                    .FirstOrDefaultAsync(u => u.Login == login.Login && u.Password == login.Password);
                if(user != null)
                {
                    await Authenticate(user);

                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Не корректные логин и(или) пароль");
            }
            return View(login);
        }

        public async Task<IActionResult> Registrate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrate(RegisterModel register)
        {
            if (ModelState.IsValid)
            {
                Users user = await _context.Users.FirstOrDefaultAsync(u => u.Login == register.Login);
                if (user == null)
                {
                    user = new Users { Login = register.Login, Password = register.Password, Email = register.Email, Name = register.Name, Surname = register.Surname };
                    Roles userRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "user");
                    if (userRole != null)
                    {
                        user.Roles = userRole;
                    }
                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();

                    await Authenticate(user);

                    return RedirectToAction("index");
                }
                else
                {
                    ModelState.AddModelError("", "Не корректные логин и(или пароль");
                }
            }
            return View(register);
        }

        private async Task Authenticate(Users user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Roles?.Name)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
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
using System.Security.Cryptography;
using System.Text;

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

        public async Task<IActionResult> Enter()
        {
            return View();
        }

        public async Task<IActionResult> Menu()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Index(int? Id)
        {
            User user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == Id);
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel lm)
        {

            if (ModelState.IsValid)
            {
                string passwd = HashMD5(lm.Password);
                User user = await _context.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Login == lm.Login && u.Password == passwd);
                if (user != null)
                {
                    await Authenticate(user);

                    return RedirectToAction("index");
                }
                ModelState.AddModelError("", "Не корректные логин и(или) пароль");
            }
            return View(lm);
        }

        [HttpGet]
        public async Task<IActionResult> Registrate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registrate(RegisterModel register)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Login == register.Login);
                if (user == null)
                {
                    string passwd = HashMD5(register.Password);
                    user = new User { Login = register.Login, Password = passwd, Email = register.Email, Name = register.Name, Surname = register.Surname };
                    Role userRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "User");
                    if (userRole != null)
                    {
                        user.Role = userRole;
                    }
                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();

                    await Authenticate(user);

                    return RedirectToAction("index");
                }
                else
                {
                    ModelState.AddModelError("", "Не корректные логин и(или) пароль");
                }
            }
            return View(register);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("index");
        }

        private async Task Authenticate(User user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public string HashMD5(string text)
        {
            using(MD5 Md5Hash = MD5.Create())
            {
                byte[] data = Md5Hash.ComputeHash(Encoding.UTF8.GetBytes(text));
                StringBuilder builder = new StringBuilder();
                for(int i = 0; i < data.Length; i++)
                {
                    builder.Append(data[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
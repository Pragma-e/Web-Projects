using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KuponApp.Data;
using KuponApp.Models;

namespace KuponApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Admin giriş sayfası
        public IActionResult Login()
        {
            return View();
        }

        // Admin giriş kontrolü
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Basit admin kontrolü (daha sonra geliştirilebilir)
            if (username == "admin" && password == "123456")
            {
                // Session'a admin bilgisini kaydet
                HttpContext.Session.SetString("IsAdmin", "true");
                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Kullanıcı adı veya şifre hatalı!";
            return View();
        }

        // Admin dashboard
        public async Task<IActionResult> Dashboard()
        {
            // Admin kontrolü
            if (HttpContext.Session.GetString("IsAdmin") != "true")
            {
                return RedirectToAction("Login");
            }

            // Tüm kuponları kullanıcı bilgileriyle birlikte getir
            var coupons = await _context.Coupons
                .Include(c => c.User)
                .OrderByDescending(c => c.CreatedDate)
                .ToListAsync();

            return View(coupons);
        }

        // Admin çıkış
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
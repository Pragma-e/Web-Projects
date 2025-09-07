using Microsoft.AspNetCore.Mvc;
using KuponApp.Data;
using KuponApp.Models;
using KuponApp.Services;

namespace KuponApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly CouponService _couponService;

        public HomeController(ApplicationDbContext context, CouponService couponService)
        {
            _context = context;
            _couponService = couponService;
        }

        // Anasayfa - Kullanıcı bilgi formu
        public IActionResult Index()
        {
            return View();
        }

        // Form gönderildiğinde çalışır
        [HttpPost]
        public async Task<IActionResult> CreateCoupon(User user)
        {
            if (ModelState.IsValid)
            {
                // Kullanıcıyı database'e kaydet
                user.CreatedDate = DateTime.Now;
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                // Kupon oluştur
                var coupon = new Coupon
                {
                    CouponCode = _couponService.GenerateUniqueCouponCode(),
                    DiscountAmount = _couponService.GenerateRandomDiscount(),
                    UserId = user.Id,
                    CreatedDate = DateTime.Now,
                    IsUsed = false
                };

                _context.Coupons.Add(coupon);
                await _context.SaveChangesAsync();

                // Kupon sayfasına yönlendir
                return RedirectToAction("ShowCoupon", "Coupon", new { id = coupon.Id });
            }

            return View("Index", user);
        }
    }
}
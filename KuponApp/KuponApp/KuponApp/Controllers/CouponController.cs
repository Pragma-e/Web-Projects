using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KuponApp.Data;

namespace KuponApp.Controllers
{
    public class CouponController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CouponController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Kupon gösterme sayfası
        public async Task<IActionResult> ShowCoupon(int id)
        {
            var coupon = await _context.Coupons
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (coupon == null)
            {
                return NotFound();
            }

            return View(coupon);
        }
    }
}
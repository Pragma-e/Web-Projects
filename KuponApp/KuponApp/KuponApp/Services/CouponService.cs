using KuponApp.Data;
using KuponApp.Models;

namespace KuponApp.Services
{
    public class CouponService
    {
        private readonly ApplicationDbContext _context;
        private readonly Random _random;

        public CouponService(ApplicationDbContext context)
        {
            _context = context;
            _random = new Random();
        }

        // 8 haneli uniq kupon kodu oluştur
        public string GenerateUniqueCouponCode()
        {
            string code;
            do
            {
                code = GenerateRandomCode();
            } while (_context.Coupons.Any(c => c.CouponCode == code));
            
            return code;
        }

        private string GenerateRandomCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        // 200-2000 TL arası rastgele indirim
        public decimal GenerateRandomDiscount()
        {
            return _random.Next(200, 2001); // 200-2000 arası
        }
    }
}
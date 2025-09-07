// Controllers/OgrencilerController.cs
using Microsoft.AspNetCore.Mvc;
using OgrenciKayitFormu.Models;
using OgrenciKayitFormu.Data;
using System.Threading.Tasks;

namespace OgrenciKayitFormu.Controllers
{
    public class OgrencilerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OgrencilerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ogrenciler/Kayit
        public IActionResult Kayit()
        {
            return View();
        }

        // POST: Ogrenciler/Kayit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Kayit([Bind("Ad,Soyad,OgrenciNumarasi,DogumTarihi")] Ogrenci ogrenci)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ogrenci);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Öğrenci başarıyla kaydedildi!";
                return RedirectToAction(nameof(Kayit)); // Formu sıfırlamak için aynı sayfaya yönlendir
            }
            return View(ogrenci);
        }
    }
}
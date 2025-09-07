// Models/Ogrenci.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace OgrenciKayitFormu.Models
{
    public class Ogrenci
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad alanı boş bırakılamaz.")]
        [StringLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir.")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyad alanı boş bırakılamaz.")]
        [StringLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir.")]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "Öğrenci Numarası alanı boş bırakılamaz.")]
        [StringLength(20, ErrorMessage = "Öğrenci Numarası en fazla 20 karakter olabilir.")]
        public string OgrenciNumarasi { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DogumTarihi { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace KuponApp.Models
{
    public class User
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Ad alanı zorunludur")]
        [StringLength(30, ErrorMessage = "Ad en fazla 30 karakter olabilir")]
        public string FirstName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Soyad alanı zorunludur")]
        [StringLength(30, ErrorMessage = "Soyad en fazla 30 karakter olabilir")]  
        public string LastName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "E-posta alanı zorunludur")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
        [StringLength(100, ErrorMessage = "E-posta en fazla 100 karakter olabilir")]
        public string Email { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Telefon alanı zorunludur")]
        [StringLength(16, ErrorMessage = "Telefon en fazla 10 karakter olabilir")]
        public string Phone { get; set; } = string.Empty;
        
        public DateTime CreatedDate { get; set; }
        
        // İlişki - Bir kullanıcının birden fazla kuponu olabilir
        public virtual ICollection<Coupon> Coupons { get; set; } = new List<Coupon>();
    }
}
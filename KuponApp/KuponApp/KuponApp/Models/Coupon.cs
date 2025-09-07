using System.ComponentModel.DataAnnotations;

namespace KuponApp.Models
{
    public class Coupon
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(8, MinimumLength = 8)]
        public string CouponCode { get; set; } = string.Empty;
        
        [Required]
        public decimal DiscountAmount { get; set; }
        
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsUsed { get; set; }
        
        // İlişki - Her kupon bir kullanıcıya ait
        public virtual User User { get; set; } = null!;
    }
}
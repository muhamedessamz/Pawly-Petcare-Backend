using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PawlyPetCare.Domain.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "Processing"; // Processing, Shipped, Delivered
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}

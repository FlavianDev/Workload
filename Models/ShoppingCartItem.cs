using System.ComponentModel.DataAnnotations;

namespace WorkloadApp.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int ShoppingCartItemId { get; set; }

        public Service Service { get; set; }
        public int Amount { get; set; }
        public string Details { get; set; }

        public string ShoppingCartId { get; set; }
    }
}

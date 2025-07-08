using System.ComponentModel.DataAnnotations;

namespace IMS.WebApp.ViewModels
{
    public class PurchaseViewModel
    {
        [Required]
        public string PONumber { get; set; } = string.Empty;

        [Range(minimum: 1, maximum:int.MaxValue, ErrorMessage ="You have to select an inventory")]
        public int InventoryId { get; set; }

        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Quantity has to be greater or equal to 1")]
        public int QuantityToPurchase { get; set; }

        [Range(minimum: 0.01, maximum: int.MaxValue, ErrorMessage = "Price has to be greater or equal to 0.01")]
        public double InventoryPrice { get; set; }
    }
}

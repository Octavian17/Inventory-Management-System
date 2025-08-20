using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusiness
{
    public class InventoryViewModel
    {
        public int InventoryId { get; set; }

        [Required]
        [StringLength(150)]
        public string InventoryName { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative number.")]
        public int Quantity { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Price must be a non-negative number.")]
        public double Price { get; set; }
	}
}

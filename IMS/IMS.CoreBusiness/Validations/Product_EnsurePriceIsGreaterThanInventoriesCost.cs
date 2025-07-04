using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness.Validations
{
	public class Product_EnsurePriceIsGreaterThanInventoriesCost: ValidationAttribute
	{
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			var product = validationContext.ObjectInstance as Product;
			if(product != null)
			{
				if (!ValidatePricing(product))
					return new ValidationResult($"The product's price is less than the inventories cost: {TotalInventoryCost(product).ToString("c")}!",
						new List<string>() { validationContext.MemberName});
			}

			return ValidationResult.Success;
		}

		private double TotalInventoryCost(Product product)
		{
			if (product == null || product.ProductInventory == null) return 0;

			return product.ProductInventory.Sum(x => x.Inventory?.Price * x.InventoryQuantity ?? 0);
		}

		private bool ValidatePricing(Product product)
		{
			if (product.ProductInventory == null || product.ProductInventory.Count <= 0) return true;

			if (TotalInventoryCost(product) > product.Price) return false;

			return true;
		}
	}
}

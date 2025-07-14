using IMS.WebApp.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace IMS.WebApp.ViewModelsValidation
{
    public class Produce_EnsureEnoughInventoryQuantity: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var produceViewModel = validationContext.ObjectInstance as ProduceViewModel;

            if(produceViewModel != null)
            {
                if(produceViewModel.Product != null && produceViewModel.Product.ProductInventory != null)
                {
                    foreach(var productInventory in produceViewModel.Product.ProductInventory)
                    {
                        if(productInventory.Inventory != null &&
                            productInventory.InventoryQuantity * produceViewModel.QuantityToProduce > productInventory.Inventory.Quantity)
                        {
                            return new ValidationResult($"The '{productInventory.Inventory.InventoryName}' does not have enough quantity to produce {produceViewModel.QuantityToProduce} of product '{produceViewModel.Product.ProductName}'.",
                                new[] { validationContext.MemberName });
                        }
                    }
                }    
            }
            return ValidationResult.Success;
        }
    }
}

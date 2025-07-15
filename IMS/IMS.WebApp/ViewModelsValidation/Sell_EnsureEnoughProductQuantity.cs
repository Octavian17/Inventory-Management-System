using IMS.WebApp.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace IMS.WebApp.ViewModelsValidation
{
    public class Sell_EnsureEnoughProductQuantity: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var sellViewModel = validationContext.ObjectInstance as SellViewModel;

            if (sellViewModel != null)
            {
                if (sellViewModel.Product != null)
                {     
                    if (sellViewModel.Product.Quantity < sellViewModel.QuantityToSell)
                    {
                        return new ValidationResult($"The product '{sellViewModel.Product.ProductName}' does not have enough quantity to sell {sellViewModel.QuantityToSell}.",
                            new[] { validationContext.MemberName });
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}

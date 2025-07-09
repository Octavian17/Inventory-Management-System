using IMS.CoreBusiness;

namespace IMS.UseCases.Activities
{
    public interface IProductTransactionRepository
    {
        Task ProduceAsync(string productionNumber, Product product, int quantity, string doneBy);
    }
}
using IMS.UseCases.Products.Interfaces;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Products
{
    public class DeleteProductUseCase : IDeleteProductUseCase
	{
		private readonly IProductRepository productRepository;

		public DeleteProductUseCase(IProductRepository productRepository)
		{
			this.productRepository = productRepository;
		}

		public async Task ExecuteAsync(int productId)
		{
			await productRepository.DeleteProductByIdAsync(productId);
		}
	}
}

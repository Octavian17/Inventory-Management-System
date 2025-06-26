﻿using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using System.Security.Cryptography.X509Certificates;

namespace IMS.Plugins.InMemory
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _inventories;

        public ProductRepository()
        {
            _inventories = new List<Product>()
            {
                new Product { ProductId = 1, ProductName = "Bike", Quantity = 10, Price = 150 },
                new Product { ProductId = 2, ProductName = "Car", Quantity = 10, Price = 250000 },
            };
        }

        public Task AddProductAsync(Product product)
        {
            if(_inventories.Any(x=> x.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase)))
            {
                return Task.CompletedTask;
            }

            var maxId = _inventories.Max(x => x.ProductId);
            product.ProductId = maxId + 1;

            _inventories.Add(product);

            return Task.CompletedTask;
        }

        public Task DeleteProductByIdAsync(int productId)
        {
            var product = _inventories.FirstOrDefault(x => x.ProductId == productId);

            if(product is not null)
            {
                 _inventories.Remove(product);
            }
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_inventories);

            return _inventories.Where(x => x.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
           return await Task.FromResult(_inventories.First(x => x.ProductId == productId));
        }

        public Task UpdateProductAsync(Product product)
        {
            if(_inventories.Any(x => x.ProductId != product.ProductId && x.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase)))
                return Task.CompletedTask; 

            var invToUpdate = _inventories.FirstOrDefault(x => x.ProductId == product.ProductId);

            if(invToUpdate is not null)
            {
                invToUpdate.ProductName = product.ProductName;
                invToUpdate.Quantity = product.Quantity;
                invToUpdate.Price = product.Price;
            }

            return Task.CompletedTask;
        }
    }
}

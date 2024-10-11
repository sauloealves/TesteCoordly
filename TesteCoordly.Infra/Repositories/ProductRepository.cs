using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TesteCoordly.Domain.Entities;
using TesteCoordly.Domain.Interfaces;

namespace TesteCoordly.Infra.Repositories {
	public class ProductRepository :IProductRepository {
		
		private readonly string _filePath = "products.json";

		private List<Product> _products;

		public ProductRepository()
        {
			_products = LoadProductsFromFile();
		}
		
		public async Task<bool> DeleteById(int id) {
			bool retorno = false;
			var product = await GetById(id);

			if(product != null) {
				_products.Remove(product);
				SaveProductsToFile();
				retorno = true; 
			}
			return retorno; 
		}

		public async Task<IEnumerable<Product>> GetAll() {
			return _products;
		}

		public async Task<Product> GetById(int id) {
			return _products.Where(e => e.ProductId == id).FirstOrDefault();
		}

		public async Task<Product> Update(Product product) {
			var existingProduct = await GetById(product.ProductId);
			if(existingProduct != null) {
				existingProduct.Name = product.Name;
				existingProduct.Price = product.Price;
				existingProduct.StockQuantity = product.StockQuantity;

				SaveProductsToFile(); 
				return existingProduct;
			}
			return null; 
		}

		public Task Create(Product product) {
			product.ProductId = _products.Count + 1;
			_products.Add(product);
			SaveProductsToFile();
			return Task.CompletedTask;
		}

		private void SaveProductsToFile() {
			var json = JsonSerializer.Serialize(_products);
			File.WriteAllText(_filePath, json);
		}

		private List<Product> LoadProductsFromFile() {
			if(File.Exists(_filePath)) {
				var json = File.ReadAllText(_filePath);
				return JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
			}
			return new List<Product>();
		}
	}
}

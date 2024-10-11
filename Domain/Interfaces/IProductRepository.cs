using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCoordly.Domain.Entities;

namespace TesteCoordly.Domain.Interfaces {
	public interface IProductRepository {
		public Task<IEnumerable<Product>> GetAll();
		public Task<Product> GetById(int id);

		public Task<bool> DeleteById(int id);

		public Task<Product> Update(Product product);
		
		public Task Create(Product product);
	}
}

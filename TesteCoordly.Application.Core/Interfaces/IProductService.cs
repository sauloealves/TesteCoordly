using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCoordly.Application.Core.Dtos;

namespace TesteCoordly.Application.Core.Interfaces {
	public interface IProductService {
		public Task<IEnumerable<ProductDto>> GetAll();
		public Task<ProductDto> GetById(int id);

		public Task<ProductDto> Update(ProductDto productDto);
		public Task<ProductDto> Create(ProductDto productDto);

		public Task<bool> DeleteById(int id);
	}
}

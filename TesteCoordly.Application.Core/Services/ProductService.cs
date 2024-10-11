using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCoordly.Application.Core.Dtos;
using TesteCoordly.Application.Core.Interfaces;
using TesteCoordly.Application.Core.MappersFactory;
using TesteCoordly.Domain.Interfaces;

namespace TesteCoordly.Application.Core.Services {
	public class ProductService :IProductService {
		private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

		public Task<ProductDto> Create(ProductDto productDto) {
			_productRepository.Create(DtoFactory.CreateFromDto(productDto));
			return Task.FromResult(productDto);
		}

		public async Task<bool> DeleteById(int id) {
			return await _productRepository.DeleteById(id);
		}

		public async Task<IEnumerable<ProductDto>> GetAll() {
			
			var products = _productRepository.GetAll().Result;
			var result = products.Select(e => DtoFactory.CreateFromEntity(e)).AsEnumerable();
			return result;
		}

		public async Task<ProductDto> GetById(int id) {
			var product = await _productRepository.GetById(id);
			return DtoFactory.CreateFromEntity(product);
		}

		public async Task<ProductDto> Update(ProductDto productDto) {
			var result = await _productRepository.Update(DtoFactory.CreateFromDto(productDto));
			return DtoFactory.CreateFromEntity(result);
		}
	}
}

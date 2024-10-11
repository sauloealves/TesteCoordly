using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCoordly.Application.Core.Dtos;
using TesteCoordly.Domain.Entities;

namespace TesteCoordly.Application.Core.MappersFactory {
	public static class DtoFactory {

		public static ProductDto CreateFromEntity(Product entity) {
			return new ProductDto {
				Name = entity.Name,
				ProductID = entity.ProductId,
				StockQuantity = entity.StockQuantity,
				Price = entity.Price
			};
		}

		public static Product CreateFromDto(ProductDto dto) {
			return new Product() {
				Name = dto.Name,
				Price = dto.Price,
				StockQuantity = dto.StockQuantity,
				ProductId = dto.ProductID
			};
		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCoordly.Application.Core.Dtos {
	public class ProductDto {
		// Identificador único gerado automaticamente
		[Required(ErrorMessage = "Product ID is required")]
		public int ProductID { get; set; }

		// Nome do produto obrigatório
		[Required(ErrorMessage = "Product name is required")]
		[StringLength(100, ErrorMessage = "Product name must be less than 100 characters")]
		public string Name { get; set; }

		// Preço do produto obrigatório e deve ser maior que zero
		[Required(ErrorMessage = "Price is required")]
		[Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
		public double Price { get; set; }

		// Quantidade de estoque obrigatória e deve ser maior ou igual a zero
		[Required(ErrorMessage = "Stock quantity is required")]
		[Range(0, int.MaxValue, ErrorMessage = "Stock quantity must be zero or greater")]
		public int StockQuantity { get; set; }

	}
}

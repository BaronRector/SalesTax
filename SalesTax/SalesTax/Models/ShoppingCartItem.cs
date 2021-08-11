using SalesTax.Abstraction;
using SalesTax.Enums;
using SalesTax.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SalesTax.Models
{
	public class CartItem : ICartItem
	{
		private readonly ITaxCalculator _taxCalculator;
		public CartItemType Type { get; set; }
		public string Name { get; set; }
		public bool IsImported { get; set; }
		public decimal Price { get; set; }

		public CartItem(ITaxCalculator taxCalculator, CartItemType type, string name, bool isImported, decimal price)
		{
			_taxCalculator = taxCalculator;
			Type = type;
			Name = name;
			IsImported = isImported;
			Price = price;
		}

		public decimal GetSalesTax()
		{
			return _taxCalculator.GetTaxAmount(this);
		}
	}
}

using SalesTax.Library.Abstraction;
using SalesTax.Library.Enums;
using SalesTax.Library.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SalesTax.Library.Models
{
	public class CartItem : ICartItem
	{
		private readonly IEnumerable<TaxCalculator> _taxCalculators;
		public CartItemType Type { get; set; }
		public string Name { get; set; }
		public bool IsImported { get; set; }
		public decimal Price { get; set; }

		public CartItem(IEnumerable<TaxCalculator> taxCalculators, CartItemType type, string name, bool isImported, decimal price)
		{
			_taxCalculators = taxCalculators;
			Type = type;
			Name = name;
			IsImported = isImported;
			Price = price;
		}

		public decimal GetSalesTax()
		{
			return _taxCalculators.Sum(x => x.GetTaxAmount(this));
		}
	}
}

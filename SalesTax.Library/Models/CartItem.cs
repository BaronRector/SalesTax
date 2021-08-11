using SalesTax.Library.Enums;
using SalesTax.Library.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SalesTax.Library.Models
{
	public class CartItem
	{
		private readonly IEnumerable<ITaxCalculator> _taxCalculators;
		public CartItemType Type { get; private set; }
		public string Name { get; private set; }
		public bool IsImported { get; private set; }
		public decimal Price { get; private set; }

		public CartItem(IEnumerable<ITaxCalculator> taxCalculators, CartItemType type, string name, bool isImported, decimal price)
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

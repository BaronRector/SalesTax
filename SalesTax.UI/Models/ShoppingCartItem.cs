using SalesTax.Library.Abstraction;
using SalesTax.Library.Enums;
using SalesTax.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SalesTax.UI.Models
{
	class CartItem : INotifyPropertyChanged, ICartItem
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

		public event PropertyChangedEventHandler PropertyChanged;
	}
}

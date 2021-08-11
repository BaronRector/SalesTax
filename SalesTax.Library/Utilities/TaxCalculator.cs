using SalesTax.Library.Interfaces;
using SalesTax.Library.Models;
using System;

namespace SalesTax.Library.Utilities
{
	public abstract class TaxCalculator : ITaxCalculator
	{
		public abstract decimal GetTaxAmount(CartItem cartItem);
		internal decimal RoundTax(decimal taxAmount) => Math.Round(taxAmount * 20) / 20;
	}
}

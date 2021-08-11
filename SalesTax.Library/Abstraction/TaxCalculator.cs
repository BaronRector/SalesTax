using SalesTax.Library.Interfaces;
using System;

namespace SalesTax.Library.Abstraction
{
	public abstract class TaxCalculator
	{
		public abstract decimal GetTaxAmount(ICartItem cartItem);
		internal decimal RoundTax(decimal taxAmount) => Math.Round(taxAmount * 20) / 20;
	}
}

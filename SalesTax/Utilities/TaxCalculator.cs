using SalesTax.Interfaces;
using System;

namespace SalesTax.Utilities
{
	public class TaxCalculator : ITaxCalculator
	{
		const decimal salesTaxRate = 0.10m;
		const decimal importTaxRate = 0.05m;
		const decimal zeroTax = 0.00m;
		public decimal GetTaxAmount(ICartItem cartItem)
		{
			return (cartItem.Type == Enums.CartItemType.Misc ? RoundTax((cartItem.Price * salesTaxRate)) : zeroTax)
						+ (cartItem.IsImported ? RoundTax((cartItem.Price * importTaxRate)) : zeroTax);
		}

		public decimal RoundTax(decimal taxAmount) => Math.Ceiling(taxAmount / 0.05m) * 0.05m;
	}
}

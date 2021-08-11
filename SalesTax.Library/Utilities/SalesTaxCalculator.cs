using SalesTax.Library.Abstraction;
using SalesTax.Library.Interfaces;

namespace SalesTax.Library.Utilities
{
	public class SalesTaxCalculator : TaxCalculator
	{
		const decimal salesTaxRate = 0.10m;
		const decimal zeroTax = 0.00m;
		public override decimal GetTaxAmount(ICartItem cartItem) => cartItem.Type == Enums.CartItemType.Misc ? RoundTax(cartItem.Price * salesTaxRate) : zeroTax;
	}
}

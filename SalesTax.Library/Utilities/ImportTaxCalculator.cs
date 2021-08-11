using SalesTax.Library.Abstraction;
using SalesTax.Library.Interfaces;

namespace SalesTax.Library.Utilities
{
	public class ImportTaxCalculator : TaxCalculator
	{
		const decimal importTaxRate = 0.05m;
		const decimal zeroTax = 0.00m;
		
		public override decimal GetTaxAmount(ICartItem cartItem) => cartItem.IsImported ? RoundTax(cartItem.Price * importTaxRate) : zeroTax;
	}
}

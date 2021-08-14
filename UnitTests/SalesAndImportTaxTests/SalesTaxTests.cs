using NUnit.Framework;
using SalesTax.Models;
using SalesTax.Utilities;

namespace UnitTests.SalesAndImportTaxTests
{
	[TestFixture]
	public class SalesTaxTests
	{
		protected TaxCalculator _taxCalculator;
		protected CartItem _cartItem;

		[SetUp]
		public void Init()
		{
			_taxCalculator = new TaxCalculator();
		}
	}
}

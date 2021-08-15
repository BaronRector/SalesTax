using NUnit.Framework;
using SalesTax.Models;
using SalesTax.Utilities;

namespace UnitTests.ShoppingCartTests
{
	[TestFixture]
	public class ShoppingCartTests
	{
		protected TaxCalculator _taxCalculator;
		protected ShoppingCart _shoppingCart;

		[SetUp]
		public void Init()
		{
			_taxCalculator = new TaxCalculator();
			_shoppingCart = new ShoppingCart(_taxCalculator);
		}
	}
}

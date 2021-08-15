using NUnit.Framework;

namespace UnitTests.SalesAndImportTaxTests
{
	[TestFixture]
	class RequiresSalesTaxOnly : SalesAndImportTaxTests
	{
		[SetUp]
		public void InitItem()
		{
			_cartItem = new SalesTax.Models.CartItem(_taxCalculator, SalesTax.Enums.CartItemType.Misc, "Music CD", false, 14.99m);
		}

		[Test]
		public void GetSalesTax()
		{
			var expected = 1.50m;
			var actual = _cartItem.GetSalesTax();

			Assert.AreEqual(expected, actual);
		}
	}
}

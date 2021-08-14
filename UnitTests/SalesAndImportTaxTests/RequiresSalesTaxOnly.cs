using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.SalesAndImportTaxTests
{
	[TestFixture]
	class RequiresSalesTaxOnly : SalesTaxTests
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

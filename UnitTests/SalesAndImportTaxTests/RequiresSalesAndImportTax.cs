using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.SalesAndImportTaxTests
{
	[TestFixture]
	class RequiresSalesAndImportTax : SalesAndImportTaxTests
	{
		[SetUp]
		public void InitItem()
		{
			_cartItem = new SalesTax.Models.CartItem(_taxCalculator, SalesTax.Enums.CartItemType.Misc, "Bottle of perfume", true, 27.99m);
		}

		[Test]
		public void GetSalesTax()
		{
			var expected = 4.20m;
			var actual = _cartItem.GetSalesTax();

			Assert.AreEqual(expected, actual);
		}
	}
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.SalesAndImportTaxTests
{
	[TestFixture]
	class RequiresImportTaxOnly : SalesAndImportTaxTests
	{
		[SetUp]
		public void InitItem()
		{
			_cartItem = new SalesTax.Models.CartItem(_taxCalculator, SalesTax.Enums.CartItemType.Food, "box of chocolates", true, 10.00m);
		}

		[Test]
		public void GetSalesTax()
		{
			var expected = .50m;
			var actual = _cartItem.GetSalesTax();

			Assert.AreEqual(expected, actual);
		}
	}
}

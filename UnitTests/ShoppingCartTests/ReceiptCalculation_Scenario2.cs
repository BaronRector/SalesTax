using NUnit.Framework;
using SalesTax.Models;
using System;

namespace UnitTests.ShoppingCartTests
{
	[TestFixture]
	class ReceiptCalculation_Scenario2 : ShoppingCartTests
	{
		[SetUp]
		public void InitShoppingCart()
		{
			_shoppingCart.AddItem(new CartItem(_taxCalculator, SalesTax.Enums.CartItemType.Food, "box of chocolates", true, 10.00m));
			_shoppingCart.AddItem(new CartItem(_taxCalculator, SalesTax.Enums.CartItemType.Misc, "bottle of perfume", true, 47.50m));
		}

		[Test]
		public void ExportReceipt()
		{
			var actual = _shoppingCart.ExportReceipt();
			Assert.AreEqual(Expected, actual);
		}

		[Test]
		public void GetTotalSale()
		{
			var actual = _shoppingCart.GetTotalSale();
			var expected = 57.50m;
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void GetTotalTax()
		{
			var actual = _shoppingCart.GetTotalTax();
			var expected = 7.65m;
			Assert.AreEqual(expected, actual);
		}

		private string Expected = $"Imported box of chocolates: 10.50{Environment.NewLine}" +
								  $"Imported bottle of perfume: 54.65{Environment.NewLine}" +
								   Environment.NewLine +
								  $"Sales Taxes: 7.65{Environment.NewLine}" +
								  $"Total: 65.15{Environment.NewLine}";
	}
}

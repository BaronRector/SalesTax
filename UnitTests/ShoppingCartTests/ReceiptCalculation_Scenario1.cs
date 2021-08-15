using NUnit.Framework;
using SalesTax.Models;
using System;

namespace UnitTests.ShoppingCartTests
{
	[TestFixture]
	class ReceiptCalculation_Scenario1 : ShoppingCartTests
	{
		[SetUp]
		public void InitShoppingCart()
		{
			_shoppingCart.AddItem(new CartItem(_taxCalculator, SalesTax.Enums.CartItemType.Book, "Book", false, 12.49m));
			_shoppingCart.AddItem(new CartItem(_taxCalculator, SalesTax.Enums.CartItemType.Book, "Book", false, 12.49m));
			_shoppingCart.AddItem(new CartItem(_taxCalculator, SalesTax.Enums.CartItemType.Misc, "Music CD", false, 14.99m));
			_shoppingCart.AddItem(new CartItem(_taxCalculator, SalesTax.Enums.CartItemType.Food, "Chocolate bar", false, 0.85m));
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
			var expected = 40.82m;
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void GetTotalTax()
		{
			var actual = _shoppingCart.GetTotalTax();
			var expected = 1.50m;
			Assert.AreEqual(expected, actual);
		}

		private string Expected = $"Book: 24.98 (2 @ 12.49){Environment.NewLine}" +
								  $"Music CD: 16.49{Environment.NewLine}" + 
								  $"Chocolate bar: 0.85{Environment.NewLine}" +
								   Environment.NewLine +
								  $"Sales Taxes: 1.50{Environment.NewLine}" +
								  $"Total: 42.32{Environment.NewLine}";
	}
}

using NUnit.Framework;
using SalesTax.Models;
using System;

namespace UnitTests.ShoppingCartTests
{
	[TestFixture]
	class ReceiptCalculation_Scenario3_MultipleDecimalPlaces : ShoppingCartTests
	{
		[SetUp]
		public void InitShoppingCart()
		{
			_shoppingCart.AddItem(new CartItem(_taxCalculator, SalesTax.Enums.CartItemType.Misc, "bottle of perfume", true, 27.98612321245521m));
			_shoppingCart.AddItem(new CartItem(_taxCalculator, SalesTax.Enums.CartItemType.Misc, "Bottle of perfume", false, 18.98651126156m));
			_shoppingCart.AddItem(new CartItem(_taxCalculator, SalesTax.Enums.CartItemType.Medical, "Packet of headache pills", false, 9.7456561654m));
			_shoppingCart.AddItem(new CartItem(_taxCalculator, SalesTax.Enums.CartItemType.Food, "box of chocolates", true, 11.247894m));
			_shoppingCart.AddItem(new CartItem(_taxCalculator, SalesTax.Enums.CartItemType.Food, "box of chocolates", true, 11.24696546541m));
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
			var expected = 79.23m;
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void GetTotalTax()
		{
			var actual = _shoppingCart.GetTotalTax();
			var expected = 7.30m;
			Assert.AreEqual(expected, actual);
		}

		private string Expected = $"Imported bottle of perfume: 32.19{Environment.NewLine}" +
								  $"Bottle of perfume: 20.89{Environment.NewLine}" +
								  $"Packet of headache pills: 9.75{Environment.NewLine}" +
								  $"Imported box of chocolates: 23.70 (2 @ 11.85){Environment.NewLine}" +
								   Environment.NewLine +
								  $"Sales Taxes: 7.30{Environment.NewLine}" +
								  $"Total: 86.53{Environment.NewLine}";
	}
}

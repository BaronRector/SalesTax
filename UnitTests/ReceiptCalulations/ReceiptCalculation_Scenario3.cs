using NUnit.Framework;
using SalesTax.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.ReceiptCalulations
{
	[TestFixture]
	class ReceiptCalculation_Scenario3 : ReceiptCalulations
	{
		[SetUp]
		public void InitShoppingCart()
		{
			_shoppingCart.AddItem(new CartItem(_taxCalculator, SalesTax.Enums.CartItemType.Misc, "bottle of perfume", true, 27.99m));
			_shoppingCart.AddItem(new CartItem(_taxCalculator, SalesTax.Enums.CartItemType.Misc, "Bottle of perfume", false, 18.99m));
			_shoppingCart.AddItem(new CartItem(_taxCalculator, SalesTax.Enums.CartItemType.Medical, "Packet of headache pills", false, 9.75m));
			_shoppingCart.AddItem(new CartItem(_taxCalculator, SalesTax.Enums.CartItemType.Food, "box of chocolates", true, 11.25m));
			_shoppingCart.AddItem(new CartItem(_taxCalculator, SalesTax.Enums.CartItemType.Food, "box of chocolates", true, 11.25m));
		}

		[Test]
		public void ExportReceipt()
		{
			var actual = _shoppingCart.ExportReceipt();
			Assert.AreEqual(Expected, actual);
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

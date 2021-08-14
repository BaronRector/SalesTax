using NUnit.Framework;
using SalesTax.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.ReceiptCalulations
{
	[TestFixture]
	class ReceiptCalculation_Scenario2 : ReceiptCalulations
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

		private string Expected = $"Imported box of chocolates: 10.50{Environment.NewLine}" +
								  $"Imported bottle of perfume: 54.65{Environment.NewLine}" +
								   Environment.NewLine +
								  $"Sales Taxes: 7.65{Environment.NewLine}" +
								  $"Total: 65.15{Environment.NewLine}";
	}
}

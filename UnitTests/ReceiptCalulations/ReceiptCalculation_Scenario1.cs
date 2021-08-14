using NUnit.Framework;
using SalesTax.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.ReceiptCalulations
{
	[TestFixture]
	class ReceiptCalculation_Scenario1 : ReceiptCalulations
	{
		[SetUp]
		public void InitItem()
		{
			_shoppingCart.AddItem(new CartItem(_taxCalculator, SalesTax.Enums.CartItemType.Book, "Book", false, 12.49m));
			_shoppingCart.AddItem(new CartItem(_taxCalculator, SalesTax.Enums.CartItemType.Book, "Book", false, 12.49m));
			_shoppingCart.AddItem(new CartItem(_taxCalculator, SalesTax.Enums.CartItemType.Misc, "Music CD", false, 14.99m));
			_shoppingCart.AddItem(new CartItem(_taxCalculator, SalesTax.Enums.CartItemType.Food, "Chocolate bar", false, 0.85m));
		}

		[Test]
		public void GetSalesTax()
		{
			var actual = _shoppingCart.ExportReceipt();

			Assert.AreEqual(Expected, actual);
		}

		private string Expected = "Book: 24.98 (2 @ 12.49)" + Environment.NewLine +
									"Music CD: 16.49" + Environment.NewLine +
									"Chocolate bar: 0.85" + Environment.NewLine +
									 Environment.NewLine +
									"Sales Taxes: 1.50" + Environment.NewLine +
									"Total: 42.32" + Environment.NewLine;
	}
}

using NUnit.Framework;
using SalesTax.Models;
using SalesTax.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.ReceiptCalulations
{
	[TestFixture]
	public class ReceiptCalulations
	{
		protected TaxCalculator _taxCalculator;
		protected ShoppingCart _shoppingCart;
		protected List<CartItem> _cartItems;

		[SetUp]
		public void Init()
		{
			_taxCalculator = new TaxCalculator();
			_shoppingCart = new ShoppingCart(_taxCalculator);
		}
	}
}

using NUnit.Framework;
using SalesTax.Enums;
using SalesTax.Interfaces;
using System;

namespace UnitTests.ShoppingCartTests
{
	[TestFixture]
	class AddItemExceptions : ShoppingCartTests
	{
		[SetUp]
		public void InitAddItemExceptions() { }

		[Test]
		public void AddNullCartItem()
		{
			EmptyCartItem cartItem = null;
			Assert.Throws(typeof(Exception), () => _shoppingCart.AddItem(cartItem));
		}

		[Test]
		public void AddCartItemHandleExceptions()
		{
			EmptyCartItem cartItem = new EmptyCartItem()
			{
				Price = -1,
				Name = "Test",
				Type = CartItemType.Book
			};

			Assert.Throws(typeof(Exception), () => _shoppingCart.AddItem(cartItem));
		}

		[Test]
		public void AddCartItemWithEmptyName()
		{
			EmptyCartItem cartItem = new EmptyCartItem()
			{
				Price = 1,
				Name = "",
				Type = CartItemType.Book
			};

			Assert.Throws(typeof(Exception), () => _shoppingCart.AddItem(cartItem));
		}

		[Test]
		public void AddCartItemWithAllSpacesName()
		{
			EmptyCartItem cartItem = new EmptyCartItem()
			{
				Price = 1,
				Name = "   ",
				Type = CartItemType.Book
			};

			Assert.Throws(typeof(Exception), () => _shoppingCart.AddItem(cartItem));
		}

		[Test]
		public void AddCartItemWithNullName()
		{
			EmptyCartItem cartItem = new EmptyCartItem()
			{
				Price = 1,
				Name = null,
				Type = CartItemType.Book
			};

			Assert.Throws(typeof(Exception), () => _shoppingCart.AddItem(cartItem));
		}
	}

	class EmptyCartItem : ICartItem
	{
		public CartItemType Type { get; set; }
		public string Name { get; set; }
		public bool IsImported { get; set; }
		public decimal Price { get; set; }

		public decimal GetSalesTax()
		{
			return 0.00m;
		}
	}
}

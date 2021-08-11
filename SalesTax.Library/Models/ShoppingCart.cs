using SalesTax.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax.Library.Models
{
	public class ShoppingCart : IShoppingCart
	{
		private readonly IReceiptWriter _receiptWriter;
		private readonly List<CartItem> CartItems = new List<CartItem>();

		public ShoppingCart(IReceiptWriter receiptWriter)
		{
			_receiptWriter = receiptWriter;
		}

		public void AddItem(CartItem cartItem)
		{
			if (cartItem != null)
			{
				CartItems.Add(cartItem);
			}
			else
			{
				throw new Exception("Cart item can't be empty");
			}
		}

		public void RemoveItem(CartItem cartItem)
		{
			if (cartItem != null)
			{
				CartItems.Remove(cartItem);
			}
			else
			{
				throw new Exception("Cart item can't be empty");
			}
		}

		public decimal GetTotalSale()
		{
			return CartItems.Sum(x => x.Price);
		}

		public decimal GetTotalTax()
		{
			return CartItems.Sum(x => x.GetSalesTax());
		}

		public void ExportReceipt()
		{
			_receiptWriter.ExportReceipt(this);
		}
	}
}

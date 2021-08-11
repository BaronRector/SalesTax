using SalesTax.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax.Models
{
	public class ShoppingCart : IShoppingCart
	{
		private readonly IReceiptWriter _receiptWriter;
		private readonly List<ICartItem> _cartItems = new List<ICartItem>();

		public ShoppingCart(IReceiptWriter receiptWriter)
		{
			_receiptWriter = receiptWriter;
		}

		public void AddItem(ICartItem cartItem)
		{
			if (cartItem != null)
			{
				_cartItems.Add(cartItem);
			}
			else
			{
				throw new Exception("Cart item can't be empty");
			}
		}

		public void RemoveItem(ICartItem cartItem)
		{
			if (cartItem != null)
			{
				_cartItems.Remove(cartItem);
			}
			else
			{
				throw new Exception("Cart item can't be empty");
			}
		}

		public decimal GetTotalSale()
		{
			return _cartItems.Sum(x => x.Price);
		}

		public decimal GetTotalTax()
		{
			return _cartItems.Sum(x => x.GetSalesTax());
		}

		public string ExportReceipt()
		{
			var output = new StringBuilder();
			var totalPrice = 0.0m;
			var totalBasePrice = _cartItems.Sum(x => x.Price);

			foreach (var shoppingCartItem in _cartItems)
			{
				var price = shoppingCartItem.Price + shoppingCartItem.GetSalesTax();
				totalPrice += price;
				output.AppendLine(String.Format("{0}: {1}", shoppingCartItem.Name, price));
			}

			output.AppendLine(String.Format("Sales Taxes: {0}", totalPrice - totalBasePrice));
			output.AppendLine(String.Format("Total: {0}", totalPrice));

			return output.ToString();
		}

		void IShoppingCart.ExportReceipt()
		{
			throw new NotImplementedException();
		}
	}
}

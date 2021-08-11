using SalesTax.Abstraction;
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
		public readonly List<ICartItem> cartItems = new List<ICartItem>();

		public ShoppingCart() { }

		public void AddItem(ICartItem cartItem)
		{
			if (cartItem != null)
			{
				cartItems.Add(cartItem);
			}
			else
			{
				throw new Exception("Cart item can't be empty");
			}
		}

		public decimal GetTotalSale()
		{
			return cartItems.Sum(x => x.Price);
		}

		public decimal GetTotalTax()
		{
			return cartItems.Sum(x => x.GetSalesTax());
		}

		public async void CreateCartItem()
		{
			Console.WriteLine("Scan cart item");
			Console.WriteLine("Exit");
		}

		public string ExportReceipt()
		{
			var output = new StringBuilder();
			var totalPrice = 0.0m;
			var totalBasePrice = cartItems.Sum(x => x.Price);

			foreach (var shoppingCartItem in cartItems)
			{
				var price = shoppingCartItem.Price + shoppingCartItem.GetSalesTax();
				totalPrice += price;
				output.AppendLine(String.Format("{0}: {1}", shoppingCartItem.Name, price));
			}

			output.AppendLine(String.Format("Sales Taxes: {0}", totalPrice - totalBasePrice));
			output.AppendLine(String.Format("Total: {0}", totalPrice));

			return output.ToString();
		}
	}
}

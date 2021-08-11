using SalesTax.Library.Models;
using System.Collections.Generic;

namespace SalesTax.Library.Interfaces
{
	public interface IShoppingCart
	{
		decimal GetTotalSale();
		decimal GetTotalTax();
		void ExportReceipt();
	}
}

using System;

namespace SalesTax.Interfaces
{
	public interface IShoppingCart
	{
		decimal GetTotalSale();
		decimal GetTotalTax();
		void ExportReceipt();
	}
}

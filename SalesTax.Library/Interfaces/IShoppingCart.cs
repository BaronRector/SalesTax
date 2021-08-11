namespace SalesTax.Library.Interfaces
{
	public interface IShoppingCart
	{
		decimal GetTotalSale();
		decimal GetTotalTax();
		void ExportReceipt();
	}
}

namespace SalesTax.Interfaces
{
	public interface IShoppingCart
	{
		decimal GetTotalSale();
		decimal GetTotalTax();
		void AddItem(ICartItem cartItem);
		string ExportReceipt();
	}
}

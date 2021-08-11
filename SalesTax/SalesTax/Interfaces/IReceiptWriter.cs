using SalesTax.Models;

namespace SalesTax.Interfaces
{
	public interface IReceiptWriter
	{
		void ExportReceipt(IShoppingCart shoppingCart);
	}
}

using SalesTax.Library.Models;

namespace SalesTax.Library.Interfaces
{
	public interface IReceiptWriter
	{
		void ExportReceipt(IShoppingCart shoppingCart);
	}
}

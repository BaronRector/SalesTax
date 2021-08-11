using SalesTax.Library.Models;

namespace SalesTax.Library.Interfaces
{
	public interface IReceiptWriter
	{
		void ExportReceipt(ShoppingCart shoppingCart);
	}
}

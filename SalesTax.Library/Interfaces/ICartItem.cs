using SalesTax.Library.Enums;

namespace SalesTax.Library.Interfaces
{
	public interface ICartItem
	{
		public CartItemType Type { get; set; }
		public string Name { get; set; }
		public bool IsImported { get; set; }
		public decimal Price { get; set; }

		public decimal GetSalesTax();
	}
}

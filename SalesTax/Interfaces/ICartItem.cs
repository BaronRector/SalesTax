using SalesTax.Enums;

namespace SalesTax.Interfaces
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

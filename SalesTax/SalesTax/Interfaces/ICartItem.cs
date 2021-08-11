using SalesTax.Enums;

namespace SalesTax.Interfaces
{
	public interface ICartItem
	{
		CartItemType Type { get; set; }
		string Name { get; set; }
		bool IsImported { get; set; }
		decimal Price { get; set; }

		decimal GetSalesTax();
	}
}

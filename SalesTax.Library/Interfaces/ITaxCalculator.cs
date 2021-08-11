using SalesTax.Library.Models;

namespace SalesTax.Library.Interfaces
{
	public interface ITaxCalculator
	{
		decimal GetTaxAmount(CartItem cartItem);
	}
}

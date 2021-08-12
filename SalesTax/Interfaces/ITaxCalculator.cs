
namespace SalesTax.Interfaces
{
	public interface ITaxCalculator
	{
		decimal GetTaxAmount(ICartItem cartItem);
	}
}

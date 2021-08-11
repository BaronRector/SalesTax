using SalesTax.Interfaces;
using System;

namespace SalesTax.Abstraction
{
	public interface ITaxCalculator
	{
		decimal GetTaxAmount(ICartItem cartItem);
	}
}

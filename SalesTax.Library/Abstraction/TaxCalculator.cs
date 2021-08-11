﻿using SalesTax.Library.Interfaces;
using System;

namespace SalesTax.Library.Abstraction
{
	public abstract class TaxCalculator
	{
		public abstract decimal GetTaxAmount(ICartItem cartItem);
		public decimal RoundTax(decimal taxAmount) => Math.Round(taxAmount * 20) / 20;
	}
}

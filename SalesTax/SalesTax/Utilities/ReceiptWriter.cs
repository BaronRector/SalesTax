using SalesTax.Interfaces;
using SalesTax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTax.Utilities
{
	public class ReceiptWriter : IReceiptWriter
	{
		public void ExportReceipt(IShoppingCart shoppingCart)
		{
			throw new NotImplementedException();
		}
	}
}

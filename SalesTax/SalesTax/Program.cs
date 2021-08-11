using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using SalesTax.Abstraction;
using SalesTax.Enums;
using SalesTax.Interfaces;
using SalesTax.Models;
using SalesTax.Utilities;

namespace SalesTax
{
	class Program
	{
		private static readonly ServiceProvider _serviceProvider
			= new ServiceCollection()
				.AddTransient<IShoppingCart, ShoppingCart>()
				.AddTransient<ITaxCalculator, TaxCalculator>()
				.AddTransient<Program>()
				.BuildServiceProvider();

		public IShoppingCart _shoppingCart;
		public ITaxCalculator _taxCalculator;

		public Program(IShoppingCart shoppingCart, ITaxCalculator taxCalculator)
		{
			_shoppingCart = shoppingCart;
			_taxCalculator = taxCalculator;
		}

		static void Main()
		{
			Console.WriteLine("Output 1:");
			_serviceProvider.GetService<Program>().GenerateOutput1();
			Console.WriteLine("Output 2:");
			_serviceProvider.GetService<Program>().GenerateOutput2();
			Console.WriteLine("Output 3:");
			_serviceProvider.GetService<Program>().GenerateOutput3();

			Console.ReadKey();
		}

		public void GenerateOutput1()
		{
			_shoppingCart.AddItem(new CartItem(_taxCalculator, CartItemType.Book, "1 book", false, 12.49m));
			_shoppingCart.AddItem(new CartItem(_taxCalculator, CartItemType.Book, "1 book", false, 12.49m));
			_shoppingCart.AddItem(new CartItem(_taxCalculator, CartItemType.Misc, "1 music CD", false, 14.99m));
			_shoppingCart.AddItem(new CartItem(_taxCalculator, CartItemType.Food, "1 chocolate bar", false, 0.85m));

			Console.WriteLine(_shoppingCart.ExportReceipt());
		}

		public void GenerateOutput2()
		{
			_shoppingCart.AddItem(new CartItem(_taxCalculator, CartItemType.Misc, "1 imported bottle of perfume", true, 10.00m));
			_shoppingCart.AddItem(new CartItem(_taxCalculator, CartItemType.Food, "1 imported box of chocolate", true, 47.50m));

			Console.WriteLine(_shoppingCart.ExportReceipt());
		}

		public  void GenerateOutput3()
		{
			_shoppingCart.AddItem(new CartItem(_taxCalculator, CartItemType.Misc, "1 imported bottle of perfume", true, 27.99m));
			_shoppingCart.AddItem(new CartItem(_taxCalculator, CartItemType.Misc, "1 bottle of perfume", false, 18.99m));
			_shoppingCart.AddItem(new CartItem(_taxCalculator, CartItemType.Medical, "1 packet of headache pills", false, 9.75m));
			_shoppingCart.AddItem(new CartItem(_taxCalculator, CartItemType.Food, "1 box of imported chocolates", true, 11.25m));

			Console.WriteLine(_shoppingCart.ExportReceipt());
		}
	}
}

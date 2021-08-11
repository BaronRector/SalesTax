using System;
using System.Collections.Generic;
using SalesTax.Abstraction;
using SalesTax.Enums;
using SalesTax.Models;
using SalesTax.Utilities;

namespace SalesTax
{
	class Program
	{
		private static List<TaxCalculator> _taxCalculators;
        private static ReceiptWriter _receiptWriter;

        static void Main(string[] args)
		{
			_taxCalculators = new List<TaxCalculator>() { 
				new SalesTaxCalculator(), 
				new ImportTaxCalculator() 
			};

             _receiptWriter = new ReceiptWriter();

            Console.WriteLine("Output 1:");
            GenerateOutput1();
            Console.WriteLine("Output 2:");
            GenerateOutput2();
            Console.WriteLine("Output 3:");
            GenerateOutput3();

            Console.ReadKey();
        }

        private static void GenerateOutput1()
        {
            var shoppintCart = new ShoppingCart(_receiptWriter);
            shoppintCart.AddItem(new CartItem(_taxCalculators, CartItemType.Book, "1 book", false, 12.49m));
            shoppintCart.AddItem(new CartItem(_taxCalculators, CartItemType.Book, "1 book", false, 12.49m));
            shoppintCart.AddItem(new CartItem(_taxCalculators, CartItemType.Misc, "1 music CD", false, 14.99m));
            shoppintCart.AddItem(new CartItem(_taxCalculators, CartItemType.Food, "1 chocolate bar", false, 0.85m));

            Console.WriteLine(shoppintCart.ExportReceipt());
        }

        private static void GenerateOutput2()
        {
            var shoppintCart = new ShoppingCart(_receiptWriter);
            shoppintCart.AddItem(new CartItem(_taxCalculators, CartItemType.Misc, "1 imported bottle of perfume", true, 10.00m));
            shoppintCart.AddItem(new CartItem(_taxCalculators, CartItemType.Food, "1 imported box of chocolate", true, 47.50m));

            Console.WriteLine(shoppintCart.ExportReceipt());
        }

        private static void GenerateOutput3()
        {
            var shoppintCart = new ShoppingCart(_receiptWriter);
            shoppintCart.AddItem(new CartItem(_taxCalculators, CartItemType.Misc, "1 imported bottle of perfume", true, 27.99m));
            shoppintCart.AddItem(new CartItem(_taxCalculators, CartItemType.Misc, "1 bottle of perfume", false, 18.99m));
            shoppintCart.AddItem(new CartItem(_taxCalculators, CartItemType.Medical, "1 packet of headache pills", false, 9.75m));
            shoppintCart.AddItem(new CartItem(_taxCalculators, CartItemType.Food, "1 box of imported chocolates", true, 11.25m));

            Console.WriteLine(shoppintCart.ExportReceipt());
        }
    }
}

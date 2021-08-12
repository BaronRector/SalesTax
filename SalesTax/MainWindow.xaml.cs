using SalesTax.Enums;
using SalesTax.Interfaces;
using System;
using System.Linq;
using System.Windows;

namespace SalesTax
{
	public partial class MainWindow : Window
	{
		private readonly IShoppingCart _shoppingCart;
		public MainWindow(IShoppingCart shoppingCart)
		{
			_shoppingCart = shoppingCart;

			DataContext = _shoppingCart;
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			CartItemType.ItemsSource = Enum.GetValues(typeof(CartItemType)).Cast<CartItemType>();
		}
	}
}

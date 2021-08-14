using SalesTax.Enums;
using SalesTax.Interfaces;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;

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

		private void CartItemType_GotFocus(object sender, RoutedEventArgs e)
		{
			CartItemType.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF7EB4EA");
		}

		private void CartItemType_LostFocus(object sender, RoutedEventArgs e)
		{
			CartItemType.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#4864b8");
		}

		private void CartItemType_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
		{
			if (e.Key == System.Windows.Input.Key.Space)
			{
				CartItemType.IsDropDownOpen = true;
			}
		}
	}
}

using SalesTax.Enums;
using SalesTax.Interfaces;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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

		private void CartItemType_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Space)
				CartItemType.IsDropDownOpen = true;
		}

		private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (string.IsNullOrEmpty(e?.Text?.Trim()))
			{
				e.Handled = true;
			}
			else
			{
				e.Handled = !decimal.TryParse($"{((TextBox)sender).Text}{e.Text.Trim()}", out var val);
			}
		}
	}
}

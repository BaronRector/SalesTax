using Microsoft.Extensions.DependencyInjection;
using SalesTax.Library.Abstraction;
using SalesTax.Library.Interfaces;
using SalesTax.Library.Models;
using SalesTax.Library.Utilities;
using System.Windows;

namespace SalesTax
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private ServiceProvider serviceProvider;
		public App()
		{
			ServiceCollection services = new ServiceCollection();
			ConfigureServices(services);
			serviceProvider = services.BuildServiceProvider();
		}

		private void ConfigureServices(ServiceCollection services)
		{
			services.AddScoped<IShoppingCart, ShoppingCart>();
			services.AddScoped<IReceiptWriter, ReceiptWriter>();
			services.AddScoped<ICartItem, CartItem>();
			services.AddScoped<TaxCalculator, SalesTaxCalculator>();
			services.AddScoped<TaxCalculator, ImportTaxCalculator>();
			services.AddSingleton<MainWindow>();
		}
		private void OnStartup(object sender, StartupEventArgs e)
		{
			var mainWindow = serviceProvider.GetService<MainWindow>();
			mainWindow.Show();
		}
	}
}

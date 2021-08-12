using Microsoft.Extensions.DependencyInjection;
using SalesTax.Interfaces;
using SalesTax.Models;
using SalesTax.Utilities;
using System.Windows;

namespace SalesTax
{
	public partial class App : Application
	{
		public ServiceProvider serviceProvider;
		public App()
		{
			ServiceCollection services = new ServiceCollection();
			ConfigureServices(services);
			serviceProvider = services.BuildServiceProvider();
		}

		private void ConfigureServices(ServiceCollection services)
		{
			services.AddScoped<IShoppingCart, ShoppingCart>();
			services.AddScoped<ITaxCalculator, TaxCalculator>();
			services.AddSingleton<MainWindow>();
		}
		private void OnStartup(object sender, StartupEventArgs e)
		{
			var mainWindow = serviceProvider.GetService<MainWindow>();
			mainWindow.Show();
		}
	}
}

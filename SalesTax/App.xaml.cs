using Microsoft.Extensions.DependencyInjection;
using SalesTax.Interfaces;
using SalesTax.Models;
using SalesTax.Utilities;
using System;
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

		private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
		{
			MessageBox.Show($"An error has occured: {Environment.NewLine}{e.Exception.Message}" , "Sales Tax App Error", MessageBoxButton.OK, MessageBoxImage.Warning);
			e.Handled = true;
		}
	}
}

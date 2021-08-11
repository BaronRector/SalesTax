using Microsoft.Extensions.DependencyInjection;
using SalesTax.Library.Interfaces;
using SalesTax.Library.Models;
using SalesTax.Library.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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
			services.AddScoped<ITaxCalculator, SalesTaxCalculator>();
			services.AddScoped<ITaxCalculator, ImportTaxCalculator>();
			services.AddSingleton<MainWindow>();
		}
		private void OnStartup(object sender, StartupEventArgs e)
		{
			var mainWindow = serviceProvider.GetService<MainWindow>();
			mainWindow.Show();
		}
	}
}

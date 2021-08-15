using SalesTax.Enums;
using SalesTax.Interfaces;
using SalesTax.Utilities;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace SalesTax.Models
{
	public class ShoppingCart : INotifyPropertyChanged, IShoppingCart
	{
		private readonly ITaxCalculator _taxCalculator;
		public ObservableCollection<ICartItem> CartItems { get; private set; } = new ObservableCollection<ICartItem>();

		private string test { get; set; }

		private string _name;
		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				OnPropertyChanged();
			}
		}

		private bool _isImported;
		public bool IsImported
		{
			get { return _isImported; }
			set
			{
				_isImported = value;
				OnPropertyChanged();
			}
		}

		private decimal? _price;
		public decimal? Price
		{
			get { return _price; }
			set
			{
				_price = value;
				OnPropertyChanged();
			}
		}

		private CartItemType? _itemType;
		public CartItemType? ItemType
		{
			get { return _itemType; }
			set
			{
				_itemType = value;
				OnPropertyChanged();
			}
		}

		private ICommand _addItemCommand;
		public ICommand AddItemCommand
		{
			get
			{
				return _addItemCommand ?? (_addItemCommand = new CommandHandler(() =>
				{
					AddItem(new CartItem(_taxCalculator, ItemType ?? CartItemType.Misc, Name, IsImported, Price ?? 0.00m));
				}, () => AddItemCanExecute));
			}
		}

		public bool AddItemCanExecute
		{
			get
			{
				return (ItemType != null && !string.IsNullOrEmpty(Name) && Price != null);
			}
		}


		private ICommand _clearCartCommand;
		public ICommand ClearCartCommand
		{
			get
			{
				return _clearCartCommand ?? (_clearCartCommand = new CommandHandler(() =>
				{
					CartItems.Clear();
					OnPropertyChanged("CartItems");
					OnPropertyChanged(propertyName: "PrintReceipt");
				}, () => ClearCartCanExecute));
			}
		}

		private bool ClearCartCanExecute
		{
			get
			{
				return CartItems.Count > 0;
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public string PrintReceipt { get { return ExportReceipt(); } }

		public ShoppingCart(ITaxCalculator taxCalculator)
		{
			_taxCalculator = taxCalculator;
		}

		public void AddItem(ICartItem cartItem)
		{
			if (cartItem == null)
			{
				throw new Exception("Cart item cannot be empty");
			}
			else if (cartItem?.Price < 0)
			{
				throw new Exception("Cart item price cannot be negative");
			}
			else if (string.IsNullOrEmpty(cartItem.Name?.Trim()))
			{
				throw new Exception("Cart item name cannot be empty");
			}

			CartItems.Add(cartItem);

			ItemType = null;
			Name = null;
			IsImported = false;
			Price = default;

			OnPropertyChanged();
			OnPropertyChanged(propertyName: "PrintReceipt");
		}

		public decimal GetTotalSale()
		{
			return CartItems.Sum(x => x.Price);
		}

		public decimal GetTotalTax()
		{
			return CartItems.Sum(x => x.GetSalesTax());
		}

		public string ExportReceipt()
		{
			var output = new StringBuilder();
			var totalTax = GetTotalTax();
			var totalSalePrice = GetTotalSale();

			if (CartItems.Count == 0)
				return "";

			foreach (var cartItemGroup in CartItems.GroupBy(x => new { Name = x.Name.ToUpper().Trim(), x.Price, x.IsImported, x.Type}))
			{
				var totalPrice = cartItemGroup.Sum(x => x.Price) + cartItemGroup.Sum(x => x.GetSalesTax());
				var itemCount = cartItemGroup.Count();
				output.AppendLine($"{(cartItemGroup.Key.IsImported ? $"Imported " : "")}" +
						$"{cartItemGroup.First().Name}: {totalPrice}" +
						$"{(itemCount > 1 ? $" ({itemCount} @ {totalPrice / itemCount})" : "")}");
			}
			output.AppendLine();
			output.AppendLine($"Sales Taxes: {totalTax}");
			output.AppendLine($"Total: {totalSalePrice + totalTax}");

			return output.ToString();
		}

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

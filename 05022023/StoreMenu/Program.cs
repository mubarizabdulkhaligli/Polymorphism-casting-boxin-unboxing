using System;
using System.Diagnostics;
using StoreLibrary;

namespace StoreMenu
{
	class Program
	{
		static void Main(string[] args)
		{
			Store market1 = new Store();

			market1.AlcoholPercentLimit = 75;

			market1.DairyProductCountLimit = 100;

			string click;

			do
			{
				Menu();
				click = Console.ReadLine();

				switch (click)
				{
					case "1":
						Console.WriteLine("\n===== Enter required information =====\n");
						try
						{
							Drink drink = market1.CreateDrinkProduct();
							market1.AddDrinkProduct(drink);
						}
						catch (Exception)
						{
							Console.WriteLine($"This product could not be added. Alcohol limit is {market1.AlcoholPercentLimit}.\nYou cannot exceed the alcohol limit.");
						}
						break;

					case "2":
						Console.WriteLine("\n===== Enter required information =====\n");
						try
						{
							Dairy dairy = market1.CreateDairyProduct();
							market1.AddDairyProduct(dairy);
						}
							catch (Exception)
						{
							Console.WriteLine($"This product could not be added. Dairy product count limit is {market1.DairyProductCountLimit}.\nYou cannot exceed the count limit.");
						}
						break;

					case "3":
						if (market1.Products.Length == 0)
							Console.WriteLine("\nThere is no product.\n");
						else
							Console.WriteLine("\n===== ALL PRODUCTS =====\n");
							foreach (var product in market1.Products)
							{
								product.ShowProductsInfo();
							}
						break;

					case "4":
						int no;
						string stringNo;
						do
						{
							Console.Write("Enter the product number: ");
							stringNo = Console.ReadLine();
						} while (!int.TryParse(stringNo, out no) || no<0);
						
						Console.WriteLine("\n===== Searching result =====\n");

						try
						{
							Product searchingProduct = market1.GetProductByNo(no);
							searchingProduct.ShowProductsInfo();
						}
						catch (ProductNotFoundException)
						{
							Console.WriteLine($"There is no product number {no}.");
						}
						break;
						
					case "5":
						if (market1.GetDrinkProducts().Length == 0)
						Console.WriteLine("\nThere is no drink product.\n");

						else
						Console.WriteLine("\n===== DRINK PRODUCTS =====\n");
						foreach (var drinkProduct in market1.GetDrinkProducts())
						{
							drinkProduct.ShowProductsInfo();
						}
						break;

					case "6":
						if (market1.GetDairyProducts().Length == 0)
						Console.WriteLine("\nThere is no dairy product.\n");

						else
						Console.WriteLine("\n===== DAIRY PRODUCTS =====\n");
						foreach (var dairyProduct in market1.GetDairyProducts())
						{
							dairyProduct.ShowProductsInfo();
						}
						break;

					case "7":
						string SearchingValue;

						do
						{
							Console.Write("Enter the value: ");
							SearchingValue = Console.ReadLine();
						} while (string.IsNullOrEmpty(SearchingValue));
						

						Console.WriteLine("\n===== Searching result =====\n");

						if (market1.Products.Length == 0)
						Console.WriteLine("There is no product.");
						else
						{
							int count = 0;
							foreach (var product in market1.Products)
							{
								if (product.Name.Contains(SearchingValue))
								product.ShowProductsInfo();
									else
									{
										count++;
										if (count == market1.Products.Length)
										Console.WriteLine("No result found.");
									}
							}
						}
						break;

					case "8":
						double minPrice;
						double maxPrice;
						string minPriceString;
						string maxPriceString;
						do
						{
							Console.Write("Enter minimum price: ");
							minPriceString = Console.ReadLine();
						} while (!double.TryParse(minPriceString,out minPrice) || minPrice<0);
						do
						{
							Console.Write("Enter maximum price: ");
							maxPriceString = Console.ReadLine();
						} while (!double.TryParse(maxPriceString, out maxPrice) || maxPrice < 0 || maxPrice<minPrice);

						Console.WriteLine("\n===== Searching result =====\n");

						if (market1.Products.Length == 0)
							Console.WriteLine("There is no product.");
						else
						{
							int count = 0;
							foreach (var product in market1.Products)
							{
								if (product.Price >= minPrice && product.Price <= maxPrice)
									product.ShowProductsInfo();
								else
								{
                                    count++;
                                    if (count == market1.Products.Length)
                                    Console.WriteLine("No result found.");
                                }
							}
						}
						break;

					case "9":
						int number;
						string numberString;
						do
						{
							Console.Write("Enter the number you want to remove: ");
							numberString = Console.ReadLine();

						} while (!int.TryParse(numberString, out number) || number<0);

						Console.WriteLine($"\nProduct No:{number} has been removed.\n");

						foreach (var product in market1.RemoveProduct(number))
						{
							product.ShowProductsInfo();
						}
						break;

					case "0":
						Console.WriteLine("You have exited the program");
						break;

					default:
						Console.WriteLine("Wrong entry, please select an option between 0 to 9");
						break;
				}

			} while (click != "0");
		}

		static void Menu()
		{
			Console.WriteLine("\n<<<<<<<<<<< -- M E N U  -- >>>>>>>>>>>");

			Console.WriteLine("\n1. Add drink product");
			Console.WriteLine("2. Add dairy product");
			Console.WriteLine("3. View all products");
			Console.WriteLine("4. Search by product number");
			Console.WriteLine("5. View drink products");
			Console.WriteLine("6. View dairy products");
			Console.WriteLine("7. Search by value into products' names");
			Console.WriteLine("8. Search by price interval");
			Console.WriteLine("9. Remove product");
			Console.WriteLine("0. Quit");

			Console.Write("\nPlease select number: ");
		}
	}
}


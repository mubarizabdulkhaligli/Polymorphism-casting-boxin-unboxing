using System;

namespace StoreLibrary
{
	public class Store : IStore
	{
		public int DairyProductCountLimit;
		public int AlcoholPercentLimit;

		private Product[] _products = new Product[0];

		public Product[] Products => _products;

		public void AddProduct(Product product)
		{
			Array.Resize(ref _products, _products.Length + 1);
			_products[_products.Length - 1] = product;
		}

		public bool HasProductByNo(int no)
		{
			foreach (var product in _products)
			{
				if (product.No == no)
					return true;
			}
			return false;
		}

		public Product GetProductByNo(int no )
		{
			foreach (var product in _products)
			{
				if (product.No == no)
					return product;
			}
			throw new ProductNotFoundException();
		}


		public Dairy[] GetDairyProducts()
		{
			Dairy[] dairies = new Dairy[0];

			foreach (var product in _products)
			{
				if (product is Dairy)
				{
                    Array.Resize(ref dairies, dairies.Length + 1);
                    dairies[dairies.Length - 1] = (Dairy)product;
                }
				
			}
			return dairies;
		}

		public Drink[] GetDrinkProducts()
		{
			Drink[] drinks = new Drink[0];

			foreach (var product in _products)
			{
				if (product is Drink)
				{
                    Array.Resize(ref drinks, drinks.Length + 1);
                    drinks[drinks.Length - 1] = (Drink)product;
                }
				
			}
			return drinks;
		}


		public Product[] RemoveProduct(int no)
		{
            Product[] NewProducts = new Product[0];

			if (_products.Length == 0)
			{
				Console.WriteLine("There is no product.");
			}
			else
			{
				foreach (var product in _products)
				{
					if (product.No != no)
					{
						Array.Resize(ref NewProducts, NewProducts.Length + 1);
						NewProducts[NewProducts.Length - 1] = product;
					}
				}
			}
            return NewProducts;
        }

		public void AddDrinkProduct(Drink drink)
		{
			Array.Resize(ref _products, _products.Length + 1);
			_products[_products.Length - 1] = drink;
			Console.WriteLine("Drink product added");
		}

		public void AddDairyProduct(Dairy dairy)
		{
			Array.Resize(ref _products, _products.Length + 1);
			_products[_products.Length - 1] = dairy;
			Console.WriteLine("Dairy product added");
		}

        public Drink CreateDrinkProduct()
        {
            string name;
            do
            {
                Console.Write("Name: ");
                name = Console.ReadLine();

            } while (string.IsNullOrWhiteSpace(name));

            double price;
            string priceString;
            do
            {
                Console.Write("Price: ");
                priceString = Console.ReadLine();
            }
            while (!double.TryParse(priceString, out price) || price < 0);

            double alcoholPercent;
            string alcoholPercentString;

            do
            {
                Console.WriteLine("Alcohol Percent: ");
                alcoholPercentString = Console.ReadLine();

            } while (!double.TryParse(alcoholPercentString, out alcoholPercent) || alcoholPercent < 0 || alcoholPercent > 100);

			if (alcoholPercent <= AlcoholPercentLimit)
			{
				Drink drink = new Drink();

				drink.Name = name;
				drink.Price = price;
				drink.AlcoholPercent = alcoholPercent;
				return drink;
			}
			else throw new Exception();
        }

        public Dairy CreateDairyProduct()
        {
            string name;
            do
            {
                Console.Write("Name: ");
                name = Console.ReadLine();

            } while (string.IsNullOrWhiteSpace(name));

            double price;
            string priceString;
            do
            {
                Console.Write("Price: ");
                priceString = Console.ReadLine();
            }
            while (!double.TryParse(priceString, out price) || price < 0);

            double fatPercent;
            string fatPercentString;

            do
            {
                Console.WriteLine("Fat Percent: ");
                fatPercentString = Console.ReadLine();

            } while (!double.TryParse(fatPercentString, out fatPercent) || fatPercent < 0 || fatPercent > 100);

            int count = 0;

            foreach (var product in _products)
            {
                if (product is Dairy)
                {
                    count++;
                }
            }
			if (count < DairyProductCountLimit)
			{
				Dairy dairy = new Dairy();

				dairy.Name = name;
				dairy.Price = price;
				dairy.FatPercent = fatPercent;

				return dairy;
			}
			else throw new Exception();
            
        }
    }
}

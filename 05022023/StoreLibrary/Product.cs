using System;
namespace StoreLibrary
{
    public abstract class Product
    {
        public int No;
        public string Name;
        public double Price;

        static int _totalCount;

        public Product()
        {
            _totalCount++;
            No = _totalCount;
        }

        public virtual void ShowProductsInfo()
        {
            Console.WriteLine($"No: {No} - Name: {Name} - Price: {Price}");
        }
    }
}

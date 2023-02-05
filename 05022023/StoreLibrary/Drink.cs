using System;
namespace StoreLibrary
{
    public class Drink : Product
    {
        public double AlcoholPercent;

        public override void ShowProductsInfo()
        {
            Console.WriteLine($"No: {No} - Name: {Name} - Price: {Price} - AlcoholPercent: {AlcoholPercent}");
        }
    }
}



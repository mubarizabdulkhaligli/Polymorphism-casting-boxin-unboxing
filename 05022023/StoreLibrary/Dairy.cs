using System;
namespace StoreLibrary
{
    public class Dairy : Product
    {
        public double FatPercent;

        public override void ShowProductsInfo()
        {
            Console.WriteLine($"No: {No} - Name: {Name} - Price: {Price} - FatPercent: {FatPercent}");
        }
    }
}


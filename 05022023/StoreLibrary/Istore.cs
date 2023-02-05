using System;
namespace StoreLibrary
{
    public interface IStore
    {
        Product[] Products { get; }

        void AddProduct(Product product);

        bool HasProductByNo(int no);

        Product GetProductByNo(int no);

        Drink[] GetDrinkProducts();

        Dairy[] GetDairyProducts();

        Product[] RemoveProduct(int no);
    }
}
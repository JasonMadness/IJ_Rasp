using System;
using System.Collections.Generic;
using System.Linq;

namespace IJ_Rasp_02_OnlineStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product iPhone12 = new Product("IPhone 12");
            Product iPhone11 = new Product("IPhone 11");

            Warehouse warehouse = new Warehouse();

            Shop shop = new Shop(warehouse);

            warehouse.Delive(iPhone12, 10);
            warehouse.Delive(iPhone11, 1);

            //Вывод всех товаров на складе с их остатком
            warehouse.ShowInfo();

            Cart cart = shop.GetNewCart();
            cart.PickProducts(iPhone12, 4);
            cart.PickProducts(iPhone11, 3); //при такой ситуации возникает ошибка так, как нет нужного количества товара на складе

            //Вывод всех товаров в корзине
            cart.ShowInfo();

            Console.WriteLine(cart.GetOrder().Paylink);

            cart.PickProducts(iPhone12, 9); //Ошибка, после заказа со склада убираются заказанные товары
        }
    }

    public class Shop
    {
        private Warehouse _warehouse;
        private List<Cart> _carts = new List<Cart>();

        public Shop(Warehouse warehouse)
        {
            _warehouse = warehouse;
        }

        public Cart GetNewCart()
        {
            Cart cart = new Cart();
            cart.Init(_warehouse);
            _carts.Add(cart);
            return _carts.Last();
        }
    }

    public class Warehouse : Storage
    {
        public Warehouse()
        {
            Name = "Склад";
        }

        public void Delive(Product product, int count)
        {
            Stockpile stockpile = new Stockpile(product, count);
            AddStockpile(stockpile);
        }
    }

    public class Cart : Storage
    {
        private Warehouse _warehouse;

        public Cart()
        {
            Name = "Тележка";
        }

        public void Init(Warehouse warehouse)
        {
            _warehouse = warehouse;
        }

        public void PickProducts(Product product, int count)
        {
            if (_warehouse.TryGetProducts(product, count, out Stockpile stockpile))
            {
                AddStockpile(stockpile);
            }
            else
            {
                Console.WriteLine($"При попытке заказать товар {product.Label} в количестве {count} шт. возникла ошибка.");
                Console.WriteLine($"Товар в нужном количестве отсутствует в хранилище '{_warehouse.Name}'");
                Console.WriteLine();
            }
        }

        public Order GetOrder()
        {
            return new Order();
        }
    }

    public class Storage
    {
        private List<Stockpile> _stockpiles = new List<Stockpile>();

        public string Name { get; protected set; }

        public void AddStockpile(Stockpile stockpile)
        {
            _stockpiles.Add(stockpile);
        }

        public bool TryGetProducts(Product product, int count, out Stockpile stockpile)
        {
            foreach (Stockpile stockpileItem in _stockpiles)
            {
                if (stockpileItem.Product.Label == product.Label && stockpileItem.Count >= count)
                {
                    stockpile = GetProducts(product, count);
                    return true;
                }
            }

            stockpile = null;
            return false;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name}, товары:");

            foreach (Stockpile stockpile in _stockpiles)
            {
                if (stockpile != null)
                {
                    Console.WriteLine($"Наименование - {stockpile.Product.Label}, количество - {stockpile.Count}");
                }
            }

            Console.WriteLine();
        }

        private Stockpile GetProducts(Product product, int count)
        {
            _stockpiles.First(stockpile => stockpile.Product.Label == product.Label).DecreaseCount(count);
            return new Stockpile(product, count);
        }
    }

    public class Order
    {
        public string Paylink { get; private set; } = "Какая-нибудь случайная строка";
    }

    public class Stockpile
    {
        public Product Product { get; private set; }
        public int Count { get; private set; }

        public Stockpile(Product product, int count)
        {
            Product = product;
            Count = count;
        }

        public void DecreaseCount(int count)
        {
            Count -= count;
        }
    }

    public class Product
    {
        public string Label { get; private set; }

        public Product(string label)
        {
            Label = label;
        }
    }
}

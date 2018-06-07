using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT_Collection5_OnlineShop
{
    class Purchase
    {
        public string buyer { get; set; }
        public string goods { get; set; }
    }
    class Shop
    {
        public List<string> client;
        public Dictionary<int, string> stuff;
        public bool isUserLoginIn;
        public List<Purchase> purchase;
        public List<string> currentUser;
        public Shop()
        {
            client = new List<string>();
            stuff = new Dictionary<int, string>();
            purchase = new List<Purchase>();
            currentUser = new List<string>();
        }
        public bool CreateClient(string clientName)
        {
            int clientNumberAtbegining = client.Count;
            int clientNumberAtTheEnd;
            client.Add(clientName);
            clientNumberAtTheEnd = client.Count;
            if (clientNumberAtbegining != clientNumberAtTheEnd)
            {
                return true;
            }
            else return false;
        }
        public bool CreateProduct(int productId, string productName)
        {
            int productNumberAtbegining = stuff.Count;
            int productNumberAtTheEnd;
            stuff.Add(productId, productName);
            productNumberAtTheEnd = stuff.Count;
            if (productNumberAtbegining != productNumberAtTheEnd)
            {
                return true;
            }
            else return false;
        }
        public bool Login(string clientName)
        {
            foreach (var name in client)
            {
                if (name == clientName)
                {
                    isUserLoginIn = true;
                    currentUser.Add(clientName);
                    Console.WriteLine($"User {clientName} succesfully Logged in");
                    //break;
                }
            }
            return isUserLoginIn;
        }
        public void MakePurchase(string clientName, string clientPurchases)
        {
            foreach (KeyValuePair<int, string> kvp in stuff)
            {
                if (kvp.Value == clientPurchases)//Check if user's purchase is in the stuff list
                {
                    purchase.Add(new Purchase() { buyer = clientName, goods = clientPurchases });//Add new purchase into list "purchase"
                    Console.WriteLine($"{clientName} succesfully bought {clientPurchases}");
                    return;
                }
            }
            Console.WriteLine($"Product {clientPurchases} {clientName} trying to buy is not in the shop");
        }
        public void PrintPurchase(string clientName)
        {
            int purchaisePerClient = 0;
            if (purchase.Count() != 0)
            {
                foreach (var item in purchase)
                {
                    if (item.buyer == clientName)
                    {
                        Console.WriteLine($"{item.buyer} - {item.goods}");
                        purchaisePerClient++;
                    }
                }
                if (purchaisePerClient == 0)
                {
                    Console.WriteLine($"No purchases for {clientName}");
                }
            }
            else
            {
                Console.WriteLine("no purchases for no users");
            }
        }
        public bool Logout(string clientName)
        {
            foreach (var name in client)
            {
                if (name == clientName)
                {
                    isUserLoginIn = false;
                    currentUser.Remove(clientName);
                    Console.WriteLine($"User {clientName} succesfully Logged out");
                    break;
                }
            }
            return isUserLoginIn;
        }
        public void ShowActiveUsers()
        {
            Console.WriteLine("Current list of active users is: ");
            for (int i = 0; i < currentUser.Count(); i++)
            {
                Console.Write($"{currentUser[i]};");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool isUserLoginIn;
            Shop shop = new Shop();
            shop.CreateProduct(1, "Pomidor");
            shop.CreateProduct(2, "Look");
            shop.CreateProduct(3, "Kapusta");
            shop.CreateClient("Vasya");
            shop.CreateClient("Petya");
            shop.CreateClient("Yulya");
            isUserLoginIn = shop.Login("Yulya");
            isUserLoginIn = shop.Login("Petya");
            isUserLoginIn = shop.Login("Vasya");
            shop.ShowActiveUsers();
            if (isUserLoginIn == true)
            {
                Console.WriteLine($"\n\nUsers make purchases");
                shop.MakePurchase("Yulya", "Look");
                shop.MakePurchase("Yulya", "macbook");
                shop.MakePurchase("Vasya", "Look");
                shop.MakePurchase("Vasya", "Kapusta");
                Console.WriteLine($"\nThe list of the purchases is:");
                shop.PrintPurchase("Yulya");
                shop.PrintPurchase("Petya");
                shop.PrintPurchase("Vasya");
            }
            Console.WriteLine($"\n");
            shop.Logout("Vasya");
            shop.ShowActiveUsers();
            Console.ReadKey();
        }
    }
}

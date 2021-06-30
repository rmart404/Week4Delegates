using System;
using FakeStore;
using shortid;
using shortid.Configuration;

Item imac = new() { Name = "iMac Latest", Price = 1_200 };
Item macmini = new() { Name = "Mac Mini", Price = 700 };
Item mbair = new() { Name = "MacBook Air", Price = 1_000 };
Item mbpro = new() { Name = "MacBook Pro", Price = 1_300 };

Menu menu = new();
Inventory inventory = new();
Cart cart = new();
SalesMan John = new();
Warehouse warehouse = new();
Purchasing purchasing = new();

John.onSale += warehouse.lookOrder;
John.onSale += purchasing.processPayment;

inventory.Add(imac);
inventory.Add(macmini);
inventory.Add(mbair);
inventory.Add(mbpro);

while (true)
{
  menu.Print();
  Console.Write("Option: ");
  string response = Console.ReadLine();

  switch (response)
  {
    case "add":
      {
        inventory.Print();

        Console.Write("\nWhat item would you like to add? (Type ID) ");
        string productID = Console.ReadLine();

        Item product = inventory.Items.Find(x => x.ID == productID);

        Console.Write("\nHow Many? ");

        if (product is not null & Int16.TryParse(Console.ReadLine(), out short productQty))
        {
          CartItem ci = new();
          ci.Product = product;
          ci.Quantity = productQty;
          cart.CartItems.Add(ci);
        }
        else
        {
          Console.WriteLine("No product with that ID or Incorrect Qty");
        }
        break;
      }
    case "show":
      {
        cart.Print();
        break;
      }
    case "clear":
      {
        cart.Clear();
        break;
      }
    case "done":
      {
        cart.Print();
        John.makeSale(cart);
        Console.Write("\n\nPress any key to continue...");
        Console.ReadKey();
        cart.Clear();
        break;
      }
    case "quit":
      {
        Environment.Exit(0);
        break;
      }
  }
}
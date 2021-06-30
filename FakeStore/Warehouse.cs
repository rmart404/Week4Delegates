using System;

namespace FakeStore
{
  public class Warehouse
  {
    public void lookOrder(object sender, Cart cart)
    {
      Console.WriteLine("\n\nWAREHOUSE");
      cart.CartItems.ForEach(x => { Console.WriteLine($"Looking for {x.Quantity} {x.Product.Name}"); });
    }
  }
}
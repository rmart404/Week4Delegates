using System;

namespace FakeStore
{
  public class SalesMan
  {
    public event EventHandler<Cart> onSale;

    public void makeSale(Cart cart)
    {
      Console.WriteLine("Order Placed, thank for shopping at Fake Store");
      onSale.Invoke(this, cart);
    }
  }
}
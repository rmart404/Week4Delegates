using System;
namespace FakeStore
{
  public class Purchasing
  {
    public void processPayment(object sender, Cart cart)
    {
      Console.WriteLine("\n\nSALES/PURCHASING");
      Console.WriteLine($"Procesing payment for ${cart.Total():N2}");
    }
  }
}
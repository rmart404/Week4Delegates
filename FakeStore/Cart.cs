using System;
using System.Collections.Generic;

namespace FakeStore
{
  public class Cart
  {
    public List<CartItem> CartItems = new();
    public void Clear() { CartItems.Clear(); }
    public int Count => CartItems.Count;
    private double _subTotal = 0;
    private const double tax = 8.25;

    public double Taxes() => _subTotal * (tax / 100);
    public double SubTotal()
    {
      _subTotal = 0;
      foreach (CartItem item in CartItems)
      {
        _subTotal += item.SubTotal();
      }
      return _subTotal;
    }
    public double Total() => _subTotal + Taxes();

    public void Print()
    {
      Console.Clear();
      Console.WriteLine("WELCOME TO THE FAKESHOP - Your Cart\n");
      Console.WriteLine("      ID            NAME              PRICE            QUANTITY         TOTAL");
      foreach (var item in CartItems)
      {
        Console.WriteLine(String.Format("{0} {1,15} \t${2,10:N2} {3,15} \t\t${4,10:N2}", item.Product.ID, item.Product.Name, item.Product.Price, item.Quantity, item.SubTotal()));
      }
      Console.WriteLine("\n                                                         SubTotal \t${0,10:N2}", SubTotal());
      Console.WriteLine("                                                            Taxes \t${0,10:N2}", Taxes());
      Console.WriteLine("\n                                                            TOTAL \t${0,10:N2}", Total());
      Console.Write("\n\nPress any key to continue...");
      Console.ReadKey();
    }
  }
}
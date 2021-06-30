using System;
using System.Collections;
using System.Collections.Generic;

namespace FakeStore
{
  public class Inventory : IEnumerable
  {
    public List<Item> Items = new();
    public void Clear() => Items.Clear();
    public void Add(Item item) => Items.Add(item);
    public int Count() => Items.Count;

    IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();

    public void Print()
    {
      Console.Clear();
      Console.WriteLine("WELCOME TO THE FAKESHOP - Our Products\n");
      Console.WriteLine("      ID            NAME              PRICE");
      foreach (Item item in this)
      {
        Console.WriteLine(String.Format("{0} {1,15} \t${2,10:N2}", item.ID, item.Name, item.Price));
      }
    }
  }
}
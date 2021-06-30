using System;

namespace DelegateDemo
{
  class Program
  {
    public delegate void MyDelegate();
    public delegate int AnotherDelegate(int i);
    static private MyDelegate myDelegate;
    static private AnotherDelegate anotherDelegate;

    static private Action myAction;
    static private Action<bool, string> anotherAction;

    static private Func<int, int> myFunc;
    static void Main(string[] args)
    {
      myDelegate = sayHello;
      myDelegate += sayGoodbye;

      myDelegate = delegate () { Console.WriteLine("Who let the dogs out?"); };
      myDelegate += () => { Console.WriteLine("Who, who, who?"); };
      myDelegate();

      // myDelegate -= sayHello;
      // myDelegate();

      anotherDelegate = twoX;

      anotherDelegate = delegate (int i) { return i * i; };

      anotherDelegate = (int i) => i * 3;
      anotherDelegate = (int i) => i * 4;

      Console.WriteLine(anotherDelegate(5));

      myAction = sayHello;
      myAction();

      anotherAction = (bool val, string text) => { Console.WriteLine($"{text} {val}"); };
      anotherAction(true, "The boolean is");

      myFunc = (int i) => i * i * i;
      Console.WriteLine(myFunc(3));
    }

    static private void sayHello()
    {
      Console.WriteLine("Hello There!");
    }
    static private void sayGoodbye()
    {
      Console.WriteLine("Goodbye There!");
    }

    static private int twoX(int number) => number * 2;
  }
}
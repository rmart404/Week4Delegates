using System;
using System.Linq;
using System.Collections.Generic;
using LinqDemos;

// Data from DataSources Folder.....
Data data = new();
List<Product> products = data.GetProductList();
List<Customer> customers = data.GetCustomerList();

// int[] grades = new int[] { 97, 92, 80, 75, 55, 43, 90, 70, 66, 75 };
List<int> grades = new() { 97, 92, 80, 75, 55, 43, 90, 70, 66, 75 };
//Eager Execution
var passingGrades = (from grade in grades
                     where grade >= 70
                     select grade)
                    .ToList();
// Lazy Execution
// var passingGrades = from grade in grades
//                     where grade >= 70
//                     select grade;

// foreach (var g in passingGrades)
// {
//   Console.Write($"{g} ");
// }

grades.AddRange(new int[] { 50, 50, 90, 90, 90 });

// Console.WriteLine();

// foreach (var g in passingGrades)
// {
//   Console.Write($"{g} ");
// }


var soldOutProducts = from p in products
                      where p.UnitsInStock == 0
                      select p;

// Console.WriteLine("Sold out products:");
// foreach (var product in soldOutProducts)
// {
//   Console.WriteLine($"{product.ProductName} is sold out!");
// }

var expensiveInStockProducts = from prod in products
                               where prod.UnitsInStock > 0 && prod.UnitPrice > 3.00M
                               select prod;

// Console.WriteLine("In-stock products that cost more than 3.00:");
// foreach (var product in expensiveInStockProducts)
// {
//   Console.WriteLine($"{product.ProductName} is in stock and costs more than 3.00.");
// }

var waCustomers = from cust in customers
                  where cust.Region == "WA"
                  select cust;
// Console.WriteLine("Customers from Washington and their orders:");
// foreach (var customer in waCustomers)
// {
//   Console.WriteLine($"Customer {customer.CustomerID}: {customer.CompanyName}");
//   foreach (var order in customer.Orders)
//   {
//     Console.WriteLine($"  Order {order.OrderID}: {order.OrderDate}");
//   }
// }


// int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

// var numsPlusOne = from n in numbers
//                   select n + 1;

// Console.WriteLine("Numbers + 1:");
// foreach (var i in numsPlusOne)
// {
//   Console.WriteLine(i);
// }

var productNames = from p in products
                   select p.ProductName;

// Console.WriteLine("Product Names:");
// foreach (var productName in productNames)
// {
//   Console.WriteLine(productName);
// }


// int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
// string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

// var textNums = from n in numbers
//                select strings[n];

// Console.WriteLine("Number strings:");
// foreach (var s in textNums)
// {
//   Console.WriteLine(s);
// }

// var first3Numbers = numbers.Take(3);

// Console.WriteLine("First 3 numbers:");
// foreach (var n in first3Numbers)
// {
//   Console.WriteLine(n);
// }


var waOrders = from cust in customers
               from order in cust.Orders
               where cust.Region == "WA"
               orderby order.OrderID descending, order.OrderDate
               select (cust.CustomerID, order.OrderID, order.OrderDate);

var allButFirst2Orders = waOrders.Skip(2);

// Console.WriteLine("All but first 2 orders in WA:");
// foreach (var order in allButFirst2Orders)
// {
//   Console.WriteLine(order);
// }


// int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

// var numberGroups = from n in numbers
//                    group n by n % 5 into g
//                    select (Remainder: g.Key, Numbers: g);

// foreach (var x in numberGroups)
// {
//   Console.WriteLine($"Numbers with a remainder of {x.Remainder} when divided by 5:");
//   foreach (var n in x.Numbers)
//   {
//     Console.WriteLine(n);
//   }
// }


// string[] words = { "blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese" };

// var wordGroups = from w in words
//                  group w by w[0] into g
//                  select (FirstLetter: g.Key, Words: g);

// foreach (var g in wordGroups)
// {
//   Console.WriteLine("Words that start with the letter '{0}':", g.FirstLetter);
//   foreach (var w in g.Words)
//   {
//     Console.WriteLine(w);
//   }
// }

int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

double numSum = numbers.Sum();

Console.WriteLine($"The sum of the numbers is {numSum}");

string[] words = { "cherry", "apple", "blueberry" };

double totalChars = words.Sum(w => w.Length);

Console.WriteLine($"There are a total of {totalChars} characters in these words.");
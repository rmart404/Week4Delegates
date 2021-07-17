using System.Collections.Generic;

namespace LinqDemos
{
  public class Data
  {
    public List<Product> GetProductList() => Products.ProductList;
    public List<Customer> GetCustomerList() => Customers.CustomerList;
  }
}
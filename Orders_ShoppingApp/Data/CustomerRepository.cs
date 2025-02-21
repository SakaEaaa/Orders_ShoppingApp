using Orders_ShoppingApp.Interfaces;
using Orders_ShoppingApp.Models;

namespace Orders_ShoppingApp.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _customers;
        private readonly List<Order> _orders;
        public CustomerRepository()
        {
            _customers = new List<Customer>()
            {
                new Customer
                {
                     CustomerId = 1,
                     Name = "John Robin"
                },
                new  Customer
                {
                     CustomerId = 2,
                    Name = "Jane Smith"
                },

                new  Customer
                {
                     CustomerId = 3,
                    Name = "Hanna Nielsen"
                },
                new  Customer
                {
                     CustomerId = 4,
                    Name = "Silan Hansen"
                }
            };

        }
        public IEnumerable<Customer> GetCustomers() => _customers;

        public Customer Add(Customer newCustomer)
        {
            _customers.Add(newCustomer);
            return newCustomer;
        }

        public Customer GetById(int id)
        {
            return _customers.Where(a => a.CustomerId == id).FirstOrDefault();
        }

        public void Remove(int id)
        {
            var existing = _orders.First(a => a.CustomerId == id);
            _orders.Remove(existing);
        }
    }
}

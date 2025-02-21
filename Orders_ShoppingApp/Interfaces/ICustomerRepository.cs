using Orders_ShoppingApp.Models;

namespace Orders_ShoppingApp.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();
        Customer Add(Customer newItem);
        Customer GetById(int id);
        void Remove(int id);
    }
}

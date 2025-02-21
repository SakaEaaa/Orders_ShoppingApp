using Orders_ShoppingApp.Models;

namespace Orders_ShoppingApp.Interfaces
{
    
        public interface IOrderRepository
        {
            IEnumerable<Order> GetOrders();
            Order Add(Order newItem);
            Order GetById(int id);
            void Remove(int id);
        }
    
}

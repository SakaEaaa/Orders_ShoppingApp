using Orders_ShoppingApp.Interfaces;
using Orders_ShoppingApp.Models;

namespace Orders_ShoppingApp.Data
{
    public class OrderRepository : IOrderRepository
    {


        private readonly List<Order> _orders;
        public OrderRepository()
        {

            _orders = new List<Order>()
            {
                new Order
                {
                     OrderId = 1,
                     CustomerId = 1,
                     Date = new DateTime(2022,12,10),
                     Amount = 1230
                },
                new Order
                {

                    OrderId = 2,
                     CustomerId = 1,
                     Date = new DateTime(2023,12,12),
                     Amount = 130
                },
                new Order
                {
                     OrderId = 3,
                     CustomerId = 2,
                     Date = new DateTime(2024,02,10),
                     Amount = 222
                }
                ,
                new Order
                {
                     OrderId = 4,
                     CustomerId = 3,
                     Date = new DateTime(2024,03,10),
                     Amount = 272
                }
                ,
                new Order
                {
                     OrderId = 5,
                     CustomerId = 4,
                     Date = new DateTime(2024,02,12),
                     Amount = 122
                }
            };
        }

        public IEnumerable<Order> GetOrders() => _orders;
        public Order Add(Order newOrder)
        {
            _orders.Add(newOrder);
            return newOrder;
        }

        public Order GetById(int id)
        {
            return _orders.Where(a => a.OrderId == id).FirstOrDefault();
        }

        public void Remove(int id)
        {
            var existing = _orders.First(a => a.CustomerId == id);
            _orders.Remove(existing);
        }
    }
}

using KillerApp.DataLayer.Interfaces;
using KillerApp.DataLayer.Models;
using System;
using System.Collections.Generic;

namespace DataLayer.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IImageRepository _itemRepository;
        public OrderRepository(IImageRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public bool AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public Order GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}

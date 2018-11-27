using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Interfaces
{
    public interface IOrderRepository
    {
        Order GetOrderById(int id);
        bool RemoveOrder(Order order);
        List<Order> GetAllOrders();
        bool AddOrder(Order order);
    }
}

﻿using System.Collections.Generic;
using DataLayer.Interfaces;
using DataLayer.Models;
using LogicLayer.Interfaces;

namespace LogicLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IItemRepository itemRepository, IOrderRepository orderRepository)
        {
            _itemRepository = itemRepository;
            _orderRepository = orderRepository;
        }

        public Image BuyOrder(int userId, int orderId)
        {
            throw new System.NotImplementedException();
        }

        public bool PlaceOrder(int userId, string orderName, List<Image> images)
        {
            throw new System.NotImplementedException();
        }
    }
}
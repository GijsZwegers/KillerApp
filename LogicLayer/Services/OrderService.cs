using System.Collections.Generic;
using KillerApp.DataLayer.Interfaces;
using KillerApp.DataLayer.Models;
using KillerApp.LogicLayer.Interfaces;

namespace KillerApp.LogicLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IImageRepository imageRepository, IOrderRepository orderRepository)
        {
            _imageRepository = imageRepository;
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

using KillerApp.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KillerApp.LogicLayer.Interfaces
{
    public interface IOrderService
    {
        bool PlaceOrder(int userId, string ordername, List<Image> images);
        Image BuyOrder(int userId, int orderId);
    }
}

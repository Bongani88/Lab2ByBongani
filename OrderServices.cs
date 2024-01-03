using Lab2.CommonModules.Entity;
using Lab2.CommonModules.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Services.Services
{
    public class OrderServices : IOrder
    {
        private readonly IOrder _iOrder;
        public OrderServices(IOrder OrderServices)
        { 
            _iOrder = OrderServices;
        }
        public async Task<bool> Add(Orders order)
        {
           return await _iOrder.Add(order);
        }

        public async Task<bool> Delete(Orders order)
        {
           return await _iOrder.Delete(order);
        }

        public async Task<bool> GetAll(Orders order)
        {
            return await _iOrder.GetAll(order);
        }

        public async Task<bool> Update(Orders order)
        {
            return await _iOrder.Update(order);
        }
    }
}

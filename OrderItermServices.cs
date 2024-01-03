using Lab2.CommonModules.Entity;
using Lab2.CommonModules.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Services.Services
{
    public class OrderItermServices : IOrderItem
    {
        private readonly IOrderItem _iOrder;
        public OrderItermServices(IOrderItem OrderItermServices)
        {
            _iOrder = OrderItermServices;
        }
        public async Task<bool> Add(OrderItem item)
        {
            return await _iOrder.Add(item);
        }
           

        public async Task<bool> Delete(OrderItem item)
        {
           return await _iOrder.Delete(item);

        }

        public async Task<bool> GetAll(OrderItem item)
        {
           return await _iOrder.GetAll(item);
        }

        public async Task<bool> Update(OrderItem item)
        {
            return await _iOrder.Update(item);

        }
    }
}

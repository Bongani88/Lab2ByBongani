using Lab2.CommonModules.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.CommonModules.Interface
{
    public interface IOrderItem
    {
        Task<bool> Add(OrderItem item);
        Task<bool> GetAll(OrderItem item);
        Task<bool> Update(OrderItem item);
        Task<bool> Delete(OrderItem item);

    
    }
}

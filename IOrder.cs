using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.CommonModules.Entity;

namespace Lab2.CommonModules.Interface
{
    public interface IOrder
    {
        Task<bool> Add(Orders order);
        Task<bool> GetAll(Orders order);
        Task<bool> Update(Orders order);
        Task<bool> Delete(Orders order);

    }
}

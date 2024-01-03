using Lab2.CommonModules.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.CommonModules.Interface
{
    public interface IProduct
    {
        Task<bool> Add(Product product);
        Task<bool>  GetAll(Product product);
        Task<bool> Update(Product product);
        Task<bool> Delete(Product product);

    }
}

using Lab2.CommonModules.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.CommonModules.Interface
{
    public interface ICustomer
    {
        Task<bool> Add(Customer customer);
        Task<bool> Get(Customer customer);
        Task<bool> Update(Customer customer);
        Task<bool> Delete(Customer customer);
     
    }
}

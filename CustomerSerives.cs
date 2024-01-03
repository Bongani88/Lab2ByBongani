using Lab2.CommonModules.Entity;
using Lab2.CommonModules.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Services.Services
{
    public class CustomerSerives : ICustomer
    {
        private readonly ICustomer _Customer;
        public CustomerSerives(ICustomer CustomerSerives)
        { 
            _Customer = CustomerSerives;
        }

        public async Task<bool> Add(Customer customer)
        {
            return await _Customer.Add(customer);
        }

        public async Task<bool> Delete(Customer customer)
        {
           
            return await _Customer.Delete(customer);
        }

        public async Task<bool> Get(Customer customer)
        {
            return await _Customer.Get(customer);
        }

        public async Task<bool> Update(Customer customer)
        {
            return await _Customer.Update(customer);
        }
    }
}

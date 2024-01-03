using Dapper;
using Lab2.CommonModules.Entity;
using Lab2.CommonModules.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Infrastructure.Reprository
{
    public class CustomerRepo : ICustomer
    {
        public async Task<bool> Add(Customer customer)
        {
            try
            {
                var connectionString = "connection";

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var sql = "INSERT INTO dbo.Customer (customerID, firstName, lastName, email, phone, address) VALUES (@customerID, @firstName, @lastName, @email, @phone, @address)";
                    var query = await connection.ExecuteAsync(sql, commandType: System.Data.CommandType.StoredProcedure);
                    return query > 0;
                }
            } catch (Exception ex)
            {
                Console.WriteLine($"Error in Add method: {ex.Message}");              
            }
            return false;
        }

        public async Task<bool> Delete(Customer customer)
        {
            try
            {
                var connectionString = "connection";
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    var sql = "DELETE FROM dbo.Customer WHERE customerID = @customerID";
                    var rowsAffected = await connection.ExecuteAsync(sql, new { customerID = customer.customerID });
                    return rowsAffected > 0;
                }
               
            } catch(Exception ex)
            {
                Console.WriteLine($"Error in Delete method: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> Get(Customer customer)
        {
           try
            {
                var connectionString = "connection";
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    var sql = "SELECT * FROM dbo.Customer";
                    var rowsAffected = await connection.ExecuteAsync(sql, customer);
                    return rowsAffected > 0;
                }
            } catch (Exception ex)
            {
                Console.WriteLine($"Error in Update method: {ex.Message}");
                return false;

            }
        }

        public async Task<bool> Update(Customer customer)
        {
            try
            {
                var connectionString = "connection";
                using (var connection = new SqlConnection(connectionString))
                {
                    var sql = "UPDATE dbo.Customer SET firstName = @firstName, lastName = @lastName, email = @email, phone = @phone, address = @address WHERE customerID = @customerID";

                    var rowsAffected = await connection.ExecuteAsync(sql, customer);
                    return rowsAffected > 0;

                }
            } catch(Exception ex)
            {
                Console.WriteLine($"Error in Update method: {ex.Message}");
                return false;
            }
        }
    }
}

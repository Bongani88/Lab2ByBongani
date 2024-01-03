using Dapper;
using Lab2.CommonModules.Entity;
using Lab2.CommonModules.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Infrastructure.Reprository
{
    public class OrderRepo : IOrder
    {
        public async Task<bool> Add(Orders order)
        {
            try
            {
                var connectionString = "connection";

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var sql = "INSERT INTO dbo.Order (orderID,customerID,date, totalAmount) VALUES (@orderID,@customerID,@date,@totalAmount)";
                    var rowsAffected = await connection.ExecuteAsync(sql, order);
                    return rowsAffected > 0;
                }

            }catch (Exception ex) 
            {
                Console.WriteLine($"Error in Update method: {ex.Message}");
                return false;

            }

        }

        public async Task<bool> Delete(Orders order)
        {
            try
            {
                var connectionString = "connection";
                using ( var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    var sql = "DELETE FROM dbo.Order WHERE orderID = @orderID";
                    var rowsAffected = await connection.ExecuteAsync(sql, new { orderID = order.orderID });
                    return rowsAffected > 0;
                }
            } catch (Exception ex)
            {
                Console.WriteLine($"Error in Delete method: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> GetAll(Orders order)
        {
            try
            {
                var connectionString = "connection";
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var sql = "SELECT * FROM dbo.Order";
                    var rowsAffected = await connection.ExecuteAsync(sql, order);
                    return rowsAffected > 0;

                }

            } catch(Exception ex)
            {
                Console.WriteLine($"Error in Update method: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> Update(Orders order)
        {
            try
            {
                var connectionString = "connection";
                using (var connection = new SqlConnection(connectionString))
                {
                    var sql = "UPDATE dbo.Order SET orderID = @orderID, customerID = @customerID, date = @date, totalAmount = @totalAmount";
                    var rowsAffected = await connection.ExecuteAsync(sql, order);
                    return rowsAffected > 0;
                }
            } catch (Exception ex)
            {
                Console.WriteLine($"Error in Update method: {ex.Message}");
                return false;
            }
        }
    }
}

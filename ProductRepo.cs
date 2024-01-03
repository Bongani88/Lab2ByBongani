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
    public class ProductRepo : IProduct
    {
        public async Task<bool> Add(Product product)
        {
            try
            {
                var connectionString = "connection";
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var sql = "INSERT INTO dbo.Product(productID,productName, description,price, stockQuantity) VALUES(@productID,@productName,@description, @price, @stockQuantity)";
                    var query = await connection.ExecuteAsync(sql, commandType: System.Data.CommandType.StoredProcedure);
                    return query > 0;
                }

            } catch (Exception ex)
            {
                Console.WriteLine($"Error in Add method: {ex.Message}");
            }
            return false;
        }

        public async Task<bool> Delete(Product product)
        {
            try
            {
                var connectionString = "connection";
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    var sql = "DELETE FROM dbo.Product WHERE productID = @productID";
                    var rowsAffected = await connection.ExecuteAsync(sql, new { productID = product.productID });
                    return rowsAffected > 0;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Delete method: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> GetAll(Product product)
        {
            try
            {
                var connectionString = "connection";
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    var sql = "SELECT * FROM dbo.Product";
                    var rowsAffected = await connection.ExecuteAsync(sql, product);
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Update method: {ex.Message}");
                return false;

            }
        }

        public async Task<bool> Update(Product product)
        {
            try
            {
                var connectionString = "connection";
                using (var connection = new SqlConnection(connectionString))
                {
                    var sql = "UPDATE dbo.Customer SET productName = @productName, description = @description, price = @price, stockQuantity = @stockQuantity";

                    var rowsAffected = await connection.ExecuteAsync(sql, product);
                    return rowsAffected > 0;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Update method: {ex.Message}");
                return false;
            }
        }
    } 
}


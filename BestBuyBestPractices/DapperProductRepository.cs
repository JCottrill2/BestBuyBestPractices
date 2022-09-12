using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace BestBuyBestPractices;
public class DapperProductRepository : IProductRepository
{
    private readonly DapperProductRepository _connection;

    public DapperProductRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    public void CreateProduct(string name, double price, int categoryID)
    {
        _connection.Execute("INSERT INTO products(Name, Price, CategoryID) VALUES (@name, @price, @categoryID);", 
            new { name = name, price = price, categoryID = categoryID });
    }

    public IEnumerable<product> GetAllProducts()
    {
        return _connection.Query<product>("SELECT * FROM products;");
        
    }    
}

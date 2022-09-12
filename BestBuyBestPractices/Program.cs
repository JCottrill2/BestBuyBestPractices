using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using BestBuyBestPractices;
//^^^^MUST HAVE USING DIRECTIVES^^^^

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
string connString = config.GetConnectionString("DefaultConnection");
IDbConnection conn = new MySqlConnection(connString);

//var departmentRepo = new DapperDepartmentRepository(conn);

//Console.WriteLine("Enter in a New Department");
//string newDepartment = Console.ReadLine();

//departmentRepo.InsertDepartment(newDepartment);

//IEnumerable<Department> departments = departmentRepo.GetAllDepartments();

//foreach (var dept in departments)
//{
//    Console.WriteLine(dept.DepartmentID);
//    Console.WriteLine(dept.Name);
//}

var productRepo = new DapperProductRepository(conn);

Console.WriteLine("Enter in the name of your new product: ");
var productName = Console.ReadLine();
Console.WriteLine("Enter in the price of your new product: ");
var price = double.Parse(Console.ReadLine());
Console.WriteLine("Enter in your category ID: ");
var catID = int.Parse(Console.ReadLine());
productRepo.CreateProduct(productName, price, catID);

var productCollection = productRepo.GetAllProducts();

foreach (var product in productCollection)
{
    Console.WriteLine(product.ProductID);
    Console.WriteLine(product.Name);
    Console.WriteLine(product.Price);
    Console.WriteLine(product.CategoryID);
    Console.WriteLine(product.OnSale);
    Console.WriteLine(product.StockLevel);
}
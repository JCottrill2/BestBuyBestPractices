using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyBestPractices
{
    public interface IProductRepository
    {
        IEnumerable<product> GetAllProducts();
        void CreateProduct(string name, double price, int categoryID);
    }
}

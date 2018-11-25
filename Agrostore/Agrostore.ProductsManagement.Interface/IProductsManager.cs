using Agrostore.CategoriesManagement.Interface.Entities;
using Agrostore.ProductsManagement.Interface.Entities;
using System.Collections.Generic;

namespace Agrostore.ProductsManagement.Interface
{
    public interface IProductsManager
    {
        void Create(Product product);

        IList<Product> GetAll(int? start = null, int? count = null);
        Product Get(int id);
        Product Get(string article);
        IList<Product> Get(Category category, int? start = null, int? count = null);

        void Update(Product product);
        void Delete(Product product);

        (long Total, IList<Product> Products) Search(string[] namePatterns, Category[] categories, int? start = null, int? count = null);
    }
}

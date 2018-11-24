using Agrostore.CategoriesManagement.Interface.Entities;
using Agrostore.ProductsManagement.Interface.Entities;
using System.Collections.Generic;

namespace Agrostore.ProductsManagement.Interface
{
    public interface IProductsManager
    {
        void Create(Product product);

        IList<Product> GetAll();
        Product Get(int id);
        Product Get(string article);
        IList<Product> Get(Category category);

        void Update(Product product);

        void Delete(Product product);
    }
}

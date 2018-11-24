using Agrostore.CategoriesManagement.Interface.Entities;
using System.Collections.Generic;

namespace Agrostore.CategoriesManagement.Interface
{
    public interface ICategoriesManager
    {
        void Create(Category category);

        IList<Category> GetAll();
        Category Get(int id);
        Category Get(string name);

        void Update(Category category);

        void Delete(Category category);
    }
}

using Agrostore.CategoriesManagement.Interface;
using Agrostore.CategoriesManagement.Interface.Entities;
using Agrostore.ProductsManagement.Interface;
using Agrostore.ProductsManagement.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Agrostore.WebAPI.Controllers
{
    public class CategoriesController : ApiController
    {
        #region core
        private ICategoriesManager _categoriesManager;
        private IProductsManager _productsManager;
        #endregion

        #region init
        public CategoriesController(ICategoriesManager categoriesManager, IProductsManager productsManager)
        {
            _categoriesManager = categoriesManager;
            _productsManager = productsManager;
        }
        #endregion

        #region WebAPI
        public IEnumerable<Category> Get()
        {
            try
            {
                return _categoriesManager.GetAll();
            }
            catch (Exception exc)
            {
                return null;
            }
        }

        public IList<Product> Get(int id)
        {
            try
            {
                var category = _categoriesManager.Get(id);
                return _productsManager.Get(category);
            }
            catch (Exception exc)
            {
                return null;
            }
        }
        #endregion

    }
}

using Agrostore.CategoriesManagement.Interface;
using Agrostore.CategoriesManagement.Interface.Entities;
using Agrostore.ProductsManagement.Interface;
using Agrostore.ProductsManagement.Interface.Entities;
using Agrostore.WebAPI.Models;
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

        public CategoryModel Get(int id, int? page = null, int? count = null)
        {
            CategoryModel res = null;
            try
            {
                int? start = null;
                if(page != null && count != null && page > 0 && count >= 0)
                {
                    start = (page - 1) * count;
                }
                var category = _categoriesManager.Get(id); res = new CategoryModel()
                {
                    Total = category.Total,
                    Products = _productsManager.Get(category, start, count)
                };
            }
            catch (Exception exc)
            {
                res = new CategoryModel()
                {
                    Total = 0,
                    Products = null
                };
            }
            return res;
        }
        #endregion

    }
}

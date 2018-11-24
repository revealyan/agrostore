using Agrostore.ProductsManagement.Interface;
using Agrostore.ProductsManagement.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Agrostore.WebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        #region core
        private IProductsManager _productManager;
        #endregion

        #region init
        public ProductsController(IProductsManager productManager)
        {
            _productManager = productManager;
        }
        #endregion

        #region WebAPI
        public IEnumerable<Product> Get()
        {
            try
            {
                return _productManager.GetAll();
            }
            catch (Exception exc)
            {
                return null;
            }
        }

        public Product Get(int id)
        {
            try
            {
                return _productManager.Get(id);
            }
            catch (Exception exc)
            {
                return null;
            }
        }
        #endregion
    }
}

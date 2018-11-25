using Agrostore.CategoriesManagement.Interface.Entities;
using Agrostore.ProductsManagement.Interface;
using Agrostore.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Agrostore.WebAPI.Controllers
{
    public class SearchController : ApiController
    {
        #region core
        private IProductsManager _productsManager;
        #endregion

        #region init
        public SearchController(IProductsManager productsManager)
        {
            _productsManager = productsManager;
        }
        #endregion

        #region support
        private string[] SplitQuery(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return null;

            var res = new List<string>();

            res.AddRange(query.Split(' '));
            res.AddRange(query.Split(','));
            res.AddRange(query.Split(';'));

            return res.ToArray();
        }
        #endregion

        #region WebAPI
        public SearchModel Get(string query, int[] categories, int? page = null, int? count = null)
        {
            SearchModel res = null;
            try
            {
                int? start = null;
                if (page > 0 && count >= 0)
                {
                    start = (page - 1) * count;
                }
                var names = SplitQuery(query);
                var container =_productsManager.Search(names, categories?.Select(x => new Category() { Id = x })?.ToArray(), start, count);
                res = new SearchModel()
                {
                    Total = container.Total,
                    Products = container.Products
                };
            }
            catch (Exception exc)
            {
                res = new SearchModel()
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

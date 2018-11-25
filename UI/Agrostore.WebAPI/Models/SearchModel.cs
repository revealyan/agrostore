using Agrostore.ProductsManagement.Interface.Entities;
using System.Collections.Generic;

namespace Agrostore.WebAPI.Models
{
    public class SearchModel
    {
        public long Total { get; set; }
        public IList<Product> Products { get; set; }
    }
}
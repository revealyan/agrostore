using Agrostore.CategoriesManagement.Interface.Entities;
using Agrostore.ProductsManagement.Interface;
using Agrostore.ProductsManagement.Interface.Entities;
using Common.Database.Interface;
using Common.Logger.Interface;
using Common.Modules.Base;
using System;
using System.Collections.Generic;

namespace Agrostore.ProductsManagement
{
    public class ProductsManager : BaseModule, IProductsManager
    {
        #region core
        private ILogger _logger;
        private IDatabase _database;
        #endregion

        #region private methods
        private Product CreateProductFromReader(IDatabaseReader reader)
        {
            return new Product()
            {
                Id = reader.GetValue<int>("id"),
                Article = reader.GetValue<string>("article"),
                Name = reader.GetValue<string>("name"),
                Count = reader.GetValue<decimal>("count"),
                Price = reader.GetValue<decimal>("price")
            };
        }
        #endregion

        #region init
        public ProductsManager(string name, IDictionary<string, string> parameters) : base(name, parameters)
        {
            RegisterInterface<IProductsManager>(this);
        }
        #endregion

        #region BaseModule
        public override void Startup()
        {
            base.Startup();
            _logger = ResolveInterface<ILogger>();
            _database = ResolveInterface<IDatabase>();
        }
        public override void Shutdown()
        {
            base.Shutdown();
        }
        #endregion


        #region IProductsManager
        public void Create(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            Product res = null;
            using (var cmd = _database.CreateCommand($"SELECT * FROM products WHERE id={id}"))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        res = CreateProductFromReader(reader);
                    }
                }
            }
            return res;
        }

        public Product Get(string article)
        {
            Product res = null;
            using (var cmd = _database.CreateCommand($"SELECT * FROM products WHERE article={article}"))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        res = CreateProductFromReader(reader);
                    }
                }
            }
            return res;
        }

        public IList<Product> Get(Category category)
        {
            var res = new List<Product>();
            using (var cmd = _database.CreateCommand($"SELECT * FROM products WHERE categories_id={category.Id}"))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        res.Add(CreateProductFromReader(reader));
                    }
                }
            }
            return res;
        }


        public IList<Product> GetAll()
        {
            var res = new List<Product>();
            using (var cmd = _database.CreateCommand($"SELECT * FROM products"))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        res.Add(CreateProductFromReader(reader));
                    }
                }
            }
            return res;
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

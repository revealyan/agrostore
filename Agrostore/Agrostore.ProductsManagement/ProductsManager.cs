using Agrostore.CategoriesManagement.Interface.Entities;
using Agrostore.ProductsManagement.Interface;
using Agrostore.ProductsManagement.Interface.Entities;
using Common.Database.Interface;
using Common.Logger.Interface;
using Common.Modules.Base;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IList<Product> Get(Category category, int? start = null, int? count = null)
        {
            var res = new List<Product>();
            var limits = start != null && count != null && start >= 0 && count >= 0 ? $"LIMIT {start}, {count}" : "";
            using (var cmd = _database.CreateCommand($"SELECT * FROM products WHERE (categories_id={category?.Id.ToString() ?? "NULL"} or {category?.Id is null}) {limits}"))
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

        public IList<Product> GetAll(int? start = null, int? count = null) => Get(null, start, count);

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }

        public (long Total, IList<Product> Products) Search(string[] namePatterns, Category[] categories, int? start = null, int? count = null)
        {
            var res = new List<Product>();
            long total = 0;
            string queryPage = "SELECT * FROM products ";
            string queryTotal = "SELECT count(*) as total FROM products ";

            string conditions = $"WHERE UPPER(name) regexp '{namePatterns?.Aggregate("", (x, y) => $"{x}|{y?.ToUpper()}", r => r.Trim('|')) ?? "\\w"}' AND (categories_id in ({categories?.Aggregate("", (x, y) => $"{x},{(y?.Id.ToString() ?? "null")}", r => r.Trim(',')) ?? "null"}) or {categories is null || categories.Length == 0}) ";
            string limits = start != null && count != null && start >= 0 && count >= 0 ? $"LIMIT {start}, {count}" : "";

            queryPage += conditions;
            queryPage += limits;

            queryTotal += conditions;
            using (var cmd = _database.CreateCommand(queryTotal))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        total = reader.GetValue<long>("total");
                    }
                }
            }

            using (var cmd = _database.CreateCommand(queryPage))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        res.Add(CreateProductFromReader(reader));
                    }
                }
            }
            return (total, res);
        }
        #endregion
    }
}

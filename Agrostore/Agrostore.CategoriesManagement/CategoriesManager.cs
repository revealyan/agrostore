using System.Collections.Generic;
using Agrostore.CategoriesManagement.Interface;
using Agrostore.CategoriesManagement.Interface.Entities;
using Common.Database.Interface;
using Common.Logger.Interface;
using Common.Modules.Base;

namespace Agrostore.CategoriesManagement
{
    public class CategoriesManager : BaseModule, ICategoriesManager
    {
        #region core
        private ILogger _logger;
        private IDatabase _database;
        #endregion

        #region SQL-Command
        #endregion

        #region private methods
        private Category CreateCategoryFromReader(IDatabaseReader reader)
        {
            return new Category()
            {
                Id = reader.GetValue<int>("id"),
                Name = reader.GetValue<string>("name")
            };
        }
        #endregion

        #region init
        public CategoriesManager(string name, IDictionary<string, string> parameters) : base(name, parameters)
        {
            RegisterInterface<ICategoriesManager>(this);
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

        #region ICategoriesManager
        public void Create(Category category)
        {
            throw new System.NotImplementedException();
        }

        public IList<Category> GetAll()
        {
            var res = new List<Category>();
            using (var cmd = _database.CreateCommand("SELECT * FROM categoreis"))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        res.Add(CreateCategoryFromReader(reader));
                    }
                }
            }
            return res;
        }

        public Category Get(int id)
        {
            Category res = null;
            using (var cmd = _database.CreateCommand($"SELECT * FROM categoreis WHERE id={id}"))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        res = CreateCategoryFromReader(reader);
                    }
                }
            }
            return res;
        }

        public Category Get(string name)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Category category)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Category category)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}

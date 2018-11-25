namespace Agrostore.CategoriesManagement.Interface.Entities
{
    public class Category
    {
        #region core
        public int Id { get; set; }
        public string Name { get; set; }
        public long Total { get; set; }
        #endregion

        #region init
        public Category()
        {
        }
        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }
        #endregion
    }
}

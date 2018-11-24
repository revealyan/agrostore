namespace Agrostore.ProductsManagement.Interface.Entities
{
    public class Product
    {
        #region core
        public int Id { get; set; }
        public string Article { get; set; }
        public string Name { get; set; }
        public decimal Count { get; set; }
        public decimal Price { get; set; }
        #endregion

        #region init
        public Product()
        {
        }
        public Product(int id, string article, string name, decimal count, decimal price)
        {
            Id = id;
            Article = article;
            Name = name;
            Count = count;
            Price = price;
        }
        #endregion
    }
}
 
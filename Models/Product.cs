namespace DianaMVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }
        public string? ImgUrl { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }
        public List<ProductColor> ProductColors { get; set; }
        public List<ProductSize> ProductSizes { get; set; }
        public List<ProductMaterial> ProductMaterials { get; set; }
        public List<ProductImage> ProductImages { get; set; }

    }
}

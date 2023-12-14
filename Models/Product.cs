namespace DianaMVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }
        public string ImgUrl { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }
        public List<Color> Colors { get; set; }
        public List<Size> Sizes { get; set; }
        public List<Material> Materials { get; set; }
        public List<ProductImage> ProductImages { get; set; }

    }
}

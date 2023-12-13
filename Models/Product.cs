namespace DianaMVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }
        public char? Size { get; set; }
        public string? Material { get; set; }
        public string ImgUrl { get; set; }
        

    }
}

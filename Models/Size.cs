namespace DianaMVC.Models
{
    public class Size
    {
        public int Id { get; set; }
        public char Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
